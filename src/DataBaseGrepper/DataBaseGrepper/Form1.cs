using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using System.ComponentModel;
using System.Threading.Tasks;

namespace DataBaseGrepper
{
    public partial class Form1 : Form
    {
        BackgroundWorker bwFindAndPreview;
        BackgroundWorker bwFindReplaceGenerateScriptToFile;

        SqlConnection cn = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        SqlDataReader dr;

        bool isGenerateScripToFile;

        List<string> databaseTables;
        List<string> columnsNames;
        List<string> dataTypes;
        List<string> results;
        List<string> dbScript;

        public Form1()
        {
            InitializeComponent();
        }

        public void SetConnection(string serverName, string databaseName, string login, string password)
        {
            if (bwFindAndPreview != null && bwFindAndPreview.WorkerSupportsCancellation && bwFindAndPreview.IsBusy)
                bwFindAndPreview.CancelAsync();

            if (cn.State != System.Data.ConnectionState.Open)
            {
                cn.ConnectionString = "Data Source=" + serverName +
                    ";Initial Catalog=" + databaseName +
                    ";Persist Security Info=True;User ID=" + login +
                    ";Password=" + password;
                cmd.Connection = cn;
            }
        }

        private void LoadTableName()
        {
            databaseTables = new List<string>();
            cmd.CommandText = "select * from information_schema.tables where table_type='base table'";
            cn.Open();
            dr = cmd.ExecuteReader();

            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    databaseTables.Add(dr["Table_name"].ToString());
                }
            }

