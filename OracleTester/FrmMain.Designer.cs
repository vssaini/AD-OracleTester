namespace OracleTester
{
    partial class FrmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.btnConnect = new System.Windows.Forms.Button();
            this.dataGridRecords = new System.Windows.Forms.DataGridView();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.bgWorkerDataFiller = new System.ComponentModel.BackgroundWorker();
            this.btnExportTable = new System.Windows.Forms.Button();
            this.btnRemoteData = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.bgWorkerDataTasks = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridRecords)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnConnect
            // 
            this.btnConnect.Image = global::OracleTester.Properties.Resources.Icon_Network;
            this.btnConnect.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnConnect.Location = new System.Drawing.Point(14, 23);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(121, 27);
            this.btnConnect.TabIndex = 0;
            this.btnConnect.Text = "Test Connection";
            this.btnConnect.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // dataGridRecords
            // 
            this.dataGridRecords.AllowUserToAddRows = false;
            this.dataGridRecords.AllowUserToDeleteRows = false;
            this.dataGridRecords.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridRecords.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridRecords.Location = new System.Drawing.Point(12, 167);
            this.dataGridRecords.Name = "dataGridRecords";
            this.dataGridRecords.Size = new System.Drawing.Size(518, 196);
            this.dataGridRecords.TabIndex = 2;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblStatus});
            this.statusStrip1.Location = new System.Drawing.Point(0, 387);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(544, 22);
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblStatus
            // 
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(188, 17);
            this.lblStatus.Text = "Developed by - Vikram Singh Saini";
            this.lblStatus.Click += new System.EventHandler(this.lblStatus_Click);
            this.lblStatus.MouseLeave += new System.EventHandler(this.lblStatus_MouseLeave);
            this.lblStatus.MouseHover += new System.EventHandler(this.lblStatus_MouseHover);
            // 
            // bgWorkerDataFiller
            // 
            this.bgWorkerDataFiller.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgWorkerDataFiller_DoWork);
            // 
            // btnExportTable
            // 
            this.btnExportTable.Image = global::OracleTester.Properties.Resources.table__plus;
            this.btnExportTable.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExportTable.Location = new System.Drawing.Point(14, 67);
            this.btnExportTable.Name = "btnExportTable";
            this.btnExportTable.Size = new System.Drawing.Size(101, 27);
            this.btnExportTable.TabIndex = 4;
            this.btnExportTable.Text = "Export Table";
            this.btnExportTable.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExportTable.UseVisualStyleBackColor = true;
            this.btnExportTable.Click += new System.EventHandler(this.btnExportTable_Click);
            // 
            // btnRemoteData
            // 
            this.btnRemoteData.Image = global::OracleTester.Properties.Resources.table_import;
            this.btnRemoteData.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnRemoteData.Location = new System.Drawing.Point(14, 117);
            this.btnRemoteData.Name = "btnRemoteData";
            this.btnRemoteData.Size = new System.Drawing.Size(103, 27);
            this.btnRemoteData.TabIndex = 5;
            this.btnRemoteData.Text = " Remote Data";
            this.btnRemoteData.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRemoteData.UseVisualStyleBackColor = true;
            this.btnRemoteData.Click += new System.EventHandler(this.btnRemoteData_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(141, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(205, 15);
            this.label1.TabIndex = 6;
            this.label1.Text = "- Test connection to remote database";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(141, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(315, 15);
            this.label2.TabIndex = 7;
            this.label2.Text = "- Create table on remote database. Then Insert Grid values.";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(141, 123);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(179, 15);
            this.label3.TabIndex = 8;
            this.label3.Text = "- Get data from remote database";
            // 
            // bgWorkerDataTasks
            // 
            this.bgWorkerDataTasks.WorkerReportsProgress = true;
            this.bgWorkerDataTasks.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgWorkerDataTasks_DoWork);
            this.bgWorkerDataTasks.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bgWorkerDataTasks_ProgressChanged);
            this.bgWorkerDataTasks.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgWorkerDataTasks_RunWorkerCompleted);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(544, 409);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnRemoteData);
            this.Controls.Add(this.btnExportTable);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.dataGridRecords);
            this.Controls.Add(this.btnConnect);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Oracle Tester";
            this.Load += new System.EventHandler(this.FrmMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridRecords)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.DataGridView dataGridRecords;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblStatus;
        private System.ComponentModel.BackgroundWorker bgWorkerDataFiller;
        private System.Windows.Forms.Button btnExportTable;
        private System.Windows.Forms.Button btnRemoteData;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.ComponentModel.BackgroundWorker bgWorkerDataTasks;
    }
}

