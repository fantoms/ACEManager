﻿using System;
using System.Collections.Generic;
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
            // Timouet Defaults:
            // ConnectionTimeout = 15
            // DefaultCommandTimeout = 30
            // ConnectionLifeTime = 0
            if (string.IsNullOrEmpty(DBConnectionString) || CurrentDatabase != databaseName)
                DBConnectionString = @"SERVER=" + ACEManager.Config.DatabaseHost + ";PORT=" + ACEManager.Config.DatabasePort + ";UID=" + ACEManager.Config.DatabaseUsername + ";PASSWORD=" + ACEManager.Config.DatabasePassword + ";" + (!string.IsNullOrEmpty(databaseName) ? "DATABASE=" + databaseName : "") + ";Allow User Variables=True;charset=utf8;convertzerodatetime=true;ConnectionTimeout=360;DefaultCommandTimeout=358;ConnectionLifeTime=3000;";
            
            MySqlConnection connection = new MySqlConnection(DBConnectionString);
            connection.Open();
            return connection;
        }

        public static string ExecuteBackup(string backupDestination, string databaseName)
        {
            if (backupDestination.Length == 0 || databaseName.Length == 0)
                return $"Error: invalid input";

            var result = "";
            try
            {
                result = BackupDatabase(backupDestination, databaseName);
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

        public static string ExecuteRestore(string backupSource, string databaseName)
        {
            if (backupSource.Length == 0 || databaseName.Length == 0)
                return $"Error: invalid input";

            var result = "";
            try
            {
                result = RestoreDatabase(backupSource, databaseName);
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

        public static string ExecuteQuery(string query, string databaseName)
        {
            var result = "";
            try
            {
                result = QueryDatabase(query, databaseName);
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
                result = RunScript(script, databaseName);
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

        private static string QueryDatabase(string query, string databaseName)
        {
            var resultString = "";
            using (MySqlConnection connection = Database.Connect(databaseName))
            using (MySqlCommand command = connection.CreateCommand())
            {
                command.CommandText = query;
                MySqlDataReader reader = command.ExecuteReader();
                resultString += $"Affected Rows: {reader.RecordsAffected}";
                connection.Close();
            }
            return resultString;
        }

        private static string RunScript(string script, string databaseName)
        {
            var resultString = "";
            using (MySqlConnection connection = Database.Connect(databaseName))
            {
                MySqlScript query = new MySqlScript(connection, script);
                query.Error += ACEManager.DatabaseMaintenanceForm.Database_MySqlError;
                query.StatementExecuted += ACEManager.DatabaseMaintenanceForm.Database_StatementExecuted;
                query.ScriptCompleted += ACEManager.DatabaseMaintenanceForm.Database_StatementCompleted;
                int count = query.Execute();
                resultString += $"Affected rows: {count.ToString()}";
                connection.Close();
            }
            return resultString;
        }

        private static List<string> GetTableList(string databaseName)
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
                connection.Close();
            }
            return results;
        }

        public static string TruncateTables(string databaseName)
        {
            string result = string.Empty;
            // go through each table and truncate
            List<string> databaseTables = GetTableList(databaseName);
            if (databaseTables.Count > 0)
            {
                try
                {
                    foreach (string dbTable in databaseTables)
                    {
                        result += $"Truncating data from {databaseName}.{dbTable}..." + Environment.NewLine;
                        // reset connection string to new database
                        using (MySqlConnection connection = Database.Connect(databaseName))
                        using (MySqlCommand query = connection.CreateCommand())
                        {
                            query.CommandText = $"TRUNCATE TABLE `{dbTable}`";
                            result += "int: " + query.ExecuteNonQuery().ToString() + Environment.NewLine;
                            connection.Close();
                        }
                    }
                    return result;
                }
                catch (SqlException ex)
                {
                    var errMsg = $"SQL connecting: {ex.Message}";
                    return errMsg;
                }
                catch (MySqlException ex)
                {
                    var errMsg = "Error: ";
                    // get the number from the inner exception
                    if (ex.InnerException != null)
                    {
                        var mySqlErrorNumber = Database.GetExceptionNumber(ex);
                        // create a short error message for the console log / label
                        errMsg += $"{mySqlErrorNumber} : {ex.InnerException.Message}";
                    }
                    else
                    {
                        errMsg += $"{ex.Message}";
                    }
                    // long message to console
                    return errMsg;
                }
                catch (Exception error)
                {
                    return error.Message;
                }
            }
            else
                return "No tables found!";
        }

        private static string BackupDatabase(string backupDestination, string databaseName)
        {
            string results;
            using (MySqlConnection connection = Database.Connect(databaseName))
            {
                using (MySqlCommand query = connection.CreateCommand())
                {
                    using (MySqlBackup mb = new MySqlBackup(query))
                    {
                        query.Connection = connection;
                        mb.ExportToFile(backupDestination);
                        connection.Close();
                        results = mb.ExportInfo.IntervalForProgressReport.ToString();
                    }
                }
            }
            return results;
        }

        private static string RestoreDatabase(string backupDestination, string databaseName)
        {
            string results;
            using (MySqlConnection connection = Database.Connect(databaseName))
            {
                using (MySqlCommand query = connection.CreateCommand())
                {
                    using (MySqlBackup mb = new MySqlBackup(query))
                    {
                        query.Connection = connection;
                        mb.ImportFromFile(backupDestination);
                        connection.Close();
                        results = mb.ImportInfo.IntervalForProgressReport.ToString();
                    }
                }
            }
            return results;
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
