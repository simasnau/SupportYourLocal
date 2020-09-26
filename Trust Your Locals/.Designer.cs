using System;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Data;
using System.Windows.Forms;

namespace Trust_Your_Locals
{
    partial class Form1
    {
        private TextBox textBox1;
        private ComboBox comboBox1;
        private Button button1;


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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(307, 58);
            this.textBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(154, 33);
            this.textBox1.TabIndex = 1;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(101, 58);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(144, 24);
            this.comboBox1.TabIndex = 2;
            this.comboBox1.SelectedIndexChanged += ComboBox1_SelectedIndexChanged;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(139, 142);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(184, 49);
            this.button1.TabIndex = 3;
            this.button1.Text = "Find this product";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.textBox1);
            this.Name = "Form1";
            this.Text = "Trust Your Locals";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                SQLConnectionHandler.MakeConnection();
                string query = "SELECT DISTINCT Name FROM Products";
                SqlDataAdapter da = new SqlDataAdapter(query, SQLConnectionHandler.GetConnection());
                DataSet ds = new DataSet();
                da.Fill(ds, "Products");
                comboBox1.DisplayMember = "Name";
                comboBox1.ValueMember = "Name";
                comboBox1.DataSource = ds.Tables["Products"];

            }
            catch (SqlException a)
            {
                Console.WriteLine(a);
            }
        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e) {
        //When selected item changes, textBox changes.
            textBox1.Text = comboBox1.SelectedValue.ToString();
        }



        private void button1_Click(object sender, EventArgs e)
        {
            
        }


    }
}

