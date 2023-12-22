namespace IPSS
{
    partial class FormCamera
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormCamera));
            this.pnVideo = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnRead = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.chkSaveInputImage = new System.Windows.Forms.CheckBox();
            this.chkAutodetect = new System.Windows.Forms.CheckBox();
            this.btnConnectCameraIP = new System.Windows.Forms.Button();
            this.txtIpAddress = new System.Windows.Forms.TextBox();
            this.ctxtMnu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this._recordNowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._takePhotoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._cropToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.timerANPR = new System.Windows.Forms.Timer(this.components);
            this.lbl_CPU = new System.Windows.Forms.Label();
            this.progress_ANPR = new System.Windows.Forms.ProgressBar();
            this.pnImages = new System.Windows.Forms.Panel();
            this.groupBox1.SuspendLayout();
            this.ctxtMnu.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnVideo
            // 
            this.pnVideo.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.pnVideo.Location = new System.Drawing.Point(12, 163);
            this.pnVideo.Name = "pnVideo";
            this.pnVideo.Size = new System.Drawing.Size(502, 289);
            this.pnVideo.TabIndex = 18;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnRead);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.chkSaveInputImage);
            this.groupBox1.Controls.Add(this.chkAutodetect);
            this.groupBox1.Controls.Add(this.btnConnectCameraIP);
            this.groupBox1.Controls.Add(this.txtIpAddress);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1202, 100);
            this.groupBox1.TabIndex = 19;
            this.groupBox1.TabStop = false;
            // 
            // btnRead
            // 
            this.btnRead.BackColor = System.Drawing.SystemColors.HotTrack;
            this.btnRead.Enabled = false;
            this.btnRead.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRead.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRead.ForeColor = System.Drawing.Color.White;
            this.btnRead.Location = new System.Drawing.Point(469, 26);
            this.btnRead.Name = "btnRead";
            this.btnRead.Size = new System.Drawing.Size(95, 28);
            this.btnRead.TabIndex = 23;
            this.btnRead.Text = "Read plate";
            this.btnRead.UseVisualStyleBackColor = false;
            this.btnRead.Click += new System.EventHandler(this.btnRead_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 19);
            this.label1.TabIndex = 22;
            this.label1.Text = "rtsp link";
            // 
            // chkSaveInputImage
            // 
            this.chkSaveInputImage.AutoSize = true;
            this.chkSaveInputImage.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkSaveInputImage.Location = new System.Drawing.Point(219, 69);
            this.chkSaveInputImage.Name = "chkSaveInputImage";
            this.chkSaveInputImage.Size = new System.Drawing.Size(133, 23);
            this.chkSaveInputImage.TabIndex = 21;
            this.chkSaveInputImage.Text = "Save input image";
            this.chkSaveInputImage.UseVisualStyleBackColor = true;
            this.chkSaveInputImage.CheckedChanged += new System.EventHandler(this.chkSaveInputImage_CheckedChanged);
            // 
            // chkAutodetect
            // 
            this.chkAutodetect.AutoSize = true;
            this.chkAutodetect.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkAutodetect.ForeColor = System.Drawing.Color.Black;
            this.chkAutodetect.Location = new System.Drawing.Point(92, 68);
            this.chkAutodetect.Name = "chkAutodetect";
            this.chkAutodetect.Size = new System.Drawing.Size(100, 23);
            this.chkAutodetect.TabIndex = 20;
            this.chkAutodetect.Text = "Auto detect";
            this.chkAutodetect.UseVisualStyleBackColor = true;
            this.chkAutodetect.CheckedChanged += new System.EventHandler(this.chkAutodetect_CheckedChanged);
            // 
            // btnConnectCameraIP
            // 
            this.btnConnectCameraIP.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConnectCameraIP.Location = new System.Drawing.Point(351, 26);
            this.btnConnectCameraIP.Name = "btnConnectCameraIP";
            this.btnConnectCameraIP.Size = new System.Drawing.Size(102, 28);
            this.btnConnectCameraIP.TabIndex = 19;
            this.btnConnectCameraIP.Text = "Start camera";
            this.btnConnectCameraIP.UseVisualStyleBackColor = true;
            this.btnConnectCameraIP.Click += new System.EventHandler(this.btnConnectCameraIP_Click);
            // 
            // txtIpAddress
            // 
            this.txtIpAddress.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIpAddress.Location = new System.Drawing.Point(91, 28);
            this.txtIpAddress.Name = "txtIpAddress";
            this.txtIpAddress.Size = new System.Drawing.Size(256, 25);
            this.txtIpAddress.TabIndex = 18;
            this.txtIpAddress.TextChanged += new System.EventHandler(this.txtIpAddress_TextChanged);
            // 
            // ctxtMnu
            // 
            this.ctxtMnu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.ctxtMnu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._recordNowToolStripMenuItem,
            this._takePhotoToolStripMenuItem,
            this._cropToolStripMenuItem});
            this.ctxtMnu.Name = "_ctxtMnu";
            this.ctxtMnu.Size = new System.Drawing.Size(144, 82);
            // 
            // _recordNowToolStripMenuItem
            // 
            this._recordNowToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("_recordNowToolStripMenuItem.Image")));
            this._recordNowToolStripMenuItem.Name = "_recordNowToolStripMenuItem";
            this._recordNowToolStripMenuItem.Size = new System.Drawing.Size(143, 26);
            this._recordNowToolStripMenuItem.Text = "Record Now";
            this._recordNowToolStripMenuItem.Visible = false;
            // 
            // _takePhotoToolStripMenuItem
            // 
            this._takePhotoToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("_takePhotoToolStripMenuItem.Image")));
            this._takePhotoToolStripMenuItem.Name = "_takePhotoToolStripMenuItem";
            this._takePhotoToolStripMenuItem.Size = new System.Drawing.Size(143, 26);
            this._takePhotoToolStripMenuItem.Text = "Take Picture";
            // 
            // _cropToolStripMenuItem
            // 
            this._cropToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("_cropToolStripMenuItem.Image")));
            this._cropToolStripMenuItem.Name = "_cropToolStripMenuItem";
            this._cropToolStripMenuItem.Size = new System.Drawing.Size(143, 26);
            this._cropToolStripMenuItem.Text = "&Set crop";
            // 
            // timerANPR
            // 
            this.timerANPR.Interval = 500;
            this.timerANPR.Tick += new System.EventHandler(this.timerANPR_Tick);
            // 
            // lbl_CPU
            // 
            this.lbl_CPU.AutoSize = true;
            this.lbl_CPU.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_CPU.Location = new System.Drawing.Point(273, 121);
            this.lbl_CPU.Name = "lbl_CPU";
            this.lbl_CPU.Size = new System.Drawing.Size(36, 19);
            this.lbl_CPU.TabIndex = 23;
            this.lbl_CPU.Text = "CPU";
            // 
            // progress_ANPR
            // 
            this.progress_ANPR.Location = new System.Drawing.Point(12, 118);
            this.progress_ANPR.Maximum = 10;
            this.progress_ANPR.Name = "progress_ANPR";
            this.progress_ANPR.Size = new System.Drawing.Size(191, 23);
            this.progress_ANPR.TabIndex = 24;
            // 
            // pnImages
            // 
            this.pnImages.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(255)))), ((int)(((byte)(153)))));
            this.pnImages.ForeColor = System.Drawing.Color.White;
            this.pnImages.Location = new System.Drawing.Point(520, 163);
            this.pnImages.Name = "pnImages";
            this.pnImages.Size = new System.Drawing.Size(502, 289);
            this.pnImages.TabIndex = 25;
            // 
            // FormCamera
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1202, 740);
            this.Controls.Add(this.pnImages);
            this.Controls.Add(this.progress_ANPR);
            this.Controls.Add(this.lbl_CPU);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.pnVideo);
            this.Name = "FormCamera";
            this.Text = "FormCamera";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormCamera_FormClosed);
            this.Load += new System.EventHandler(this.FormCamera_Load);
            this.Shown += new System.EventHandler(this.FormCamera_Shown);
            this.VisibleChanged += new System.EventHandler(this.FormCamera_VisibleChanged);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ctxtMnu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel pnVideo;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox chkSaveInputImage;
        private System.Windows.Forms.CheckBox chkAutodetect;
        private System.Windows.Forms.Button btnConnectCameraIP;
        private System.Windows.Forms.TextBox txtIpAddress;
        private System.Windows.Forms.ContextMenuStrip ctxtMnu;
        private System.Windows.Forms.ToolStripMenuItem _recordNowToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem _takePhotoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem _cropToolStripMenuItem;
        private System.Windows.Forms.Timer timerANPR;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbl_CPU;
        private System.Windows.Forms.ProgressBar progress_ANPR;
        private System.Windows.Forms.Panel pnImages;
        private System.Windows.Forms.Button btnRead;
    }
}