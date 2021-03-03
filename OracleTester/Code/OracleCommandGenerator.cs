using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace OracleTester.Code
{
    /// <summary>
    /// This class generates SQL commands for an Oracle database
    /// </summary>
    public class OracleCommandGenerator : IDBCommandGenerator
    {
        /// <summary>
        /// Returns the truncate table command text for the provided table name
        /// </summary>
        /// <param name="tableName">The table name to truncate</param>
        /// <returns>The truncate table command text for the provided table name</returns>
        public override string GetTruncateTableCommandText(string tableName)
        {
            // Return the truncate table command
            return string.Format(@"TRUNCATE TABLE {0}", tableName);
        }

        /// <summary>
        /// Returns the drop table command text for the provided table name
        /// </summary>
        /// <param name="tableName">The table name to drop</param>
        /// <returns>The drop table command text for the provided table name</returns>
        public override string GetDropTableCommandText(string tableName)
        {
            // Return the drop table command
            return string.Format(@"DROP TABLE {0}", tableName);
        }

        /// <summary>
        /// Generates the create table command based on the passed table name and columns
        /// </summary>
        /// <param name="tableName">The table name to create</param>
        /// <param name="columns">The columns that will be included in the table</param>        
        /// <returns>The create table command</returns>
        public override string GetCreateTableCommandText(string tableName, List<DataGridViewColumn> columns)
        {
            // Create a new string builder to build the command
            StringBuilder sbCommand = new StringBuilder();

            // Append the create table command with the table name
            sbCommand.AppendFormat(@"CREATE TABLE {0}", tableName);
            sbCommand.Append("(");

            // Loop within columns
            foreach (var column in columns)
            {
                //if (column.Name == "Rank")
                //{
                //    sbCommand.AppendFormat(@"{0} ", column.Name);
                //    sbCommand.AppendFormat("NUMBER({0}) ", 1);
                //}
                //else
                //{
                //    sbCommand.AppendFormat(@"{0} ", column.Name);
                //    sbCommand.AppendFormat("NVARCHAR2({0}) ", "1024");
                //}


                sbCommand.AppendFormat(@"{0} ", column.Name);
                sbCommand.AppendFormat("NVARCHAR2({0}) ", "1024");

                // If this is not the last column, append a comma
                if (column != columns[columns.Count - 1])
                    sbCommand.Append(",");
            }

            // Append the closing parentheses
            sbCommand.Append(")");

            // Return the command string
            return sbCommand.ToString();
        }

        /// <summary>
        /// Generates the insert command based on the passed table name and columns
        /// </summary>
        /// <param name="tableName">The table name to insert into</param>
        /// <param name="columns">The columns that will be inserted into the table</param>   
        /// <returns>The insert into table command</returns>
        public override string GetInsertCommandText(string tableName, List<DataGridViewColumn> columns)
        {
            // This string builder will build a comma separated list of column names
            var sbColumnNames = new StringBuilder();

            // This string builder will build a comma separated list of for the parameters
            var sbValues = new StringBuilder();

            // Loop within columns
            foreach (var column in columns)
            {
                // Append the column name and parameter
                sbColumnNames.AppendFormat(@"{0}", column.Name);
                sbValues.Append(":").Append(column.Name);

                // If this is not the last column, append commas
                if (column == columns[columns.Count - 1]) continue;
                sbColumnNames.Append(",");
                sbValues.Append(",");
            }

            // Format and return the insert into command
            return string.Format(@"INSERT INTO {0} ({1}) VALUES({2})", tableName, sbColumnNames, sbValues);
        }
    }
}
