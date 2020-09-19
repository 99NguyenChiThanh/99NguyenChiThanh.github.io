using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace quanLyNhanSuTruongHoc
{
    class KetNoi
    {
        public SqlConnection getConnection()
        {
            return new SqlConnection(@"Data Source=DESKTOP-B6JV0HC\GARRET;Initial Catalog=QL_NSTHPT;Integrated Security=True");
        }
    }
}
