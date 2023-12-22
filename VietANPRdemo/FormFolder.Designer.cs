namespace VietANPRdemo
{
    partial class FormFolder
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
            this.bgLoadFile = new System.ComponentModel.BackgroundWorker();
            this.bgWorker1 = new System.ComponentModel.BackgroundWorker();
            this.btnSelectFolderInput = new System.Windows.Forms.Button();
            this.txtFolderInput = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnDetect = new System.Windows.Forms.Button();
            this.picResult = new System.Windows.Forms.PictureBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.btnCopyPath = new System.Windows.Forms.ToolStripMenuItem();
            this.btnCopyImage = new System.Windows.Forms.ToolStripMenuItem();
            this.btnOpenImage = new System.Windows.Forms.ToolStripMenuItem();
            this.btnDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.grFolder = new System.Windows.Forms.GroupBox();
            this.txtInvalidDir = new System.Windows.Forms.TextBox();
            this.chkMoveInvalid = new System.Windows.Forms.CheckBox();
            this.txtValidDir = new System.Windows.Forms.TextBox();
            this.chkMoveValid = new System.Windows.Forms.CheckBox();
            this.txtFailedDir = new System.Windows.Forms.TextBox();
            this.chkMoveFail = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.lstImage = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            ((System.ComponentModel.ISupportInitialize)(this.picResult)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.grFolder.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // bgLoadFile
            // 
            this.bgLoadFile.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgLoadFile_DoWork);
            this.bgLoadFile.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgLoadFile_RunWorkerCompleted);
            // 
            // bgWorker1
            // 
            this.bgWorker1.WorkerSupportsCancellation = true;
            this.bgWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgWorker1_DoWork);
            this.bgWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bgWorker1_ProgressChanged);
            this.bgWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgWorker1_RunWorkerCompleted);
            // 
            // btnSelectFolderInput
            // 
            this.btnSelectFolderInput.Location = new System.Drawing.Point(387, 33);
            this.btnSelectFolderInput.Name = "btnSelectFolderInput";
            this.btnSelectFolderInput.Size = new System.Drawing.Size(24, 27);
            this.btnSelectFolderInput.TabIndex = 17;
            this.btnSelectFolderInput.Text = "...";
            this.btnSelectFolderInput.UseVisualStyleBackColor = true;
            this.btnSelectFolderInput.Click += new System.EventHandler(this.btnSelectFolderInput_Click);
            // 
            // txtFolderInput
            // 
            this.txtFolderInput.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFolderInput.Location = new System.Drawing.Point(110, 34);
            this.txtFolderInput.Name = "txtFolderInput";
            this.txtFolderInput.Size = new System.Drawing.Size(273, 25);
            this.txtFolderInput.TabIndex = 16;
            this.txtFolderInput.TextChanged += new System.EventHandler(this.txtFolderInput_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(11, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 19);
            this.label2.TabIndex = 15;
            this.label2.Text = "Input folder";
            // 
            // btnDetect
            // 
            this.btnDetect.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDetect.Location = new System.Drawing.Point(883, 15);
            this.btnDetect.Name = "btnDetect";
            this.btnDetect.Size = new System.Drawing.Size(100, 52);
            this.btnDetect.TabIndex = 18;
            this.btnDetect.Text = "Start detect (F5)";
            this.btnDetect.UseVisualStyleBackColor = true;
            this.btnDetect.Click += new System.EventHandler(this.btnDetect_Click);
            // 
            // picResult
            // 
            this.picResult.Location = new System.Drawing.Point(491, 118);
            this.picResult.Name = "picResult";
            this.picResult.Size = new System.Drawing.Size(480, 360);
            this.picResult.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picResult.TabIndex = 32;
            this.picResult.TabStop = false;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnCopyPath,
            this.btnCopyImage,
            this.btnOpenImage,
            this.btnDelete});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(172, 92);
            this.contextMenuStrip1.Text = "Copy path";
            this.contextMenuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.contextMenuStrip1_ItemClicked);
            // 
            // btnCopyPath
            // 
            this.btnCopyPath.Name = "btnCopyPath";
            this.btnCopyPath.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.btnCopyPath.Size = new System.Drawing.Size(171, 22);
            this.btnCopyPath.Text = "Copy path";
            // 
            // btnCopyImage
            // 
            this.btnCopyImage.Name = "btnCopyImage";
            this.btnCopyImage.Size = new System.Drawing.Size(171, 22);
            this.btnCopyImage.Text = "Copy image";
            // 
            // btnOpenImage
            // 
            this.btnOpenImage.Name = "btnOpenImage";
            this.btnOpenImage.Size = new System.Drawing.Size(171, 22);
            this.btnOpenImage.Text = "Open image";
            // 
            // btnDelete
            // 
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(171, 22);
            this.btnDelete.Text = "Delete image";
            // 
            // grFolder
            // 
            this.grFolder.Controls.Add(this.txtInvalidDir);
            this.grFolder.Controls.Add(this.chkMoveInvalid);
            this.grFolder.Controls.Add(this.txtValidDir);
            this.grFolder.Controls.Add(this.btnDetect);
            this.grFolder.Controls.Add(this.chkMoveValid);
            this.grFolder.Controls.Add(this.btnSelectFolderInput);
            this.grFolder.Controls.Add(this.txtFolderInput);
            this.grFolder.Controls.Add(this.txtFailedDir);
            this.grFolder.Controls.Add(this.label2);
            this.grFolder.Controls.Add(this.chkMoveFail);
            this.grFolder.Controls.Add(this.label4);
            this.grFolder.Dock = System.Windows.Forms.DockStyle.Top;
            this.grFolder.Location = new System.Drawing.Point(0, 0);
            this.grFolder.Name = "grFolder";
            this.grFolder.Size = new System.Drawing.Size(995, 112);
            this.grFolder.TabIndex = 33;
            this.grFolder.TabStop = false;
            // 
            // txtInvalidDir
            // 
            this.txtInvalidDir.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtInvalidDir.Location = new System.Drawing.Point(600, 77);
            this.txtInvalidDir.Name = "txtInvalidDir";
            this.txtInvalidDir.Size = new System.Drawing.Size(273, 25);
            this.txtInvalidDir.TabIndex = 17;
            // 
            // chkMoveInvalid
            // 
            this.chkMoveInvalid.AutoSize = true;
            this.chkMoveInvalid.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkMoveInvalid.Location = new System.Drawing.Point(423, 78);
            this.chkMoveInvalid.Name = "chkMoveInvalid";
            this.chkMoveInvalid.Size = new System.Drawing.Size(144, 23);
            this.chkMoveInvalid.TabIndex = 16;
            this.chkMoveInvalid.Text = "Move invalid file to";
            this.chkMoveInvalid.UseVisualStyleBackColor = true;
            this.chkMoveInvalid.CheckedChanged += new System.EventHandler(this.chkMoveInvalid_CheckedChanged);
            // 
            // txtValidDir
            // 
            this.txtValidDir.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtValidDir.Location = new System.Drawing.Point(600, 46);
            this.txtValidDir.Name = "txtValidDir";
            this.txtValidDir.Size = new System.Drawing.Size(273, 25);
            this.txtValidDir.TabIndex = 15;
            // 
            // chkMoveValid
            // 
            this.chkMoveValid.AutoSize = true;
            this.chkMoveValid.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkMoveValid.Location = new System.Drawing.Point(423, 47);
            this.chkMoveValid.Name = "chkMoveValid";
            this.chkMoveValid.Size = new System.Drawing.Size(133, 23);
            this.chkMoveValid.TabIndex = 14;
            this.chkMoveValid.Text = "Move valid file to";
            this.chkMoveValid.UseVisualStyleBackColor = true;
            this.chkMoveValid.CheckedChanged += new System.EventHandler(this.chkMoveValid_CheckedChanged);
            // 
            // txtFailedDir
            // 
            this.txtFailedDir.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFailedDir.Location = new System.Drawing.Point(600, 15);
            this.txtFailedDir.Name = "txtFailedDir";
            this.txtFailedDir.Size = new System.Drawing.Size(273, 25);
            this.txtFailedDir.TabIndex = 13;
            // 
            // chkMoveFail
            // 
            this.chkMoveFail.AutoSize = true;
            this.chkMoveFail.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkMoveFail.Location = new System.Drawing.Point(423, 15);
            this.chkMoveFail.Name = "chkMoveFail";
            this.chkMoveFail.Size = new System.Drawing.Size(176, 23);
            this.chkMoveFail.TabIndex = 12;
            this.chkMoveFail.Text = "Move file can\'t detect to";
            this.chkMoveFail.UseVisualStyleBackColor = true;
            this.chkMoveFail.CheckedChanged += new System.EventHandler(this.chkMoveFail_CheckedChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(336, 75);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(0, 13);
            this.label4.TabIndex = 4;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // lstImage
            // 
            this.lstImage.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.lstImage.ContextMenuStrip = this.contextMenuStrip1;
            this.lstImage.FullRowSelect = true;
            this.lstImage.GridLines = true;
            this.lstImage.HideSelection = false;
            this.lstImage.Location = new System.Drawing.Point(-5, 118);
            this.lstImage.MultiSelect = false;
            this.lstImage.Name = "lstImage";
            this.lstImage.Size = new System.Drawing.Size(486, 360);
            this.lstImage.TabIndex = 34;
            this.lstImage.UseCompatibleStateImageBehavior = false;
            this.lstImage.View = System.Windows.Forms.View.Details;
            this.lstImage.SelectedIndexChanged += new System.EventHandler(this.lstImage_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Image name";
            this.columnHeader1.Width = 272;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Plate";
            this.columnHeader2.Width = 154;
            // 
            // FormFolder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(995, 513);
            this.Controls.Add(this.lstImage);
            this.Controls.Add(this.grFolder);
            this.Controls.Add(this.picResult);
            this.Name = "FormFolder";
            this.Text = "FormFolder";
            this.Load += new System.EventHandler(this.FormFolder_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picResult)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.grFolder.ResumeLayout(false);
            this.grFolder.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.ComponentModel.BackgroundWorker bgLoadFile;
        private System.ComponentModel.BackgroundWorker bgWorker1;
        private System.Windows.Forms.Button btnSelectFolderInput;
        private System.Windows.Forms.TextBox txtFolderInput;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnDetect;
        private System.Windows.Forms.PictureBox picResult;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem btnCopyPath;
        private System.Windows.Forms.ToolStripMenuItem btnCopyImage;
        private System.Windows.Forms.ToolStripMenuItem btnOpenImage;
        private System.Windows.Forms.ToolStripMenuItem btnDelete;
        private System.Windows.Forms.GroupBox grFolder;
        private System.Windows.Forms.TextBox txtInvalidDir;
        private System.Windows.Forms.CheckBox chkMoveInvalid;
        private System.Windows.Forms.TextBox txtValidDir;
        private System.Windows.Forms.CheckBox chkMoveValid;
        private System.Windows.Forms.TextBox txtFailedDir;
        private System.Windows.Forms.CheckBox chkMoveFail;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.ListView lstImage;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
    }
}