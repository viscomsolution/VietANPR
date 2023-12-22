using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;
using TGMTcs;
using TGMTplayer.Controls;

namespace IPSS
{
    public partial class FormCamera : Form
    {
        static FormCamera m_instance;
        CameraPanel m_cameraPanel;
        CameraPanel m_currentCameraPanel;
        bool m_autoANPR = false;
        private readonly List<float> _cpuAverages = new List<float>();

        private System.Timers.Timer _houseKeepingTimer;
        public static float CpuUsage, CpuTotal;
        private static string _counters = "";
        public static bool HighCPU;
        private PerformanceCounter _cpuCounter, _cputotalCounter, _pcMem;
        private bool _shuttingDown = false;
        int m_numCamera = 1;
        public PictureBox[] m_ImageBoxs;

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        public bool Inited
        {
            get; set;
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        public FormCamera()
        {
            InitializeComponent();
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        public static FormCamera GetInstance()
        {
            if (m_instance == null)
                m_instance = new FormCamera();
            return m_instance;
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void FormCamera_Load(object sender, EventArgs e)
        {
            
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void FormCamera_Shown(object sender, EventArgs e)
        {
            chkSaveInputImage.Checked = TGMTregistry.GetInstance().ReadBool("SaveInputImage");
            txtIpAddress.Text = TGMTini.GetInstance().Read("cameraAddress", "TGMTcamera");

            _houseKeepingTimer = new System.Timers.Timer(1000);
            _houseKeepingTimer.Elapsed += HouseKeepingTimerElapsed;
            _houseKeepingTimer.AutoReset = true;
            _houseKeepingTimer.SynchronizingObject = this;
            _houseKeepingTimer.Start();

            Thread t4 = new Thread(new ThreadStart(ShowCPUusage));
            t4.Start();

            InitImageBoxs();
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void txtIpAddress_TextChanged(object sender, EventArgs e)
        {
            if (!txtIpAddress.Focused) return;
            TGMTini.GetInstance().Write("cameraAddress", txtIpAddress.Text, "TGMTcamera");
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void chkSaveInputImage_CheckedChanged(object sender, EventArgs e)
        {
            Program.g_detector.SaveInputImage = chkSaveInputImage.Checked;
            TGMTregistry.GetInstance().SaveValue("SaveInputImage", Program.g_detector.SaveInputImage);
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void InitCameraPanels()
        {
            try
            {
                string url = txtIpAddress.Text;
                string resolution = TGMTini.GetInstance().Read("resolution", "TGMTcamera", "1280x720");
                InitCameraPanel(url, resolution, pnVideo, 0);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        public void InitCameraPanel(string url, string resolution, Panel panelDisplay, int camIndex)
        {
            if (m_cameraPanel != null)
            {
                panelDisplay.Controls.Clear();

                m_cameraPanel.Stop();
                m_cameraPanel.Dispose();
                m_cameraPanel = null;

            }
            m_cameraPanel = new CameraPanel(url, resolution);


            m_cameraPanel.parent = panelDisplay;
            m_cameraPanel.Click += cameraWindows_Click;


            string strRoi = TGMTini.GetInstance().Read("ROI", "CAM" + camIndex);
            if (strRoi != "")
            {
                string[] strrois = strRoi.Split(',');
                if (strrois.Length == 4)
                {
                    int x = int.Parse(strrois[0]);
                    int y = int.Parse(strrois[1]);
                    int w = int.Parse(strrois[2]);
                    int h = int.Parse(strrois[3]);
                    Rectangle rect = new Rectangle(x, y, w, h);
                    m_cameraPanel.ROI = rect;
                }
            }

            panelDisplay.Controls.Add(m_cameraPanel);

            BackgroundWorker worker = new BackgroundWorker();
            worker.WorkerReportsProgress = true;
            worker.DoWork += worker_DoWork;
            worker.RunWorkerCompleted += worker_RunWorkerCompleted;
            worker.RunWorkerAsync();
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void cameraWindows_Click(object sender, EventArgs e)
        {
            m_currentCameraPanel = (CameraPanel)sender;
            MouseEventArgs ee = (MouseEventArgs)e;

            if (ee.Button == MouseButtons.Right)
            {
                ctxtMnu.Show(new Point(this.Location.X + ee.Location.X, this.Location.Y + ee.Location.Y));
            }
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            m_cameraPanel.Start();
            if (m_autoANPR && !timerANPR.Enabled)
            {
                int count = 0;
                while (m_cameraPanel.GetFrame() == null && count < 5)
                {
                    Thread.Sleep(500);
                    count++;
                }
            }
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            FormMain.GetInstance().PrintMessage(""); //clear disconnect message
            if (m_autoANPR)
            {
                timerANPR.Start();
            }
            Inited = true;
            btnConnectCameraIP.Text = "Stop camera";
            btnRead.Enabled = true;
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void timerANPR_Tick(object sender, EventArgs e)
        {
            timerANPR.Stop();

            if (m_cameraPanel == null)
                return;


            if (progress_ANPR.Value == progress_ANPR.Maximum)
            {
                progress_ANPR.Value = progress_ANPR.Minimum;
            }
            progress_ANPR.Value += 1;


            Bitmap bmp = m_cameraPanel.GetFrame();
            if (bmp == null)
            {
                //PrintError("Không đọc được hình ảnh từ camera, đang thử kết nối lại...");
                //timerReconnect.Start();
                return;
            }
            else
            {
                //PrintError("");
            }

            Thread t = new Thread(() => OnNewFrame(bmp));
            t.Start();
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        public void OnNewFrame(Bitmap bmp)
        {
            this.Invoke(new Action(() =>
            {
                

                if(chkSaveInputImage.Checked)
                {
                    SaveDebugImage(bmp);
                }

                BikePlate plate = Program.g_detector.ReadPlate(bmp);
                if (plate == null || plate.text == "" || plate.text.Length < 6)
                {
                    FormMain.GetInstance().PrintError("Cannot read plate");
                    m_ImageBoxs[0].Image = bmp;
                    if (chkAutodetect.Checked)
                    {
                        timerANPR.Start();
                        return;
                    }
                    
                }

                FormMain.GetInstance().PrintResult(plate.text);
                progress_ANPR.Value = progress_ANPR.Minimum;
                m_ImageBoxs[0].Image = new Bitmap(plate.bitmap);
            }));
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void btnConnectCameraIP_Click(object sender, EventArgs e)
        {         
            if(btnConnectCameraIP.Text == "Start camera")
            {                
                InitCameraPanels();
            }
            else
            {
                btnConnectCameraIP.Text = "Start camera";
                m_cameraPanel.Stop();
                btnRead.Enabled = false;
            }
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void btnRead_Click(object sender, EventArgs e)
        {
            Bitmap bmp = m_cameraPanel.GetFrame();
            if (bmp == null)
            {
                FormMain.GetInstance().PrintError("Không đọc được hình ảnh từ camera, vui lòng kết nối lại...");
                return;
            }
            else
            {
                FormMain.GetInstance().PrintError("");
            }

            Thread t = new Thread(() => OnNewFrame(bmp));
            t.Start();
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void chkAutodetect_CheckedChanged(object sender, EventArgs e)
        {
            if(chkAutodetect.Checked)
            {
                timerANPR.Start();
                btnRead.Enabled = false;
            }
            else
            {
                timerANPR.Stop();
                btnRead.Enabled = true;
            }
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        void ShowCPUusage()
        {
            try
            {
                _cputotalCounter = new PerformanceCounter("Processor", "% Processor Time", "_total", true);
                _cpuCounter = new PerformanceCounter("Process", "% Processor Time", Process.GetCurrentProcess().ProcessName, true);
                try
                {
                    _pcMem = new PerformanceCounter("Process", "Working Set - Private", Process.GetCurrentProcess().ProcessName, true);
                }
                catch
                {
                    try
                    {
                        _pcMem = new PerformanceCounter("Memory", "Available MBytes");
                    }
                    catch (Exception ex2)
                    {
                        _pcMem = null;
                    }
                }
            }
            catch (Exception ex)
            {
                _cputotalCounter = null;
            }
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void FormCamera_VisibleChanged(object sender, EventArgs e)
        {
            if(!this.Visible)
            {
                timerANPR.Stop();
                _houseKeepingTimer.Stop();
                if(m_cameraPanel != null)
                {
                    m_cameraPanel.Stop();
                }                
            }
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void FormCamera_FormClosed(object sender, FormClosedEventArgs e)
        {
            timerANPR.Stop();
            _houseKeepingTimer.Stop();
            if (m_cameraPanel != null)
            {
                m_cameraPanel.Stop();
            }
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void HouseKeepingTimerElapsed(object sender, ElapsedEventArgs e)
        {
            _houseKeepingTimer.Stop();


            if (_cputotalCounter != null)
            {
                try
                {
                    while (_cpuAverages.Count > 4)
                        _cpuAverages.RemoveAt(0);
                    _cpuAverages.Add(_cpuCounter.NextValue() / Environment.ProcessorCount);

                    CpuUsage = _cpuAverages.Sum() / _cpuAverages.Count;
                    CpuTotal = _cputotalCounter.NextValue();
                    _counters = $"CPU: {CpuUsage:0.00}%";

                    if (_pcMem != null)
                    {
                        _counters += " RAM: " + Convert.ToInt32(_pcMem.RawValue / 1048576) + "MB";
                    }
                    lbl_CPU.Text = _counters;
                }
                catch
                {
                }

                HighCPU = CpuTotal > 90;
            }
            else
            {
                _counters = "Stats Unavailable - See Log File";
            }


            if (!_shuttingDown)
                _houseKeepingTimer.Start();
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void InitImageBoxs()
        {
            try
            {
                m_ImageBoxs = new PictureBox[m_numCamera];
                for (int i = 0; i < m_numCamera; i++)
                {
                    int wC = pnImages.Width / m_numCamera;
                    m_ImageBoxs[i] = new PictureBox();
                    m_ImageBoxs[i].SizeMode = PictureBoxSizeMode.StretchImage;
                    m_ImageBoxs[i].Left = i * wC;
                    m_ImageBoxs[i].Top = 0;
                    m_ImageBoxs[i].Width = wC + 1;
                    m_ImageBoxs[i].Height = pnImages.Height;
                    m_ImageBoxs[i].Dock = DockStyle.Fill;
                    pnImages.Controls.Add(m_ImageBoxs[i]);
                }

            }
            catch (Exception)
            {
            }
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        void SaveDebugImage(Bitmap bmp)
        {
            DateTime now = DateTime.Now;
            string filePath = String.Format(@"{0}\{1}{2}", Application.StartupPath, now.ToString("yyyy-MM-dd-hh-mm-ss") , ".jpg");
            bmp.Save(filePath);
        }
    }
}
