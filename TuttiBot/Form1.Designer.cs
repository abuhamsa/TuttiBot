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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
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
            this.pgb_woking = new System.Windows.Forms.ProgressBar();
            this.btn_stop = new System.Windows.Forms.Button();
            this.txt_interval = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.txt_api = new System.Windows.Forms.TextBox();
            this.lbl_api = new System.Windows.Forms.Label();
            this.btn_setapi = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_plz = new System.Windows.Forms.TextBox();
            this.txt_radius = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.grp_provider.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 163);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Save File:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // txt_filepath
            // 
            this.txt_filepath.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_filepath.Location = new System.Drawing.Point(16, 179);
            this.txt_filepath.Name = "txt_filepath";
            this.txt_filepath.Size = new System.Drawing.Size(207, 20);
            this.txt_filepath.TabIndex = 1;
            this.txt_filepath.Click += new System.EventHandler(this.btn_choosefile_Click);
            // 
            // btn_choosefile
            // 
            this.btn_choosefile.Cursor = System.Windows.Forms.Cursors.Default;
            this.btn_choosefile.Location = new System.Drawing.Point(229, 177);
            this.btn_choosefile.Name = "btn_choosefile";
            this.btn_choosefile.Size = new System.Drawing.Size(75, 23);
            this.btn_choosefile.TabIndex = 2;
            this.btn_choosefile.Text = "Choose File";
            this.btn_choosefile.UseVisualStyleBackColor = true;
            this.btn_choosefile.Click += new System.EventHandler(this.btn_choosefile_Click);
            // 
            // btn_runsearch
            // 
            this.btn_runsearch.Location = new System.Drawing.Point(15, 275);
            this.btn_runsearch.Name = "btn_runsearch";
            this.btn_runsearch.Size = new System.Drawing.Size(180, 23);
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
            this.grp_provider.Location = new System.Drawing.Point(16, 53);
            this.grp_provider.Name = "grp_provider";
            this.grp_provider.Size = new System.Drawing.Size(143, 66);
            this.grp_provider.TabIndex = 6;
            this.grp_provider.TabStop = false;
            this.grp_provider.Text = "Provider:";
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
            this.rbtn_telegram.CheckedChanged += new System.EventHandler(this.rbtn_telegram_CheckedChanged);
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
            this.rbtn_pushover.CheckedChanged += new System.EventHandler(this.rbtn_pushover_CheckedChanged);
            // 
            // txt_log
            // 
            this.txt_log.Location = new System.Drawing.Point(311, 27);
            this.txt_log.Multiline = true;
            this.txt_log.Name = "txt_log";
            this.txt_log.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txt_log.Size = new System.Drawing.Size(420, 243);
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
            // pgb_woking
            // 
            this.pgb_woking.Location = new System.Drawing.Point(311, 276);
            this.pgb_woking.Name = "pgb_woking";
            this.pgb_woking.Size = new System.Drawing.Size(420, 21);
            this.pgb_woking.TabIndex = 9;
            // 
            // btn_stop
            // 
            this.btn_stop.Enabled = false;
            this.btn_stop.Location = new System.Drawing.Point(201, 275);
            this.btn_stop.Name = "btn_stop";
            this.btn_stop.Size = new System.Drawing.Size(104, 23);
            this.btn_stop.TabIndex = 10;
            this.btn_stop.Text = "Stop Search";
            this.btn_stop.UseVisualStyleBackColor = true;
            this.btn_stop.Click += new System.EventHandler(this.btn_stop_Click);
            // 
            // txt_interval
            // 
            this.txt_interval.Location = new System.Drawing.Point(16, 227);
            this.txt_interval.Name = "txt_interval";
            this.txt_interval.Size = new System.Drawing.Size(104, 20);
            this.txt_interval.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 211);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Interval:";
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.ContextMenuStrip = this.contextMenuStrip1;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "TuttiBot";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(104, 26);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(103, 22);
            this.toolStripMenuItem1.Text = "Close";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // txt_api
            // 
            this.txt_api.Location = new System.Drawing.Point(15, 138);
            this.txt_api.Name = "txt_api";
            this.txt_api.Size = new System.Drawing.Size(207, 20);
            this.txt_api.TabIndex = 13;
            // 
            // lbl_api
            // 
            this.lbl_api.AutoSize = true;
            this.lbl_api.Location = new System.Drawing.Point(12, 122);
            this.lbl_api.Name = "lbl_api";
            this.lbl_api.Size = new System.Drawing.Size(53, 13);
            this.lbl_api.TabIndex = 14;
            this.lbl_api.Text = "User-Key:";
            // 
            // btn_setapi
            // 
            this.btn_setapi.Location = new System.Drawing.Point(228, 136);
            this.btn_setapi.Name = "btn_setapi";
            this.btn_setapi.Size = new System.Drawing.Size(75, 23);
            this.btn_setapi.TabIndex = 15;
            this.btn_setapi.Text = "Set";
            this.btn_setapi.UseVisualStyleBackColor = true;
            this.btn_setapi.Click += new System.EventHandler(this.btn_setapi_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(127, 54);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 13);
            this.label3.TabIndex = 16;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(161, 65);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(30, 13);
            this.label4.TabIndex = 17;
            this.label4.Text = "PLZ:";
            // 
            // txt_plz
            // 
            this.txt_plz.Location = new System.Drawing.Point(205, 62);
            this.txt_plz.Name = "txt_plz";
            this.txt_plz.Size = new System.Drawing.Size(100, 20);
            this.txt_plz.TabIndex = 18;
            // 
            // txt_radius
            // 
            this.txt_radius.Location = new System.Drawing.Point(205, 92);
            this.txt_radius.Name = "txt_radius";
            this.txt_radius.Size = new System.Drawing.Size(100, 20);
            this.txt_radius.TabIndex = 20;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(161, 95);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 13);
            this.label5.TabIndex = 19;
            this.label5.Text = "Radius:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(743, 309);
            this.Controls.Add(this.txt_radius);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txt_plz);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btn_setapi);
            this.Controls.Add(this.lbl_api);
            this.Controls.Add(this.txt_api);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txt_interval);
            this.Controls.Add(this.btn_stop);
            this.Controls.Add(this.pgb_woking);
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
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "TuttiBot";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.grp_provider.ResumeLayout(false);
            this.grp_provider.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
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
        private System.Windows.Forms.ProgressBar pgb_woking;
        private System.Windows.Forms.Button btn_stop;
        private System.Windows.Forms.TextBox txt_interval;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.TextBox txt_api;
        private System.Windows.Forms.Label lbl_api;
        private System.Windows.Forms.Button btn_setapi;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_plz;
        private System.Windows.Forms.TextBox txt_radius;
        private System.Windows.Forms.Label label5;
    }
}

