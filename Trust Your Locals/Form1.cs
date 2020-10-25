using System;
using System.Windows.Forms;

namespace Trust_Your_Locals
{
    public partial class Form1 : Form
    {
        private DataDisplayClass dataDisplay;
        public Form1()
        {
            InitializeComponent();
            dataDisplay = new DataDisplayClass(comboBox1, dgv);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ComboBoxHandler cbHandler = new ComboBoxHandler(comboBox1);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataDisplay.updateDataGridView();
        }

        private void dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dataDisplay.getAdress(txt_pavadinimas, e);
        }

        private void pavadinimas_button_Click(object sender, EventArgs e)
        {
            MapHandler mapHandler = new MapHandler(webBrowser1);
            mapHandler.showAdress(txt_pavadinimas.Text);
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            RatingForm form_Rate = new RatingForm();
            form_Rate.ShowDialog();
        }
    }
}
