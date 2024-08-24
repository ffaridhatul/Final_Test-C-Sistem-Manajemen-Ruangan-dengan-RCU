using CSharpTest.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EvaluasipraktisCS
{
    static class Program
    {
        /// <summary>
        /// Ini adalah titik masuk utama untuk aplikasi tersebut.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmMain());
        }
    }
}
