using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TGMT;
using TGMTcs;

namespace VietANPRdemo
{
    public partial class FormFolder : Form
    {
        string m_folderOutput = "";
        List<Plate> m_plates = new List<Plate>();

        static FormFolder m_instance;

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        public FormFolder()
        {
            InitializeComponent();

            Control.CheckForIllegalCrossThreadCalls = false;
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void FormFolder_Load(object sender, EventArgs e)
        {
            txtFolderInput.Text = TGMTregistry.GetInstance().ReadString("folderInput");
            txtFailedDir.Text = TGMTregistry.GetInstance().ReadString("txtFailedDir");
            txtValidDir.Text = TGMTregistry.GetInstance().ReadString("txtValidDir");
            txtInvalidDir.Text = TGMTregistry.GetInstance().ReadString("txtInvalidDir");
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        public static FormFolder GetInstance()
        {
            if (m_instance == null)
                m_instance = new FormFolder();
            return m_instance;
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void bgLoadFile_DoWork(object sender, DoWorkEventArgs e)
        {
            List<string> files = new List<string>();
            lstImage.Items.Clear();

            string[] fileList = Directory.GetFiles(txtFolderInput.Text, "*.jpg");
            foreach (string filePath in fileList)
            {
                files.Add(Path.GetFileName(filePath));
            }

            fileList = Directory.GetFiles(txtFolderInput.Text, "*.png");
            foreach (string filePath in fileList)
            {
                files.Add(Path.GetFileName(filePath));
            }

            fileList = Directory.GetFiles(txtFolderInput.Text, "*.bmp");
            foreach (string filePath in fileList)
            {
                files.Add(Path.GetFileName(filePath));
            }

            e.Result = files;
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void bgLoadFile_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            List<string> files = (List<string>)e.Result;
            for (int i = 0; i < files.Count; i++)
            {
                lstImage.Items.Add(files[i]);
            }
            FormMain.GetInstance().PrintMessage("Loaded " + lstImage.Items.Count + " images");
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void lstImage_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (lstImage.FocusedItem.Bounds.Contains(e.Location) == true)
                {
                    contextMenuStrip1.Show(Cursor.Position);
                }
            }
            else if (e.Button == MouseButtons.Left)
            {
                DisplayResultImage();
            }
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void lstImage_KeyDown(object sender, KeyEventArgs e)
        {
            string filePath = TGMTutil.CorrectPath(txtFolderInput.Text);
            filePath += lstImage.SelectedItems[0].Text;
            if (e.KeyCode == Keys.Enter)
            {
                System.Diagnostics.Process.Start(filePath);
            }
            else if (e.KeyCode == Keys.Delete)
            {
                FileSystem.DeleteFile(filePath, UIOption.AllDialogs, RecycleOption.SendToRecycleBin);
            }
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        void DisplayResultImage()
        {
            if (lstImage.Items.Count == 0 || lstImage.SelectedItems.Count == 0)
            {
                return;
            }

            string fileName = lstImage.SelectedItems[0].Text;


            string inputPath = TGMTutil.CorrectPath(txtFolderInput.Text);
            string failedDir = txtFailedDir.Text != "" ? TGMTutil.CorrectPath(txtFailedDir.Text) : "";
            

            if (m_folderOutput != "" && File.Exists(m_folderOutput + fileName))
            {
                picResult.ImageLocation = m_folderOutput + fileName;
                FormMain.GetInstance().PrintMessage(m_folderOutput + fileName);
            }
            else if (File.Exists(inputPath + fileName))
            {
                picResult.ImageLocation = inputPath + fileName;
                FormMain.GetInstance().PrintMessage(inputPath + fileName);
            }
            else if (txtFailedDir.Text != "" && File.Exists(failedDir + fileName))
            {
                picResult.ImageLocation = failedDir + fileName;
                FormMain.GetInstance().PrintMessage(failedDir + fileName);
            }
            else
            {
                FormMain.GetInstance().PrintError("File " + inputPath + fileName + " does not exist");
            }
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void lstImage_SelectedIndexChanged(object sender, EventArgs e)
        {
            DisplayResultImage();
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void txtFolderInput_TextChanged(object sender, EventArgs e)
        {
            if (!Directory.Exists(txtFolderInput.Text))
                return;

            TGMTregistry.GetInstance().SaveValue("folderInput", txtFolderInput.Text);
            FormMain.GetInstance().PrintMessage("Loading files...");
            lstImage.Items.Clear();
            bgLoadFile.RunWorkerAsync();
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void contextMenuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            string filePath = TGMTutil.CorrectPath(txtFolderInput.Text);
            filePath += lstImage.SelectedItems[0].Text;
            if (!File.Exists(filePath))
            {
                FormMain.GetInstance().PrintMessage("File does not exist");

            }


            if (e.ClickedItem.Name == "btnCopyPath")
            {
                Clipboard.SetText(filePath);
                FormMain.GetInstance().PrintMessage("Copied path to clipboard");
            }
            else if (e.ClickedItem.Name == "btnCopyImage")
            {
                StringCollection paths = new StringCollection();
                paths.Add(filePath);
                Clipboard.SetFileDropList(paths);
                FormMain.GetInstance().PrintMessage("Copied image to clipboard");
            }
            else if (e.ClickedItem.Name == "btnOpenImage")
            {
                System.Diagnostics.Process.Start(filePath);
            }
            else if (e.ClickedItem.Name == "btnDelete")
            {
                FileSystem.DeleteFile(filePath, UIOption.AllDialogs, RecycleOption.SendToRecycleBin);
            }
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void bgWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            string inputPath = "";
            if (txtFolderInput.Text != "")
                inputPath = TGMTutil.CorrectPath(txtFolderInput.Text);
            string failedDir = "";
            if (txtFailedDir.Text != "")
                failedDir = TGMTutil.CorrectPath(txtFailedDir.Text);

            string validDir = "";
            if (txtValidDir.Text != "")
                validDir = TGMTutil.CorrectPath(txtValidDir.Text);

            string invalidDir = "";
            if (txtInvalidDir.Text != "")
                invalidDir = TGMTutil.CorrectPath(txtInvalidDir.Text);

            int exactlyCount = 0;
            string content = "";

            

            for (int i = 0; i < lstImage.Items.Count; i++)
            {
                if (bgWorker1.CancellationPending)
                    return;
                //bgWorker1.ReportProgress(i + 1);

                //Program.reader.OutputFileName = lstImage.Items[i].Text;

                string filePath = inputPath + lstImage.Items[i].Text;
                string ext = filePath.Substring(filePath.Length - 4).ToLower();
                content += Path.GetFileName(filePath) + ",";

                

                if (ext != ".jpg" && ext != ".png" && ext != ".bmp")
                    continue;
                FormMain.GetInstance().PrintMessage(i + " / " + lstImage.Items.Count + " " + filePath);

                PlateInfo result = Program.reader.Read(filePath);

                m_plates.Add(new Plate(filePath, result.text));


                if (result.text != "")
                {
                    if (lstImage.Items[i].SubItems.Count == 1)
                    {
                        lstImage.Items[i].SubItems.Add(result.text);
                    }
                    else
                    {
                        lstImage.Items[i].SubItems[1].Text = result.text;
                    }
                    lstImage.Items[i].ForeColor = result.isValid ? Color.Blue : Color.Black;
                    content += "x,";

                    if (result.isValid)
                    {
                        exactlyCount++;
                        if (chkMoveValid.Checked)
                        {
                            Task.Run(() => File.Move(inputPath + lstImage.Items[i].Text, validDir + lstImage.Items[i].Text));
                        }
                    }
                    else
                    {
                        if (chkMoveInvalid.Checked)
                        {
                            Task.Run(() => File.Move(inputPath + lstImage.Items[i].Text, invalidDir + lstImage.Items[i].Text));
                        }
                    }
                }
                else
                {
                    if (lstImage.Items[i].SubItems.Count == 1)
                    {
                        lstImage.Items[i].SubItems.Add(result.error);
                    }
                    else
                    {
                        lstImage.Items[i].SubItems[1].Text = result.error;
                    }
                    if (chkMoveFail.Checked)
                    {
                        Task.Run(() => File.Move(inputPath + lstImage.Items[i].Text, failedDir + lstImage.Items[i].Text));
                    }

                    lstImage.Items[i].ForeColor = Color.Red;
                    content += ",";
                }

                content += result.text;
                content += "\r\n";


                //result.Dispose();


                lstImage.EnsureVisible(i);
            }

            if (inputPath != "")
            {
                content += "Exactly " + exactlyCount + " / " + lstImage.Items.Count + " plates\r\n";
                File.WriteAllText(Path.GetDirectoryName(inputPath) + "\\_report.csv", content);
            }

        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void bgWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            FormMain.GetInstance().PrintMessage(e.ProgressPercentage + "/" + lstImage.Items.Count + "(" + (100 * e.ProgressPercentage / lstImage.Items.Count) + " %)");
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void bgWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            FormMain.GetInstance().StopProgressbar();

            btnDetect.Text = "Start detect (F5)";
            if (m_folderOutput != "")
                FormMain.GetInstance().PrintMessage("Save report to " + TGMTutil.CorrectPath(txtFolderInput.Text) + "_report.csv");
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void btnSelectFolderInput_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.ShowDialog();
            if (fbd.SelectedPath != "")
            {
                txtFolderInput.Text = fbd.SelectedPath;
            }
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void chkMoveFail_CheckedChanged(object sender, EventArgs e)
        {
            if (chkMoveFail.Checked)
            {
                errorProvider1.Clear();

                if (txtFailedDir.Text == "")
                {
                    chkMoveFail.Checked = false;
                    FormMain.GetInstance().PrintError("Target directory is empty");
                }
                else if (!Directory.Exists(txtFailedDir.Text))
                {
                    //does not create new dir to avoid replace existed file
                    errorProvider1.SetError(txtFailedDir, "Dir does not exist");

                    chkMoveFail.Checked = false;
                }
                else
                {
                    TGMTregistry.GetInstance().SaveValue("txtFailedDir", txtFailedDir.Text);
                }
            }
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void chkMoveValid_CheckedChanged(object sender, EventArgs e)
        {
            if (chkMoveValid.Checked)
            {
                errorProvider1.Clear();

                if (txtValidDir.Text == "")
                {
                    FormMain.GetInstance().PrintError("Valid directory is empty");
                    chkMoveValid.Checked = false;
                }
                else if (!Directory.Exists(txtValidDir.Text))
                {
                    //does not create new dir to avoid replace existed file
                    errorProvider1.SetError(txtValidDir, "Dir does not exist");
                    chkMoveValid.Checked = false;
                }
                else
                {
                    TGMTregistry.GetInstance().SaveValue("txtValidDir", txtValidDir.Text);
                }
            }
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void chkMoveInvalid_CheckedChanged(object sender, EventArgs e)
        {
            if (chkMoveInvalid.Checked)
            {
                errorProvider1.Clear();

                if (txtInvalidDir.Text == "")
                {
                    FormMain.GetInstance().PrintError("Invalid directory is empty");
                    chkMoveInvalid.Checked = false;
                }
                else if (!Directory.Exists(txtInvalidDir.Text))
                {
                    //does not create new dir to avoid replace existed file
                    errorProvider1.SetError(txtInvalidDir, "Dir does not exist");
                    chkMoveInvalid.Checked = false;
                }
                else
                {
                    TGMTregistry.GetInstance().SaveValue("txtInvalidDir", txtInvalidDir.Text);
                }
            }
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void btnDetect_Click(object sender, EventArgs e)
        {
            if (btnDetect.Text.Contains("Start"))
            {
                bgWorker1.RunWorkerAsync();
                btnDetect.Text = "Stop";
            }
            else
            {
                bgWorker1.CancelAsync();
                btnDetect.Text = "Start detect";
            }
        }

    }
}
