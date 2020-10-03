﻿using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Trust_Your_Locals
{
    public class ComboBoxHandler
    {
        public ComboBoxHandler(ComboBox cb)
        {
            SQLConnectionHandler.MakeConnection();
            string query = "SELECT DISTINCT Name FROM Products";
            SqlDataAdapter da = new SqlDataAdapter(query, SQLConnectionHandler.GetConnection());
            DataTable dt = new DataTable();
            da.Fill(dt);

            DataRow dr = dt.NewRow();
            dr["Name"] = "Visi";
            dt.Rows.InsertAt(dr, 0);

            cb.DisplayMember = "Name";
            cb.ValueMember = "Name";
            cb.DataSource = dt;

        }

           
                
           
    }
}