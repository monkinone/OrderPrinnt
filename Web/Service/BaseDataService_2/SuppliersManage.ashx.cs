using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using Web.Model;

namespace Web.Service.BaseDataService_2
{
    /// <summary>
    /// SuppliersManage 的摘要说明
    /// </summary>
    public class SuppliersManage : BaseService
    {

        public override void ProcessRequest(HttpContext context)
        {
            base.ProcessRequest(context);
            context.Response.ContentType = "application/json";
            string opr = context.Request["opr"] + "";
            switch (opr.ToLower())
            {
                case "list"://获取列表
                    GetList(context);
                    break;
                case "getuserlist": //获取供应商用户列表
                    GetGyxUserlist(context);
                    break;
                case "add"://添加供应商
                    Add(context);
                    break;
                case "edit"://编辑
                    Edit(context);
                    break;
                case "del": //删除
                    Del(context);
                    break;
            }
            //context.Response.ContentType = "text/plain";
            //context.Response.Write("Hello World");
        }

        //获取列表
        private void GetList(HttpContext context)
        {

            // var q = from a in db.table1
            //  from b in db.table2
            //  where a.id==b.id
            // select new {
            //     id1=a.id,
            //     id2=b.id
            //};
            // if (!string.IsNullOrEmpty(title)){
            //        q=q.where(c=>c.title.contains(title));    //like
            // }
            // return q.toList();
            // 如果是mvc的话 传到view需要视图model


            int pageSize = NCore.DataConvert.ToInt(context.Request["rows"] + "", 20);
            int pageIndex = NCore.DataConvert.ToInt(context.Request["page"] + "", 1);
            string SuppliersName = context.Request["SuppliersName"] + "";//供应商名称
            int total;// = db.base_Suppliers.Count();//总条数
            //启用状态的供应商.OrderByDescending(o => o.ID)
            var list = from sup in db.base_Suppliers.Where(w => w.Status == 0)
                       join user in db.userManage.Where(w => w.userType == 9)
                           on sup.LoginUserID equals user.userId into temp
                       from tt in temp.DefaultIfEmpty()
                       orderby sup.ID
                       select new
                       {
                           ID = sup.ID,
                           CompanyName = sup.CompanyName,
                           ContactMan = sup.ContactMan,
                           Telephone = sup.Telephone,
                           MobilePhone = sup.MobilePhone,
                           Fax = sup.Fax,
                           Position = sup.Position,
                           AssessmentLevel = sup.AssessmentLevel,
                           Payment = sup.Payment,
                           InvoiceFa = sup.InvoiceFa,
                           IsContractModel = sup.IsContractModel,
                           BankAccount = sup.BankAccount,
                           BankName = sup.BankName,
                           TaxpayerNumber = sup.TaxpayerNumber,
                           OtherContactMan = sup.OtherContactMan,
                           CompanyAdress = sup.CompanyAdress,
                           ContactManDetailInfo = sup.ContactManDetailInfo,
                           LoginUserID = sup.LoginUserID,
                           AddBy = sup.AddBy,   
                           trueName = tt == null ? "" : tt.trueName
                       };
            total = list.Count();
            if (!string.IsNullOrEmpty(SuppliersName))
            {
                list = list.Where(w => w.CompanyName.Contains(SuppliersName) == true);
            }

            list = list.Skip((pageIndex - 1) * pageSize).Take(pageSize);

            var obk = new { total = total, rows = list.ToList() };
            //序列化json字符串
            string result = JsonConvert.SerializeObject(obk);
            context.Response.Write(result);
        }
        //获取供应商用户列表
        private void GetGyxUserlist(HttpContext context)
        {
            var list = db.userManage.Where(w => w.userType == 9).
                                                         Select(s => new { userId = s.userId, trueName = s.trueName });
            //序列化json字符串
            string result = JsonConvert.SerializeObject(list);
            context.Response.Write(result);

        }

