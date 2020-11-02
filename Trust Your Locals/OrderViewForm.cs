using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Trust_Your_Locals
{
    public partial class OrderViewForm : Form
    {
        public OrderViewForm(int userId=0)
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            InitializeComponent();
            string sqlQuery = "SELECT Name, FORMAT(Time, N'hh\\:mm') AS Time, Quantity, Adress FROM Orders, Seller WHERE ID=\"Seller ID\" AND \"Buyer ID\"="+userId;
            DataTable dt = new DataTable();
            SQLConnectionHandler.MakeConnection();
            SqlDataAdapter da = new SqlDataAdapter(sqlQuery, SQLConnectionHandler.GetConnection());
            da.Fill(dt);
            
            dataGridView1.DataSource = dt;
        }

        private void OrderViewForm_Load(object sender, System.EventArgs e)
        {

        }
    }
}