            cn.Close();
        }

        /// <summary>
        /// Load columns names based on the table index
        /// </summary>
        /// <param name="index">index of the database table</param>
        private void LoadColumnName(int index)
        {
            columnsNames = new List<string>();
            cmd.CommandText = "select column_name from information_schema.columns where table_name='" + databaseTables.ElementAt(index).ToString() + "'";
            cn.Open();
            dr = cmd.ExecuteReader();

            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    columnsNames.Add(dr[0].ToString());
                }
            }

            cn.Close();
        }

        /// <summary>
        /// Load the data type of the columns based on the table index
        /// </summary>
        /// <param name="index">index of the database table</param>
        private void LoadDataType(int index)
        {
            if (columnsNames.Count > 0)
            {
                dataTypes = new List<string>();

                for (int i = 0; i < columnsNames.Count; i++)
                {
                    string columnName = columnsNames.ElementAt(i).ToString();
                    cmd.CommandText = "select data_type from information_schema.columns where table_name='" + databaseTables.ElementAt(index).ToString() + "' and column_name='" + columnName + "'";
                    cn.Open();
                    dr = cmd.ExecuteReader();

                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            dataTypes.Add(dr[0].ToString());
                        }
                    }

                    cn.Close();
                }
            }
        }

        /// <summary>
        /// Determine the type of the data to be searched in the database
        /// </summary>
        /// <param name="str">data to be searched</param>
        /// <returns></returns>
        private string ParseInput(string str)
        {
            Boolean boolValue;
            Int32 intValue;
            float realValue;
            DateTime dateValue;

            if (Boolean.TryParse(str, out boolValue))
                return "bit";
            else if (Int32.TryParse(str, out intValue))
                return "int";
            else if (float.TryParse(str, out realValue))
                return "real";
            else if (DateTime.TryParse(str, out dateValue))
                return "datetime";
            else
                return "nvarchar";
        }

        /// <summary>
        /// Search the entire database for correspondences of the data input
        /// </summary>
        private void SearchDb()
        {
            for (int i = 0; i < databaseTables.Count; i++)
            {
                LoadColumnName(i);
                LoadDataType(i);

                int columnCount = columnsNames.Count;

                for (int j = 0; j < columnCount; j++)
                {
                    var tableName = databaseTables.ElementAt(i).ToString();
                    var columnName = columnsNames.ElementAt(j).ToString();
                    var dataType = ParseInput(txtFind.Text.ToString());

                    if (dataTypes.ElementAt(j).ToString() == dataType)
                    {
                        if (dataType != "int")
                            cmd.CommandText = "select distinct " + columnName + " from " + tableName + " where " + columnName + " like '%" + txtFind.Text.ToString() + "%'";
                        if (dataType == "int")
                            cmd.CommandText = "select " + columnName + " from " + tableName + " where " + columnName + " like '%" + txtFind.Text.ToString() + "%'";
                        if (dataType == "datetime")
                            cmd.CommandText = "select " + columnName + " from " + tableName + " where " + columnName + "='" + txtFind.Text.ToString() + "'";
                        cn.Open();
                        dr = cmd.ExecuteReader();

                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                if (bwFindAndPreview != null && bwFindAndPreview.IsBusy)
                                    bwFindAndPreview.ReportProgress(0, "Find - Table: " + tableName + " Column: " + columnName + " Content: " + dr[0].ToString());
                                if (bwFindReplaceGenerateScriptToFile != null && bwFindReplaceGenerateScriptToFile.IsBusy)
                                    bwFindReplaceGenerateScriptToFile.ReportProgress(0, "Find - Table: " + tableName + " Column: " + columnName + " Content: " + dr[0].ToString());

                                if (isGenerateScripToFile)
                                {
                                    string newEntry = dr[0].ToString().Replace(txtFind.Text, txtReplace.Text).Replace("\"", "\\\"");

                                    string sqlLine = "UPDATE " + tableName + " SET " + columnName + " = \"" + newEntry + "\" WHERE " + columnName + " = \"" + dr[0].ToString().Replace("\"", "\\\"").Replace("'", "''") + "\"";
                                    dbScript.Add(sqlLine);
                                }

                                Application.DoEvents();
                            }
                        }

                        cn.Close();
                    }
                }
            }
        }

        private void btnFindAndPreview_Click(object sender, EventArgs e)
        {
            SetConnection(txtServerName.Text, txtDatabaseName.Text, txtLogin.Text, txtPassword.Text);

            bwFindAndPreview = new BackgroundWorker();
            bwFindAndPreview.DoWork += BwFindAndPreview_DoWork;
            bwFindAndPreview.ProgressChanged += BwFindAndPreview_ProgressChanged;
            bwFindAndPreview.RunWorkerCompleted += BwFindAndPreview_RunWorkerCompleted;
            bwFindAndPreview.WorkerReportsProgress = true;
            bwFindAndPreview.WorkerSupportsCancellation = true;

            if (bwFindAndPreview.IsBusy != true)
            {
                rbResults.Clear();
                txtStatus.Text = "Finding in database";
                pbStatus.Style = ProgressBarStyle.Marquee;
                bwFindAndPreview.RunWorkerAsync();
            }
        }
        private void BwFindAndPreview_DoWork(object sender, DoWorkEventArgs e)
        {
            results = new List<string>();
            LoadTableName();
            SearchDb();
        }

        private void BwFindAndPreview_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            results.Add(e.UserState.ToString());
            rbResults.Text += e.UserState.ToString() + "\r\n";
        }

        private void BwFindAndPreview_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled == true)
            {
                MessageBox.Show("Canceled!");
            }
            else if (e.Error != null)
            {
                MessageBox.Show("Error: " + e.Error.Message);
            }
            else
            {
                txtStatus.Text = "Done finding";
                pbStatus.Style = ProgressBarStyle.Blocks;
            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (bwFindAndPreview != null && bwFindAndPreview.WorkerSupportsCancellation && bwFindAndPreview.IsBusy)
            {
                bwFindAndPreview.CancelAsync();
            }

            if (bwFindReplaceGenerateScriptToFile != null && bwFindReplaceGenerateScriptToFile.WorkerSupportsCancellation && bwFindReplaceGenerateScriptToFile.IsBusy)
            {
                bwFindReplaceGenerateScriptToFile.CancelAsync();
            }

            if (cn.State == System.Data.ConnectionState.Open)
                cn.Close();

            cn.Dispose();
        }

        private void btnFindReplaceGenerateScriptsToFile_Click(object sender, EventArgs e)
        {
            SetConnection(txtServerName.Text, txtDatabaseName.Text, txtLogin.Text, txtPassword.Text);

            bwFindReplaceGenerateScriptToFile = new BackgroundWorker();
            bwFindReplaceGenerateScriptToFile.DoWork += BwFindReplaceGenerateScriptToFile_DoWork;
            bwFindReplaceGenerateScriptToFile.ProgressChanged += BwFindReplaceGenerateScriptToFile_ProgressChanged;
            bwFindReplaceGenerateScriptToFile.RunWorkerCompleted += BwFindReplaceGenerateScriptToFile_RunWorkerCompleted;
            bwFindReplaceGenerateScriptToFile.WorkerReportsProgress = true;
            bwFindReplaceGenerateScriptToFile.WorkerSupportsCancellation = true;

            if (bwFindReplaceGenerateScriptToFile.IsBusy != true)
            {
                isGenerateScripToFile = true;
                rbResults.Clear();
                txtStatus.Text = "Finding in database";
                pbStatus.Style = ProgressBarStyle.Marquee;
                bwFindReplaceGenerateScriptToFile.RunWorkerAsync();
            }
        }

        private void BwFindReplaceGenerateScriptToFile_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled == true)
            {
                MessageBox.Show("Canceled!");
            }
            else if (e.Error != null)
            {
                MessageBox.Show("Error: " + e.Error.Message);
            }
            else
            {
                SaveFileDialog saveFileDialog1 = new SaveFileDialog();

                saveFileDialog1.Filter = "sql files (*.sql)|*.sql|All files (*.*)|*.*";
                saveFileDialog1.FilterIndex = 1;
                saveFileDialog1.RestoreDirectory = true;

                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    StreamWriter saveFile = new StreamWriter(saveFileDialog1.FileName);

                    saveFile.WriteLine("BEGIN TRY");
                    saveFile.WriteLine("BEGIN TRANSACTION");


                    foreach (var line in dbScript)
                    {
                        saveFile.WriteLine(line);
                    }

                    saveFile.WriteLine("COMMIT");
                    saveFile.WriteLine("END TRY");
                    saveFile.WriteLine("BEGIN CATCH");
                    saveFile.WriteLine("ROLLBACK");
                    saveFile.WriteLine("END CATCH");

                    saveFile.Close();
                }

                txtStatus.Text = "Done finding";
                pbStatus.Style = ProgressBarStyle.Blocks;
            }
        }

        private void BwFindReplaceGenerateScriptToFile_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            results.Add(e.UserState.ToString());
            rbResults.Text += e.UserState.ToString() + "\r\n";
        }

        private void BwFindReplaceGenerateScriptToFile_DoWork(object sender, DoWorkEventArgs e)
        {
            results = new List<string>();
            dbScript = new List<string>();
            LoadTableName();
            SearchDb();
        }

        private void btnSaveToFile_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();

            saveFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            saveFileDialog1.FilterIndex = 2;
            saveFileDialog1.RestoreDirectory = true;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                StreamWriter saveFile = new StreamWriter(saveFileDialog1.FileName);

                foreach (var line in results)
                {
                    saveFile.WriteLine(line);
                }

                saveFile.Close();
            }
        }
    }
}
