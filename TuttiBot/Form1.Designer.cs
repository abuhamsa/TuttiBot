namespace TuttiBot
{
    partial class Form1
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.txt_filepath = new System.Windows.Forms.TextBox();
            this.btn_choosefile = new System.Windows.Forms.Button();
            this.btn_runsearch = new System.Windows.Forms.Button();
            this.txt_searchterm = new System.Windows.Forms.TextBox();
            this.lbl_searchterm = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.grp_provider = new System.Windows.Forms.GroupBox();
            this.rbtn_telegram = new System.Windows.Forms.RadioButton();
            this.rbtn_pushover = new System.Windows.Forms.RadioButton();
            this.txt_log = new System.Windows.Forms.TextBox();
            this.lbl_log = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.grp_provider.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Save File:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // txt_filepath
            // 
            this.txt_filepath.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_filepath.Location = new System.Drawing.Point(16, 82);
            this.txt_filepath.Name = "txt_filepath";
            this.txt_filepath.Size = new System.Drawing.Size(207, 20);
            this.txt_filepath.TabIndex = 1;
            this.txt_filepath.Click += new System.EventHandler(this.btn_choosefile_Click);
            // 
            // btn_choosefile
            // 
            this.btn_choosefile.Cursor = System.Windows.Forms.Cursors.Default;
            this.btn_choosefile.Location = new System.Drawing.Point(229, 80);
            this.btn_choosefile.Name = "btn_choosefile";
            this.btn_choosefile.Size = new System.Drawing.Size(75, 23);
            this.btn_choosefile.TabIndex = 2;
            this.btn_choosefile.Text = "Choose File";
            this.btn_choosefile.UseVisualStyleBackColor = true;
            this.btn_choosefile.Click += new System.EventHandler(this.btn_choosefile_Click);
            // 
            // btn_runsearch
            // 
            this.btn_runsearch.Location = new System.Drawing.Point(15, 191);
            this.btn_runsearch.Name = "btn_runsearch";
            this.btn_runsearch.Size = new System.Drawing.Size(289, 23);
            this.btn_runsearch.TabIndex = 4;
            this.btn_runsearch.Text = "Run Search";
            this.btn_runsearch.UseVisualStyleBackColor = true;
            this.btn_runsearch.Click += new System.EventHandler(this.button2_Click);
            // 
            // txt_searchterm
            // 
            this.txt_searchterm.Location = new System.Drawing.Point(15, 27);
            this.txt_searchterm.Name = "txt_searchterm";
            this.txt_searchterm.Size = new System.Drawing.Size(289, 20);
            this.txt_searchterm.TabIndex = 3;
            this.txt_searchterm.Text = "unihockey";
            // 
            // lbl_searchterm
            // 
            this.lbl_searchterm.AutoSize = true;
            this.lbl_searchterm.Location = new System.Drawing.Point(12, 9);
            this.lbl_searchterm.Name = "lbl_searchterm";
            this.lbl_searchterm.Size = new System.Drawing.Size(64, 13);
            this.lbl_searchterm.TabIndex = 5;
            this.lbl_searchterm.Text = "Searchterm:";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // grp_provider
            // 
            this.grp_provider.Controls.Add(this.rbtn_telegram);
            this.grp_provider.Controls.Add(this.rbtn_pushover);
            this.grp_provider.Location = new System.Drawing.Point(16, 119);
            this.grp_provider.Name = "grp_provider";
            this.grp_provider.Size = new System.Drawing.Size(288, 66);
            this.grp_provider.TabIndex = 6;
            this.grp_provider.TabStop = false;
            this.grp_provider.Text = "Provider";
            // 
            // rbtn_telegram
            // 
            this.rbtn_telegram.AutoSize = true;
            this.rbtn_telegram.Location = new System.Drawing.Point(6, 42);
            this.rbtn_telegram.Name = "rbtn_telegram";
            this.rbtn_telegram.Size = new System.Drawing.Size(69, 17);
            this.rbtn_telegram.TabIndex = 1;
            this.rbtn_telegram.Text = "Telegram";
            this.rbtn_telegram.UseVisualStyleBackColor = true;
            // 
            // rbtn_pushover
            // 
            this.rbtn_pushover.AutoSize = true;
            this.rbtn_pushover.Checked = true;
            this.rbtn_pushover.Location = new System.Drawing.Point(6, 19);
            this.rbtn_pushover.Name = "rbtn_pushover";
            this.rbtn_pushover.Size = new System.Drawing.Size(70, 17);
            this.rbtn_pushover.TabIndex = 0;
            this.rbtn_pushover.TabStop = true;
            this.rbtn_pushover.Text = "Pushover";
            this.rbtn_pushover.UseVisualStyleBackColor = true;
            // 
            // txt_log
            // 
            this.txt_log.Location = new System.Drawing.Point(311, 27);
            this.txt_log.Multiline = true;
            this.txt_log.Name = "txt_log";
            this.txt_log.Size = new System.Drawing.Size(420, 158);
            this.txt_log.TabIndex = 7;
            // 
            // lbl_log
            // 
            this.lbl_log.AutoSize = true;
            this.lbl_log.Location = new System.Drawing.Point(308, 9);
            this.lbl_log.Name = "lbl_log";
            this.lbl_log.Size = new System.Drawing.Size(28, 13);
            this.lbl_log.TabIndex = 8;
            this.lbl_log.Text = "Log:";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(311, 192);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(420, 21);
            this.progressBar1.TabIndex = 9;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(743, 225);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.lbl_log);
            this.Controls.Add(this.txt_log);
            this.Controls.Add(this.grp_provider);
            this.Controls.Add(this.btn_choosefile);
            this.Controls.Add(this.lbl_searchterm);
            this.Controls.Add(this.txt_filepath);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_searchterm);
            this.Controls.Add(this.btn_runsearch);
            this.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.Name = "Form1";
            this.Text = "TuttiBot-Test GUI";
            this.grp_provider.ResumeLayout(false);
            this.grp_provider.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_choosefile;
        private System.Windows.Forms.TextBox txt_filepath;
        private System.Windows.Forms.Button btn_runsearch;
        private System.Windows.Forms.TextBox txt_searchterm;
        private System.Windows.Forms.Label lbl_searchterm;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.GroupBox grp_provider;
        private System.Windows.Forms.RadioButton rbtn_telegram;
        private System.Windows.Forms.RadioButton rbtn_pushover;
        private System.Windows.Forms.TextBox txt_log;
        private System.Windows.Forms.Label lbl_log;
        private System.Windows.Forms.ProgressBar progressBar1;
    }
}

