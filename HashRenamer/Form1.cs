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

        //boolean to check cancelled, skip, first run of preview
        bool cancel = false, skip = false, fRun = true;
        
        //fileCount, listCount, previewedCount, renamedCount, progressCounter
        int fCount = 0, lCount = 0, pCount = 0, rCount = 0, p = 0;
        long tmp1, tmp2, size, totalBytesRead = 0;
        
        //cSel to store previously run preview option, state for pause/resume
        string cSel, state = "unknown";

        public Form1()
        {
            InitializeComponent();
            timer.Tick += new EventHandler(timer_Tick);
            timer.Interval = 1000;
        }
        
        private void selectfilesBtn_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                addFiles(openFileDialog1.FileNames);
            }
            hashBtn.Enabled = true;
        }

        private void hashBtn_Click(object sender, EventArgs e)
        {
            hashBtn.Enabled = false;
            selectfilesBtn.Enabled = false;
            renameBtn.Enabled = false;
            previewButton.Enabled = false;
            pauseButton.Enabled = true;
            skipButton.Enabled = true;
            cancelBtn.Enabled = true;
            totprogressBar.Maximum = files.Count;
            fileprogressBar.Maximum = 100;
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
            long tmp = tmp1 - tmp2;
            tmp2 += tmp;
            TimeSpan t = TimeSpan.FromSeconds((size - totalBytesRead)/tmp);
            remainingLabel.Text = $"Remaining Time : {t.Hours:00}:{t.Minutes:00}:{t.Seconds:00}";
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
                // Remove first item since it is exe path
                paras.RemoveAt(0);
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
                }
            }
        }

        private void itemContextMenu_Opening(object sender, CancelEventArgs e)
        {
            if (listView1.SelectedIndices.Count > 0)
            {
                itemContextMenu.Items[1].Visible = true;
            }
            else
            {
                itemContextMenu.Items[1].Visible = false;
            }
        }

        private void addMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                addFiles(openFileDialog1.FileNames);
            }
            hashBtn.Enabled = true;
        }

        private void skipMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < listView1.SelectedIndices.Count; i++)
            {
                files[listView1.SelectedIndices[i]].skip = true;
                listView1.Items[listView1.SelectedIndices[i]].SubItems[1].Text = "Skipped";
            }
        }

        private void skipButton_Click(object sender, EventArgs e)
        {
            skip = true;
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
            string[] s = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            addFiles(s);
            hashBtn.Enabled = true;
        }

        private void backgroundWorker1_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;

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
                cnt = size / Convert.ToInt64(bufferSize);
                if (cnt <= 100)
                {
                    cnt = (100 / (cnt + 1));
                    flag = false;
                }
                else
                {
                    cnt = (cnt / 100) + 1;
                }

                stream.Position = totalBytesRead;
                readAheadBuffer = new byte[bufferSize];
                readAheadBytesRead = stream.Read(readAheadBuffer, 0, readAheadBuffer.Length);
                totalBytesRead += readAheadBytesRead;
                tmp1 = tmp2 = totalBytesRead;

                if (state == "unknown")
                {
                    crc32 = new Crc32Algorithm();
                    worker.ReportProgress(0, size);
                }

                do
                {
                    bytesRead = readAheadBytesRead;
                    buffer = readAheadBuffer;

                    readAheadBuffer = new byte[bufferSize];
                    readAheadBytesRead = stream.Read(readAheadBuffer, 0, readAheadBuffer.Length);

                    totalBytesRead += readAheadBytesRead;
                    tmp1 = totalBytesRead;

                    if (readAheadBytesRead == 0)
                        crc32.TransformFinalBlock(buffer, 0, bytesRead);
                    else
                        crc32.TransformBlock(buffer, 0, bytesRead, buffer, 0);
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
                } while (readAheadBytesRead != 0 && !cancel && state != "paused" && skip == false);

                if (cancel == false && state!= "paused" && skip == false)
                {
                    hash = crc32.Hash;
                    foreach (byte b in hash)
                        cHex += b.ToString("x2");
                    files[fCount].hash = cHex.ToUpper();
                    fCount += 1;
                    worker.ReportProgress(100, size);
                    totalBytesRead = 0;
                    p = 0;
                    state = "unknown";
                }

                if (skip)
                {
                    files[fCount].skip = true;
                    fCount += 1;
                    worker.ReportProgress(-1);
                }

                if (state != "paused")
                {
                    crc32.Dispose();
                }
                stream.Dispose();
            }
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            if (state == "paused")
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
                crc32.Dispose();
                fCount = lCount = p = 0;
                state = "unknown";
                tmp1 = tmp2 = size = totalBytesRead = 0;
                cancel = true;
                stopWatch.Reset();
                timer.Stop();
                hashBtn.Enabled = true;
                selectfilesBtn.Enabled = true;
                renameBtn.Enabled = true;
                previewButton.Enabled = true;
                pauseButton.Enabled = false;
                skipButton.Enabled = false;
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
            }
            else if (state == "unknown")
            {
                timer.Stop();
                stopWatch.Stop();
                state = "paused";
                pauseButton.Text = "Resume";
            }
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            int c = e.ProgressPercentage;
            if (c == 100)
            {
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
                listView1.Items[lCount].SubItems[1].Text = "Skipped";
                fileprogressBar.Value = 100;
                progressLabel.Text = "100%";
                totprogressBar.Value += 1;
                countLabel.Text = $"{(lCount + 1)}/{files.Count}";
                lCount += 1;
            }
            else if (c == 0)
            {
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
            if (!cancel)
            {
                if ((endRadioButton.Checked == true && cSel == "Start") || (startRadioButton.Checked == true && cSel == "End"))
                {
                    pCount = 0;
                    rCount = 0;
                }
                if (fRun == true)
                {
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
            }
        }

        private void renameBtn_Click(object sender, EventArgs e)
        {
            if (!cancel)
            {
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
                    files[i].currentFilePath = files[i].newFilePath;
                    files[i].newFilePath = "";
                    rCount += 1;
                }
            }
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (state == "resumed" || state == "unknown")
            {
                stopWatch.Stop();
                timer.Stop();
                hashBtn.Enabled = true;
                selectfilesBtn.Enabled = true;
                renameBtn.Enabled = true;
                previewButton.Enabled = true;
                pauseButton.Enabled = false;
                skipButton.Enabled = false;
                if (cancel)
                {
                    for (int i = lCount; i < files.Count; i++)
                    {
                        listView1.Items[i].SubItems[1].Text = "Cancelled";
                    }
                    cancel = false;
                    fCount = lCount = p = 0;
                    state = "unknown";
                    tmp1 = tmp2 = size = totalBytesRead = 0;
                    elapsedLabel.Text = "Elapsed Time : 00:00:00";
                    remainingLabel.Text = "Remaining Time : 00:00:00";
                    speedLabel.Text = "Speed : 0";
                    processedLabel.Text = "Processed : 0";
                    totSizeLabel.Text = "File Size : 0";
                    stopWatch.Reset();
                    fileprogressBar.Value = 100;
                    totprogressBar.Value = totprogressBar.Maximum;
                    progressLabel.Text = "%";
                    countLabel.Text = "-/-";
                }
            }
            else if (state == "paused")
            {
                totalBytesRead -= 4096;
            }
        }

    }
}
