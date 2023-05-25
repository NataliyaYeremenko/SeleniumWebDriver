using System;
using System.Data.SqlClient;

namespace CoreFramework.Utils
{
    public class DBHelpers
    {
        public static SqlConnection connection;
        private static string _startQuerry = "EXEC SP_SESSION_CONTEXT @Key = N'AdminBusinessCodeMask', @Value = 15;";
        //private static string _connectionString = "Data Source=tcp:bpm-dassql1-stg-eus.database.windows.net,1433;Initial Catalog=ForecastDB;User ID=usa-nyeremenko@deloitte.com;Password=R!tkGPB<aod53%q#EjKEc#Uh;";
        private static string _connectionString = "Server=tcp:bpm-dassql1-stg-eus.database.windows.net;Initial Catalog=Sefm;User ID=nyeremenko;Password=R!tkGPB<aod53%q#EjKEc#Uh;Connection Timeout=30;";
        //private static string _connectionString = "Server=bpmdatastore.database.windows.net;Initial Catalog=Efm;Persist Security Info=False;User ID=bpmadmin;Password=H1oxq0VU3w8;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        public static int ExecuteNonQueryScript(string sqlScript)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                using (var sqlCommand = new SqlCommand(sqlScript, connection))
                {
                    connection.Open();
                    var affectedRows = sqlCommand.ExecuteNonQuery();
                    return affectedRows;  
                }
            }
        }
        public static bool OpenConnection()
        {
            try
            {
                connection.Open();
                return true;
            }
            catch (SqlException)
            {
                return false;
            }


        }
        public static SqlDataReader ExecuteSqlScript (string sqlScript)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                using (var sqlCommand = new SqlCommand(sqlScript, connection))
                {
                    connection.Open();
                    ExecuteNonQueryScript(_startQuerry);
                    var readerResult = sqlCommand.ExecuteReader();
                    return readerResult;
                }
            }
        }
        public void ReadData(string sqlScript)
        {
            var reader = ExecuteSqlScript(sqlScript);
            while (reader.Read())
            {
                Console.WriteLine(reader.ToString());   
            }
            CloseConnection();
        }
        public static void CloseConnection()
        {
            connection.Close(); 
        }
    }
}