        //添加信息
        private void Add(HttpContext context)
        {
            string CompanyName = context.Request["CompanyName"] + "";//供应商名称

            var list = db.base_Suppliers.Where(w => w.CompanyName == CompanyName);
            if (list.Count() > 0)
            {
                context.Response.Write("{\"d\":111}");//供应商名称重复
            }
            else
            {
                Model.base_Suppliers sup = new Model.base_Suppliers()
                {
                    CompanyName = CompanyName,//公司名称
                    ContactMan = context.Request["ContactMan"] + "",//联系人
                    Telephone = context.Request["Telephone"] + "",//联系人电话
                    MobilePhone = context.Request["MobilePhone"] + "",//联系人手机号
                    Fax = context.Request["Fax"] + "",//传真
                    Position = context.Request["Position"] + "",//职位
                    InvoiceFa = context.Request["InvoiceFa"] + "",//开票方式
                    Payment = context.Request["Payment"] + "",//付款方式
                    IsContractModel = Convert.ToInt32((context.Request["IsContractModel"]) == "" ? "0" : (context.Request["IsContractModel"])),//是否供应商提供合同范本
                    BankAccount = context.Request["BankAccount"] + "",//银行卡号
                    BankName = context.Request["BankName"] + "",//开户行
                    TaxpayerNumber = context.Request["TaxpayerNumber"] + "",//纳税人编号
                    CompanyAdress = context.Request["CompanyAdress"] + "",//公司地址
                    OtherContactMan = context.Request["OtherContactMan"] + "",//其他联系人档案
                    ContactManDetailInfo = context.Request["ContactManDetailInfo"] + "",//联系人性格描述
                    Status = 0,//状态
                    AddBy = UserInfo.UserName,//添加人
                    AddTime = DateTime.Now//添加时间         
                };
                if (!string.IsNullOrEmpty(context.Request["LoginUserID"]))
                {
                    sup.LoginUserID = Convert.ToInt32(context.Request["LoginUserID"] + "");
                }
                db.base_Suppliers.Add(sup);
                int num = db.SaveChanges();
                context.Response.Write("{\"d\":" + num + "}");
            }
        }
        //编辑信息
        private void Edit(HttpContext context)
        {

            string CompanyName = context.Request["CompanyName"] + "";//供应商名称
            int ID = int.Parse(context.Request["ID"] + "");//供应商编号
            var list = db.base_Suppliers.Where(w => w.CompanyName == CompanyName && w.ID != ID);
            if (list.Count() > 0)
            {
                context.Response.Write("{\"d\":111}");//供应商名称重复
            }
            else
            {
                base_Suppliers sup = db.base_Suppliers.Where(w => w.ID == ID).FirstOrDefault();
                if (!string.IsNullOrEmpty(context.Request["LoginUserID"]))
                {
                    sup.LoginUserID = Convert.ToInt32(context.Request["LoginUserID"] + "");
                }
                sup.CompanyName = CompanyName;//公司名称
                sup.ContactMan = context.Request["ContactMan"] + "";//联系人
                sup.Telephone = context.Request["Telephone"] + "";//联系人电话
                sup.MobilePhone = context.Request["MobilePhone"] + "";//联系人手机号
                sup.Fax = context.Request["Fax"] + "";//传真
                sup.Position = context.Request["Position"] + "";//职位
                sup.InvoiceFa = context.Request["InvoiceFa"] + "";//开票方式
                sup.Payment = context.Request["Payment"] + "";//付款方式
                sup.IsContractModel = Convert.ToInt32((context.Request["IsContractModel"]) == "" ? "0" : (context.Request["IsContractModel"]));//是否供应商提供合同范本
                sup.BankAccount = context.Request["BankAccount"] + "";//银行卡号
                sup.BankName = context.Request["BankName"] + "";//开户行
                sup.TaxpayerNumber = context.Request["TaxpayerNumber"] + "";//纳税人编号
                sup.CompanyAdress = context.Request["CompanyAdress"] + "";//公司地址
                sup.OtherContactMan = context.Request["OtherContactMan"] + "";//其他联系人档案
                sup.ContactManDetailInfo = context.Request["ContactManDetailInfo"] + "";//联系人性格描述                            
                sup.LastUpdateBy = UserInfo.UserName;//编辑人
                sup.LastUpdateTime = DateTime.Now;//编辑时间        

                int num = db.SaveChanges();
                context.Response.Write("{\"d\":" + num + "}");
            }

        }
        //删除信息
        private void Del(HttpContext context)
        {
            int ID = int.Parse(context.Request["ID"] + "");//供应商编号
            base_Suppliers sup = db.base_Suppliers.Where(w => w.ID == ID).FirstOrDefault();

            sup.Status = 1;//停用此供应商
            sup.DeleteBy = UserInfo.UserName;
            sup.DeleteTime = DateTime.Now;

            //先将实体附加到实体上下文中
            //db.base_Suppliers.Attach(sup);
            //手动修改实体的状态
            //db.Entry(sup).State = EntityState.Modified;
            int num = db.SaveChanges();
            context.Response.Write("{\"d\":" + num + "}");
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}