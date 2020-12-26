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
        List<string> files = new List<string>();
        string[] newNames;
        bool cancel = false;
        string[] hex;
        int fCount = 0;
        long tmp1, tmp2;

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
                files.AddRange(openFileDialog1.FileNames);
                label2.Text = "0/" + files.Count.ToString();
                for (int i = listView1.Items.Count; i < files.Count; i++)
                {
                    ListViewItem item = new ListViewItem(new string[] { "00" + (i + 1).ToString(), files[i].Substring(files[i].LastIndexOf("\\")+1) });
                    listView1.Items.Add(item);
                }
            }
        }

        private void hashBtn_Click(object sender, EventArgs e)
        {
            hashBtn.Enabled = false;
            selectfilesBtn.Enabled = false;
            renameBtn.Enabled = false;
            hex = new string[files.Count];
            newNames = new string[files.Count];
            totprogressBar.Maximum = files.Count;
            fileprogressBar.Maximum = 100;
            stopWatch.Start();
            timer.Start();
            timer.Enabled = true;
            backgroundWorker1.RunWorkerAsync();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            elapsedLabel.Text = "Elapsed Time : " + String.Format("{0:00}:{1:00}:{2:00}", stopWatch.Elapsed.Hours, stopWatch.Elapsed.Minutes, stopWatch.Elapsed.Seconds);
            long tmp = tmp1 - tmp2;
            tmp2 += tmp;
            if (tmp  <= 1024)
            {
                speedLabel.Text = "Speed : " + tmp .ToString() + "Bytes/s";
            }
            else if (tmp  <= 1048576)
            {
                speedLabel.Text = "Speed : " + String.Format("{0:F2}", (tmp  / 1024.00)) + "KB/s";
            }
            else if (tmp  <= 1073741824)
            {
                speedLabel.Text = "Speed : " + String.Format("{0:F2}", (tmp  / 1048576.00)) + "MB/s";
            }
            else if (tmp  > 1073741824)
            {
                speedLabel.Text = "Speed : " + String.Format("{0:F2}", (tmp  / 1073741824.00)) + "GB/s";
            }
        }

        private void backgroundWorker1_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;

            for (int i = 0; i < files.Count; i++)
            {
                if (worker.CancellationPending == true)
                {
                    e.Cancel = true;
                    break;
                }
                var crc32 = new Crc32Algorithm();
                FileStream stream = File.OpenRead(files[i]);
                
                byte[] hash = null;
                string cHex = "";
                bool flag = true;
                int p = 0;
                int _bufferSize = 4096;

                byte[] readAheadBuffer, buffer;
                int readAheadBytesRead, bytesRead;
                long size, cnt = 0, totalBytesRead = 0;

                size = stream.Length;
                worker.ReportProgress(0, size);
                cnt = size / Convert.ToInt64(_bufferSize);
                if(cnt <= 100)
                {
                    cnt = (100 / (cnt + 1));
                    flag = false;
                }
                else
                {
                    cnt = (cnt / 100) + 1;
                }
                readAheadBuffer = new byte[_bufferSize];
                readAheadBytesRead = stream.Read(readAheadBuffer, 0, readAheadBuffer.Length);

                totalBytesRead += readAheadBytesRead;
                tmp1 = tmp2 = totalBytesRead;

                do
                {
                    bytesRead = readAheadBytesRead;
                    buffer = readAheadBuffer;

                    readAheadBuffer = new byte[_bufferSize];
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
                } while (readAheadBytesRead != 0 && !cancel);

                if (cancel)
                {
                    hash = null;
                }
                else
                {
                    hash = crc32.Hash;
                    foreach (byte b in hash)
                        cHex += b.ToString("x2");
                    hex[fCount] = cHex.ToUpper();
                    worker.ReportProgress(100, size);
                }
                
                crc32.Dispose();
                stream.Dispose();
            }
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            cancel = true;
            backgroundWorker1.CancelAsync();
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            int c = e.ProgressPercentage;
            if(c == 100)
            {
                double processed = (long)e.UserState;
                if (processed <= 1024)
                {
                    processedLabel.Text = "Processed : " + processed.ToString() + "Bytes";
                }
                else if (processed <= 1048576)
                {
                    processedLabel.Text = "Processed : " + String.Format("{0:F2}", (processed / 1024.00)) + "KB";
                }
                else if (processed <= 1073741824)
                {
                    processedLabel.Text = "Processed : " + String.Format("{0:F2}", (processed / 1048576.00)) + "MB";
                }
                else if (processed > 1073741824)
                {
                    processedLabel.Text = "Processed : " + String.Format("{0:F2}", (processed / 1073741824.00)) + "GB";
                }
                fileprogressBar.Value = c;
                label1.Text = c.ToString() + "%";
                totprogressBar.Value += 1;
                int a = files[fCount].LastIndexOf("\\") + 1;
                int b = files[fCount].LastIndexOf(".");
                string name = files[fCount].Substring(a, b - a) + " [" + hex[fCount] + "]" + files[fCount].Substring(files[fCount].LastIndexOf("."));
                newNames[fCount] = files[fCount].Substring(0, files[fCount].LastIndexOf("\\") + 1) + name;
                label2.Text = (fCount + 1).ToString() + "/" + files.Count.ToString();
                listView1.Items[fCount].SubItems.Add(hex[fCount]);
                listView1.Items[fCount].SubItems.Add(name);
                fCount += 1;
            }
            else if(c == 0)
            {
                double totSize = (long)e.UserState;
                if (totSize <= 1024)
                {
                    totSizeLabel.Text = "File Size : " +  totSize.ToString() + "Bytes";
                }
                else if ( totSize <= 1048576)
                {
                    totSizeLabel.Text = "File Size : " + String.Format("{0:F2}", (totSize / 1024.00)) + "KB";
                }
                else if(totSize <= 1073741824)
                {
                    totSizeLabel.Text = "File Size : " + String.Format("{0:F2}", (totSize / 1048576.00)) + "MB";
                }
                else if (totSize > 1073741824)
                {
                    totSizeLabel.Text = "File Size : " + String.Format("{0:F2}", (totSize / 1073741824.00)) + "GB";
                }
            }
            else
            {
                double processed = (long)e.UserState;
                if (processed <= 1024)
                {
                    processedLabel.Text = "Processed : " + processed.ToString() + "Bytes";
                }
                else if (processed <= 1048576)
                {
                    processedLabel.Text = "Processed : " + String.Format("{0:F2}", (processed / 1024.00)) + "KB";
                }
                else if (processed <= 1073741824)
                {
                    processedLabel.Text = "Processed : " + String.Format("{0:F2}", (processed / 1048576.00)) + "MB";
                }
                else if (processed > 1073741824)
                {
                    processedLabel.Text = "Processed : " + String.Format("{0:F2}", (processed / 1073741824.00)) + "GB";
                }
                fileprogressBar.Value += c;
                Console.WriteLine(fileprogressBar.Value);
                label1.Text = fileprogressBar.Value.ToString() + "%";
            }
            
        }

        private void renameBtn_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < files.Count; i++)
            {
                try
                {
                    File.Move(files[i], newNames[i]);
                    listView1.Items[i].ForeColor = System.Drawing.Color.LightGreen;
                }
                catch (Exception ex)
                {
                    listView1.Items[i].ForeColor = System.Drawing.Color.Red;
                    listView1.Items[i].ToolTipText = ex.Message;
                }
            }
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            stopWatch.Stop();
            timer.Stop();
            hashBtn.Enabled = true;
            selectfilesBtn.Enabled = true;
            renameBtn.Enabled = true;
            if (cancel)
            {
                fileprogressBar.Value = 100;
                totprogressBar.Value = totprogressBar.Maximum;
                label1.Text = "%";
                label2.Text = "-/-";
            }
        }

    }
}
