namespace LittleClock
{
    partial class Setting
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.numericUpDownX = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownY = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.HideOnHoverCheckBox = new System.Windows.Forms.CheckBox();
            this.clickThroughCheckBox = new System.Windows.Forms.CheckBox();
            this.dragableCheckBox = new System.Windows.Forms.CheckBox();
            this.onTopCheckBox = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownY)).BeginInit();
            this.SuspendLayout();
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.DecimalPlaces = 1;
            this.numericUpDown1.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numericUpDown1.Location = new System.Drawing.Point(79, 11);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(36, 22);
            this.numericUpDown1.TabIndex = 1;
            this.numericUpDown1.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(156, 246);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(79, 26);
            this.button1.TabIndex = 2;
            this.button1.Text = "Save";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "Idle opacity";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(75, 246);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 26);
            this.button2.TabIndex = 4;
            this.button2.Text = "Cancel";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(15, 150);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 20);
            this.comboBox1.TabIndex = 7;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 177);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(13, 12);
            this.label2.TabIndex = 8;
            this.label2.Text = "X";
            // 
            // numericUpDownX
            // 
            this.numericUpDownX.Location = new System.Drawing.Point(19, 193);
            this.numericUpDownX.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDownX.Name = "numericUpDownX";
            this.numericUpDownX.Size = new System.Drawing.Size(56, 22);
            this.numericUpDownX.TabIndex = 9;
            this.numericUpDownX.ValueChanged += new System.EventHandler(this.numericUpDownX_ValueChanged);
            // 
            // numericUpDownY
            // 
            this.numericUpDownY.Location = new System.Drawing.Point(81, 193);
            this.numericUpDownY.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDownY.Name = "numericUpDownY";
            this.numericUpDownY.Size = new System.Drawing.Size(55, 22);
            this.numericUpDownY.TabIndex = 10;
            this.numericUpDownY.ValueChanged += new System.EventHandler(this.numericUpDownY_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(79, 177);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(13, 12);
            this.label3.TabIndex = 11;
            this.label3.Text = "Y";
            // 
            // HideOnHoverCheckBox
            // 
            this.HideOnHoverCheckBox.AutoSize = true;
            this.HideOnHoverCheckBox.Location = new System.Drawing.Point(13, 89);
            this.HideOnHoverCheckBox.Name = "HideOnHoverCheckBox";
            this.HideOnHoverCheckBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.HideOnHoverCheckBox.Size = new System.Drawing.Size(91, 16);
            this.HideOnHoverCheckBox.TabIndex = 12;
            this.HideOnHoverCheckBox.Text = "Hide on hover";
            this.HideOnHoverCheckBox.UseVisualStyleBackColor = true;
            this.HideOnHoverCheckBox.CheckedChanged += new System.EventHandler(this.HideOnHoverCheckBox_CheckedChanged);
            // 
            // clickThroughCheckBox
            // 
            this.clickThroughCheckBox.AutoSize = true;
            this.clickThroughCheckBox.Location = new System.Drawing.Point(13, 112);
            this.clickThroughCheckBox.Name = "clickThroughCheckBox";
            this.clickThroughCheckBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.clickThroughCheckBox.Size = new System.Drawing.Size(90, 16);
            this.clickThroughCheckBox.TabIndex = 13;
            this.clickThroughCheckBox.Text = "Click-through";
            this.clickThroughCheckBox.UseVisualStyleBackColor = true;
            this.clickThroughCheckBox.CheckedChanged += new System.EventHandler(this.clickThroughCheckBox_CheckedChanged);
            // 
            // dragableCheckBox
            // 
            this.dragableCheckBox.AutoSize = true;
            this.dragableCheckBox.Checked = global::LittleClock.Properties.Settings.Default.Dragable;
            this.dragableCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::LittleClock.Properties.Settings.Default, "Dragable", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.dragableCheckBox.Location = new System.Drawing.Point(13, 66);
            this.dragableCheckBox.Name = "dragableCheckBox";
            this.dragableCheckBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dragableCheckBox.Size = new System.Drawing.Size(66, 16);
            this.dragableCheckBox.TabIndex = 6;
            this.dragableCheckBox.Text = "Dragable";
            this.dragableCheckBox.UseVisualStyleBackColor = true;
            this.dragableCheckBox.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
            // 
            // onTopCheckBox
            // 
            this.onTopCheckBox.AutoSize = true;
            this.onTopCheckBox.Checked = global::LittleClock.Properties.Settings.Default.TopMost;
            this.onTopCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.onTopCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::LittleClock.Properties.Settings.Default, "TopMost", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.onTopCheckBox.Location = new System.Drawing.Point(13, 43);
            this.onTopCheckBox.Name = "onTopCheckBox";
            this.onTopCheckBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.onTopCheckBox.Size = new System.Drawing.Size(91, 16);
            this.onTopCheckBox.TabIndex = 5;
            this.onTopCheckBox.Text = "Alawys on top";
            this.onTopCheckBox.UseVisualStyleBackColor = true;
            this.onTopCheckBox.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // Setting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(247, 284);
            this.Controls.Add(this.clickThroughCheckBox);
            this.Controls.Add(this.HideOnHoverCheckBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.numericUpDownY);
            this.Controls.Add(this.numericUpDownX);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.dragableCheckBox);
            this.Controls.Add(this.onTopCheckBox);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.numericUpDown1);
            this.Name = "Setting";
            this.Text = "Setting";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownY)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.CheckBox onTopCheckBox;
        private System.Windows.Forms.CheckBox dragableCheckBox;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numericUpDownX;
        private System.Windows.Forms.NumericUpDown numericUpDownY;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox HideOnHoverCheckBox;
        private System.Windows.Forms.CheckBox clickThroughCheckBox;
    }
}