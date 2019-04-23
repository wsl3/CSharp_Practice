using System;
using System.Collections.Generic;
using System.Text;
using System.Data.OleDb;
namespace AddressList
{
    class DBClass
    {
        public OleDbConnection OleDbConn = new OleDbConnection("provider=Microsoft.Jet.OLEDB.4.0; data Source=./telephone.mdb; Persist Security Info=False");
    }
}

