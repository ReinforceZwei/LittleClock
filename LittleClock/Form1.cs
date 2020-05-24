using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace LittleClock
{

    public partial class Form1 : Form
    {
        const Int32 WS_EX_LAYERED = 0x80000;
        const Int32 HTCAPTION = 0x02;
        const Int32 WM_NCHITTEST = 0x84;
        const Int32 HTTRANSPARENT = -1;
        const Int32 WS_EX_TRANSPARENT = 0x20;
        const Int32 WS_EX_TOOLWINDOW = 0x80;

        private bool dragging = false;
        private Point dragCursorPoint;
        private Point dragFormPoint;

        internal bool Dragable = Properties.Settings.Default.Dragable;
        private Point initPos;
        private Point LastPos;

        const CheckState Checked = CheckState.Checked;
        const CheckState Unchecked = CheckState.Unchecked;

        private Setting settingForm;

        internal Properties.Settings settings = Properties.Settings.Default;

        string[] TimeFormat =
        {
            "hh:mm:ss tt",  // 0
            "hh:mm tt",     // 1
            "hh:mm:ss",     // 2
            "hh:mm",        // 3
            "HH:mm:ss",     // 4
            "HH:mm"         // 5
        };

        internal string DisplayTimeFormat = String.IsNullOrEmpty(Properties.Settings.Default.TimeFormat) ? "hh:mm:ss tt" : Properties.Settings.Default.TimeFormat;

        internal bool hideOnHover;

        internal bool clickThrough;

        internal double opacity;

        private int initialStyle;

        [DllImport("user32.dll", SetLastError = true)]
        static extern int GetWindowLong(IntPtr hWnd, int nIndex);

        [DllImport("user32.dll")]
        static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);

        public Form1()
        {
            InitializeComponent();

            this.FormBorderStyle = FormBorderStyle.None;
            this.ControlBox = false;
            this.ShowInTaskbar = false;
            this.TopMost = Properties.Settings.Default.TopMost;
            this.Icon = Resource1.Devidol_;
            this.label1.Text = DateTime.Now.ToString(DisplayTimeFormat);
            Width = label1.Width;
            Height = 25;
            Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));

            //this.BackColor = Color.White;
            //this.TransparencyKey = Color.Fuchsia;

            Rectangle workingArea = Screen.GetWorkingArea(this);
            LastPos = Properties.Settings.Default.Pos;
            //LastPos = new Point(0, 0);
            if(LastPos == new Point(0, 0))
            {
                // user usually don't drag to (0,0)
                // no last position, start with app default location
                
                this.Location = new Point(workingArea.Right - Size.Width,
                                          workingArea.Bottom - Size.Height);
            }
            else
            {
                this.Location = Properties.Settings.Default.Pos;
            }
            initPos = this.Location;
            //Location = new Point(500, 500);

            //this.dragableToolStripMenuItem.Checked = Properties.Settings.Default.Dragable;

            this.onTopToolStripMenuItem.Checked = this.TopMost;

            this.hideOnHover = settings.HideOnHover;
            this.clickThrough = settings.clickThrough;
            this.opacity = settings.Opacity;

            this.timer2.Enabled = true;

            notifyIcon1.Icon = Resource1.Devidol_;

            Point pos = Properties.Settings.Default.Pos;

            if (Properties.Settings.Default.Dragable)
            {
                this.dragableToolStripMenuItem.CheckState = Checked;
            }
            else
            {
                this.dragableToolStripMenuItem.CheckState = Unchecked;
            }

            initialStyle = GetWindowLong(this.Handle, -20);
            SetWindowLong(this.Handle, -20, initialStyle | WS_EX_TOOLWINDOW);
            initialStyle = GetWindowLong(this.Handle, -20);
            if (clickThrough)
            {
                SetWindowLong(this.Handle, -20, initialStyle | 0x80000 | 0x20);
            }
        }

        // make the form click-throughtable
        /*
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                // Set the form click-through
                cp.ExStyle |= 0x80000  | 0x20 ;
                return cp;
            }
        }
        
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == WM_NCHITTEST)
                m.Result = (IntPtr)WS_EX_TRANSPARENT;
            else
                base.WndProc(ref m);
        }
        */
        // enable window drag without titlebar =====
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (Dragable)
                {
                    dragging = true;
                    dragCursorPoint = Cursor.Position;
                    dragFormPoint = this.Location;
                }
            }
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging)
            {
                Point dif = Point.Subtract(Cursor.Position, new Size(dragCursorPoint));
                Point pos = Point.Add(dragFormPoint, new Size(dif));
                this.Location = pos;
            }
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                dragging = false;
                try
                {
                    settingForm.updatePos(this.Location);
                }
                catch
                {
                    // do nothing
                }
            }
        }
        // ========================================

        /*
        protected override void WndProc(ref Message message)
        {
            if (message.Msg == WM_NCHITTEST)
            {
                // Tell Windows that the user is on the title bar (caption)
                message.Result = (IntPtr)HTCAPTION;
            }
            else
            {
                base.WndProc(ref message);
            }
        }
        */

        private async void FadeIn(Form o, int interval = 80)
        {
            //Object is not fully invisible. Fade it in
            while (o.Opacity < 1.0)
            {
                await Task.Delay(interval);
                o.Opacity += 0.05;
            }
            o.Opacity = 1; //make fully visible       
        }

        private async void FadeOut(Form o, int interval = 80)
        {
            // double opacity = Properties.Settings.Default.Opacity;
            //Object is fully visible. Fade it out
            while (o.Opacity > opacity)
            {
                await Task.Delay(interval);
                o.Opacity -= 0.05;
            }
            o.Opacity = opacity; //make fully invisible       
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.label1.Text = DateTime.Now.ToString(DisplayTimeFormat);
        }

        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
        (
            int nLeftRect,     // x-coordinate of upper-left corner
            int nTopRect,      // y-coordinate of upper-left corner
            int nRightRect,    // x-coordinate of lower-right corner
            int nBottomRect,   // y-coordinate of lower-right corner
            int nWidthEllipse, // height of ellipse
            int nHeightEllipse // width of ellipse
        );

        private void Form1_MouseEnter(object sender, EventArgs e)
        {
            if (hideOnHover)
            {
                hideOnHoverTimer.Start();
                this.Opacity = 0;
            }
            else
            {
                FadeIn(this, 10);
                timer2.Enabled = false;
            }
        }

        private void Form1_MouseLeave(object sender, EventArgs e)
        {
            if (!hideOnHover)
            {
                timer2.Enabled = true;
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            FadeOut(this,50);
            timer2.Enabled = false;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(this.Location != initPos)
            {
                // user draged the form to other place
                Properties.Settings.Default.Pos = this.Location;
                Properties.Settings.Default.Save();
            }
            Application.Exit();
        }

        private void settingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Setting setting = new Setting(this);
            setting.Show();
            Rectangle workingArea = Screen.GetWorkingArea(this);
            setting.Location = new Point(workingArea.Right - setting.Size.Width - this.Size.Width,
                                      workingArea.Bottom - setting.Size.Height);
            settingForm = setting;
        }
        /*
        public void UpdateSetting()
        {
            //this.TopMost = Properties.Settings.Default.TopMost;
            //this.Opacity = Properties.Settings.Default.Opacity;
            this.Dragable = Properties.Settings.Default.Dragable;
            DisplayTimeFormat = Properties.Settings.Default.TimeFormat;
            this.label1.Text = DateTime.Now.ToString(DisplayTimeFormat);
            Width = label1.Width;
            Height = 25;
            Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
            if (Properties.Settings.Default.Dragable)
            {
                this.dragableToolStripMenuItem.CheckState = Checked;
            }
            else
            {
                this.dragableToolStripMenuItem.CheckState = Unchecked;
            }
            Location = Properties.Settings.Default.Pos;
            //MessageBox.Show("callback invoked");
        }
        */
        private void dragableToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            if(dragableToolStripMenuItem.CheckState == Checked)
            {
                Properties.Settings.Default.Dragable = true;
                SetWindowLong(this.Handle, -20, initialStyle);
            }
            else
            {
                Properties.Settings.Default.Dragable = false;
                SetWindowLong(this.Handle, -20, initialStyle | 0x80000 | 0x20);
            }
            this.Dragable = dragableToolStripMenuItem.Checked;
        }
        public void updateDragableLong(bool t)
        {
            if (t)
            {
                SetWindowLong(this.Handle, -20, initialStyle);
            }
            else
            {
                SetWindowLong(this.Handle, -20, initialStyle | 0x80000 | 0x20);
            }
        }

        private void onTopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.TopMost = onTopToolStripMenuItem.Checked;
        }

        private void hideOnHoverTimer_Tick(object sender, EventArgs e)
        {
            if (!this.Bounds.Contains(Cursor.Position.X, Cursor.Position.Y))
            {
                this.hideOnHoverTimer.Stop();
                this.Opacity = opacity;
            }
        }
    }
}
