using System;
using System.Windows.Forms;

namespace CSharpTest.View
{
    public static class GridExtentionMethod
    {
        public static int GetSelectedRcuId(this DataGridView grid)
        {
            if (grid.CurrentRow != null)
            {
                return Convert.ToInt32(grid.CurrentRow.Cells[1].Value);
            }
            else
                return -1;
        }
    }
}
