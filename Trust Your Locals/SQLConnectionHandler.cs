using System;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Data;


namespace Trust_Your_Locals
{
	static class SQLConnectionHandler
	{
		const string connectionString= "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\Database1.mdf;Integrated Security=True";
		static SqlConnection conn;

		public static void MakeConnection()
        {
			conn = new SqlConnection(connectionString);
			conn.Open();
		}

		public static SqlConnection GetConnection()
        {
			return conn;
        }

		public static string getSellerIdByAdress(string adress)
        {
			SQLConnectionHandler.MakeConnection();
			string sqlQuery = "SELECT ID FROM Seller WHERE Adress= @adress";
			SqlCommand cmd = new SqlCommand(sqlQuery, SQLConnectionHandler.GetConnection());
			cmd.Parameters.Add("@adress", SqlDbType.NVarChar).Value = adress;
			string sellerID = cmd.ExecuteScalar().ToString();

			return sellerID;
		}


	}
}