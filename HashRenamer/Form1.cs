using Force.Crc32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace HashRenamer
{
    public partial class Form1 : Form
    {
        Timer timer = new Timer();
        Stopwatch stopWatch = new Stopwatch();
        Crc32Algorithm crc32;
        List<itemClass> files = new List<itemClass>();

        // to hold selected indices in listview
        int[] selIndex;

        // to hold files to add
        string[] fileHolder;

        // boolean to check cancelled hashing, skip current file, removed currently hashing file, hashing has started, any pending operation, first time running preview
        bool cancel = false, skip = false, remove = false, hashing = false, pending = false, fRun = true;
        
        // fileCount, listCount, previewedCount, renamedCount, progressCounter
        int fCount = 0, lCount = 0, pCount = 0, rCount = 0, p = 0;
        long tmp1, tmp2, size, totalBytesRead = 0;
        
        // cSel to store previously run preview option, state for pause/resume, remove/add/skip operation
        string cSel, state = "unknown", operation = "";

        public Form1()
        {
            InitializeComponent();
            timer.Tick += new EventHandler(timer_Tick);
            timer.Interval = 1000;
            fileprogressBar.Maximum = 100;
        }
        
        private void selectfilesBtn_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                itemContextMenu.Items[0].Enabled = false;
                itemContextMenu.Items[1].Enabled = false;
                itemContextMenu.Items[2].Enabled = false;
                selectfilesBtn.Enabled = false;
                fileHolder = openFileDialog1.FileNames;
                if (hashing)
                {
                    pending = true;
                    operation = "addfiles";
                }
                else
                {
                    addFiles(fileHolder);
                    itemContextMenu.Items[0].Enabled = true;
                    itemContextMenu.Items[1].Enabled = true;
                    itemContextMenu.Items[2].Enabled = true;
                    selectfilesBtn.Enabled = true;
                    if (state == "unknown")
                    {
                        hashBtn.Enabled = true;
                        clearButton.Enabled = true;
                    }
                }
            }
        }

        private void hashBtn_Click(object sender, EventArgs e)
        {
            hashBtn.Enabled = false;
            renameBtn.Enabled = false;
            previewButton.Enabled = false;
            clearButton.Enabled = false;
            pauseButton.Enabled = true;
            skipButton.Enabled = true;
            cancelBtn.Enabled = true;
            stopWatch.Start();
            timer.Start();
            timer.Enabled = true;
            runWorker();
        }

        private void addFiles(string[] fList)
        {
            foreach (var item in fList)
            {
                string name = item.Substring(item.LastIndexOf("\\") + 1);
                itemClass obj = new itemClass(item, name);
                files.Add(obj);
            }
            previewButton.Enabled = false;
            renameBtn.Enabled = false;
            totprogressBar.Maximum = files.Count;
            countLabel.Text = $"{fCount}/{files.Count}";
            for (int i = listView1.Items.Count; i < files.Count; i++)
            {
                ListViewItem item = new ListViewItem(new string[] { $"00{(i + 1)}", "Queued", files[i].currentName, "", "" });
                listView1.Items.Add(item);
            }
            fRun = true;
        }

        private void runWorker()
        {
            backgroundWorker1.RunWorkerAsync();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            elapsedLabel.Text = $"Elapsed Time : {stopWatch.Elapsed.Hours:00}:{stopWatch.Elapsed.Minutes:00}:{stopWatch.Elapsed.Seconds:00}";
            // Get bytes read in previous second
            long tmp = tmp1 - tmp2;
            // Set tmp2 to tmp1 for next calculation
            tmp2 += tmp;
            // Calculate remaining time - remaining bytes/bytes read in 1 second
            if (tmp != 0)
            {
                TimeSpan t = TimeSpan.FromSeconds((size - totalBytesRead) / tmp);
                remainingLabel.Text = $"Remaining Time : {t.Hours:00}:{t.Minutes:00}:{t.Seconds:00}";
            }
            // Convert units - B,KB,MB,GB/s
            if (tmp  <= 1024)
            {
                speedLabel.Text = $"Speed : {tmp} Bytes/s";
            }
            else if (tmp  <= 1048576)
            {
                speedLabel.Text = $"Speed : {(tmp / 1024.00):F2} KB/s";
            }
            else if (tmp  <= 1073741824)
            {
                speedLabel.Text = $"Speed : {(tmp / 1048576.00):F2} MB/s";
            }
            else if (tmp  > 1073741824)
            {
                speedLabel.Text = $"Speed : {(tmp / 1073741824.00):F2} GB/s";
            }
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            string[] args = Environment.GetCommandLineArgs();
            if (args.Length > 1)
            {
                List<string> paras = new List<string>(args);
                // Remove first item since it is this exe path
                paras.RemoveAt(0);
                // Check if dropped items are files
                for (int i = paras.Count - 1; i >= 0; i--)
                {
                    if (!File.Exists(paras[i]))
                    {
                        paras.RemoveAt(i);
                    }
                }
                if (paras.Count > 0)
                {
                    args = paras.ToArray();
                    addFiles(args);
                    hashBtn.Enabled = true;
                    clearButton.Enabled = true;
                }
            }
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            clearButton.Enabled = false;
            reset();
            clearButton.Enabled = true;
        }

        private void reset()
        {
            listView1.Items.Clear();
            stopWatch.Reset();
            timer.Stop();
            // Buttons...
            clearButton.Enabled = false;
            hashBtn.Enabled = false;
            previewButton.Enabled = false;
            renameBtn.Enabled = false;
            selectfilesBtn.Enabled = true;
            itemContextMenu.Items[0].Enabled = true;
            itemContextMenu.Items[1].Enabled = true;
            itemContextMenu.Items[2].Enabled = true;
            // Labels...
            elapsedLabel.Text = "Elapsed Time : 00:00:00";
            remainingLabel.Text = "Remaining Time : 00:00:00";
            speedLabel.Text = "Speed : 0";
            processedLabel.Text = "Processed : 0";
            totSizeLabel.Text = "File Size : 0";
            progressLabel.Text = "0%";
            countLabel.Text = "0/0";
            // Variables...
            files.Clear();
            fCount = lCount = rCount = pCount = p = 0;
            state = "unknown";
            operation = "";
            tmp1 = tmp2 = size = totalBytesRead = 0;
            fRun = true;
            cancel = skip = remove = hashing = pending = false;
            // ProgressBars...
            fileprogressBar.Value = 0;
            totprogressBar.Value = 0;
        }

        private void itemContextMenu_Opening(object sender, CancelEventArgs e)
        {
            if (listView1.SelectedIndices.Count > 0)
            {
                itemContextMenu.Items[1].Visible = true;
                itemContextMenu.Items[2].Visible = true;
            }
            else
            {
                itemContextMenu.Items[1].Visible = false;
                itemContextMenu.Items[2].Visible = false;
            }
        }

        private void addMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                itemContextMenu.Items[0].Enabled = false;
                itemContextMenu.Items[1].Enabled = false;
                itemContextMenu.Items[2].Enabled = false;
                selectfilesBtn.Enabled = false;
                fileHolder = openFileDialog1.FileNames;
                if (hashing)
                {
                    pending = true;
                    operation = "addfiles";
                }
                else
                {
                    addFiles(fileHolder);
                    itemContextMenu.Items[0].Enabled = true;
                    itemContextMenu.Items[1].Enabled = true;
                    itemContextMenu.Items[2].Enabled = true;
                    selectfilesBtn.Enabled = true;
                    if (state == "unknown")
                    {
                        hashBtn.Enabled = true;
                        clearButton.Enabled = true;
                    }
                }
            }
        }

        private void skipMenuItem_Click(object sender, EventArgs e)
        {
            itemContextMenu.Items[0].Enabled = false;
            itemContextMenu.Items[1].Enabled = false;
            itemContextMenu.Items[2].Enabled = false;
            selectfilesBtn.Enabled = false;
            selIndex = new int[listView1.SelectedIndices.Count];
            listView1.SelectedIndices.CopyTo(selIndex, 0);
            if (hashing)
            {
                pending = true;
                operation = "skip";
            }
            else
            {
                for (int i = 0; i < selIndex.Length; i++)
                {
                    files[selIndex[i]].skip = true;
                    listView1.Items[selIndex[i]].SubItems[1].Text = "Skipped";
                }
                itemContextMenu.Items[0].Enabled = true;
                itemContextMenu.Items[1].Enabled = true;
                itemContextMenu.Items[2].Enabled = true;
                selectfilesBtn.Enabled = true;
            }
        }

        private void removeMenuItem_Click(object sender, EventArgs e)
        {
            itemContextMenu.Items[0].Enabled = false;
            itemContextMenu.Items[1].Enabled = false;
            itemContextMenu.Items[2].Enabled = false;
            selectfilesBtn.Enabled = false;
            selIndex = new int[listView1.SelectedIndices.Count];
            listView1.SelectedIndices.CopyTo(selIndex, 0);
            if (hashing)
            {
                pending = true;
                operation = "remove";
            }
            else
            {
                for (int i = 0; i < selIndex.Length; i++)
                {
                    if (selIndex[i] < fCount)
                    {
                        // removing already hashed file
                        fCount -= 1;
                        lCount -= 1;
                    }
                    else if (fCount == selIndex[i])
                    {
                        // if currently hashing file is to be removed
                        remove = true;
                    }
                    files.RemoveAt(selIndex[i]);
                    listView1.Items.RemoveAt(selIndex[i]);
                }
                if (files.Count == 0)
                {
                    reset();
                }
                else
                {
                    countLabel.Text = $"{fCount}/{files.Count}";
                    totprogressBar.Maximum = files.Count;
                    totprogressBar.Value = fCount;
                }
                itemContextMenu.Items[0].Enabled = true;
                itemContextMenu.Items[1].Enabled = true;
                itemContextMenu.Items[2].Enabled = true;
                selectfilesBtn.Enabled = true;
            }
        }

        private void skipButton_Click(object sender, EventArgs e)
        {
            skip = true;
            if (state == "paused")
            {
                MessageBox.Show("File will be skipped on resume", "File skipped!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void Form1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.All;
            else
                e.Effect = DragDropEffects.None;
        }

        private void Form1_DragDrop(object sender, DragEventArgs e)
        {
            itemContextMenu.Items[0].Enabled = false;
            itemContextMenu.Items[1].Enabled = false;
            itemContextMenu.Items[2].Enabled = false;
            selectfilesBtn.Enabled = false;
            fileHolder = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            if (hashing)
            {
                pending = true;
                operation = "addfiles";
            }
            else
            {
                addFiles(fileHolder);
                itemContextMenu.Items[0].Enabled = true;
                itemContextMenu.Items[1].Enabled = true;
                itemContextMenu.Items[2].Enabled = true;
                selectfilesBtn.Enabled = true;
                if (state == "unknown")
                {
                    hashBtn.Enabled = true;
                    clearButton.Enabled = true;
                }
            }
        }

        private void backgroundWorker1_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;

            hashing = true;
            for (int i = fCount; i < files.Count; i++)
            {
                if (state == "paused")
                {
                    break;
                }
                if (worker.CancellationPending == true || cancel == true)
                {
                    e.Cancel = true;
                    break;
                }
                else if(files[i].skip == true)
                {
                    fCount += 1;
                    worker.ReportProgress(-1);
                    continue;
                }

                FileStream stream = File.OpenRead(files[i].currentFilePath);
                
                byte[] hash = null;
                string cHex = "";
                bool flag = true;
                int bufferSize = 4096;

                byte[] readAheadBuffer, buffer;
                int readAheadBytesRead, bytesRead;
                long cnt = 0;

                size = stream.Length;
                // find number of times loop runs till end of stream
                cnt = size / Convert.ToInt64(bufferSize);
                // find interval in which to update progressbar
                if (cnt <= 100)
                {
                    // example - cnt = 49, after below calc cnt = 2, so update progress bar by 2 every time loop runs
                    cnt = (100 / (cnt + 1));
                    // to show cnt < 100 or not
                    flag = false;
                }
                else
                {
                    // example - cnt = 200, after below calc cnt = 3, update progress bar by 1 every time loop runs cnt times (3 in this case)
                    cnt = (cnt / 100) + 1;
                }

                // set stream position to totalBytesRead which holds paused position or default 0 (start of stream)
                stream.Position = totalBytesRead;
                readAheadBuffer = new byte[bufferSize];
                // read next 4096 bytes (returns number of bytes read)
                readAheadBytesRead = stream.Read(readAheadBuffer, 0, readAheadBuffer.Length);
                // update totalBytesRead counter by number of bytes read
                totalBytesRead += readAheadBytesRead;
                // used for speed calc
                tmp1 = tmp2 = totalBytesRead;

                // if starting for the first time (not resuming)
                if (state == "unknown")
                {
                    crc32 = new Crc32Algorithm();
                    worker.ReportProgress(0, size);
                }

                do
                {
                    if (skip || remove || cancel || state == "paused")
                    {
                        break;
                    }
                    // if there are any pending operations
                    if (pending)
                    {
                        pending = false;
                        if (operation == "skip")
                        {
                            for (int j = 0; j < selIndex.Length; j++)
                            {
                                if (selIndex[j] < fCount)
                                {
                                    // already hashed file
                                    continue;
                                }
                                else if (fCount == selIndex[j])
                                {
                                    // if currently hashing file is to be skipped
                                    skip = true;
                                }
                                files[selIndex[j]].skip = true;
                            }
                            worker.ReportProgress(-2);
                            if (skip)
                            {
                                break;
                            }
                        }
                        else if(operation == "remove")
                        {
                            int tmp = fCount;
                            for (int j = 0; j < selIndex.Length; j++)
                            {
                                if (selIndex[j] < tmp)
                                {
                                    // removing already hashed file
                                    fCount -= 1;
                                    i -= 1;
                                }
                                else if (tmp == selIndex[j])
                                {
                                    // if currently hashing file is to be removed
                                    i -= 1;
                                    remove = true;
                                }
                                files.RemoveAt(selIndex[j]);
                            }
                            worker.ReportProgress(-2);
                            if (remove)
                            {
                                break;
                            }
                        }
                        else if (operation == "addfiles")
                        {
                            foreach (var item in fileHolder)
                            {
                                string name = item.Substring(item.LastIndexOf("\\") + 1);
                                itemClass obj = new itemClass(item, name);
                                files.Add(obj);
                            }
                            worker.ReportProgress(-2);
                        }
                    }
                    bytesRead = readAheadBytesRead;
                    buffer = readAheadBuffer;

                    // read next 4096 bytes while current 4096 bytes are being processed
                    readAheadBuffer = new byte[bufferSize];
                    readAheadBytesRead = stream.Read(readAheadBuffer, 0, readAheadBuffer.Length);

                    totalBytesRead += readAheadBytesRead;
                    tmp1 = totalBytesRead;

                    // if end of stream reached
                    if (readAheadBytesRead == 0)
                        crc32.TransformFinalBlock(buffer, 0, bytesRead);
                    else
                        crc32.TransformBlock(buffer, 0, bytesRead, buffer, 0);
                    // if cnt > 100
                    if (flag)
                    {
                        p += 1;
                        if (p == cnt)
                        {
                            p = 0;
                            worker.ReportProgress(1, totalBytesRead);
                        }
                    }
                    else
                    {
                        worker.ReportProgress(Convert.ToInt32(cnt), totalBytesRead);
                    }
                } while (readAheadBytesRead != 0);

                if (cancel == false && state!= "paused" && skip == false && remove == false)
                {
                    // convert hash to readable form and store it
                    hash = crc32.Hash;
                    foreach (byte b in hash)
                        cHex += b.ToString("x2");
                    files[fCount].hash = cHex.ToUpper();
                    fCount += 1;
                    worker.ReportProgress(100, size);
                    totalBytesRead = 0;
                    p = 0;
                    // so that it creates new crc32
                    state = "unknown";
                }

                if (remove)
                {
                    remove = false;
                    totalBytesRead = 0;
                    p = 0;
                    state = "unknown";
                }

                if (skip)
                {
                    skip = false;
                    files[fCount].skip = true;
                    fCount += 1;
                    totalBytesRead = 0;
                    p = 0;
                    state = "unknown";
                    worker.ReportProgress(-1);
                }

                if (state != "paused")
                {
                    crc32.Dispose();
                }
                stream.Dispose();
            }
            hashing = false;
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            if (state == "paused")
            {
                // if cancelling while paused reset everything
                for (int i = lCount; i < files.Count; i++)
                {
                    listView1.Items[i].SubItems[1].Text = "Cancelled";
                }
                elapsedLabel.Text = "Elapsed Time : 00:00:00";
                remainingLabel.Text = "Remaining Time : 00:00:00";
                speedLabel.Text = "Speed : 0";
                processedLabel.Text = "Processed : 0";
                totSizeLabel.Text = "File Size : 0";
                crc32.Dispose();
                fCount = lCount = p = 0;
                state = "unknown";
                tmp1 = tmp2 = size = totalBytesRead = 0;
                cancel = true;
                stopWatch.Reset();
                timer.Stop();
                clearButton.Enabled = true;
                cancelBtn.Enabled = false;
                hashBtn.Enabled = false;
                selectfilesBtn.Enabled = false;
                renameBtn.Enabled = false;
                previewButton.Enabled = false;
                pauseButton.Enabled = false;
                skipButton.Enabled = false;
                itemContextMenu.Items[0].Enabled = false;
                itemContextMenu.Items[1].Enabled = false;
                itemContextMenu.Items[2].Enabled = false;
                fileprogressBar.Value = 100;
                totprogressBar.Value = totprogressBar.Maximum;
                progressLabel.Text = "%";
                countLabel.Text = "-/-";
            }
            else
            {
                cancel = true;
                backgroundWorker1.CancelAsync();
            }
        }

        private void pauseButton_Click(object sender, EventArgs e)
        {
            if (state == "paused")
            {
                timer.Start();
                stopWatch.Start();
                state = "resumed";
                pauseButton.Text = "Pause";
                runWorker();
            }
            else if (state == "resumed")
            {
                timer.Stop();
                stopWatch.Stop();
                state = "paused";
                pauseButton.Text = "Resume";
                pauseButton.Enabled = false;
            }
            else if (state == "unknown")
            {
                timer.Stop();
                stopWatch.Stop();
                state = "paused";
                pauseButton.Text = "Resume";
                pauseButton.Enabled = false;
            }
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            int c = e.ProgressPercentage;
            if (c == 100)
            {
                // hashing current file completed
                double processed = (long)e.UserState;
                if (processed <= 1024)
                {
                    processedLabel.Text = $"Processed : {processed} Bytes";
                }
                else if (processed <= 1048576)
                {
                    processedLabel.Text = $"Processed : {(processed / 1024.00):F2} KB";
                }
                else if (processed <= 1073741824)
                {
                    processedLabel.Text = $"Processed : {(processed / 1048576.00):F2} MB";
                }
                else if (processed > 1073741824)
                {
                    processedLabel.Text = $"Processed : {(processed / 1073741824.00):F2} GB";
                }
                fileprogressBar.Value = c;
                progressLabel.Text = $"{c}%";
                totprogressBar.Value += 1;
                countLabel.Text = $"{(lCount + 1)}/{files.Count}";
                listView1.Items[lCount].SubItems[3].Text = (files[lCount].hash);
                listView1.Items[lCount].SubItems[1].Text = "Completed";
                lCount += 1;
            }
            else if (c == -1)
            {
                // skip currently hashing file
                fileprogressBar.Value = 100;
                progressLabel.Text = "100%";
                totprogressBar.Value += 1;
                countLabel.Text = $"{(lCount + 1)}/{files.Count}";
                lCount += 1;
            }
            else if (c == -2)
            {
                // complete pending operation
                if (operation == "skip")
                {
                    for (int i = 0; i < selIndex.Length; i++)
                    {
                        listView1.Items[selIndex[i]].SubItems[1].Text = "Skipped";
                    }
                }
                else if(operation == "remove")
                {
                    if (files.Count == 0)
                    {
                        reset();
                    }
                    else
                    {
                        countLabel.Text = $"{fCount}/{files.Count}";
                        totprogressBar.Maximum = files.Count;
                        totprogressBar.Value = fCount;
                    }
                    int tmp = lCount;
                    for (int i = 0; i < selIndex.Length; i++)
                    {
                        if (selIndex[i] < tmp)
                        {
                            lCount -= 1;
                        }
                        listView1.Items.RemoveAt(selIndex[i]);
                    }
                }
                else if (operation == "addfiles")
                {
                    totprogressBar.Maximum = files.Count;
                    countLabel.Text = $"{fCount}/{files.Count}";
                    for (int i = listView1.Items.Count; i < files.Count; i++)
                    {
                        ListViewItem item = new ListViewItem(new string[] { $"00{(i + 1)}", "Queued", files[i].currentName, "", "" });
                        listView1.Items.Add(item);
                    }
                    fRun = true;
                }
                operation = "";
                itemContextMenu.Items[0].Enabled = true;
                itemContextMenu.Items[1].Enabled = true;
                itemContextMenu.Items[2].Enabled = true;
                selectfilesBtn.Enabled = true;
            }
            else if (c == 0)
            {
                // start hashing new file
                fileprogressBar.Value = 0;
                double totSize = (long)e.UserState;
                if (totSize <= 1024)
                {
                    totSizeLabel.Text = $"File Size : {totSize} Bytes";
                }
                else if (totSize <= 1048576)
                {
                    totSizeLabel.Text = $"File Size : {(totSize / 1024.00):F2} KB";
                }
                else if (totSize <= 1073741824)
                {
                    totSizeLabel.Text = $"File Size : {(totSize / 1048576.00):F2} MB";
                }
                else if (totSize > 1073741824)
                {
                    totSizeLabel.Text = $"File Size : {(totSize / 1073741824.00):F2} GB";
                }
            }
            else
            {
                // update hashing progress
                double processed = (long)e.UserState;
                if (processed <= 1024)
                {
                    processedLabel.Text = $"Processed : {processed} Bytes";
                }
                else if (processed <= 1048576)
                {
                    processedLabel.Text = $"Processed : {(processed / 1024.00):F2} KB";
                }
                else if (processed <= 1073741824)
                {
                    processedLabel.Text = $"Processed : {(processed / 1048576.00):F2} MB";
                }
                else if (processed > 1073741824)
                {
                    processedLabel.Text = $"Processed : {(processed / 1073741824.00):F2} GB";
                }
                fileprogressBar.Value += c;
                progressLabel.Text = fileprogressBar.Value.ToString() + "%";
            }
        }

        private void previewButton_Click(object sender, EventArgs e)
        {
            previewButton.Enabled = false;
            // check if previously run and currently selected mode are different
            if ((endRadioButton.Checked == true && cSel == "Start") || (startRadioButton.Checked == true && cSel == "End"))
            {
                // if so reset counters
                pCount = 0;
                rCount = 0;
            }
            if (fRun == true)
            {
                // if first time running preview
                if (endRadioButton.Checked == true)
                {
                    for (int i = pCount; i < files.Count; i++)
                    {
                        if (files[i].skip == true)
                        {
                            pCount += 1;
                            continue;
                        }
                        int a = files[i].currentFilePath.LastIndexOf("\\") + 1;
                        int b = files[i].currentFilePath.LastIndexOf(".");
                        files[i].newName = $"{files[i].currentFilePath.Substring(a, b - a)} [{files[i].hash}]{files[i].currentFilePath.Substring(files[i].currentFilePath.LastIndexOf("."))}";
                        files[i].newFilePath = $"{files[i].currentFilePath.Substring(0, files[i].currentFilePath.LastIndexOf("\\") + 1)}{files[i].newName}";
                        listView1.Items[i].SubItems[4].Text = files[i].newName;
                        pCount += 1;
                    }
                    fRun = false;
                    cSel = "End";
                }
                else if (startRadioButton.Checked == true)
                {
                    for (int i = pCount; i < files.Count; i++)
                    {
                        if (files[i].skip == true)
                        {
                            pCount += 1;
                            continue;
                        }
                        files[i].newName = $"[{files[i].hash}] {files[i].currentFilePath.Substring(files[i].currentFilePath.LastIndexOf("\\") + 1)}";
                        files[i].newFilePath = $"{files[i].currentFilePath.Substring(0, files[i].currentFilePath.LastIndexOf("\\") + 1)}{files[i].newName}";
                        listView1.Items[i].SubItems[4].Text = files[i].newName;
                        pCount += 1;
                    }
                    fRun = false;
                    cSel = "Start";
                }
            }
            else
            {
                if (endRadioButton.Checked == true && cSel != "End")
                {
                    for (int i = pCount; i < files.Count; i++)
                    {
                        if (files[i].skip == true)
                        {
                            pCount += 1;
                            continue;
                        }
                        int a = files[i].currentFilePath.LastIndexOf("\\") + 1;
                        int b = files[i].currentFilePath.LastIndexOf(".");
                        files[i].newName = $"{files[i].currentFilePath.Substring(a, b - a)} [{files[i].hash}]{files[i].currentFilePath.Substring(files[i].currentFilePath.LastIndexOf("."))}";
                        files[i].newFilePath = $"{files[i].currentFilePath.Substring(0, files[i].currentFilePath.LastIndexOf("\\") + 1)}{files[i].newName}";
                        listView1.Items[i].SubItems[4].Text = files[i].newName;
                        pCount += 1;
                    }
                    cSel = "End";
                }
                else if (startRadioButton.Checked == true && cSel != "Start")
                {
                    for (int i = pCount; i < files.Count; i++)
                    {
                        if (files[i].skip == true)
                        {
                            pCount += 1;
                            continue;
                        }
                        files[i].newName = $"[{files[i].hash}] {files[i].currentFilePath.Substring(files[i].currentFilePath.LastIndexOf("\\") + 1)}";
                        files[i].newFilePath = $"{files[i].currentFilePath.Substring(0, files[i].currentFilePath.LastIndexOf("\\") + 1)}{files[i].newName}";
                        listView1.Items[i].SubItems[4].Text = files[i].newName;
                        pCount += 1;
                    }
                    cSel = "Start";
                }
            }
            previewButton.Enabled = true;
        }

        private void renameBtn_Click(object sender, EventArgs e)
        {
            renameBtn.Enabled = false;
            for (int i = rCount; i < files.Count; i++)
            {
                if (files[i].skip == true)
                {
                    rCount += 1;
                    continue;
                }
                try
                {
                    File.Move(files[i].currentFilePath, files[i].newFilePath);
                    listView1.Items[i].ForeColor = System.Drawing.Color.LightGreen;
                }
                catch (Exception ex)
                {
                    listView1.Items[i].ForeColor = System.Drawing.Color.Red;
                    listView1.Items[i].ToolTipText = ex.Message;
                    rCount += 1;
                    continue;
                }
                // update currentFilePath with new path
                files[i].currentFilePath = files[i].newFilePath;
                files[i].newFilePath = "";
                rCount += 1;
            }
            renameBtn.Enabled = true;
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (state == "resumed" || state == "unknown")
            {
                if (cancel)
                {
                    for (int i = lCount; i < files.Count; i++)
                    {
                        listView1.Items[i].SubItems[1].Text = "Cancelled";
                    }
                    elapsedLabel.Text = "Elapsed Time : 00:00:00";
                    remainingLabel.Text = "Remaining Time : 00:00:00";
                    speedLabel.Text = "Speed : 0";
                    processedLabel.Text = "Processed : 0";
                    totSizeLabel.Text = "File Size : 0";
                    cancel = false;
                    fCount = lCount = p = 0;
                    state = "unknown";
                    tmp1 = tmp2 = size = totalBytesRead = 0;
                    timer.Stop();
                    stopWatch.Reset();
                    clearButton.Enabled = true;
                    cancelBtn.Enabled = false;
                    hashBtn.Enabled = false;
                    selectfilesBtn.Enabled = false;
                    renameBtn.Enabled = false;
                    previewButton.Enabled = false;
                    pauseButton.Enabled = false;
                    skipButton.Enabled = false;
                    itemContextMenu.Items[0].Enabled = false;
                    itemContextMenu.Items[1].Enabled = false;
                    itemContextMenu.Items[2].Enabled = false;
                    fileprogressBar.Value = 100;
                    totprogressBar.Value = totprogressBar.Maximum;
                    progressLabel.Text = "%";
                    countLabel.Text = "-/-";
                }
                else
                {
                    stopWatch.Stop();
                    timer.Stop();
                    clearButton.Enabled = true;
                    selectfilesBtn.Enabled = true;
                    pauseButton.Enabled = false;
                    skipButton.Enabled = false;
                    cancelBtn.Enabled = false;
                    if (files.Count != 0)
                    {
                        renameBtn.Enabled = true;
                        previewButton.Enabled = true;
                    }
                }
            }
            else if (state == "paused")
            {
                totalBytesRead -= 4096;
                pauseButton.Enabled = true;
            }
        }

    }
}
