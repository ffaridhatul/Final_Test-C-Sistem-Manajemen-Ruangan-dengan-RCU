using CSharpTest.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSharpTest.View
{
    public partial class frmCheckInList : Form
    {
        public frmCheckInList()
        {
            InitializeComponent();
        }

        private void frmCheckInList_Load(object sender, EventArgs e)
        {
            RefreshGrid();
        }

        private void RefreshGrid()
        {
            dgvCheckInList.AutoGenerateColumns = false;
            dgvCheckInList.DataSource = CheckInDAO.GetInstance().GetAll();
        }
    }
}
