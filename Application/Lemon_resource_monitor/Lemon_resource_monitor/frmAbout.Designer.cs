namespace Lemon_resource_monitor
{
    partial class frmAbout
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAbout));
            this.panelUpper = new System.Windows.Forms.Panel();
            this.formClose = new System.Windows.Forms.Panel();
            this.pbClose = new System.Windows.Forms.PictureBox();
            this.lblFormHeading = new System.Windows.Forms.Label();
            this.btnOKIn = new System.Windows.Forms.Panel();
            this.lblBtnOK = new System.Windows.Forms.Label();
            this.btnOKOut = new System.Windows.Forms.Panel();
            this.lblVersion = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.lblCopyright = new System.Windows.Forms.Label();
            this.pbFacebook = new System.Windows.Forms.PictureBox();
            this.panelUpper.SuspendLayout();
            this.formClose.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbClose)).BeginInit();
            this.btnOKIn.SuspendLayout();
            this.pnlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbFacebook)).BeginInit();
            this.SuspendLayout();
            // 
            // panelUpper
            // 
            this.panelUpper.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelUpper.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(34)))), ((int)(((byte)(37)))));
            this.panelUpper.Controls.Add(this.formClose);
            this.panelUpper.Controls.Add(this.lblFormHeading);
            this.panelUpper.Location = new System.Drawing.Point(0, 0);
            this.panelUpper.Name = "panelUpper";
            this.panelUpper.Size = new System.Drawing.Size(273, 22);
            this.panelUpper.TabIndex = 42;
            this.panelUpper.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panelUpper_MouseMove);
            // 
            // formClose
            // 
            this.formClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.formClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(34)))), ((int)(((byte)(37)))));
            this.formClose.Controls.Add(this.pbClose);
            this.formClose.Location = new System.Drawing.Point(245, 0);
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
            // lblFormHeading
            // 
            this.lblFormHeading.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblFormHeading.Font = new System.Drawing.Font("Lucida Sans", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFormHeading.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(210)))), ((int)(((byte)(195)))));
            this.lblFormHeading.Location = new System.Drawing.Point(0, 0);
            this.lblFormHeading.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblFormHeading.Name = "lblFormHeading";
            this.lblFormHeading.Size = new System.Drawing.Size(273, 22);
            this.lblFormHeading.TabIndex = 9;
            this.lblFormHeading.Text = "About";
            this.lblFormHeading.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblFormHeading.MouseMove += new System.Windows.Forms.MouseEventHandler(this.lblFormHeading_MouseMove);
            // 
            // btnOKIn
            // 
            this.btnOKIn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOKIn.BackColor = System.Drawing.Color.Gainsboro;
            this.btnOKIn.Controls.Add(this.lblBtnOK);
            this.btnOKIn.Location = new System.Drawing.Point(175, 97);
            this.btnOKIn.Name = "btnOKIn";
            this.btnOKIn.Size = new System.Drawing.Size(84, 30);
            this.btnOKIn.TabIndex = 9;
            this.btnOKIn.Click += new System.EventHandler(this.btnOKIn_Click);
            this.btnOKIn.MouseEnter += new System.EventHandler(this.btnOKIn_MouseEnter);
            this.btnOKIn.MouseLeave += new System.EventHandler(this.btnOKIn_MouseLeave);
            // 
            // lblBtnOK
            // 
            this.lblBtnOK.AutoSize = true;
            this.lblBtnOK.Font = new System.Drawing.Font("Lucida Sans", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBtnOK.Location = new System.Drawing.Point(30, 8);
            this.lblBtnOK.Name = "lblBtnOK";
            this.lblBtnOK.Size = new System.Drawing.Size(24, 15);
            this.lblBtnOK.TabIndex = 0;
            this.lblBtnOK.Text = "OK";
            this.lblBtnOK.Click += new System.EventHandler(this.lblBtnOK_Click);
            this.lblBtnOK.MouseEnter += new System.EventHandler(this.lblBtnOK_MouseEnter);
            this.lblBtnOK.MouseLeave += new System.EventHandler(this.lblBtnOK_MouseLeave);
            // 
            // btnOKOut
            // 
            this.btnOKOut.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOKOut.BackColor = System.Drawing.Color.DimGray;
            this.btnOKOut.Location = new System.Drawing.Point(174, 96);
            this.btnOKOut.Name = "btnOKOut";
            this.btnOKOut.Size = new System.Drawing.Size(86, 32);
            this.btnOKOut.TabIndex = 8;
            this.btnOKOut.Click += new System.EventHandler(this.btnOKOut_Click);
            this.btnOKOut.MouseEnter += new System.EventHandler(this.btnOKOut_MouseEnter);
            this.btnOKOut.MouseLeave += new System.EventHandler(this.btnOKOut_MouseLeave);
            // 
            // lblVersion
            // 
            this.lblVersion.AutoSize = true;
            this.lblVersion.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVersion.Location = new System.Drawing.Point(13, 17);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(137, 16);
            this.lblVersion.TabIndex = 43;
            this.lblVersion.Text = "Lemon monitor v1.2";
            this.lblVersion.MouseMove += new System.Windows.Forms.MouseEventHandler(this.lblVersion_MouseMove);
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.Location = new System.Drawing.Point(55, 50);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(112, 14);
            this.lblName.TabIndex = 50;
            this.lblName.Text = "Yordan Yordanov";
            this.lblName.MouseMove += new System.Windows.Forms.MouseEventHandler(this.lblName_MouseMove);
            // 
            // pnlMain
            // 
            this.pnlMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(224)))), ((int)(((byte)(228)))));
            this.pnlMain.Controls.Add(this.lblCopyright);
            this.pnlMain.Controls.Add(this.pbFacebook);
            this.pnlMain.Controls.Add(this.btnOKIn);
            this.pnlMain.Controls.Add(this.btnOKOut);
            this.pnlMain.Controls.Add(this.lblName);
            this.pnlMain.Controls.Add(this.lblVersion);
            this.pnlMain.Location = new System.Drawing.Point(2, 22);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(269, 139);
            this.pnlMain.TabIndex = 51;
            this.pnlMain.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pnlMain_MouseMove);
            // 
            // lblCopyright
            // 
            this.lblCopyright.AutoSize = true;
            this.lblCopyright.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCopyright.Location = new System.Drawing.Point(13, 113);
            this.lblCopyright.Name = "lblCopyright";
            this.lblCopyright.Size = new System.Drawing.Size(123, 14);
            this.lblCopyright.TabIndex = 52;
            this.lblCopyright.Text = "© December, 2024";
            this.lblCopyright.MouseMove += new System.Windows.Forms.MouseEventHandler(this.lblCopyright_MouseMove);
            // 
            // pbFacebook
            // 
            this.pbFacebook.Image = ((System.Drawing.Image)(resources.GetObject("pbFacebook.Image")));
            this.pbFacebook.Location = new System.Drawing.Point(16, 41);
            this.pbFacebook.Name = "pbFacebook";
            this.pbFacebook.Size = new System.Drawing.Size(33, 33);
            this.pbFacebook.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbFacebook.TabIndex = 51;
            this.pbFacebook.TabStop = false;
            this.pbFacebook.Click += new System.EventHandler(this.pbFacebook_Click);
            this.pbFacebook.MouseEnter += new System.EventHandler(this.pbFacebook_MouseEnter);
            this.pbFacebook.MouseLeave += new System.EventHandler(this.pbFacebook_MouseLeave);
            // 
            // frmAbout
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.ClientSize = new System.Drawing.Size(273, 163);
            this.Controls.Add(this.panelUpper);
            this.Controls.Add(this.pnlMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmAbout";
            this.ShowInTaskbar = false;
            this.Text = "About";
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.frmAbout_MouseMove);
            this.panelUpper.ResumeLayout(false);
            this.formClose.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbClose)).EndInit();
            this.btnOKIn.ResumeLayout(false);
            this.btnOKIn.PerformLayout();
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbFacebook)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelUpper;
        private System.Windows.Forms.Label lblFormHeading;
        private System.Windows.Forms.Panel formClose;
        private System.Windows.Forms.PictureBox pbClose;
        private System.Windows.Forms.Panel btnOKIn;
        private System.Windows.Forms.Label lblBtnOK;
        private System.Windows.Forms.Panel btnOKOut;
        private System.Windows.Forms.Label lblVersion;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.PictureBox pbFacebook;
        private System.Windows.Forms.Label lblCopyright;
    }
}