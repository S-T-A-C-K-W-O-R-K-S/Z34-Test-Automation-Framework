//using Microsoft.Data.Sqlite;
//using System;
//using System.Data;
//using System.Diagnostics.CodeAnalysis;

//namespace FrameworkCore.Helpers
//{
//    public static class SQLDatabaseHelpers
//    {
//        [SuppressMessage("Style", "IDE0060: Remove Unused Parameter", Justification = "False-Positive")]
//        [SuppressMessage("Design", "CA1031:Do Not Catch General Exception Types", Justification = "Exception Type Is Unknown")]
//        public static SqliteConnection DBConnect(this SqliteConnection sqlConnection, string connectionString)
//        {
//            try
//            {
//                sqlConnection = new SqliteConnection(connectionString);
//                sqlConnection.Open();
//                return sqlConnection;
//            }

//            catch (Exception /* exception */) { /* LegacyLogHelpers.WriteToLog($"[ERROR] :: [DATABASE] :: {exception.Message}"); */ }

//            return null;
//        }

//        [SuppressMessage("Style", "IDE0060: Remove Unused Parameter", Justification = "False-Positive")]
//        [SuppressMessage("Design", "CA1031:Do Not Catch General Exception Types", Justification = "Exception Type Is Unknown")]
//        public static void DBClose(this SqliteConnection sqlConnection, string connectionString)
//        {
//            try { sqlConnection.Close(); }

//            catch (Exception /* exception */) { /* LegacyLogHelpers.WriteToLog($"[ERROR] :: [DATABASE] :: {exception.Message}"); */ }
//        }

//		[SuppressMessage("Security", "CA2100: Review SQL Queries For Security Vulnerabilities", Justification = "Not Needed")]
//		[SuppressMessage("Style", "IDE0059: Unnecessary Assignment Of A Value", Justification = "False-Positive")]
//		[SuppressMessage("Design", "CA1031:Do Not Catch General Exception Types", Justification = "Exception Type Is Unknown")]
//		public static DataTable ExecuteQuery(this SqliteConnection sqlConnection, string queryString)
//		{
//			DataSet dataSet;

//			try
//			{
//				if (sqlConnection is null || sqlConnection is not null && (sqlConnection.State.Equals(ConnectionState.Closed) || sqlConnection.State.Equals(ConnectionState.Broken)))
//					sqlConnection?.Open();

//				SqliteDataAdapter dataAdapter = new SqliteDataAdapter
//				{
//					SelectCommand = new SqliteCommand(queryString, sqlConnection)
//					{
//						CommandType = CommandType.Text
//					}
//				};

//				dataSet = new DataSet();
//				dataAdapter.Fill(dataSet, "table");

//				sqlConnection?.Close();
//				dataAdapter.Dispose();

//				return dataSet.Tables["table"];
//			}

//			catch (Exception /* exception */)
//			{
//				dataSet = null;
//				sqlConnection?.Close();

//				// LegacyLogHelpers.WriteToLog($"[ERROR] :: [DATABASE] :: {exception.Message}");

//				return null;
//			}

//			finally
//			{
//				dataSet = null;
//				sqlConnection?.Close();
//			}
//		}
//	}
//}

