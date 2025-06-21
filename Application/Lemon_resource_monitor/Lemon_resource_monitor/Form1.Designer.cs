namespace Lemon_resource_monitor
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.panelUpper = new System.Windows.Forms.Panel();
            this.lblFormHeading = new System.Windows.Forms.Label();
            this.formClose = new System.Windows.Forms.Panel();
            this.pbClose = new System.Windows.Forms.PictureBox();
            this.form_mini = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbDividers = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.rbScrolling = new System.Windows.Forms.RadioButton();
            this.tbRight = new System.Windows.Forms.TextBox();
            this.rbSwitch = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.tbLeft = new System.Windows.Forms.TextBox();
            this.cbBackground = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbAutoPort = new System.Windows.Forms.CheckBox();
            this.cbAutostart = new System.Windows.Forms.CheckBox();
            this.cbPorts = new System.Windows.Forms.ComboBox();
            this.btnAboutIn = new System.Windows.Forms.Panel();
            this.lblBtnAbout = new System.Windows.Forms.Label();
            this.btnAboutOut = new System.Windows.Forms.Panel();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pbFlag = new System.Windows.Forms.PictureBox();
            this.panelUpper.SuspendLayout();
            this.formClose.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbClose)).BeginInit();
            this.form_mini.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.pnlMain.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.btnAboutIn.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbFlag)).BeginInit();
            this.SuspendLayout();
            // 
            // panelUpper
            // 
            this.panelUpper.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelUpper.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(34)))), ((int)(((byte)(37)))));
            this.panelUpper.Controls.Add(this.lblFormHeading);
            this.panelUpper.Controls.Add(this.formClose);
            this.panelUpper.Controls.Add(this.form_mini);
            this.panelUpper.Location = new System.Drawing.Point(-1, 0);
            this.panelUpper.Name = "panelUpper";
            this.panelUpper.Size = new System.Drawing.Size(466, 22);
            this.panelUpper.TabIndex = 41;
            this.panelUpper.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panelUpper_MouseMove);
            // 
            // lblFormHeading
            // 
            this.lblFormHeading.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.lblFormHeading.AutoSize = true;
            this.lblFormHeading.Font = new System.Drawing.Font("Lucida Sans", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFormHeading.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(210)))), ((int)(((byte)(195)))));
            this.lblFormHeading.Location = new System.Drawing.Point(185, 5);
            this.lblFormHeading.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblFormHeading.Name = "lblFormHeading";
            this.lblFormHeading.Size = new System.Drawing.Size(87, 14);
            this.lblFormHeading.TabIndex = 9;
            this.lblFormHeading.Text = "Lemon monitor";
            this.lblFormHeading.MouseMove += new System.Windows.Forms.MouseEventHandler(this.lblFormHeading_MouseMove);
            // 
            // formClose
            // 
            this.formClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.formClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(34)))), ((int)(((byte)(37)))));
            this.formClose.Controls.Add(this.pbClose);
            this.formClose.Location = new System.Drawing.Point(438, 0);
            this.formClose.Name = "formClose";
            this.formClose.Size = new System.Drawing.Size(28, 22);
            this.formClose.TabIndex = 5;
            this.formClose.Click += new System.EventHandler(this.formClose_Click);
            this.formClose.MouseEnter += new System.EventHandler(this.formClose_MouseEnter);
            this.formClose.MouseLeave += new System.EventHandler(this.formClose_MouseLeave);
            // 
            // pbClose
            // 
            this.pbClose.Image = global::Lemon_resource_monitor.Properties.Resources.close;
            this.pbClose.Location = new System.Drawing.Point(9, 6);
            this.pbClose.Name = "pbClose";
            this.pbClose.Size = new System.Drawing.Size(10, 10);
            this.pbClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbClose.TabIndex = 6;
            this.pbClose.TabStop = false;
            this.pbClose.Click += new System.EventHandler(this.formClose_Click);
            this.pbClose.MouseEnter += new System.EventHandler(this.formClose_MouseEnter);
            this.pbClose.MouseLeave += new System.EventHandler(this.formClose_MouseLeave);
            // 
            // form_mini
            // 
            this.form_mini.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.form_mini.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(34)))), ((int)(((byte)(37)))));
            this.form_mini.Controls.Add(this.pictureBox2);
            this.form_mini.Location = new System.Drawing.Point(411, 0);
            this.form_mini.Name = "form_mini";
            this.form_mini.Size = new System.Drawing.Size(28, 22);
            this.form_mini.TabIndex = 2;
            this.form_mini.Click += new System.EventHandler(this.form_mini_Click);
            this.form_mini.MouseDown += new System.Windows.Forms.MouseEventHandler(this.form_mini_MouseDown);
            this.form_mini.MouseEnter += new System.EventHandler(this.form_mini_MouseEnter);
            this.form_mini.MouseLeave += new System.EventHandler(this.form_mini_MouseLeave);
            this.form_mini.MouseUp += new System.Windows.Forms.MouseEventHandler(this.form_mini_MouseUp);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(9, 10);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(10, 1);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 0;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.form_mini_Click);
            this.pictureBox2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.form_mini_MouseDown);
            this.pictureBox2.MouseEnter += new System.EventHandler(this.form_mini_MouseEnter);
            this.pictureBox2.MouseLeave += new System.EventHandler(this.form_mini_MouseLeave);
            this.pictureBox2.MouseUp += new System.Windows.Forms.MouseEventHandler(this.form_mini_MouseUp);
            // 
            // pnlMain
            // 
            this.pnlMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.pnlMain.Controls.Add(this.groupBox1);
            this.pnlMain.Controls.Add(this.cbBackground);
            this.pnlMain.Controls.Add(this.label1);
            this.pnlMain.Controls.Add(this.cbAutoPort);
            this.pnlMain.Controls.Add(this.cbAutostart);
            this.pnlMain.Controls.Add(this.cbPorts);
            this.pnlMain.Controls.Add(this.btnAboutIn);
            this.pnlMain.Controls.Add(this.btnAboutOut);
            this.pnlMain.Font = new System.Drawing.Font("Lucida Sans", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlMain.Location = new System.Drawing.Point(2, 22);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(461, 271);
            this.pnlMain.TabIndex = 42;
            this.pnlMain.Click += new System.EventHandler(this.pnlMain_Click);
            this.pnlMain.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pnlMain_MouseMove);
            this.pnlMain.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.pnlMain_PreviewKeyDown);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.groupBox1.Controls.Add(this.cbDividers);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.rbScrolling);
            this.groupBox1.Controls.Add(this.tbRight);
            this.groupBox1.Controls.Add(this.rbSwitch);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.tbLeft);
            this.groupBox1.Location = new System.Drawing.Point(12, 146);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(428, 110);
            this.groupBox1.TabIndex = 100;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Device settings";
            this.groupBox1.UseCompatibleTextRendering = true;
            // 
            // cbDividers
            // 
            this.cbDividers.AutoSize = true;
            this.cbDividers.Location = new System.Drawing.Point(21, 24);
            this.cbDividers.Name = "cbDividers";
            this.cbDividers.Size = new System.Drawing.Size(77, 19);
            this.cbDividers.TabIndex = 93;
            this.cbDividers.Text = "Dividers";
            this.cbDividers.UseVisualStyleBackColor = true;
            this.cbDividers.CheckedChanged += new System.EventHandler(this.cbDividers_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(217, 77);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 15);
            this.label3.TabIndex = 99;
            this.label3.Text = "Hotkey right";
            // 
            // rbScrolling
            // 
            this.rbScrolling.AutoSize = true;
            this.rbScrolling.Checked = true;
            this.rbScrolling.Location = new System.Drawing.Point(21, 47);
            this.rbScrolling.Name = "rbScrolling";
            this.rbScrolling.Size = new System.Drawing.Size(79, 19);
            this.rbScrolling.TabIndex = 94;
            this.rbScrolling.TabStop = true;
            this.rbScrolling.Text = "Scrolling";
            this.rbScrolling.UseVisualStyleBackColor = true;
            this.rbScrolling.CheckedChanged += new System.EventHandler(this.rbScrolling_CheckedChanged);
            // 
            // tbRight
            // 
            this.tbRight.Location = new System.Drawing.Point(309, 74);
            this.tbRight.Name = "tbRight";
            this.tbRight.Size = new System.Drawing.Size(106, 23);
            this.tbRight.TabIndex = 98;
            this.tbRight.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbRight_KeyDown);
            // 
            // rbSwitch
            // 
            this.rbSwitch.AutoSize = true;
            this.rbSwitch.Location = new System.Drawing.Point(21, 72);
            this.rbSwitch.Name = "rbSwitch";
            this.rbSwitch.Size = new System.Drawing.Size(109, 19);
            this.rbSwitch.TabIndex = 95;
            this.rbSwitch.Text = "Switch pages";
            this.rbSwitch.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(217, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 15);
            this.label2.TabIndex = 97;
            this.label2.Text = "Hotkey left";
            // 
            // tbLeft
            // 
            this.tbLeft.Location = new System.Drawing.Point(309, 41);
            this.tbLeft.Name = "tbLeft";
            this.tbLeft.Size = new System.Drawing.Size(106, 23);
            this.tbLeft.TabIndex = 96;
            this.tbLeft.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbLeft_KeyDown);
            // 
            // cbBackground
            // 
            this.cbBackground.AutoSize = true;
            this.cbBackground.Location = new System.Drawing.Point(18, 74);
            this.cbBackground.Name = "cbBackground";
            this.cbBackground.Size = new System.Drawing.Size(205, 19);
            this.cbBackground.TabIndex = 92;
            this.cbBackground.Text = "Keep running in background";
            this.cbBackground.UseVisualStyleBackColor = true;
            this.cbBackground.CheckedChanged += new System.EventHandler(this.cbBackground_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 123);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 15);
            this.label1.TabIndex = 91;
            this.label1.Text = "Serial port:";
            // 
            // cbAutoPort
            // 
            this.cbAutoPort.AutoSize = true;
            this.cbAutoPort.Location = new System.Drawing.Point(18, 97);
            this.cbAutoPort.Name = "cbAutoPort";
            this.cbAutoPort.Size = new System.Drawing.Size(221, 19);
            this.cbAutoPort.TabIndex = 90;
            this.cbAutoPort.Text = "Automatically select Serial port";
            this.cbAutoPort.UseVisualStyleBackColor = true;
            this.cbAutoPort.CheckedChanged += new System.EventHandler(this.cbAutoPort_CheckedChanged);
            // 
            // cbAutostart
            // 
            this.cbAutostart.AutoSize = true;
            this.cbAutostart.Location = new System.Drawing.Point(18, 51);
            this.cbAutostart.Name = "cbAutostart";
            this.cbAutostart.Size = new System.Drawing.Size(86, 19);
            this.cbAutostart.TabIndex = 89;
            this.cbAutostart.Text = "Autostart";
            this.cbAutostart.UseVisualStyleBackColor = true;
            this.cbAutostart.CheckedChanged += new System.EventHandler(this.cbAutostart_CheckedChanged);
            // 
            // cbPorts
            // 
            this.cbPorts.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(224)))), ((int)(((byte)(228)))));
            this.cbPorts.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPorts.Font = new System.Drawing.Font("Lucida Sans", 7.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbPorts.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cbPorts.FormattingEnabled = true;
            this.cbPorts.Location = new System.Drawing.Point(110, 121);
            this.cbPorts.Margin = new System.Windows.Forms.Padding(2);
            this.cbPorts.Name = "cbPorts";
            this.cbPorts.Size = new System.Drawing.Size(162, 22);
            this.cbPorts.Sorted = true;
            this.cbPorts.TabIndex = 88;
            this.cbPorts.SelectedIndexChanged += new System.EventHandler(this.cbPorts_SelectedIndexChanged);
            // 
            // btnAboutIn
            // 
            this.btnAboutIn.BackColor = System.Drawing.Color.Gainsboro;
            this.btnAboutIn.Controls.Add(this.lblBtnAbout);
            this.btnAboutIn.Location = new System.Drawing.Point(0, 0);
            this.btnAboutIn.Name = "btnAboutIn";
            this.btnAboutIn.Size = new System.Drawing.Size(65, 21);
            this.btnAboutIn.TabIndex = 9;
            this.btnAboutIn.Click += new System.EventHandler(this.btnAboutIn_Click);
            this.btnAboutIn.MouseEnter += new System.EventHandler(this.btnAboutIn_MouseEnter);
            this.btnAboutIn.MouseLeave += new System.EventHandler(this.btnAboutIn_MouseLeave);
            // 
            // lblBtnAbout
            // 
            this.lblBtnAbout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblBtnAbout.Font = new System.Drawing.Font("Lucida Sans", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBtnAbout.Location = new System.Drawing.Point(0, 0);
            this.lblBtnAbout.Name = "lblBtnAbout";
            this.lblBtnAbout.Size = new System.Drawing.Size(65, 21);
            this.lblBtnAbout.TabIndex = 0;
            this.lblBtnAbout.Text = "About";
            this.lblBtnAbout.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblBtnAbout.Click += new System.EventHandler(this.lblBtnAbout_Click);
            this.lblBtnAbout.MouseEnter += new System.EventHandler(this.lblBtnAbout_MouseEnter);
            this.lblBtnAbout.MouseLeave += new System.EventHandler(this.lblBtnAbout_MouseLeave);
            // 
            // btnAboutOut
            // 
            this.btnAboutOut.BackColor = System.Drawing.Color.DimGray;
            this.btnAboutOut.Location = new System.Drawing.Point(0, 0);
            this.btnAboutOut.Name = "btnAboutOut";
            this.btnAboutOut.Size = new System.Drawing.Size(66, 22);
            this.btnAboutOut.TabIndex = 8;
            this.btnAboutOut.Click += new System.EventHandler(this.btnAboutOut_Click);
            this.btnAboutOut.MouseEnter += new System.EventHandler(this.btnAboutOut_MouseEnter);
            this.btnAboutOut.MouseLeave += new System.EventHandler(this.btnAboutOut_MouseLeave);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.ContextMenuStrip = this.contextMenuStrip1;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "Lemon monitor";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.DoubleClick += new System.EventHandler(this.notifyIcon1_DoubleClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(104, 48);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // pbFlag
            // 
            this.pbFlag.Location = new System.Drawing.Point(0, 0);
            this.pbFlag.Name = "pbFlag";
            this.pbFlag.Size = new System.Drawing.Size(100, 50);
            this.pbFlag.TabIndex = 0;
            this.pbFlag.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.ClientSize = new System.Drawing.Size(465, 295);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.panelUpper);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "Lemon monitor";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseMove);
            this.panelUpper.ResumeLayout(false);
            this.panelUpper.PerformLayout();
            this.formClose.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbClose)).EndInit();
            this.form_mini.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.btnAboutIn.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbFlag)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panelUpper;
        private System.Windows.Forms.Panel formClose;
        private System.Windows.Forms.PictureBox pbClose;
        private System.Windows.Forms.Panel form_mini;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label lblFormHeading;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Panel btnAboutIn;
        private System.Windows.Forms.Label lblBtnAbout;
        private System.Windows.Forms.Panel btnAboutOut;
        private System.Windows.Forms.PictureBox pbFlag;
        private System.Windows.Forms.ComboBox cbPorts;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox cbAutoPort;
        private System.Windows.Forms.CheckBox cbAutostart;
        private System.Windows.Forms.CheckBox cbBackground;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.CheckBox cbDividers;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbLeft;
        private System.Windows.Forms.RadioButton rbSwitch;
        private System.Windows.Forms.RadioButton rbScrolling;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbRight;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}

