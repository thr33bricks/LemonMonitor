using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Diagnostics;

namespace Lemon_resource_monitor
{
    public partial class frmAbout : Form
    {
        #region Movable
        //====================================================================================
        //Declarations used for making the form movable
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        private void CheckBeingMoved(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void panelUpper_MouseMove(object sender, MouseEventArgs e)
        {
            CheckBeingMoved(e);
        }

        private void lblFormHeading_MouseMove(object sender, MouseEventArgs e)
        {
            CheckBeingMoved(e);
        }

        private void frmAbout_MouseMove(object sender, MouseEventArgs e)
        {
            CheckBeingMoved(e);
        }

        private void pnlMain_MouseMove(object sender, MouseEventArgs e)
        {
            CheckBeingMoved(e);
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            CheckBeingMoved(e);
        }

        private void lblVersion_MouseMove(object sender, MouseEventArgs e)
        {
            CheckBeingMoved(e);
        }

        private void lblName_MouseMove(object sender, MouseEventArgs e)
        {
            CheckBeingMoved(e);
        }

        private void lblFlaticon_MouseMove(object sender, MouseEventArgs e)
        {
            CheckBeingMoved(e);
        }

        private void lblCopyright_MouseMove(object sender, MouseEventArgs e)
        {
            CheckBeingMoved(e);
        }
        //====================================================================================
        #endregion

        public frmAbout()
        {
            InitializeComponent();
        }

        #region Title bar button
        private void formClose_MouseEnter(object sender, EventArgs e)
        {
            Image close_clicked = Properties.Resources.close_clicked;
            formClose.BackColor = ColorTranslator.FromHtml("#f04747");
            pbClose.Image = (Image)(new Bitmap(close_clicked));
        }

        private void formClose_MouseLeave(object sender, EventArgs e)
        {
            Image close = Properties.Resources.close;
            formClose.BackColor = ColorTranslator.FromHtml("#202225");
            pbClose.Image = (Image)(new Bitmap(close));
        }

        private void form_mini_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void formClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region Button OK
        private void btnOKOut_Click(object sender, EventArgs e)
        {
            btnOK_Click();
        }

        private void btnOKOut_MouseEnter(object sender, EventArgs e)
        {
            btnOK_MouseEnter();
        }

        private void btnOKOut_MouseLeave(object sender, EventArgs e)
        {
            btnOK_MouseLeave();
        }

        private void btnOKIn_Click(object sender, EventArgs e)
        {
            btnOK_Click();
        }

        private void btnOKIn_MouseEnter(object sender, EventArgs e)
        {
            btnOK_MouseEnter();
        }

        private void btnOKIn_MouseLeave(object sender, EventArgs e)
        {
            btnOK_MouseLeave();
        }

        private void lblBtnOK_Click(object sender, EventArgs e)
        {
            btnOK_Click();
        }

        private void lblBtnOK_MouseEnter(object sender, EventArgs e)
        {
            btnOK_MouseEnter();
        }

        private void lblBtnOK_MouseLeave(object sender, EventArgs e)
        {
            btnOK_MouseLeave();
        }

        private void btnOK_Click()
        {
            this.Close();
        }

        private void btnOK_MouseEnter()
        {
            btnOKOut.BackColor = Color.FromArgb(0, 122, 204);
            btnOKIn.BackColor = Color.LightGray;
        }

        private void btnOK_MouseLeave()
        {
            btnOKOut.BackColor = Color.DimGray;
            btnOKIn.BackColor = Color.Gainsboro;
        }
        #endregion

        #region Facebook pictureBox
        private void pbFacebook_Click(object sender, EventArgs e)
        {
            Process.Start("https://www.facebook.com/people/%D0%99%D0%BE%D1%80%D0%B4%D0%B0%D0%BD-%D0%99%D0%BE%D1%80%D0%B4%D0%B0%D0%BD%D0%BE%D0%B2/100004481626817");
        }

        private void pbFacebook_MouseEnter(object sender, EventArgs e)
        {
            pbFacebook.Image = Properties.Resources.fb_black;
        }

        private void pbFacebook_MouseLeave(object sender, EventArgs e)
        {
            pbFacebook.Image = Properties.Resources.fb_blue;
        }
        #endregion
    }
}
