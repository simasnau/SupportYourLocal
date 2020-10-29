using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Trust_Your_Locals
{
    public static class ExtensionMethods
    {
        public static string getSelectedCellValue(this DataGridView dgv, String column)
        {
            try
            {
                if (dgv.SelectedRows[0].Cells[column].Value != null)
                    return dgv.SelectedRows[0].Cells[column].Value.ToString();
                else return null;

            }
            catch (ArgumentOutOfRangeException)
            {
                return null;
            }
           
        }


    }
}
