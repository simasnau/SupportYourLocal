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
        public static string getSelectedCellAdress(this DataGridView dgv, DataGridViewCellEventArgs eArgs)
        {
            if (dgv.Rows[eArgs.RowIndex].Cells[eArgs.ColumnIndex].Value != null)
                return dgv.Rows[eArgs.RowIndex].Cells["Adress"].FormattedValue.ToString();
            else return null;
        }

    }
}
