﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Trust_Your_Locals
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            ComboBoxHandler.HandleComboBoxWithoutAll(comboBox1);
        }

        private void back_button_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            Form1 form1 = new Form1();
            form1.Show();
        }


    }
}
