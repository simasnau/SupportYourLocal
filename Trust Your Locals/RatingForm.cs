using System;
using System.Collections.Generic;
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
            string query = "SELECT DISTINCT \"Name:\" FROM Seller";
            SqlDataAdapter da = new SqlDataAdapter(query, SQLConnectionHandler.GetConnection());
            DataTable dt = new DataTable();
            da.Fill(dt);

            cb.DisplayMember = "Name:";
            cb.ValueMember = "Name:";
            cb.DataSource = dt;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form3_Load(object sender, EventArgs e)
        {
                if (comboBox2.Items.Contains(textBox2.Text))
                    comboBox2.Items.RemoveAt(1);
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

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
            string fileName = AppDomain.CurrentDomain.BaseDirectory; // Path.Combine(AppDomain.CurrentDomain.BaseDirectory, name + ".txt");
            fileName = fileName.Replace("\\Trust Your Locals\\bin\\Debug", "");
            fileName = Path.Combine(fileName, name + ".txt");
            
            int ID = findID(name);
            if (File.Exists(fileName))
            {
                System.IO.StreamReader file = new System.IO.StreamReader(fileName);
                float stars = Convert.ToInt32(file.ReadLine());
                int n = Convert.ToInt32(file.ReadLine());
                file.Close();
                n++;
                float starRate = (stars + star);
                lineChanger(starRate.ToString(), fileName, 1);
                lineChanger(n.ToString(), fileName, 2);

                if (comment == null || comment == "") { }
                else
                {
                    StreamWriter sr;
                    sr = File.AppendText(fileName);
                    sr.WriteLine(comment); 
                    sr.Close();
                }
            }
            else
            using (FileStream fs = File.Create(fileName))
            {
                Byte[] _star = new UTF8Encoding(true).GetBytes(star.ToString() + "\n");
                fs.Write(_star, 0, _star.Length);
                Byte[] _count = new UTF8Encoding(true).GetBytes("1" + "\n");
                fs.Write(_count, 0, _star.Length);
                Byte[] _name = new UTF8Encoding(true).GetBytes(name + "\n");
                fs.Write(_name, 0, _name.Length);
                    if (comment == null || comment == "") { }
                    else{
                        Byte[] _comment = new UTF8Encoding(true).GetBytes(comment);
                        fs.Write(_comment, 0, _comment.Length);
                    }
            }

        }
        private int findID(string name)
        {
            
            SQLConnectionHandler.MakeConnection();
            string query = "SELECT DISTINCT \"ID\" FROM Seller WHERE \"Name:\" LIKE '%" + name + "%'";
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
                        addRating(namely, commently, i+1);
                    }
                }

                Close();
            }
            else
            { MessageBox.Show("Please choose a rating"); }
            RatingForm Form_3 = new RatingForm();

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SQLConnectionHandler.MakeConnection();
            string query = "SELECT DISTINCT \"Name:\" FROM Seller WHERE \"Name:\" LIKE '%" + textBox2.Text + "%'";
            SqlDataAdapter da = new SqlDataAdapter(query, SQLConnectionHandler.GetConnection());
            DataTable dt = new DataTable();
            da.Fill(dt);

            comboBox2.DisplayMember = "Name:";
            comboBox2.ValueMember = "Name:";
            comboBox2.DataSource = dt;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string pathName = AppDomain.CurrentDomain.BaseDirectory;//Path.Combine(AppDomain.CurrentDomain.BaseDirectory, comboBox2.Text + ".txt");
            pathName = pathName.Replace("\\Trust Your Locals\\bin\\Debug", "");
            pathName = Path.Combine(pathName, comboBox2.Text + ".txt");
            if (File.Exists(pathName))
            {
                listView1.Clear();
                System.IO.StreamReader file = new System.IO.StreamReader(pathName);
                double stars = Math.Round((Convert.ToDouble(file.ReadLine())*1.0) / Convert.ToDouble(file.ReadLine()) *1.0, 1);
                listView1.Items.Add("Prekyvietes pavadinimas: " + file.ReadLine() + "\n");
                listView1.Items.Add("Reitingas: " + stars.ToString() + " ★");
                listView1.Items.Add("Komentarai:" + "\n");
                string line;
                while ((line = file.ReadLine()) != null)
                    listView1.Items.Add(line);
                file.Close();
            }
            else MessageBox.Show("No ratings or comments exist for this seller yet.");
                    
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
