using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpTest.Model
{
    public class DBHelper : IDisposable
    {
        private const string connectionStr = @"Server=LAPTOP-E82LJ3K6\SQLEXPRESS;Database=RMS;User Id=sa;Password=1234";

        private SqlConnection con;
        private SqlTransaction tx;

        public SqlConnection Connection
        {
            get
            {
                if (con == null)
                    con = new SqlConnection(connectionStr);

                return con;
            }
        }

        public SqlConnection ConnectionTx
        {
            get
            {
                if (con == null || tx == null)
                {
                    con = new SqlConnection(connectionStr);
                    tx = con.BeginTransaction();
                }

                return con;
            }
        }

        public void Commit()
        {
            if (tx != null)
            {
                tx.Commit();
                tx = null;
            }
        }

        public void Rollback()
        {
            if (tx != null)
            {
                tx.Rollback();
                tx = null;
            }
        }

        public void Dispose()
        {
            if (tx != null)
                tx.Rollback();

            if (con != null)
            {
                con.Dispose();  //Panggil Close() secara internal
                con = null;
            }
        }
    }
}
