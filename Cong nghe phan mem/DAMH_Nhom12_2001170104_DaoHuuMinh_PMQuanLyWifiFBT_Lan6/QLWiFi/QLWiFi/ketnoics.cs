using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLWiFi
{
    class ketnoics
    {
        string a;

        public string A
        {
            get { return a; }
            set { a = value; }
        }
        public ketnoics()
        {
            this.a = @"Data Source=DESKTOP-2LMHPI9\SQLEXPRESS;Initial Catalog=QL_INTERNET1;Integrated Security=True";
        }
        public string xuat()
        {
            return a;
        }
    }
}
