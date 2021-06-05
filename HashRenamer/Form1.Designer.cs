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
            this.removeMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
            this.clearButton = new System.Windows.Forms.Button();
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
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(18, 78);
            this.listView1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.listView1.Name = "listView1";
            this.listView1.ShowItemToolTips = true;
            this.listView1.Size = new System.Drawing.Size(1658, 545);
            this.listView1.TabIndex = 2;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // nColumnHeader
            // 
            this.nColumnHeader.Text = "#";
            this.nColumnHeader.Width = 62;
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
            this.itemContextMenu.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.itemContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addMenuItem,
            this.skipMenuItem,
            this.removeMenuItem});
            this.itemContextMenu.Name = "itemContextMenu";
            this.itemContextMenu.Size = new System.Drawing.Size(223, 100);
            this.itemContextMenu.Opening += new System.ComponentModel.CancelEventHandler(this.itemContextMenu_Opening);
            // 
            // addMenuItem
            // 
            this.addMenuItem.Name = "addMenuItem";
            this.addMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.addMenuItem.Size = new System.Drawing.Size(222, 32);
            this.addMenuItem.Text = "Add Files";
            this.addMenuItem.Click += new System.EventHandler(this.addMenuItem_Click);
            // 
            // skipMenuItem
            // 
            this.skipMenuItem.Name = "skipMenuItem";
            this.skipMenuItem.Size = new System.Drawing.Size(222, 32);
            this.skipMenuItem.Text = "Skip";
            this.skipMenuItem.Visible = false;
            this.skipMenuItem.Click += new System.EventHandler(this.skipMenuItem_Click);
            // 
            // removeMenuItem
            // 
            this.removeMenuItem.Name = "removeMenuItem";
            this.removeMenuItem.Size = new System.Drawing.Size(222, 32);
            this.removeMenuItem.Text = "Remove";
            this.removeMenuItem.Visible = false;
            this.removeMenuItem.Click += new System.EventHandler(this.removeMenuItem_Click);
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
            this.totprogressBar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.totprogressBar.BackColor = System.Drawing.SystemColors.Control;
            this.totprogressBar.Location = new System.Drawing.Point(1450, 680);
            this.totprogressBar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.totprogressBar.Name = "totprogressBar";
            this.totprogressBar.Size = new System.Drawing.Size(226, 20);
            this.totprogressBar.TabIndex = 7;
            // 
            // fileprogressBar
            // 
            this.fileprogressBar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.fileprogressBar.Location = new System.Drawing.Point(1135, 680);
            this.fileprogressBar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.fileprogressBar.Name = "fileprogressBar";
            this.fileprogressBar.Size = new System.Drawing.Size(226, 20);
            this.fileprogressBar.TabIndex = 6;
            // 
            // cancelBtn
            // 
            this.cancelBtn.BackColor = System.Drawing.Color.Transparent;
            this.cancelBtn.Enabled = false;
            this.cancelBtn.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.cancelBtn.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ControlDark;
            this.cancelBtn.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.cancelBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cancelBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.cancelBtn.Location = new System.Drawing.Point(854, 14);
            this.cancelBtn.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(188, 54);
            this.cancelBtn.TabIndex = 12;
            this.cancelBtn.Text = "Cancel";
            this.cancelBtn.UseVisualStyleBackColor = false;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // renameBtn
            // 
            this.renameBtn.BackColor = System.Drawing.Color.Transparent;
            this.renameBtn.Enabled = false;
            this.renameBtn.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.renameBtn.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ControlDark;
            this.renameBtn.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.renameBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.renameBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.renameBtn.Location = new System.Drawing.Point(1481, 14);
            this.renameBtn.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.renameBtn.Name = "renameBtn";
            this.renameBtn.Size = new System.Drawing.Size(188, 54);
            this.renameBtn.TabIndex = 14;
            this.renameBtn.Text = "Rename";
            this.renameBtn.UseVisualStyleBackColor = false;
            this.renameBtn.Click += new System.EventHandler(this.renameBtn_Click);
            // 
            // selectfilesBtn
            // 
            this.selectfilesBtn.BackColor = System.Drawing.Color.Transparent;
            this.selectfilesBtn.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.selectfilesBtn.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ControlDark;
            this.selectfilesBtn.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.selectfilesBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.selectfilesBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.selectfilesBtn.Location = new System.Drawing.Point(18, 14);
            this.selectfilesBtn.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.selectfilesBtn.Name = "selectfilesBtn";
            this.selectfilesBtn.Size = new System.Drawing.Size(188, 54);
            this.selectfilesBtn.TabIndex = 9;
            this.selectfilesBtn.Text = "Add Files";
            this.selectfilesBtn.UseVisualStyleBackColor = false;
            this.selectfilesBtn.Click += new System.EventHandler(this.selectfilesBtn_Click);
            // 
            // hashBtn
            // 
            this.hashBtn.BackColor = System.Drawing.Color.Transparent;
            this.hashBtn.Enabled = false;
            this.hashBtn.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.hashBtn.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ControlDark;
            this.hashBtn.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.hashBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.hashBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.hashBtn.Location = new System.Drawing.Point(227, 14);
            this.hashBtn.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.hashBtn.Name = "hashBtn";
            this.hashBtn.Size = new System.Drawing.Size(188, 54);
            this.hashBtn.TabIndex = 8;
            this.hashBtn.Text = "Hash";
            this.hashBtn.UseVisualStyleBackColor = false;
            this.hashBtn.Click += new System.EventHandler(this.hashBtn_Click);
            // 
            // countLabel
            // 
            this.countLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.countLabel.AutoSize = true;
            this.countLabel.ForeColor = System.Drawing.SystemColors.Info;
            this.countLabel.Location = new System.Drawing.Point(1385, 680);
            this.countLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.countLabel.Name = "countLabel";
            this.countLabel.Size = new System.Drawing.Size(31, 20);
            this.countLabel.TabIndex = 21;
            this.countLabel.Text = "0/0";
            // 
            // progressLabel
            // 
            this.progressLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.progressLabel.AutoSize = true;
            this.progressLabel.ForeColor = System.Drawing.SystemColors.Info;
            this.progressLabel.Location = new System.Drawing.Point(1071, 680);
            this.progressLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.progressLabel.Name = "progressLabel";
            this.progressLabel.Size = new System.Drawing.Size(32, 20);
            this.progressLabel.TabIndex = 22;
            this.progressLabel.Text = "0%";
            // 
            // elapsedLabel
            // 
            this.elapsedLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.elapsedLabel.AutoSize = true;
            this.elapsedLabel.ForeColor = System.Drawing.SystemColors.Info;
            this.elapsedLabel.Location = new System.Drawing.Point(585, 680);
            this.elapsedLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.elapsedLabel.Name = "elapsedLabel";
            this.elapsedLabel.Size = new System.Drawing.Size(179, 20);
            this.elapsedLabel.TabIndex = 16;
            this.elapsedLabel.Text = "Elapsed Time : 00:00:00";
            // 
            // totSizeLabel
            // 
            this.totSizeLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.totSizeLabel.AutoSize = true;
            this.totSizeLabel.ForeColor = System.Drawing.SystemColors.Info;
            this.totSizeLabel.Location = new System.Drawing.Point(2, 680);
            this.totSizeLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.totSizeLabel.Name = "totSizeLabel";
            this.totSizeLabel.Size = new System.Drawing.Size(90, 20);
            this.totSizeLabel.TabIndex = 17;
            this.totSizeLabel.Text = "File Size : 0";
            // 
            // processedLabel
            // 
            this.processedLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.processedLabel.AutoSize = true;
            this.processedLabel.ForeColor = System.Drawing.SystemColors.Info;
            this.processedLabel.Location = new System.Drawing.Point(190, 680);
            this.processedLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.processedLabel.Name = "processedLabel";
            this.processedLabel.Size = new System.Drawing.Size(105, 20);
            this.processedLabel.TabIndex = 18;
            this.processedLabel.Text = "Processed : 0";
            // 
            // speedLabel
            // 
            this.speedLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.speedLabel.AutoSize = true;
            this.speedLabel.ForeColor = System.Drawing.SystemColors.Info;
            this.speedLabel.Location = new System.Drawing.Point(399, 680);
            this.speedLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.speedLabel.Name = "speedLabel";
            this.speedLabel.Size = new System.Drawing.Size(77, 20);
            this.speedLabel.TabIndex = 19;
            this.speedLabel.Text = "Speed : 0";
            // 
            // pauseButton
            // 
            this.pauseButton.BackColor = System.Drawing.Color.Transparent;
            this.pauseButton.Enabled = false;
            this.pauseButton.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.pauseButton.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ControlDark;
            this.pauseButton.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.pauseButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.pauseButton.ForeColor = System.Drawing.SystemColors.Control;
            this.pauseButton.Location = new System.Drawing.Point(436, 14);
            this.pauseButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pauseButton.Name = "pauseButton";
            this.pauseButton.Size = new System.Drawing.Size(188, 54);
            this.pauseButton.TabIndex = 10;
            this.pauseButton.Text = "Pause";
            this.pauseButton.UseVisualStyleBackColor = false;
            this.pauseButton.Click += new System.EventHandler(this.pauseButton_Click);
            // 
            // previewButton
            // 
            this.previewButton.BackColor = System.Drawing.Color.Transparent;
            this.previewButton.Enabled = false;
            this.previewButton.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.previewButton.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ControlDark;
            this.previewButton.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.previewButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.previewButton.ForeColor = System.Drawing.SystemColors.Control;
            this.previewButton.Location = new System.Drawing.Point(1272, 14);
            this.previewButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.previewButton.Name = "previewButton";
            this.previewButton.Size = new System.Drawing.Size(188, 54);
            this.previewButton.TabIndex = 15;
            this.previewButton.Text = "Preview";
            this.previewButton.UseVisualStyleBackColor = false;
            this.previewButton.Click += new System.EventHandler(this.previewButton_Click);
            // 
            // endRadioButton
            // 
            this.endRadioButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.endRadioButton.AutoSize = true;
            this.endRadioButton.Checked = true;
            this.endRadioButton.ForeColor = System.Drawing.Color.White;
            this.endRadioButton.Location = new System.Drawing.Point(1606, 646);
            this.endRadioButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.endRadioButton.Name = "endRadioButton";
            this.endRadioButton.Size = new System.Drawing.Size(63, 24);
            this.endRadioButton.TabIndex = 24;
            this.endRadioButton.TabStop = true;
            this.endRadioButton.Text = "End";
            this.endRadioButton.UseVisualStyleBackColor = true;
            // 
            // startRadioButton
            // 
            this.startRadioButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.startRadioButton.AutoSize = true;
            this.startRadioButton.ForeColor = System.Drawing.Color.White;
            this.startRadioButton.Location = new System.Drawing.Point(1502, 646);
            this.startRadioButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.startRadioButton.Name = "startRadioButton";
            this.startRadioButton.Size = new System.Drawing.Size(69, 24);
            this.startRadioButton.TabIndex = 23;
            this.startRadioButton.Text = "Start";
            this.startRadioButton.UseVisualStyleBackColor = true;
            // 
            // remainingLabel
            // 
            this.remainingLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.remainingLabel.AutoSize = true;
            this.remainingLabel.ForeColor = System.Drawing.SystemColors.Info;
            this.remainingLabel.Location = new System.Drawing.Point(817, 680);
            this.remainingLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.remainingLabel.Name = "remainingLabel";
            this.remainingLabel.Size = new System.Drawing.Size(197, 20);
            this.remainingLabel.TabIndex = 20;
            this.remainingLabel.Text = "Remaining Time : 00:00:00";
            // 
            // skipButton
            // 
            this.skipButton.BackColor = System.Drawing.Color.Transparent;
            this.skipButton.Enabled = false;
            this.skipButton.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.skipButton.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ControlDark;
            this.skipButton.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.skipButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.skipButton.ForeColor = System.Drawing.SystemColors.Control;
            this.skipButton.Location = new System.Drawing.Point(645, 14);
            this.skipButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.skipButton.Name = "skipButton";
            this.skipButton.Size = new System.Drawing.Size(188, 54);
            this.skipButton.TabIndex = 11;
            this.skipButton.Text = "Skip";
            this.skipButton.UseVisualStyleBackColor = false;
            this.skipButton.Click += new System.EventHandler(this.skipButton_Click);
            // 
            // clearButton
            // 
            this.clearButton.BackColor = System.Drawing.Color.Transparent;
            this.clearButton.Enabled = false;
            this.clearButton.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.clearButton.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ControlDark;
            this.clearButton.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.clearButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.clearButton.ForeColor = System.Drawing.SystemColors.Control;
            this.clearButton.Location = new System.Drawing.Point(1063, 14);
            this.clearButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(188, 54);
            this.clearButton.TabIndex = 13;
            this.clearButton.Text = "Clear";
            this.clearButton.UseVisualStyleBackColor = false;
            this.clearButton.Click += new System.EventHandler(this.clearButton_Click);
            // 
            // Form1
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.ClientSize = new System.Drawing.Size(1694, 709);
            this.Controls.Add(this.clearButton);
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
            this.ForeColor = System.Drawing.SystemColors.Control;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MinimumSize = new System.Drawing.Size(1706, 739);
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
        private System.Windows.Forms.ToolStripMenuItem removeMenuItem;
        private System.Windows.Forms.Button clearButton;
    }
}

