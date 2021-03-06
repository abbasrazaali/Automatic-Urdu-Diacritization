using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Urdu_Diacritization
{
    public partial class frmAbout : Form
    {
        frmMain main = new frmMain();

        public frmAbout()
        {
            InitializeComponent();

            this.Text = main.projectName + " کے متعلق";
            appProjName.Text = main.projectName;
        }

        private void OK_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
            }
            catch (Exception caught)
            {
                MessageBox.Show(caught.Message, main.projectName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}