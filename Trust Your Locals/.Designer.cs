using System;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;
using System.Text;
using System.IO;

namespace Trust_Your_Locals
{
    partial class Form1
    {
        private ComboBox comboBox1;
        private DataGridView dgv;
        private SplitContainer splitContainer1;
        private Button pavadinimas_button;
        private Label label1;
        private TextBox txt_pavadinimas;
        private WebBrowser webBrowser1;
        private Label label2;



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
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.dgv = new System.Windows.Forms.DataGridView();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.addProduct_Button = new System.Windows.Forms.Button();
            this.orderView = new System.Windows.Forms.Button();
            this.orderButton = new System.Windows.Forms.Button();
            this.pavadinimas_button = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_pavadinimas = new System.Windows.Forms.TextBox();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.label2 = new System.Windows.Forms.Label();
            this.navigate_button = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.rateButton = new System.Windows.Forms.Button();
            this.signOut_Button = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // comboBox1
            // 
            this.comboBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(213, 105);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(144, 24);
            this.comboBox1.TabIndex = 2;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // dgv
            // 
            this.dgv.AllowUserToAddRows = false;
            this.dgv.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv.Location = new System.Drawing.Point(12, 198);
            this.dgv.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgv.Name = "dgv";
            this.dgv.ReadOnly = true;
            this.dgv.RowHeadersVisible = false;
            this.dgv.RowHeadersWidth = 62;
            this.dgv.RowTemplate.Height = 28;
            this.dgv.Size = new System.Drawing.Size(557, 345);
            this.dgv.TabIndex = 5;
            this.dgv.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_CellContentClick);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(575, 1);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.addProduct_Button);
            this.splitContainer1.Panel1.Controls.Add(this.orderView);
            this.splitContainer1.Panel1.Controls.Add(this.orderButton);
            this.splitContainer1.Panel1.Controls.Add(this.pavadinimas_button);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.Controls.Add(this.txt_pavadinimas);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.webBrowser1);
            this.splitContainer1.Size = new System.Drawing.Size(914, 559);
            this.splitContainer1.SplitterDistance = 167;
            this.splitContainer1.TabIndex = 6;
            // 
            // addProduct_Button
            // 
            this.addProduct_Button.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addProduct_Button.Location = new System.Drawing.Point(17, 292);
            this.addProduct_Button.Name = "addProduct_Button";
            this.addProduct_Button.Size = new System.Drawing.Size(137, 41);
            this.addProduct_Button.TabIndex = 11;
            this.addProduct_Button.Text = "Add product";
            this.addProduct_Button.UseVisualStyleBackColor = true;
            this.addProduct_Button.Click += new System.EventHandler(this.addProduct_Button_Click);
            // 
            // orderView
            // 
            this.orderView.Location = new System.Drawing.Point(17, 441);
            this.orderView.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.orderView.Name = "orderView";
            this.orderView.Size = new System.Drawing.Size(137, 54);
            this.orderView.TabIndex = 4;
            this.orderView.Text = "View Your Orders";
            this.orderView.UseVisualStyleBackColor = true;
            this.orderView.Click += new System.EventHandler(this.viewOrdersClick);
            // 
            // orderButton
            // 
            this.orderButton.Location = new System.Drawing.Point(17, 366);
            this.orderButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.orderButton.Name = "orderButton";
            this.orderButton.Size = new System.Drawing.Size(137, 54);
            this.orderButton.TabIndex = 3;
            this.orderButton.Text = "Place Order";
            this.orderButton.UseVisualStyleBackColor = true;
            this.orderButton.Click += new System.EventHandler(this.orderButton_Click);
            // 
            // pavadinimas_button
            // 
            this.pavadinimas_button.Location = new System.Drawing.Point(17, 209);
            this.pavadinimas_button.Name = "pavadinimas_button";
            this.pavadinimas_button.Size = new System.Drawing.Size(137, 58);
            this.pavadinimas_button.TabIndex = 2;
            this.pavadinimas_button.Text = "Search in maps";
            this.pavadinimas_button.UseVisualStyleBackColor = true;
            this.pavadinimas_button.Click += new System.EventHandler(this.pavadinimas_button_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(50, 104);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Location:";
            // 
            // txt_pavadinimas
            // 
            this.txt_pavadinimas.Location = new System.Drawing.Point(17, 146);
            this.txt_pavadinimas.Name = "txt_pavadinimas";
            this.txt_pavadinimas.Size = new System.Drawing.Size(137, 22);
            this.txt_pavadinimas.TabIndex = 0;
            // 
            // webBrowser1
            // 
            this.webBrowser1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowser1.Location = new System.Drawing.Point(0, 0);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.ScriptErrorsSuppressed = true;
            this.webBrowser1.Size = new System.Drawing.Size(743, 559);
            this.webBrowser1.TabIndex = 0;
            this.webBrowser1.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.webBrowser1_DocumentCompleted);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(174, 152);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(227, 17);
            this.label2.TabIndex = 7;
            this.label2.Text = "Press on row to search for location";
            // 
            // navigate_button
            // 
            this.navigate_button.Location = new System.Drawing.Point(13, 12);
            this.navigate_button.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.navigate_button.Name = "navigate_button";
            this.navigate_button.Size = new System.Drawing.Size(77, 22);
            this.navigate_button.TabIndex = 8;
            this.navigate_button.Text = "Log in";
            this.navigate_button.UseVisualStyleBackColor = true;
            this.navigate_button.Click += new System.EventHandler(this.navigate_button_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(13, 39);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(77, 22);
            this.button1.TabIndex = 9;
            this.button1.Text = "Register";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // rateButton
            // 
            this.rateButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rateButton.Location = new System.Drawing.Point(335, 10);
            this.rateButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rateButton.Name = "rateButton";
            this.rateButton.Size = new System.Drawing.Size(171, 33);
            this.rateButton.TabIndex = 8;
            this.rateButton.Text = "Rate seller";
            this.rateButton.UseVisualStyleBackColor = true;
            this.rateButton.Click += new System.EventHandler(this.rateButton_Click);
            // 
            // signOut_Button
            // 
            this.signOut_Button.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.signOut_Button.Location = new System.Drawing.Point(13, 12);
            this.signOut_Button.Name = "signOut_Button";
            this.signOut_Button.Size = new System.Drawing.Size(89, 35);
            this.signOut_Button.TabIndex = 10;
            this.signOut_Button.Text = "Sign out";
            this.signOut_Button.UseVisualStyleBackColor = true;
            this.signOut_Button.Click += new System.EventHandler(this.signOut_Button_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1492, 554);
            this.Controls.Add(this.signOut_Button);
            this.Controls.Add(this.navigate_button);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.dgv);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.rateButton);
            this.Name = "Form1";
            this.Text = "Trust Your Locals";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed_1);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }


        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            File.Delete("locations.js");
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {

        }

        private Button navigate_button;
        private Button orderButton;
        private Button orderView;
        private Button button1;
        private Button rateButton;
        private Button signOut_Button;
        private Button addProduct_Button;
    }
}


