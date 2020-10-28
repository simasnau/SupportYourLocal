using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Windows.Forms.VisualStyles;
using System.IO;
using System.Net.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Runtime.CompilerServices;

namespace Trust_Your_Locals
{
    public partial class RatingForm : Form
    {

        int ix = 0;

        public RatingForm()
        {
            InitializeComponent();
            fillCombo(comboBox2);
        }
        void fillCombo(ComboBox cb)
        {

            SQLConnectionHandler.MakeConnection();
            string query = "SELECT DISTINCT \"Seller name\" FROM Seller";
            SqlDataAdapter da = new SqlDataAdapter(query, SQLConnectionHandler.GetConnection());
            DataTable dt = new DataTable();
            da.Fill(dt);

            cb.DisplayMember = "Seller name";
            cb.ValueMember = "Seller name";
            cb.DataSource = dt;
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            if (comboBox2.Items.Contains(textBox2.Text))
                comboBox2.Items.RemoveAt(1);
        }

        private void checkedListBox1_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            for (ix = 0; ix < checkedListBox1.Items.Count; ++ix)
                if (ix != e.Index) checkedListBox1.SetItemChecked(ix, false);
        }
        static void lineChanger(string newText, string fileName, int line_to_edit)
        {
            string[] arrLine = File.ReadAllLines(fileName);
            arrLine[line_to_edit - 1] = newText;
            File.WriteAllLines(fileName, arrLine);
        }
        private void addRating(String name, String comment, int star)
        {
            string fileName = AppDomain.CurrentDomain.BaseDirectory;
            fileName = fileName.Replace("\\Trust Your Locals\\bin\\Debug", "");
            fileName = Path.Combine(fileName, name + ".json");
            Farmer farmer = new Farmer()
            {
                Name = name,
                Rating = star,
                Comment = comment
            };
            int ID = findID(name);
            if (File.Exists(fileName))
            {
                string JResult = JsonConvert.SerializeObject(farmer);
                StreamWriter sr;
                sr = File.AppendText(fileName);
                sr.WriteLine(JResult);
                sr.Close();
            }
            else
                using (StreamWriter fs = new StreamWriter(fileName))
                {
                    string JResult = JsonConvert.SerializeObject(farmer);
                    fs.WriteLine(JResult);
                }
        }
        private int findID(string name)
        {

            SQLConnectionHandler.MakeConnection();
            string query = "SELECT DISTINCT \"ID\" FROM Seller WHERE \"Seller name\" LIKE '%" + name + "%'";
            SqlDataAdapter da = new SqlDataAdapter(query, SQLConnectionHandler.GetConnection());
            DataTable dt = new DataTable();
            da.Fill(dt);

            int id = Convert.ToInt32(dt.Rows[0].ItemArray[0]);
            return id;
        }

        private void button2_Click(object sender, EventArgs e)
        {

            if (checkedListBox1.CheckedItems.Count != 0)
            {
                for (int i = 0; i <= (checkedListBox1.Items.Count - 1); i++)
                {
                    if (checkedListBox1.GetItemChecked(i))
                    {
                        string namely = comboBox2.Text;
                        string commently = textBox1.Text;
                        addRating(namely, commently, i + 1);
                    }
                }

                Close();
            }
            else
            { MessageBox.Show("Please choose a rating"); }
            RatingForm Form_3 = new RatingForm();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SQLConnectionHandler.MakeConnection();
            string query = "SELECT DISTINCT \"Seller name\" FROM Seller WHERE \"Seller name\" LIKE '%" + textBox2.Text + "%'";
            SqlDataAdapter da = new SqlDataAdapter(query, SQLConnectionHandler.GetConnection());
            DataTable dt = new DataTable();
            da.Fill(dt);

            comboBox2.DisplayMember = "Seller name";
            comboBox2.ValueMember = "Seller name";
            comboBox2.DataSource = dt;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string pathName = AppDomain.CurrentDomain.BaseDirectory;
            pathName = pathName.Replace("\\Trust Your Locals\\bin\\Debug", "");
            pathName = Path.Combine(pathName, comboBox2.Text + ".json");
            if (File.Exists(pathName))
            {
                listView1.Clear();
                System.IO.StreamReader ratingsFile = new System.IO.StreamReader(pathName);
                string JRead;
                int n = 0;
                int Rate = 0;
                while ((JRead = ratingsFile.ReadLine()) != null)
                {
                    Farmer GetRatings = JsonConvert.DeserializeObject<Farmer>(JRead);
                    Rate += GetRatings.Rating;
                    n++;
                }
                double Overall = Math.Round((Rate * 1.0 / n), 1);
                ratingsFile.Close();
                StreamReader fileForData = new StreamReader(pathName);
                listView1.Items.Add("Seller: \"" + comboBox2.Text + "\":\n");
                listView1.Items.Add("Overall rating: " + Overall + " ★\n");
                listView1.Items.Add("Individual ratings: ");
                while ((JRead = fileForData.ReadLine()) != null)
                {
                    Farmer farmerData = JsonConvert.DeserializeObject<Farmer>(JRead);
                    listView1.Items.Add(farmerData.ToString());
                }
                fileForData.Close();
            }
            else MessageBox.Show("No ratings or comments exist for this seller yet.");

        }

    }
}