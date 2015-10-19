using System;
using System.Collections.Generic;
using System.Text;

namespace OrderPrintSystem.Modules
{
    public class PrevProductMOD
    {
        private string proName;
        private string proType;
        private string bianbi;
        private string danwei;
        private string proNum;
        private string danjia;
        private string jine;
        private string beizhu;
        private string suiGongDanNum;

        public string SuiGongDanNum
        {
            get { return suiGongDanNum; }
            set { suiGongDanNum = value; }
        }

       
        public string Beizhu
        {
            get { return beizhu; }
            set { beizhu = value; }
        }

        public string Jine
        {
            get { return jine; }
            set { jine = value; }
        }

        public string Danjia
        {
            get { return danjia; }
            set { danjia = value; }
        }

        public string ProNum
        {
            get { return proNum; }
            set { proNum = value; }
        }

        public string Danwei
        {
            get { return danwei; }
            set { danwei = value; }
        }

        public string Bianbi
        {
            get { return bianbi; }
            set { bianbi = value; }
        }

        public string ProType
        {
            get { return proType; }
            set { proType = value; }
        }

        public string ProName
        {
            get { return proName; }
            set { proName = value; }
        }
    }
}
