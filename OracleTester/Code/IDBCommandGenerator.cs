using System.Collections.Generic;
using System.Windows.Forms;

namespace OracleTester.Code
{
    /// <summary>
    /// This abstract class should be implemented by all database command generators
    /// </summary>
    public abstract class IDBCommandGenerator
    {
        /// <summary>
        /// Returns the truncate table command text for the provided table name
        /// </summary>
        /// <param name="tableName">The table name to truncate</param>
        /// <returns>The truncate table command text for the provided table name</returns>
        public abstract string GetTruncateTableCommandText(string tableName);

        /// <summary>
        /// Returns the drop table command text for the provided table name
        /// </summary>
        /// <param name="tableName">The table name to drop</param>
        /// <returns>The drop table command text for the provided table name</returns>
        public abstract string GetDropTableCommandText(string tableName);

        /// <summary>
        /// Generates the create table command based on the passed table name and columns
        /// </summary>
        /// <param name="tableName">The table name to create</param>
        /// <param name="columns">The columns that will be included in the table</param>        
        /// <returns>The create table command</returns>
        public abstract string GetCreateTableCommandText(string tableName, List<DataGridViewColumn> columns);

        /// <summary>
        /// Generates the insert command based on the passed table name and columns
        /// </summary>
        /// <param name="tableName">The table name to insert into</param>
        /// <param name="columns">The columns that will be inserted into the table</param>   
        /// <returns>The insert into table command</returns>
        public abstract string GetInsertCommandText(string tableName, List<DataGridViewColumn> columns);
    }
}
