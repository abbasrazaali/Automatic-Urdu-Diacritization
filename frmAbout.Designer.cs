namespace Urdu_Diacritization
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
            this.creator = new System.Windows.Forms.Label();
            this.appProjName = new System.Windows.Forms.Label();
            this.OK = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // creator
            // 
            this.creator.Location = new System.Drawing.Point(40, 48);
            this.creator.Name = "creator";
            this.creator.Size = new System.Drawing.Size(152, 16);
            this.creator.TabIndex = 10;
            this.creator.Text = "تیار کردہ: عباس رضا علی";
            this.creator.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // appProjName
            // 
            this.appProjName.Location = new System.Drawing.Point(41, 24);
            this.appProjName.Name = "appProjName";
            this.appProjName.Size = new System.Drawing.Size(150, 16);
            this.appProjName.TabIndex = 9;
            this.appProjName.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // OK
            // 
            this.OK.Location = new System.Drawing.Point(79, 88);
            this.OK.Name = "OK";
            this.OK.Size = new System.Drawing.Size(75, 23);
            this.OK.TabIndex = 8;
            this.OK.Text = "ٹ&ھیک ہے";
            this.OK.Click += new System.EventHandler(this.OK_Click);
            // 
            // frmAbout
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(232, 134);
            this.ControlBox = false;
            this.Controls.Add(this.creator);
            this.Controls.Add(this.appProjName);
            this.Controls.Add(this.OK);
            this.Name = "frmAbout";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmAbout";
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.Label creator;
        internal System.Windows.Forms.Label appProjName;
        internal System.Windows.Forms.Button OK;
    }
}