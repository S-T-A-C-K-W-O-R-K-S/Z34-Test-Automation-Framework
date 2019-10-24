using System;
using System.Data;
using System.Data.SqlClient;

namespace Framework.Helpers
{
    public static class DatabaseExtentionHelpers
    {
        public static SqlConnection DBConnect(this SqlConnection sqlConnection, string connectionString)
        {
            try
            {
                sqlConnection = new SqlConnection(connectionString);
                sqlConnection.Open();
                return sqlConnection;
            }

            catch (Exception exception)
            {
                LogHelpers.WriteToLog("ERROR :: " + exception.Message);
            }

            return null;
        }

        public static void DBClose(this SqlConnection sqlConnection, string connectionString)
        {
            try
            {
                sqlConnection.Close();
            }

            catch (Exception exception)
            {
                LogHelpers.WriteToLog("ERROR :: " + exception.Message);
            }
        }

        public static DataTable ExecuteQuery(this SqlConnection sqlConnection, string queryString)
        {
            DataSet dataSet;

            try
            {
                if (sqlConnection == null || sqlConnection != null && (sqlConnection.State == ConnectionState.Closed || sqlConnection.State == ConnectionState.Broken))
                    sqlConnection.Open();

                SqlDataAdapter dataAdapter = new SqlDataAdapter();
                dataAdapter.SelectCommand = new SqlCommand(queryString, sqlConnection);
                dataAdapter.SelectCommand.CommandType = CommandType.Text;

                dataSet = new DataSet();
                dataAdapter.Fill(dataSet, "table");
                sqlConnection.Close();

                return dataSet.Tables["table"];
            }

            catch (Exception exception)
            {
                dataSet = null;
                sqlConnection.Close();

                LogHelpers.WriteToLog("ERROR :: " + exception.Message);
                return null;
            }

            finally
            {
                dataSet = null;
                sqlConnection.Close();
            }
        }
    }
}