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
            string fileName = @"C:\\Users\\Kestas\\Desktop\\2KURSAS\\PSI\\IProgramosPhase\\" + name + ".txt";
            int ID = findID(name);
            if (File.Exists(fileName))
            {
                System.IO.StreamReader file =
                new System.IO.StreamReader(fileName);
                float stars = Convert.ToInt32(file.ReadLine());
                file.Close();
                float starRate = (stars + star) / 2;
                //System.IO.StreamWriter file2 = new StreamWriter(fileName, true);
                //
                //file2.WriteLine(starRate);
                ////file2 = File.AppendText(fileName);
                ////file2.WriteLine(comment);
                //file2.Close();
                lineChanger(starRate.ToString(), fileName, 1);

                StreamWriter sr;

                sr = File.AppendText(fileName);

                sr.WriteLine(comment);
                sr.Close();
                //using (sr = new StreamWriter(fileName))
                //{
                //    string s = "";
                //    //while ((s = sr.ReadLine()) != null )
                //    //{ }
                //    File.AppendAllText(fileName);
                //    Byte[] _comment = new UTF8Encoding(true).GetBytes(comment + "\n");
                //    sr.Write(_comment, 0, _comment.Length);
                //}
            }
            else
            using (FileStream fs = File.Create(fileName))
            {
                Byte[] _star = new UTF8Encoding(true).GetBytes(star.ToString() + "\n");
                fs.Write(_star, 0, _star.Length);
                Byte[] id = new UTF8Encoding(true).GetBytes(ID.ToString() + "\n");
                fs.Write(id, 0, id.Length);
                Byte[] _name = new UTF8Encoding(true).GetBytes(name + "\n");
                fs.Write(_name, 0, _name.Length);
                Byte[] _comment = new UTF8Encoding(true).GetBytes(comment);
                fs.Write(_comment, 0, _comment.Length);
            }







            //int l=0;
            ////  f.comment = comment;
            //

            //foreach(var i in f.ID)
            //{
            //    l++;

            //    if (ID == i)
            //    {


            //    }

            //}
            //if (l==0)
            //{
            //    if (f.starOverall[0] == 0 )
            //        f.starOverall[0] = star;
            //    else f.starOverall[0] = (f.starOverall[0] + star)/2;
            //    f.ID[0] = ID;
            //    f.name[0] = name;
            //    f.comment[0] = comment;
            //}
        }
        private int findID(string name)
        {
            
            SQLConnectionHandler.MakeConnection();
            string query = "SELECT DISTINCT \"ID\" FROM Seller WHERE \"Name:\" LIKE '%" + name + "%'";
            SqlDataAdapter da = new SqlDataAdapter(query, SQLConnectionHandler.GetConnection());
            DataTable dt = new DataTable();
            da.Fill(dt);
            
            //Console.Out.Write(dt);
           // MessageBox.Show(dt.Rows[0].ItemArray[0].ToString());
            //string identify = dt.Rows[0].ItemArray[0].ToString();
            int id = Convert.ToInt32(dt.Rows[0].ItemArray[0]);
            return id;
            //      comboBox2.DisplayMember = "ID";
            //     comboBox2.ValueMember = "ID";
            //     comboBox2.DataSource = dt;
        }

        struct FarmerRating {
            public int[] ID;
            public string[] name;
            public int star;
            public float[] starOverall;
            public string[] comment;
        } FarmerRating f;
        

        private void button2_Click(object sender, EventArgs e)
        {

            if (checkedListBox1.CheckedItems.Count != 0)
            {//string s;

                // String m = comboBox2.SelectedItem.ToString();
                // MessageBox.Show(m); 
                for (int i = 0; i <= (checkedListBox1.Items.Count - 1); i++)
                {
                    if (checkedListBox1.GetItemChecked(i))
                    {
                        string namely = comboBox2.Text;
                        string commently = textBox1.Text;
                        addRating(namely, commently, i+1);
                       // MessageBox.Show(namely);
                    }
                }

                Close();
            }
            else
            { MessageBox.Show("Please choose a rating"); }
            // DialogResult dr = MessageBox.Show("Rating added");
            RatingForm Form_3 = new RatingForm();

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(textBox2.Text);
            SQLConnectionHandler.MakeConnection();
            string query = "SELECT DISTINCT \"Name:\" FROM Seller WHERE \"Name:\" LIKE '%" + textBox2.Text + "%'";
            SqlDataAdapter da = new SqlDataAdapter(query, SQLConnectionHandler.GetConnection());
            DataTable dt = new DataTable();
            da.Fill(dt);

            comboBox2.DisplayMember = "Name:";
            comboBox2.ValueMember = "Name:";
            comboBox2.DataSource = dt;
        }
    }
}
