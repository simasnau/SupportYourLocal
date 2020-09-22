using System;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Data;


namespace Trust_Your_Locals
{
	static class SQLConnectionHandler
	{
		static string connectionString= "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=D:\\Downloads\\SupportYourLocal-master\\Trust Your Locals\\Database1.mdf;Integrated Security=True";
		static SqlConnection conn;

		static SQLConnectionHandler()
		{
		}
		public static void MakeConnection()
        {
			conn = new SqlConnection(connectionString);
			conn.Open();
		}

		public static SqlConnection GetConnection()
        {
			return conn;
        }


	}
}