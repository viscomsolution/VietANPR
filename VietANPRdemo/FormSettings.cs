using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TGMTcs;

namespace VietANPRdemo
{
    public partial class FormSettings : Form
    {
        static FormSettings m_instance;

        public FormSettings()
        {
            InitializeComponent();
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        public static FormSettings GetInstance()
        {
            if (m_instance == null)
                m_instance = new FormSettings();
            return m_instance;
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void FormSettings_Load(object sender, EventArgs e)
        {
            
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void FormSettings_Shown(object sender, EventArgs e)
        {
            chk_enableDeepScan.Checked = TGMTregistry.GetInstance().ReadBool("EnableDeepScan");
            chkEnableLog.Checked = TGMTregistry.GetInstance().ReadBool("EnableLog");
            
            chkCrop.Checked = TGMTregistry.GetInstance().ReadBool("CropResultImage");
            
            txtFolderOutput.Text = TGMTregistry.GetInstance().ReadString("folderOutput");
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void btn_save_Click(object sender, EventArgs e)
        {
            //Program.reader.EnableDeepScan = chk_enableDeepScan.Checked;
            //TGMTregistry.GetInstance().SaveValue("EnableDeepScan", Program.g_detector.EnableDeepScan);


            //Program.g_detector.EnableLog = chkEnableLog.Checked;
            //TGMTregistry.GetInstance().SaveValue("EnableLog", Program.g_detector.EnableLog);            


            


            //Program.g_detector.CropResultImage = chkCrop.Checked;
            //TGMTregistry.GetInstance().SaveValue("CropResultImage", Program.g_detector.CropResultImage);


            //Program.folderOutput = txtFolderOutput.Text != "" ? TGMTutil.CorrectPath(txtFolderOutput.Text) : "";
            //TGMTregistry.GetInstance().SaveValue("folderOutput", txtFolderOutput.Text);

        }
    }
}
