using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class Connection
    {       
        public SqlConnection conn = new SqlConnection("Server=.\\SQLEXPRESS; Uid=jw_seo;Pwd =1234; database=windowform; ");
        public SqlCommand cmd = new SqlCommand();

        public void command()
        {
            cmd.Connection = conn;
        }

    }
}
