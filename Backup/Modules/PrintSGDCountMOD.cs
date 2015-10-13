using System;
using System.Collections.Generic;
using System.Text;

namespace OrderPrintSystem.Modules
{
   public class PrintSGDCountMOD
    {
        private int _id;
        private string _orderNum;
        private string _proType;
        private int _printCount;


        public int PrintCount
        {
            get { return _printCount; }
            set { _printCount = value; }
        }

        public string ProType
        {
            get { return _proType; }
            set { _proType = value; }
        }

        public string OrderNum
        {
            get { return _orderNum; }
            set { _orderNum = value; }
        }

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }
    }
}
