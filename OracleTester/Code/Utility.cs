using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;

namespace OracleTester.Code
{
    class Utility
    {
        /// <summary>
        /// Get connection string to remote Oracle database.
        /// </summary>
        public static string RemoteConString
        {
            get
            {
                return ConfigurationManager.ConnectionStrings["RemoteConString"].ConnectionString;
            }
        }

        /// <summary>
        /// Get connection string to localhost Oracle database.
        /// </summary>
        public static string LocalConString
        {
            get
            {
                return ConfigurationManager.ConnectionStrings["LocalConString"].ConnectionString;
            }
        }

        /// <summary>
        /// Get value if to use remote connection string.
        /// </summary>
        public static bool UseRemoteConString
        {
            get
            {
                var useRcs = ConfigurationManager.AppSettings["UseRemoteConString"];
                return Convert.ToBoolean(useRcs);
            }
        }

        /// <summary>
        /// Get oracle connection object.
        /// </summary>
        public static OracleConnection OracleCon
        {
            get
            {
                return new OracleConnection(UseRemoteConString ? RemoteConString : LocalConString);
            }
        }

        /// <summary>
        /// Check if the concerned table exists or not.
        /// </summary>
        public static bool IsTableExist(string tableName, OracleConnection connection)
        {
            // Get table name from the tables in database
            var query = new StringBuilder("SELECT TABLE_NAME FROM DBA_TABLES WHERE TABLE_NAME='");
            query.Append(tableName.ToUpper()).Append("'");

            using (var selectCommand = new OracleCommand())
            {
                selectCommand.Connection = connection;
                selectCommand.CommandText = query.ToString();
                var result = selectCommand.ExecuteScalar();

                // If not null return true
                return result != null;
            }
        }

        /// <summary>
        /// Creates a new database table based on the passed columns
        /// </summary>
        /// <param name="tableName">The new table name</param>
        /// <param name="columns">The columns to be created</param>        
        /// <param name="connection">The Oracle connection</param>
        /// <param name="commandGenerator">The command text generator</param>
        public static void CreateTable(string tableName, List<DataGridViewColumn> columns, OracleConnection connection, IDBCommandGenerator commandGenerator)
        {
            // Create a new command
            using (var createCommand = new OracleCommand())
            {
                // Set the command connection
                createCommand.Connection = connection;

                // Generate the create command text and set it
                createCommand.CommandText = commandGenerator.GetCreateTableCommandText(tableName, columns);

                // Execute the command
                createCommand.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Drops a database table
        /// </summary>
        /// <param name="tableName">The table name</param>
        /// <param name="connection">The Oracle connection</param>
        /// <param name="commandGenerator">The command text generator</param>
        public static void DropTable(string tableName, OracleConnection connection, IDBCommandGenerator commandGenerator)
        {
            // Create a new command
            using (var dropCommand = new OracleCommand())
            {
                // Set the command connection
                dropCommand.Connection = connection;

                // Generate the drop command text and set it
                dropCommand.CommandText = commandGenerator.GetDropTableCommandText(tableName);

                // Execute the command
                dropCommand.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Insert records in the table.
        /// </summary>
        public static void InsertRecords(string tableName, OracleConnection connection, DataView dataView, List<DataGridViewColumn> columns, IDBCommandGenerator commandGenerator)
        {
            using (var insertCommand = new OracleCommand())
            {
                // Set the command connection
                insertCommand.Connection = connection;
                insertCommand.CommandText = commandGenerator.GetInsertCommandText(tableName, columns);

                // Loop within data rows in the data view
                for (var i = 0; i < dataView.Count; i++)
                {
                    // Set the command parameters from the current data row
                    SetInsertCommandParameters(insertCommand, dataView[i], columns);

                    // Execute the command
                    insertCommand.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Sets the insert command parameters from a data row
        /// </summary>
        /// <param name="insertCommand">The insert command</param>
        /// <param name="dataRowView">The data row view containing the data to be inserted</param>
        /// <param name="columns">The list of columns to be exported</param>
        public static void SetInsertCommandParameters(OracleCommand insertCommand, DataRowView dataRowView, List<DataGridViewColumn> columns)
        {
            // Clear the previous command parameters
            insertCommand.Parameters.Clear();

            // Loop within columns
            foreach (var column in columns)
            {
                var colName = column.Name;
                insertCommand.Parameters.Add(new OracleParameter(colName, dataRowView[colName]));
            }
        }
    }
}
