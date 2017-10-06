using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Data.SqlClient;

namespace ACEManager
{
    public class Database
    {
        private static string DBConnectionString { get; set; }
        public static int MySqlErrorNumber { get; private set; }
        private static string CurrentDatabase { get; set; }
        public static MySqlConnection Connect(string databaseName)
        {
            if (string.IsNullOrEmpty(DBConnectionString) || CurrentDatabase != databaseName)
                DBConnectionString = @"SERVER=" + ACEManager.Config.DatabaseHost + ";PORT=" + ACEManager.Config.DatabasePort + ";UID=" + ACEManager.Config.DatabaseUsername + ";PASSWORD=" + ACEManager.Config.DatabasePassword + ";" + (!string.IsNullOrEmpty(databaseName) ? "DATABASE=" + databaseName : "") + ";Allow User Variables=True;";
            
            MySqlConnection connection = new MySqlConnection(DBConnectionString);
            connection.Open();
            return connection;
        }

        public static string Execute(string script, string databaseName)
        {
            var result = "";
            try
            {
                result = Query(script, databaseName);
            }
            catch (SqlException ex)
            {
                var errMsg = $"SQL Error in the downloaded data: {ex.Message}";
#if DEBUG
                Console.WriteLine(errMsg);
#endif
                return errMsg;
            }
            catch (MySqlException ex)
            {
                var errMsg = "Error: ";
                // get the number from the inner exception
                if (ex.InnerException != null)
                {
                    MySqlErrorNumber = GetExceptionNumber(ex);
                    // create a short error message for the console log / label
                    errMsg += $"{MySqlErrorNumber} : {ex.InnerException.Message}";
                } else
                {
                    errMsg += $"{ex.Message}";
                }
#if DEBUG
                // long message to console
                Console.WriteLine(errMsg);
#endif
                return errMsg;
            }
            catch (Exception e)
            {
                var errMsg = $"Error: {e.Message}";
#if DEBUG
                Console.WriteLine(errMsg);
#endif
                return errMsg;
            }
            return $"{result}";
        }

        public static string ExecuteScript(string script, string databaseName)
        {
            var result = "";
            try
            {
                result = QueryScript(script, databaseName);
            }
            catch (SqlException ex)
            {
                var errMsg = $"SQL Error in the downloaded data: {ex.Message}";
#if DEBUG
                Console.WriteLine(errMsg);
#endif
                return errMsg;
            }
            catch (MySqlException ex)
            {
                var errMsg = "Error";
                // get the number from the inner exception
                if (ex.InnerException != null)
                {
                    MySqlErrorNumber = GetExceptionNumber(ex);
                    // create a short error message for the console log / label
                    errMsg += $"{MySqlErrorNumber} : {ex.InnerException.Message}";
                }
                else
                {
                    errMsg += $"{ex.Message}";
                }
#if DEBUG
                // long message to console
                Console.WriteLine(errMsg);
#endif
                return errMsg;
            }
            catch (Exception e)
            {
                var errMsg = $"Error: {e.Message}";
#if DEBUG
                Console.WriteLine(errMsg);
#endif
                return errMsg;
            }
            return $"{result}";
        }

        private static string Query(string script, string databaseName)
        {
            var resultString = "";
            using (MySqlConnection connection = Database.Connect(databaseName))
            using (MySqlCommand query = connection.CreateCommand())
            {
                query.CommandText = script;
                MySqlDataReader reader = query.ExecuteReader();
                resultString += $"Affected Rows: {reader.RecordsAffected}";
            }
            return resultString;
        }

        private static string QueryScript(string script, string databaseName)
        {
            var resultString = "";
            using (MySqlConnection connection = Database.Connect(databaseName))
            {
                MySqlScript query = new MySqlScript(connection, script);
                // TODO: Regex capture actual delimter, instead of forcing "$$";
                if (script.Contains("DELIMITER"))
                {
                    query.Delimiter = "$$";
                }
                query.Error += ACEManager.DatabaseMaintenanceForm.Database_MySqlError;
                query.StatementExecuted += ACEManager.DatabaseMaintenanceForm.Database_StatementExecuted;
                query.ScriptCompleted += ACEManager.DatabaseMaintenanceForm.Database_StatementCompleted;
                int count = query.Execute();
                resultString += $"Affected rows: {count.ToString()}";
            }
            return resultString;
        }

        private static List<string> DatabaseTables(string databaseName)
        {
            List<string> results = new List<string>();
            using (MySqlConnection connection = Database.Connect(databaseName))
            using (MySqlCommand query = connection.CreateCommand())
            {
                query.CommandText = "SHOW TABLES;";
                MySqlDataReader reader = query.ExecuteReader();
                while (reader.Read())
                {
                    // 0 should be table names
                    results.Add(reader.GetString(0));
                }
            }
            return results;
        }

        public static string TruncateTables(string databaseName)
        {
            string result = string.Empty;
            // go through each table and truncate
            List<string> databaseTables = DatabaseTables(databaseName);
            if (databaseTables.Count > 0)
            {
                foreach (string dbTable in databaseTables)
                {
                    result += $"Truncating data from {databaseName}.{dbTable}..." + Environment.NewLine;
                    // reset connection string to new database
                    using (MySqlConnection connection = Database.Connect(databaseName))
                    using (MySqlCommand query = connection.CreateCommand())
                    {
                        query.CommandText = $"TRUNCATE TABLE {dbTable}";
                        result += "int: " + query.ExecuteNonQuery().ToString() + Environment.NewLine;
                    }
                }
                return result;
            }
            else
                return "No tables found!";
        }

        public static int GetExceptionNumber(MySqlException my)
        {
            if (my != null)
            {
                int number = my.Number;
                // if the number is zero, try to get the number of the inner exception
                if (number == 0 && (my = my.InnerException as MySqlException) != null)
                {
                    number = my.Number;
                }
                return number;
            }
            return -1;
        }
    }
}
