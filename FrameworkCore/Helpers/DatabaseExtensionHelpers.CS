using System;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.CodeAnalysis;

namespace FrameworkCore.Helpers
{
    public static class DatabaseExtensionHelpers
    {
        [SuppressMessage("Style", "IDE0060: Remove Unused Parameter", Justification = "False-Positive")]
        [SuppressMessage("Design", "CA1031:Do Not Catch General Exception Types", Justification = "Exception Type Is Unknown")]
        public static SqlConnection DBConnect(this SqlConnection sqlConnection, string connectionString)
        {
            try
            {
                sqlConnection = new SqlConnection(connectionString);
                sqlConnection.Open();
                return sqlConnection;
            }

            catch (Exception exception) { LogHelpers.WriteToLog($"[ERROR] :: [DATABASE] :: {exception.Message}"); }

            return null;
        }

        [SuppressMessage("Style", "IDE0060: Remove Unused Parameter", Justification = "False-Positive")]
        [SuppressMessage("Design", "CA1031:Do Not Catch General Exception Types", Justification = "Exception Type Is Unknown")]
        public static void DBClose(this SqlConnection sqlConnection, string connectionString)
        {
            try { sqlConnection.Close(); }

            catch (Exception exception) { LogHelpers.WriteToLog($"[ERROR] :: [DATABASE] :: {exception.Message}"); }
        }

        [SuppressMessage("Security", "CA2100: Review SQL Queries For Security Vulnerabilities", Justification = "Not Needed")]
        [SuppressMessage("Style", "IDE0059: Unnecessary Assignment Of A Value", Justification = "False-Positive")]
        [SuppressMessage("Design", "CA1031:Do Not Catch General Exception Types", Justification = "Exception Type Is Unknown")]
        public static DataTable ExecuteQuery(this SqlConnection sqlConnection, string queryString)
        {
            DataSet dataSet;

            try
            {
                if (sqlConnection == null || sqlConnection != null && (sqlConnection.State == ConnectionState.Closed || sqlConnection.State == ConnectionState.Broken))
                    sqlConnection?.Open();

                SqlDataAdapter dataAdapter = new SqlDataAdapter
                {
                    SelectCommand = new SqlCommand(queryString, sqlConnection)
                    {
                        CommandType = CommandType.Text
                    }
                };

                dataSet = new DataSet();
                dataAdapter.Fill(dataSet, "table");

                sqlConnection?.Close();
                dataAdapter.Dispose();

                return dataSet.Tables["table"];
            }

            catch (Exception exception)
            {
                dataSet = null;
                sqlConnection?.Close();

                LogHelpers.WriteToLog($"[ERROR] :: [DATABASE] :: {exception.Message}");

                return null;
            }

            finally
            {
                dataSet = null;
                sqlConnection?.Close();
            }
        }
    }
}