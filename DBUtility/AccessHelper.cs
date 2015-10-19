using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.OleDb;
using System.Configuration;

namespace DCQWBOA.W8.DBUtility
{
    public class AccessHelper
    {
         private OleDbConnection conn;
        private OleDbDataAdapter oda = new OleDbDataAdapter();
        private OleDbCommand cmd;
        private DataSet myds = new DataSet();

        public void AccessHelperDoInit(string Fileaddr)
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
            conn = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + Fileaddr );
        }
        public DataSet getDS(string strSQL)
        {
            myds = new DataSet();
            oda = new OleDbDataAdapter(strSQL, conn);
            oda.Fill(myds);
            return myds;
        }

        public DataSet getDS2(string strSQL, int si, int mi)
        {
            conn.Open();
            myds = new DataSet();
            oda = new OleDbDataAdapter(strSQL, conn);
            oda.Fill(myds, si, mi, "tab1");
            conn.Close();
            return myds;

        }

        public bool setDS(string strSQL)
        {
            conn.Open();
            cmd = new OleDbCommand(strSQL, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
            return true;
        }
    }
}
