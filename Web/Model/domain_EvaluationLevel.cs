//------------------------------------------------------------------------------
// <auto-generated>
//    此代码是根据模板生成的。
//
//    手动更改此文件可能会导致应用程序中发生异常行为。
//    如果重新生成代码，则将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace Web.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class domain_EvaluationLevel
    {
        public int ID { get; set; }
        public Nullable<int> SuppliersID { get; set; }
        public string CompanyName { get; set; }
        public string Level { get; set; }
        public string AddBy { get; set; }
        public Nullable<System.DateTime> AddTime { get; set; }
        public string LastUpdateBy { get; set; }
        public Nullable<System.DateTime> LastUpdateTime { get; set; }
    }
}