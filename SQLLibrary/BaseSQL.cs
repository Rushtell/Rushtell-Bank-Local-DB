using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using SaveAndLoadLibrary;

namespace SQLLibrary
{
    class BaseSQL
    {
        public static SqlConnection connect;
        public DataTable tableW;
        public DataTable tableVIPW;
        public DataTable tableO;
        public DataRowView row;
        public SqlDataAdapter Changer;

        public BaseSQL()
        {
            SqlConnectionStringBuilder sqlConnectionString = new SqlConnectionStringBuilder()
            {
                DataSource = @"(localdb)\MSSQLLocalDB",
                InitialCatalog = @"SQLDBRushtellBank",
                IntegratedSecurity = true,
                Pooling = true
            };

            connect = new SqlConnection(sqlConnectionString.ToString());
        }

        public void Add()
        {

        }
    }
}
