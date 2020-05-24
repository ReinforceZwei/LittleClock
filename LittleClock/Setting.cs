using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LittleClock
{
    public partial class Setting : Form
    {
        Form1 form;

        string[] TimeFormat =
        {
            "hh:mm:ss tt",  // 0
            "hh:mm tt",     // 1
            "hh:mm:ss",     // 2
            "hh:mm",        // 3
            "HH:mm:ss",     // 4
            "HH:mm"         // 5
        };
        Properties.Settings settings = Properties.Settings.Default;
        public Setting(Form1 _form1)
        {
            InitializeComponent();
            form = _form1;
            numericUpDown1.Value = Convert.ToDecimal(form.Opacity);
            foreach(string v in TimeFormat)
            {
                comboBox1.Items.Add(v);
            }
            comboBox1.Text = form.DisplayTimeFormat;
            Point Pos = new Point(_form1.Location.X, _form1.Location.Y);
            numericUpDownX.Value = Pos.X;
            numericUpDownY.Value = Pos.Y;
            clickThroughCheckBox.Checked = form.clickThrough;
            HideOnHoverCheckBox.Checked = form.hideOnHover;
            //checkBox1.Checked = Properties.Settings.Default.TopMost;
            //checkBox2.Checked = Properties.Settings.Default.Dragable;
        }

        private void button1_Click(object sender, EventArgs e)
        {           
            settings.Save();
            //callback.Invoke();
            this.Close();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            Single o = Convert.ToSingle(numericUpDown1.Value);
            settings.Opacity = o;
            form.Opacity = o;
            form.opacity = o;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            settings.TopMost = onTopCheckBox.Checked;
            form.TopMost = onTopCheckBox.Checked;
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            settings.Dragable = dragableCheckBox.Checked;
            form.Dragable = dragableCheckBox.Checked;
            form.updateDragableLong(dragableCheckBox.Checked);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            settings.TimeFormat = TimeFormat[comboBox1.SelectedIndex];
            form.DisplayTimeFormat = TimeFormat[comboBox1.SelectedIndex];
        }

        private void numericUpDownX_ValueChanged(object sender, EventArgs e)
        {
            int posX = Convert.ToInt16(numericUpDownX.Value);
            int posY = Convert.ToInt16(numericUpDownY.Value);
            settings.Pos = new Point(posX, posY);
            form.Location = new Point(posX, posY);
        }

        private void numericUpDownY_ValueChanged(object sender, EventArgs e)
        {
            int posX = Convert.ToInt16(numericUpDownX.Value);
            int posY = Convert.ToInt16(numericUpDownY.Value);
            settings.Pos = new Point(posX, posY);
            form.Location = new Point(posX, posY);
        }
        public void updatePos(Point pos)
        {
            numericUpDownX.Value = pos.X;
            numericUpDownY.Value = pos.Y;
        }

        private void HideOnHoverCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            this.settings.HideOnHover = this.HideOnHoverCheckBox.Checked;
            form.hideOnHover = this.HideOnHoverCheckBox.Checked;
        }

        private void clickThroughCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            this.settings.clickThrough = this.clickThroughCheckBox.Checked;
            form.clickThrough = this.clickThroughCheckBox.Checked;
            form.updateDragableLong(!this.clickThroughCheckBox.Checked);
        }
    }
}
