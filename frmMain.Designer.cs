namespace Urdu_Diacritization
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.mnuMain = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.undoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.cutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pasteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.selectAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.formateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.wordWrapToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fontToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.preprocessingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.normalizationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.undiacritizationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tokenizationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ٹ = new System.Windows.Forms.ToolStripSeparator();
            this.partofSpeechToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.searchFromCorpusToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.searchFromLexiconToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.morphemesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.diacritizationTrigramToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.diacritizationBigramToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.نتائیجToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.testDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutAUDToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fntMain = new System.Windows.Forms.FontDialog();
            this.opnMain = new System.Windows.Forms.OpenFileDialog();
            this.savMain = new System.Windows.Forms.SaveFileDialog();
            this.statusBar = new System.Windows.Forms.StatusBar();
            this.txtInput = new System.Windows.Forms.RichTextBox();
            this.mnuMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // mnuMain
            // 
            this.mnuMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.formateToolStripMenuItem,
            this.preprocessingToolStripMenuItem,
            this.نتائیجToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.mnuMain.Location = new System.Drawing.Point(0, 0);
            this.mnuMain.Name = "mnuMain";
            this.mnuMain.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.mnuMain.ShowItemToolTips = true;
            this.mnuMain.Size = new System.Drawing.Size(590, 24);
            this.mnuMain.TabIndex = 1;
            this.mnuMain.Text = "Main menu";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.toolStripSeparator1,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(45, 20);
            this.fileToolStripMenuItem.Text = "م&سل";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.newToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.newToolStripMenuItem.Text = "ن&یا...";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.openToolStripMenuItem.Text = "ک&ھولیں...";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.saveToolStripMenuItem.Text = "م&حفوظ...";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(159, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.exitToolStripMenuItem.Text = "خر&وج کریں";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.undoToolStripMenuItem,
            this.toolStripSeparator2,
            this.cutToolStripMenuItem,
            this.copyToolStripMenuItem,
            this.pasteToolStripMenuItem,
            this.toolStripSeparator3,
            this.selectAllToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.editToolStripMenuItem.Text = "ت&دوین";
            // 
            // undoToolStripMenuItem
            // 
            this.undoToolStripMenuItem.Name = "undoToolStripMenuItem";
            this.undoToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Z)));
            this.undoToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.undoToolStripMenuItem.Text = "کالع&دم";
            this.undoToolStripMenuItem.Click += new System.EventHandler(this.undoToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(188, 6);
            // 
            // cutToolStripMenuItem
            // 
            this.cutToolStripMenuItem.Name = "cutToolStripMenuItem";
            this.cutToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.T)));
            this.cutToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.cutToolStripMenuItem.Text = "ک&اٹیں";
            this.cutToolStripMenuItem.Click += new System.EventHandler(this.cutToolStripMenuItem_Click);
            // 
            // copyToolStripMenuItem
            // 
            this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            this.copyToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.copyToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.copyToolStripMenuItem.Text = "ن&قل";
            this.copyToolStripMenuItem.Click += new System.EventHandler(this.copyToolStripMenuItem_Click);
            // 
            // pasteToolStripMenuItem
            // 
            this.pasteToolStripMenuItem.Name = "pasteToolStripMenuItem";
            this.pasteToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V)));
            this.pasteToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.pasteToolStripMenuItem.Text = "ج&وڑیں";
            this.pasteToolStripMenuItem.Click += new System.EventHandler(this.pasteToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(188, 6);
            // 
            // selectAllToolStripMenuItem
            // 
            this.selectAllToolStripMenuItem.Name = "selectAllToolStripMenuItem";
            this.selectAllToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.A)));
            this.selectAllToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.selectAllToolStripMenuItem.Text = "ت&مام منتخب کریں";
            this.selectAllToolStripMenuItem.Click += new System.EventHandler(this.selectAllToolStripMenuItem_Click);
            // 
            // formateToolStripMenuItem
            // 
            this.formateToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.wordWrapToolStripMenuItem,
            this.fontToolStripMenuItem});
            this.formateToolStripMenuItem.Name = "formateToolStripMenuItem";
            this.formateToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.formateToolStripMenuItem.Text = "و&ضع";
            // 
            // wordWrapToolStripMenuItem
            // 
            this.wordWrapToolStripMenuItem.Name = "wordWrapToolStripMenuItem";
            this.wordWrapToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.W)));
            this.wordWrapToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.wordWrapToolStripMenuItem.Text = "الفاظ لپیٹیں&";
            this.wordWrapToolStripMenuItem.Click += new System.EventHandler(this.wordWrapToolStripMenuItem_Click);
            // 
            // fontToolStripMenuItem
            // 
            this.fontToolStripMenuItem.Name = "fontToolStripMenuItem";
            this.fontToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F)));
            this.fontToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.fontToolStripMenuItem.Text = "ف&انٹ";
            this.fontToolStripMenuItem.Click += new System.EventHandler(this.fontToolStripMenuItem_Click);
            // 
            // preprocessingToolStripMenuItem
            // 
            this.preprocessingToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.normalizationToolStripMenuItem,
            this.undiacritizationToolStripMenuItem,
            this.tokenizationToolStripMenuItem,
            this.ٹ,
            this.partofSpeechToolStripMenuItem,
            this.toolStripSeparator4,
            this.searchFromCorpusToolStripMenuItem,
            this.searchFromLexiconToolStripMenuItem,
            this.toolStripSeparator6,
            this.morphemesToolStripMenuItem,
            this.toolStripSeparator5,
            this.diacritizationBigramToolStripMenuItem,
            this.diacritizationTrigramToolStripMenuItem});
            this.preprocessingToolStripMenuItem.Name = "preprocessingToolStripMenuItem";
            this.preprocessingToolStripMenuItem.Size = new System.Drawing.Size(95, 20);
            this.preprocessingToolStripMenuItem.Text = "پ&ری پروسیسنگ";
            // 
            // normalizationToolStripMenuItem
            // 
            this.normalizationToolStripMenuItem.Name = "normalizationToolStripMenuItem";
            this.normalizationToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift)
                        | System.Windows.Forms.Keys.N)));
            this.normalizationToolStripMenuItem.Size = new System.Drawing.Size(238, 22);
            this.normalizationToolStripMenuItem.Text = "&مطابقت";
            this.normalizationToolStripMenuItem.Click += new System.EventHandler(this.normalizationToolStripMenuItem_Click);
            // 
            // undiacritizationToolStripMenuItem
            // 
            this.undiacritizationToolStripMenuItem.Name = "undiacritizationToolStripMenuItem";
            this.undiacritizationToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift)
                        | System.Windows.Forms.Keys.U)));
            this.undiacritizationToolStripMenuItem.Size = new System.Drawing.Size(238, 22);
            this.undiacritizationToolStripMenuItem.Text = "&اعراب ہٹانا";
            this.undiacritizationToolStripMenuItem.Click += new System.EventHandler(this.undiacritizationToolStripMenuItem_Click);
            // 
            // tokenizationToolStripMenuItem
            // 
            this.tokenizationToolStripMenuItem.Name = "tokenizationToolStripMenuItem";
            this.tokenizationToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift)
                        | System.Windows.Forms.Keys.T)));
            this.tokenizationToolStripMenuItem.Size = new System.Drawing.Size(238, 22);
            this.tokenizationToolStripMenuItem.Text = "ٹ&وکنائزیشن";
            this.tokenizationToolStripMenuItem.Click += new System.EventHandler(this.tokenizationToolStripMenuItem_Click);
            // 
            // ٹ
            // 
            this.ٹ.Name = "ٹ";
            this.ٹ.Size = new System.Drawing.Size(235, 6);
            // 
            // partofSpeechToolStripMenuItem
            // 
            this.partofSpeechToolStripMenuItem.Name = "partofSpeechToolStripMenuItem";
            this.partofSpeechToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift)
                        | System.Windows.Forms.Keys.P)));
            this.partofSpeechToolStripMenuItem.Size = new System.Drawing.Size(238, 22);
            this.partofSpeechToolStripMenuItem.Text = "&پارٹ آف سپیچ ٹیگنگ";
            this.partofSpeechToolStripMenuItem.Click += new System.EventHandler(this.partofSpeechToolStripMenuItem_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(235, 6);
            // 
            // searchFromCorpusToolStripMenuItem
            // 
            this.searchFromCorpusToolStripMenuItem.ForeColor = System.Drawing.Color.SteelBlue;
            this.searchFromCorpusToolStripMenuItem.Name = "searchFromCorpusToolStripMenuItem";
            this.searchFromCorpusToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift)
                        | System.Windows.Forms.Keys.C)));
            this.searchFromCorpusToolStripMenuItem.Size = new System.Drawing.Size(238, 22);
            this.searchFromCorpusToolStripMenuItem.Text = "&کارپس سے تلاش";
            this.searchFromCorpusToolStripMenuItem.Click += new System.EventHandler(this.searchFromCorpusToolStripMenuItem_Click);
            // 
            // searchFromLexiconToolStripMenuItem
            // 
            this.searchFromLexiconToolStripMenuItem.ForeColor = System.Drawing.Color.ForestGreen;
            this.searchFromLexiconToolStripMenuItem.Name = "searchFromLexiconToolStripMenuItem";
            this.searchFromLexiconToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift)
                        | System.Windows.Forms.Keys.L)));
            this.searchFromLexiconToolStripMenuItem.Size = new System.Drawing.Size(238, 22);
            this.searchFromLexiconToolStripMenuItem.Text = "&لیگزیکون سے تلاش";
            this.searchFromLexiconToolStripMenuItem.Click += new System.EventHandler(this.searchFromLexiconToolStripMenuItem_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(235, 6);
            // 
            // morphemesToolStripMenuItem
            // 
            this.morphemesToolStripMenuItem.ForeColor = System.Drawing.Color.DarkOrange;
            this.morphemesToolStripMenuItem.Name = "morphemesToolStripMenuItem";
            this.morphemesToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift)
                        | System.Windows.Forms.Keys.M)));
            this.morphemesToolStripMenuItem.Size = new System.Drawing.Size(238, 22);
            this.morphemesToolStripMenuItem.Text = "م&ورفیمز لگانا";
            this.morphemesToolStripMenuItem.Click += new System.EventHandler(this.morphemesToolStripMenuItem_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(235, 6);
            // 
            // diacritizationTrigramToolStripMenuItem
            // 
            this.diacritizationTrigramToolStripMenuItem.ForeColor = System.Drawing.Color.Red;
            this.diacritizationTrigramToolStripMenuItem.Name = "diacritizationTrigramToolStripMenuItem";
            this.diacritizationTrigramToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift)
                        | System.Windows.Forms.Keys.D)));
            this.diacritizationTrigramToolStripMenuItem.Size = new System.Drawing.Size(238, 22);
            this.diacritizationTrigramToolStripMenuItem.Text = "اعراب &لگانا (Trigram)";
            this.diacritizationTrigramToolStripMenuItem.Click += new System.EventHandler(this.diacritizationTrigramToolStripMenuItem_Click);
            // 
            // diacritizationBigramToolStripMenuItem
            // 
            this.diacritizationBigramToolStripMenuItem.ForeColor = System.Drawing.Color.Red;
            this.diacritizationBigramToolStripMenuItem.Name = "diacritizationBigramToolStripMenuItem";
            this.diacritizationBigramToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift)
                        | System.Windows.Forms.Keys.B)));
            this.diacritizationBigramToolStripMenuItem.Size = new System.Drawing.Size(238, 22);
            this.diacritizationBigramToolStripMenuItem.Text = "اعراب &لگانا (Bigram)";
            this.diacritizationBigramToolStripMenuItem.Click += new System.EventHandler(this.diacritizationBigramToolStripMenuItem_Click);
            // 
            // نتائیجToolStripMenuItem
            // 
            this.نتائیجToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.testDataToolStripMenuItem});
            this.نتائیجToolStripMenuItem.Name = "نتائیجToolStripMenuItem";
            this.نتائیجToolStripMenuItem.Size = new System.Drawing.Size(40, 20);
            this.نتائیجToolStripMenuItem.Text = "&نتائج";
            // 
            // testDataToolStripMenuItem
            // 
            this.testDataToolStripMenuItem.Name = "testDataToolStripMenuItem";
            this.testDataToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift)
                        | System.Windows.Forms.Keys.Y)));
            this.testDataToolStripMenuItem.Size = new System.Drawing.Size(207, 22);
            this.testDataToolStripMenuItem.Text = "ٹ&یسٹ ڈاٹا بنانا";
            this.testDataToolStripMenuItem.Click += new System.EventHandler(this.testDataToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutAUDToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(36, 20);
            this.helpToolStripMenuItem.Text = "م&دد";
            // 
            // aboutAUDToolStripMenuItem
            // 
            this.aboutAUDToolStripMenuItem.Name = "aboutAUDToolStripMenuItem";
            this.aboutAUDToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F1;
            this.aboutAUDToolStripMenuItem.Size = new System.Drawing.Size(254, 22);
            this.aboutAUDToolStripMenuItem.Text = "&خود کار اُردو اعراب لگانے کے متعلق";
            this.aboutAUDToolStripMenuItem.Click += new System.EventHandler(this.aboutAUDToolStripMenuItem_Click);
            // 
            // fntMain
            // 
            this.fntMain.Font = new System.Drawing.Font("Nafees Pakistani Naskh v2.01", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fntMain.FontMustExist = true;
            // 
            // opnMain
            // 
            this.opnMain.DefaultExt = "txt";
            this.opnMain.FileName = "*.txt";
            this.opnMain.Filter = "Text Documents (*.txt)|*.txt|All files (*.*)|*.*";
            this.opnMain.InitialDirectory = "c:\\";
            this.opnMain.RestoreDirectory = true;
            this.opnMain.Title = "کھولیں";
            // 
            // savMain
            // 
            this.savMain.DefaultExt = "txt";
            this.savMain.FileName = "*.txt";
            this.savMain.Filter = "Text Documents (*.txt)|*.txt|All files (*.*)|*.*";
            this.savMain.InitialDirectory = "c:\\";
            this.savMain.RestoreDirectory = true;
            this.savMain.Title = "محفوظ بطور";
            // 
            // statusBar
            // 
            this.statusBar.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statusBar.Location = new System.Drawing.Point(0, 244);
            this.statusBar.Name = "statusBar";
            this.statusBar.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.statusBar.Size = new System.Drawing.Size(590, 22);
            this.statusBar.SizingGrip = false;
            this.statusBar.TabIndex = 2;
            // 
            // txtInput
            // 
            this.txtInput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtInput.Font = new System.Drawing.Font("Nafees Pakistani Naskh v2.01", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtInput.Location = new System.Drawing.Point(0, 24);
            this.txtInput.Name = "txtInput";
            this.txtInput.Size = new System.Drawing.Size(590, 220);
            this.txtInput.TabIndex = 3;
            this.txtInput.Text = "";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(590, 266);
            this.Controls.Add(this.txtInput);
            this.Controls.Add(this.statusBar);
            this.Controls.Add(this.mnuMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.mnuMain;
            this.Name = "frmMain";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "خود کار اُردو اعراب لگانا";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.mnuMain.ResumeLayout(false);
            this.mnuMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mnuMain;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem formateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem undoToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem cutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pasteToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem selectAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem wordWrapToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fontToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutAUDToolStripMenuItem;
        private System.Windows.Forms.FontDialog fntMain;
        private System.Windows.Forms.OpenFileDialog opnMain;
        private System.Windows.Forms.SaveFileDialog savMain;
        private System.Windows.Forms.ToolStripMenuItem preprocessingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tokenizationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem normalizationToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator ٹ;
        private System.Windows.Forms.ToolStripMenuItem morphemesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem partofSpeechToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem searchFromLexiconToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem diacritizationBigramToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem undiacritizationToolStripMenuItem;
        private System.Windows.Forms.StatusBar statusBar;
        private System.Windows.Forms.ToolStripMenuItem searchFromCorpusToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripMenuItem نتائیجToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem testDataToolStripMenuItem;
        private System.Windows.Forms.RichTextBox txtInput;
        private System.Windows.Forms.ToolStripMenuItem diacritizationTrigramToolStripMenuItem;
    }
}

