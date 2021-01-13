namespace HashRenamer
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
            this.listView1 = new System.Windows.Forms.ListView();
            this.nColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.statusColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.currentNameColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.hashColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.newNameColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.itemContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.skipMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.totprogressBar = new System.Windows.Forms.ProgressBar();
            this.fileprogressBar = new System.Windows.Forms.ProgressBar();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.renameBtn = new System.Windows.Forms.Button();
            this.selectfilesBtn = new System.Windows.Forms.Button();
            this.hashBtn = new System.Windows.Forms.Button();
            this.countLabel = new System.Windows.Forms.Label();
            this.progressLabel = new System.Windows.Forms.Label();
            this.elapsedLabel = new System.Windows.Forms.Label();
            this.totSizeLabel = new System.Windows.Forms.Label();
            this.processedLabel = new System.Windows.Forms.Label();
            this.speedLabel = new System.Windows.Forms.Label();
            this.pauseButton = new System.Windows.Forms.Button();
            this.previewButton = new System.Windows.Forms.Button();
            this.endRadioButton = new System.Windows.Forms.RadioButton();
            this.startRadioButton = new System.Windows.Forms.RadioButton();
            this.remainingLabel = new System.Windows.Forms.Label();
            this.skipButton = new System.Windows.Forms.Button();
            this.itemContextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // listView1
            // 
            this.listView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listView1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.listView1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.nColumnHeader,
            this.statusColumnHeader,
            this.currentNameColumnHeader,
            this.hashColumnHeader,
            this.newNameColumnHeader});
            this.listView1.ContextMenuStrip = this.itemContextMenu;
            this.listView1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listView1.ForeColor = System.Drawing.SystemColors.Info;
            this.listView1.FullRowSelect = true;
            this.listView1.Location = new System.Drawing.Point(12, 12);
            this.listView1.Name = "listView1";
            this.listView1.ShowItemToolTips = true;
            this.listView1.Size = new System.Drawing.Size(1105, 298);
            this.listView1.TabIndex = 2;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // nColumnHeader
            // 
            this.nColumnHeader.Text = "#";
            this.nColumnHeader.Width = 40;
            // 
            // statusColumnHeader
            // 
            this.statusColumnHeader.Text = "Status";
            this.statusColumnHeader.Width = 110;
            // 
            // currentNameColumnHeader
            // 
            this.currentNameColumnHeader.Text = "File name";
            this.currentNameColumnHeader.Width = 406;
            // 
            // hashColumnHeader
            // 
            this.hashColumnHeader.Text = "Hash";
            this.hashColumnHeader.Width = 160;
            // 
            // newNameColumnHeader
            // 
            this.newNameColumnHeader.Text = "New Name";
            this.newNameColumnHeader.Width = 384;
            // 
            // itemContextMenu
            // 
            this.itemContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addMenuItem,
            this.skipMenuItem});
            this.itemContextMenu.Name = "itemContextMenu";
            this.itemContextMenu.Size = new System.Drawing.Size(166, 48);
            this.itemContextMenu.Opening += new System.ComponentModel.CancelEventHandler(this.itemContextMenu_Opening);
            // 
            // addMenuItem
            // 
            this.addMenuItem.Name = "addMenuItem";
            this.addMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.addMenuItem.Size = new System.Drawing.Size(165, 22);
            this.addMenuItem.Text = "Add Files";
            this.addMenuItem.Click += new System.EventHandler(this.addMenuItem_Click);
            // 
            // skipMenuItem
            // 
            this.skipMenuItem.Name = "skipMenuItem";
            this.skipMenuItem.Size = new System.Drawing.Size(165, 22);
            this.skipMenuItem.Text = "Skip";
            this.skipMenuItem.Visible = false;
            this.skipMenuItem.Click += new System.EventHandler(this.skipMenuItem_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.Multiselect = true;
            this.openFileDialog1.Title = "Select Files";
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.WorkerSupportsCancellation = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // totprogressBar
            // 
            this.totprogressBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.totprogressBar.Location = new System.Drawing.Point(59, 379);
            this.totprogressBar.Name = "totprogressBar";
            this.totprogressBar.Size = new System.Drawing.Size(1058, 23);
            this.totprogressBar.TabIndex = 9;
            // 
            // fileprogressBar
            // 
            this.fileprogressBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fileprogressBar.Location = new System.Drawing.Point(59, 347);
            this.fileprogressBar.Name = "fileprogressBar";
            this.fileprogressBar.Size = new System.Drawing.Size(1058, 23);
            this.fileprogressBar.TabIndex = 7;
            // 
            // cancelBtn
            // 
            this.cancelBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelBtn.Enabled = false;
            this.cancelBtn.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cancelBtn.Location = new System.Drawing.Point(492, 414);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(140, 35);
            this.cancelBtn.TabIndex = 12;
            this.cancelBtn.Text = "Cancel";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // renameBtn
            // 
            this.renameBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.renameBtn.Enabled = false;
            this.renameBtn.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.renameBtn.Location = new System.Drawing.Point(812, 414);
            this.renameBtn.Name = "renameBtn";
            this.renameBtn.Size = new System.Drawing.Size(140, 35);
            this.renameBtn.TabIndex = 11;
            this.renameBtn.Text = "Rename";
            this.renameBtn.UseVisualStyleBackColor = true;
            this.renameBtn.Click += new System.EventHandler(this.renameBtn_Click);
            // 
            // selectfilesBtn
            // 
            this.selectfilesBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.selectfilesBtn.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.selectfilesBtn.Location = new System.Drawing.Point(652, 414);
            this.selectfilesBtn.Name = "selectfilesBtn";
            this.selectfilesBtn.Size = new System.Drawing.Size(140, 35);
            this.selectfilesBtn.TabIndex = 10;
            this.selectfilesBtn.Text = "Add Files";
            this.selectfilesBtn.UseVisualStyleBackColor = true;
            this.selectfilesBtn.Click += new System.EventHandler(this.selectfilesBtn_Click);
            // 
            // hashBtn
            // 
            this.hashBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.hashBtn.Enabled = false;
            this.hashBtn.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.hashBtn.Location = new System.Drawing.Point(972, 414);
            this.hashBtn.Name = "hashBtn";
            this.hashBtn.Size = new System.Drawing.Size(140, 35);
            this.hashBtn.TabIndex = 8;
            this.hashBtn.Text = "Hash";
            this.hashBtn.UseVisualStyleBackColor = true;
            this.hashBtn.Click += new System.EventHandler(this.hashBtn_Click);
            // 
            // countLabel
            // 
            this.countLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.countLabel.AutoSize = true;
            this.countLabel.ForeColor = System.Drawing.SystemColors.Info;
            this.countLabel.Location = new System.Drawing.Point(15, 385);
            this.countLabel.Name = "countLabel";
            this.countLabel.Size = new System.Drawing.Size(24, 13);
            this.countLabel.TabIndex = 14;
            this.countLabel.Text = "0/0";
            // 
            // progressLabel
            // 
            this.progressLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.progressLabel.AutoSize = true;
            this.progressLabel.ForeColor = System.Drawing.SystemColors.Info;
            this.progressLabel.Location = new System.Drawing.Point(15, 354);
            this.progressLabel.Name = "progressLabel";
            this.progressLabel.Size = new System.Drawing.Size(21, 13);
            this.progressLabel.TabIndex = 15;
            this.progressLabel.Text = "0%";
            // 
            // elapsedLabel
            // 
            this.elapsedLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.elapsedLabel.AutoSize = true;
            this.elapsedLabel.ForeColor = System.Drawing.SystemColors.Info;
            this.elapsedLabel.Location = new System.Drawing.Point(15, 323);
            this.elapsedLabel.Name = "elapsedLabel";
            this.elapsedLabel.Size = new System.Drawing.Size(122, 13);
            this.elapsedLabel.TabIndex = 16;
            this.elapsedLabel.Text = "Elapsed Time : 00:00:00";
            // 
            // totSizeLabel
            // 
            this.totSizeLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.totSizeLabel.AutoSize = true;
            this.totSizeLabel.ForeColor = System.Drawing.SystemColors.Info;
            this.totSizeLabel.Location = new System.Drawing.Point(230, 323);
            this.totSizeLabel.Name = "totSizeLabel";
            this.totSizeLabel.Size = new System.Drawing.Size(61, 13);
            this.totSizeLabel.TabIndex = 17;
            this.totSizeLabel.Text = "File Size : 0";
            // 
            // processedLabel
            // 
            this.processedLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.processedLabel.AutoSize = true;
            this.processedLabel.ForeColor = System.Drawing.SystemColors.Info;
            this.processedLabel.Location = new System.Drawing.Point(384, 323);
            this.processedLabel.Name = "processedLabel";
            this.processedLabel.Size = new System.Drawing.Size(72, 13);
            this.processedLabel.TabIndex = 18;
            this.processedLabel.Text = "Processed : 0";
            // 
            // speedLabel
            // 
            this.speedLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.speedLabel.AutoSize = true;
            this.speedLabel.ForeColor = System.Drawing.SystemColors.Info;
            this.speedLabel.Location = new System.Drawing.Point(549, 323);
            this.speedLabel.Name = "speedLabel";
            this.speedLabel.Size = new System.Drawing.Size(53, 13);
            this.speedLabel.TabIndex = 19;
            this.speedLabel.Text = "Speed : 0";
            // 
            // pauseButton
            // 
            this.pauseButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pauseButton.Enabled = false;
            this.pauseButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.pauseButton.Location = new System.Drawing.Point(332, 414);
            this.pauseButton.Name = "pauseButton";
            this.pauseButton.Size = new System.Drawing.Size(140, 35);
            this.pauseButton.TabIndex = 20;
            this.pauseButton.Text = "Pause";
            this.pauseButton.UseVisualStyleBackColor = true;
            this.pauseButton.Click += new System.EventHandler(this.pauseButton_Click);
            // 
            // previewButton
            // 
            this.previewButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.previewButton.Enabled = false;
            this.previewButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.previewButton.Location = new System.Drawing.Point(12, 414);
            this.previewButton.Name = "previewButton";
            this.previewButton.Size = new System.Drawing.Size(140, 35);
            this.previewButton.TabIndex = 21;
            this.previewButton.Text = "Preview";
            this.previewButton.UseVisualStyleBackColor = true;
            this.previewButton.Click += new System.EventHandler(this.previewButton_Click);
            // 
            // endRadioButton
            // 
            this.endRadioButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.endRadioButton.AutoSize = true;
            this.endRadioButton.Checked = true;
            this.endRadioButton.ForeColor = System.Drawing.Color.White;
            this.endRadioButton.Location = new System.Drawing.Point(1072, 321);
            this.endRadioButton.Name = "endRadioButton";
            this.endRadioButton.Size = new System.Drawing.Size(44, 17);
            this.endRadioButton.TabIndex = 22;
            this.endRadioButton.TabStop = true;
            this.endRadioButton.Text = "End";
            this.endRadioButton.UseVisualStyleBackColor = true;
            // 
            // startRadioButton
            // 
            this.startRadioButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.startRadioButton.AutoSize = true;
            this.startRadioButton.ForeColor = System.Drawing.Color.White;
            this.startRadioButton.Location = new System.Drawing.Point(1004, 321);
            this.startRadioButton.Name = "startRadioButton";
            this.startRadioButton.Size = new System.Drawing.Size(47, 17);
            this.startRadioButton.TabIndex = 23;
            this.startRadioButton.Text = "Start";
            this.startRadioButton.UseVisualStyleBackColor = true;
            // 
            // remainingLabel
            // 
            this.remainingLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.remainingLabel.AutoSize = true;
            this.remainingLabel.ForeColor = System.Drawing.SystemColors.Info;
            this.remainingLabel.Location = new System.Drawing.Point(695, 323);
            this.remainingLabel.Name = "remainingLabel";
            this.remainingLabel.Size = new System.Drawing.Size(134, 13);
            this.remainingLabel.TabIndex = 24;
            this.remainingLabel.Text = "Remaining Time : 00:00:00";
            // 
            // skipButton
            // 
            this.skipButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.skipButton.Enabled = false;
            this.skipButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.skipButton.Location = new System.Drawing.Point(172, 414);
            this.skipButton.Name = "skipButton";
            this.skipButton.Size = new System.Drawing.Size(140, 35);
            this.skipButton.TabIndex = 25;
            this.skipButton.Text = "Skip";
            this.skipButton.UseVisualStyleBackColor = true;
            this.skipButton.Click += new System.EventHandler(this.skipButton_Click);
            // 
            // Form1
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.ClientSize = new System.Drawing.Size(1129, 461);
            this.Controls.Add(this.skipButton);
            this.Controls.Add(this.remainingLabel);
            this.Controls.Add(this.startRadioButton);
            this.Controls.Add(this.endRadioButton);
            this.Controls.Add(this.previewButton);
            this.Controls.Add(this.pauseButton);
            this.Controls.Add(this.speedLabel);
            this.Controls.Add(this.processedLabel);
            this.Controls.Add(this.totSizeLabel);
            this.Controls.Add(this.elapsedLabel);
            this.Controls.Add(this.progressLabel);
            this.Controls.Add(this.countLabel);
            this.Controls.Add(this.totprogressBar);
            this.Controls.Add(this.fileprogressBar);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.renameBtn);
            this.Controls.Add(this.selectfilesBtn);
            this.Controls.Add(this.hashBtn);
            this.Controls.Add(this.listView1);
            this.MinimumSize = new System.Drawing.Size(1145, 500);
            this.Name = "Form1";
            this.Text = "Hash Renamer";
            this.Shown += new System.EventHandler(this.Form1_Shown);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.Form1_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.Form1_DragEnter);
            this.itemContextMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader nColumnHeader;
        private System.Windows.Forms.ColumnHeader currentNameColumnHeader;
        private System.Windows.Forms.ColumnHeader hashColumnHeader;
        private System.Windows.Forms.ColumnHeader newNameColumnHeader;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.ProgressBar totprogressBar;
        private System.Windows.Forms.ProgressBar fileprogressBar;
        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.Button renameBtn;
        private System.Windows.Forms.Button selectfilesBtn;
        private System.Windows.Forms.Button hashBtn;
        private System.Windows.Forms.Label countLabel;
        private System.Windows.Forms.Label progressLabel;
        private System.Windows.Forms.Label elapsedLabel;
        private System.Windows.Forms.Label totSizeLabel;
        private System.Windows.Forms.Label processedLabel;
        private System.Windows.Forms.Label speedLabel;
        private System.Windows.Forms.Button pauseButton;
        private System.Windows.Forms.Button previewButton;
        private System.Windows.Forms.RadioButton endRadioButton;
        private System.Windows.Forms.RadioButton startRadioButton;
        private System.Windows.Forms.Label remainingLabel;
        private System.Windows.Forms.ContextMenuStrip itemContextMenu;
        private System.Windows.Forms.ToolStripMenuItem skipMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addMenuItem;
        private System.Windows.Forms.ColumnHeader statusColumnHeader;
        private System.Windows.Forms.Button skipButton;
    }
}

