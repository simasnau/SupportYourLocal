using System;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Data;
using System.Windows.Forms;

namespace Trust_Your_Locals
{
    partial class Form1
    {
        private Button button1;
        private TextBox textBox1;
        private ComboBox comboBox1;
       
    
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
       
            this.components = new System.ComponentModel.Container();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(381, 150);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(111, 53);
            this.button1.TabIndex = 0;
            this.button1.Text = "Get Data";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += Button1_Click;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(345, 73);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(173, 40);
            this.textBox1.TabIndex = 1;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(111, 73);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(161, 28);
            this.comboBox1.TabIndex = 2;
            this.comboBox1.SelectedIndexChanged += ComboBox1_SelectedIndexChanged;
           
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 562);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button1);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Form1";
            this.Text = "Trust Your Locals";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e) {
        //When selected item changes, textBox changes.
            textBox1.Text = comboBox1.SelectedValue.ToString();
        }

        private void Button1_Click(object sender, System.EventArgs e) { 
        //This Function connects to local database on button press and populates the combo box
            try {
                // INSERT YOUR OWN CONNECTION STRING
                string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Programavimas\\VU\\2 Kursas\\PSI\\test\\Trust Your Locals\\Trust Your Locals\\Database1.mdf;Integrated Security=True";
                SqlConnection conn = new SqlConnection(connectionString);
                string query = "SELECT DISTINCT Name FROM Products";
                conn.Open();
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataSet ds = new DataSet();
                da.Fill(ds, "Products");
                comboBox1.DisplayMember = "Name";
                comboBox1.ValueMember = "Name";
                comboBox1.DataSource = ds.Tables["Products"];

            }
            catch (SqlException a) {
                Console.WriteLine(a);
            }
            
            
        }

    }
}

