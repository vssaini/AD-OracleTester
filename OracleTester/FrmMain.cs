using System;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.ComponentModel;
using OracleTester.Code;

namespace OracleTester
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        #region Populate grid from xml data

        private void FrmMain_Load(object sender, EventArgs e)
        {
            // Argument can be passed here too
            bgWorkerDataFiller.RunWorkerAsync();
        }

        private void bgWorkerDataFiller_DoWork(object sender, DoWorkEventArgs e)
        {
            // Parse the passed arguments. Caste to same type
            //object[] args = (object[])e.Argument;

            Invoke((MethodInvoker)PopulateDataGrid);
        }

        #endregion

        #region Button clicks

        private void btnConnect_Click(object sender, EventArgs e)
        {
            try
            {
                ToggleButtonState(false);
                using (var con = Utility.OracleCon)
                {
                    con.Open();

                    if (!con.State.Equals(ConnectionState.Open)) return;
                    lblStatus.ForeColor = Color.DarkGreen;
                    lblStatus.Text = "Connection succeeded!";
                }
                ToggleButtonState(true);
            }
            catch (Exception exception)
            {
                lblStatus.ForeColor = Color.Red;
                lblStatus.Text = "Connection failed.";

                MessageBox.Show(exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ToggleButtonState(true);
            }
        }

        private void btnExportTable_Click(object sender, EventArgs e)
        {
            if (dataGridRecords.Rows.Count > 0)
            {
                lblStatus.Text = "Initiating process of creating table...";
                ToggleButtonState(false);
                bgWorkerDataTasks.RunWorkerAsync();
            }
            else
            {
                lblStatus.Text = "Data.xml file not found. Grid is empty. Can't export records.";
            }

        }

        private void btnRemoteData_Click(object sender, EventArgs e)
        {

        }

        #endregion

        #region Handle database tasks by thread

        private void bgWorkerDataTasks_DoWork(object sender, DoWorkEventArgs e)
        {
            InitiateDbTasks(e);
        }

        private void bgWorkerDataTasks_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            var progStatus = e.UserState.ToString();
            lblStatus.Text = string.Format("{0} ({1}% completed)", progStatus, e.ProgressPercentage);
        }

        private void bgWorkerDataTasks_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                MessageBox.Show(this, e.Error.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                lblStatus.ForeColor = Color.Red;
                lblStatus.Text = "An error occured. Fix errors and try again!";
            }
            else
            {
                lblStatus.ForeColor = Color.DarkGreen;
                lblStatus.Text = e.Result.ToString();
            }

            // Reset button state
            ToggleButtonState(true);
        }

        #endregion

        #region Helpers

        /// <summary>
        /// Bind xml file to DataGrid
        /// </summary>
        private void PopulateDataGrid()
        {
            // Retrieve path to xml file
            var path = Path.Combine(Application.StartupPath, "Data.xml");

            var dataSet = new DataSet();
            dataSet.ReadXml(path);

            dataGridRecords.DataSource = dataSet;
            dataGridRecords.DataMember = "ADData";
        }

        /// <summary>
        /// Database related tasks.
        /// </summary>
        private void InitiateDbTasks(DoWorkEventArgs e)
        {
            var tableName = ConfigurationManager.AppSettings["TableName"];

            using (var con = Utility.OracleCon)
            {
                con.Open();

                var orCmdGen = new OracleCommandGenerator();
                var colList = dataGridRecords.Columns.Cast<DataGridViewColumn>().ToList();

                // 1. Drop table if it already exist
                string progStatus;
                if (Utility.IsTableExist(tableName, con))
                {
                    Utility.DropTable(tableName, con, orCmdGen);
                    progStatus = "Table 'VikramTest' was dropped.";
                    bgWorkerDataTasks.ReportProgress(25, progStatus);
                }

                // 2. Create table
                Utility.CreateTable(tableName, colList, con, orCmdGen);
                progStatus = "Table 'VikramTest' created.";
                bgWorkerDataTasks.ReportProgress(50, progStatus);

                // 3. Insert records in table
                var dataSet = (DataSet)dataGridRecords.DataSource;
                var dataView = new DataView { Table = dataSet.Tables[0] };
                Utility.InsertRecords(tableName, con, dataView, colList, orCmdGen);

                // 4. Final response
                e.Result = "Records were exported successfully!";
            }
        }

        /// <summary>
        /// Enable or disable button states
        /// </summary>
        private void ToggleButtonState(bool state)
        {
            btnConnect.Enabled = state;
            btnRemoteData.Enabled = state;
            btnExportTable.Enabled = state;
        }

        #endregion

        #region Label Status

        private void lblStatus_MouseHover(object sender, EventArgs e)
        {
            Cursor = Cursors.Default;
        }

        private void lblStatus_MouseLeave(object sender, EventArgs e)
        {
            Cursor = Cursors.Hand;
        }

        private void lblStatus_Click(object sender, EventArgs e)
        {
            Process.Start("http://lnkd.in/bJ3eyHY");
        }

        #endregion

    }
}
