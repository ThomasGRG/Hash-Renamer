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
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
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
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.listView1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listView1.ForeColor = System.Drawing.SystemColors.Info;
            this.listView1.Location = new System.Drawing.Point(12, 12);
            this.listView1.MultiSelect = false;
            this.listView1.Name = "listView1";
            this.listView1.ShowItemToolTips = true;
            this.listView1.Size = new System.Drawing.Size(991, 298);
            this.listView1.TabIndex = 2;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "#";
            this.columnHeader1.Width = 40;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "File name";
            this.columnHeader2.Width = 406;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Hash";
            this.columnHeader3.Width = 160;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "New Name";
            this.columnHeader4.Width = 384;
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
            this.totprogressBar.Size = new System.Drawing.Size(944, 23);
            this.totprogressBar.TabIndex = 9;
            // 
            // fileprogressBar
            // 
            this.fileprogressBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fileprogressBar.Location = new System.Drawing.Point(59, 347);
            this.fileprogressBar.Name = "fileprogressBar";
            this.fileprogressBar.Size = new System.Drawing.Size(944, 23);
            this.fileprogressBar.TabIndex = 7;
            // 
            // cancelBtn
            // 
            this.cancelBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelBtn.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cancelBtn.Location = new System.Drawing.Point(352, 414);
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
            this.renameBtn.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.renameBtn.Location = new System.Drawing.Point(692, 414);
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
            this.selectfilesBtn.Location = new System.Drawing.Point(522, 414);
            this.selectfilesBtn.Name = "selectfilesBtn";
            this.selectfilesBtn.Size = new System.Drawing.Size(140, 35);
            this.selectfilesBtn.TabIndex = 10;
            this.selectfilesBtn.Text = "Select Files";
            this.selectfilesBtn.UseVisualStyleBackColor = true;
            this.selectfilesBtn.Click += new System.EventHandler(this.selectfilesBtn_Click);
            // 
            // hashBtn
            // 
            this.hashBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.hashBtn.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.hashBtn.Location = new System.Drawing.Point(862, 414);
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
            this.totSizeLabel.Location = new System.Drawing.Point(193, 323);
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
            this.processedLabel.Location = new System.Drawing.Point(310, 323);
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
            this.speedLabel.Location = new System.Drawing.Point(438, 323);
            this.speedLabel.Name = "speedLabel";
            this.speedLabel.Size = new System.Drawing.Size(53, 13);
            this.speedLabel.TabIndex = 19;
            this.speedLabel.Text = "Speed : 0";
            // 
            // pauseButton
            // 
            this.pauseButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pauseButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.pauseButton.Location = new System.Drawing.Point(182, 414);
            this.pauseButton.Name = "pauseButton";
            this.pauseButton.Size = new System.Drawing.Size(140, 35);
            this.pauseButton.TabIndex = 20;
            this.pauseButton.Text = "Pause";
            this.pauseButton.UseVisualStyleBackColor = true;
            // 
            // previewButton
            // 
            this.previewButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.previewButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.previewButton.Location = new System.Drawing.Point(12, 414);
            this.previewButton.Name = "previewButton";
            this.previewButton.Size = new System.Drawing.Size(140, 35);
            this.previewButton.TabIndex = 21;
            this.previewButton.Text = "Preview";
            this.previewButton.UseVisualStyleBackColor = true;
            this.previewButton.Click += new System.EventHandler(this.previewButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.ClientSize = new System.Drawing.Size(1015, 461);
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
            this.MinimumSize = new System.Drawing.Size(1030, 500);
            this.Name = "Form1";
            this.Text = "Hash Renamer";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
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
    }
}

