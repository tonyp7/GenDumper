namespace WinCartDumper
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rtfLog = new System.Windows.Forms.RichTextBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripProgressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtRegion = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtSave = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtRomSize = new System.Windows.Forms.TextBox();
            this.txtSerialNumber = new System.Windows.Forms.TextBox();
            this.txtCopyright = new System.Windows.Forms.TextBox();
            this.txtGameTitle = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.txtFilenameFormat = new System.Windows.Forms.TextBox();
            this.btnDump = new System.Windows.Forms.Button();
            this.lblFilenameFormat = new System.Windows.Forms.Label();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveLogToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.serialPortToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.autodetectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSerialSeperator = new System.Windows.Forms.ToolStripSeparator();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.saveFileDialogLog = new System.Windows.Forms.SaveFileDialog();
            this.groupBox2.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rtfLog);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 278);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(543, 267);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Console";
            // 
            // rtfLog
            // 
            this.rtfLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtfLog.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtfLog.Location = new System.Drawing.Point(3, 16);
            this.rtfLog.Name = "rtfLog";
            this.rtfLog.ReadOnly = true;
            this.rtfLog.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.rtfLog.Size = new System.Drawing.Size(537, 248);
            this.rtfLog.TabIndex = 0;
            this.rtfLog.Text = "";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripProgressBar,
            this.toolStripStatusLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 545);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(543, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip";
            // 
            // toolStripProgressBar
            // 
            this.toolStripProgressBar.Name = "toolStripProgressBar";
            this.toolStripProgressBar.Size = new System.Drawing.Size(200, 16);
            this.toolStripProgressBar.Step = 1;
            this.toolStripProgressBar.Visible = false;
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(42, 17);
            this.toolStripStatusLabel.Text = "Ready.";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtRegion);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.txtSave);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.txtRomSize);
            this.groupBox3.Controls.Add(this.txtSerialNumber);
            this.groupBox3.Controls.Add(this.txtCopyright);
            this.groupBox3.Controls.Add(this.txtGameTitle);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox3.Location = new System.Drawing.Point(0, 24);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(543, 187);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Cart Info";
            // 
            // txtRegion
            // 
            this.txtRegion.Location = new System.Drawing.Point(101, 81);
            this.txtRegion.Name = "txtRegion";
            this.txtRegion.ReadOnly = true;
            this.txtRegion.Size = new System.Drawing.Size(332, 20);
            this.txtRegion.TabIndex = 14;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(54, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "Region";
            // 
            // txtSave
            // 
            this.txtSave.Location = new System.Drawing.Point(101, 159);
            this.txtSave.Name = "txtSave";
            this.txtSave.ReadOnly = true;
            this.txtSave.Size = new System.Drawing.Size(332, 20);
            this.txtSave.TabIndex = 12;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(39, 162);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Save Chip";
            // 
            // txtRomSize
            // 
            this.txtRomSize.Location = new System.Drawing.Point(101, 133);
            this.txtRomSize.Name = "txtRomSize";
            this.txtRomSize.ReadOnly = true;
            this.txtRomSize.Size = new System.Drawing.Size(332, 20);
            this.txtRomSize.TabIndex = 10;
            // 
            // txtSerialNumber
            // 
            this.txtSerialNumber.Location = new System.Drawing.Point(101, 107);
            this.txtSerialNumber.Name = "txtSerialNumber";
            this.txtSerialNumber.ReadOnly = true;
            this.txtSerialNumber.Size = new System.Drawing.Size(332, 20);
            this.txtSerialNumber.TabIndex = 9;
            // 
            // txtCopyright
            // 
            this.txtCopyright.Location = new System.Drawing.Point(101, 55);
            this.txtCopyright.Name = "txtCopyright";
            this.txtCopyright.ReadOnly = true;
            this.txtCopyright.Size = new System.Drawing.Size(332, 20);
            this.txtCopyright.TabIndex = 8;
            // 
            // txtGameTitle
            // 
            this.txtGameTitle.Location = new System.Drawing.Point(101, 29);
            this.txtGameTitle.Name = "txtGameTitle";
            this.txtGameTitle.ReadOnly = true;
            this.txtGameTitle.Size = new System.Drawing.Size(332, 20);
            this.txtGameTitle.TabIndex = 7;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(43, 136);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(52, 13);
            this.label8.TabIndex = 6;
            this.label8.Text = "Rom Size";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(22, 110);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(73, 13);
            this.label6.TabIndex = 4;
            this.label6.Text = "Serial Number";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(44, 58);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Copyright";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(37, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Game Title";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.txtFilenameFormat);
            this.groupBox4.Controls.Add(this.btnDump);
            this.groupBox4.Controls.Add(this.lblFilenameFormat);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox4.Location = new System.Drawing.Point(0, 211);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(543, 67);
            this.groupBox4.TabIndex = 4;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Dump";
            // 
            // txtFilenameFormat
            // 
            this.txtFilenameFormat.Location = new System.Drawing.Point(101, 24);
            this.txtFilenameFormat.Name = "txtFilenameFormat";
            this.txtFilenameFormat.Size = new System.Drawing.Size(332, 20);
            this.txtFilenameFormat.TabIndex = 15;
            this.txtFilenameFormat.Text = "%T (%R)";
            // 
            // btnDump
            // 
            this.btnDump.Location = new System.Drawing.Point(439, 19);
            this.btnDump.Name = "btnDump";
            this.btnDump.Size = new System.Drawing.Size(92, 29);
            this.btnDump.TabIndex = 5;
            this.btnDump.Text = "Dump!";
            this.btnDump.UseVisualStyleBackColor = true;
            this.btnDump.Click += new System.EventHandler(this.btnDump_Click);
            // 
            // lblFilenameFormat
            // 
            this.lblFilenameFormat.AutoSize = true;
            this.lblFilenameFormat.Location = new System.Drawing.Point(11, 27);
            this.lblFilenameFormat.Name = "lblFilenameFormat";
            this.lblFilenameFormat.Size = new System.Drawing.Size(84, 13);
            this.lblFilenameFormat.TabIndex = 3;
            this.lblFilenameFormat.Text = "Filename Format";
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.toolsToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(543, 24);
            this.menuStrip.TabIndex = 5;
            this.menuStrip.Text = "menuStrip";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveLogToolStripMenuItem,
            this.toolStripSeparator1,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // saveLogToolStripMenuItem
            // 
            this.saveLogToolStripMenuItem.Name = "saveLogToolStripMenuItem";
            this.saveLogToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.saveLogToolStripMenuItem.Text = "&Save Console Output";
            this.saveLogToolStripMenuItem.Click += new System.EventHandler(this.saveLogToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(182, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.serialPortToolStripMenuItem});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
            this.toolsToolStripMenuItem.Text = "&Tools";
            // 
            // serialPortToolStripMenuItem
            // 
            this.serialPortToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.autodetectToolStripMenuItem,
            this.toolStripSerialSeperator});
            this.serialPortToolStripMenuItem.Name = "serialPortToolStripMenuItem";
            this.serialPortToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.serialPortToolStripMenuItem.Text = "Serial Port: <>";
            // 
            // autodetectToolStripMenuItem
            // 
            this.autodetectToolStripMenuItem.Name = "autodetectToolStripMenuItem";
            this.autodetectToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.autodetectToolStripMenuItem.Text = "Autodetect";
            this.autodetectToolStripMenuItem.Click += new System.EventHandler(this.autodetectToolStripMenuItem_Click);
            // 
            // toolStripSerialSeperator
            // 
            this.toolStripSerialSeperator.Name = "toolStripSerialSeperator";
            this.toolStripSerialSeperator.Size = new System.Drawing.Size(130, 6);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "&Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.aboutToolStripMenuItem.Text = "&About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.Filter = "Mega Drive Roms|*.md|Save Files|*.sav|All Files|*.*";
            // 
            // toolTip
            // 
            this.toolTip.AutomaticDelay = 100;
            this.toolTip.AutoPopDelay = 5000;
            this.toolTip.InitialDelay = 100;
            this.toolTip.IsBalloon = true;
            this.toolTip.ReshowDelay = 20;
            this.toolTip.ShowAlways = true;
            // 
            // saveFileDialogLog
            // 
            this.saveFileDialogLog.Filter = "Text Documents|*.txt|All Files|*.*";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(543, 567);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmMain";
            this.Text = "GenDumper";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.groupBox2.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RichTextBox rtfLog;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txtRegion;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtSave;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtRomSize;
        private System.Windows.Forms.TextBox txtSerialNumber;
        private System.Windows.Forms.TextBox txtCopyright;
        private System.Windows.Forms.TextBox txtGameTitle;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button btnDump;
        private System.Windows.Forms.Label lblFilenameFormat;
        private System.Windows.Forms.TextBox txtFilenameFormat;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem serialPortToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem autodetectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveLogToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSerialSeperator;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.SaveFileDialog saveFileDialogLog;
    }
}

