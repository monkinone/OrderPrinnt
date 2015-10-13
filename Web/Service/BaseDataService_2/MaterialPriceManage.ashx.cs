using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Web.Model;
namespace Web.Service.BaseDataService_2
{
    /// <summary>
    /// MaterialPriceManage 的摘要说明
    /// 单价管理
    /// </summary>
    public class MaterialPriceManage : BaseService
    {

        public override void ProcessRequest(HttpContext context)
        {
            base.ProcessRequest(context);
            context.Response.ContentType = "application/json";
            string opr = context.Request["opr"] + "";
            switch (opr)
            {
                case "addMaterialPrice"://添加
                    addMaterialPrice(context);
                    break;
                case "getMaterialPriceList":
                    getMaterialPrice(context);
                    break;
                case "getSuppliersList":
                    getSuppliersList(context);
                    break;
                case "getMaterialList":
                    getMaterialList(context);
                    break;
                case "editMaterialPrice":
                    editMaterialPrice(context);
                    break;
                case "delMaterialPrice":
                    delMaterialPrice(context);
                    break;
                case "getPriceRecord":
                    getPriceRecord(context);
                    break;
            }
        }

        /// <summary>
        /// 获取单价列表
        /// </summary>
        /// <param name="context"></param>
        private void getMaterialPrice(HttpContext context)
        {
            int pageSize = NCore.DataConvert.ToInt(context.Request["rows"] + "", 20);
            int pageIndex = NCore.DataConvert.ToInt(context.Request["page"] + "", 1);
            IQueryable<domain_MaterialPrice> list = db.domain_MaterialPrice.OrderByDescending(o => o.AddTime);
            int total;//总条数
            if (!string.IsNullOrEmpty(context.Request["SuppliersID"]))//供应商id
            {
                int SuppliersID = Convert.ToInt32(context.Request["SuppliersID"]);
                list = list.Where(w => w.SuppliersID == SuppliersID);
            }
            if (!string.IsNullOrEmpty(context.Request["ModelNumber"]))//物料id
            {
                string ModelNumber = context.Request["ModelNumber"] + "";
                list = list.Where(w => w.ModelNumber == ModelNumber);
            }
            total = list.Count();
            var data = new { total = total, rows = list.ToList() };
            //序列化json字符串
            string result = JsonConvert.SerializeObject(data);
            context.Response.Write(result);
        }

        /// <summary>
        /// 获取供应商列表
        /// </summary>
        /// <param name="context"></param>
        private void getSuppliersList(HttpContext context)
        {
            var list = db.base_Suppliers.Where(w => w.Status == 0).
                Select(s => new { ID = s.ID, CompanyName = s.CompanyName });
            string result = JsonConvert.SerializeObject(list);
            context.Response.Write(result);
        }
        /// <summary>
        /// 获取物料列表
        /// </summary>
        /// <param name="context"></param>
        private void getMaterialList(HttpContext context)
        {
            var list = db.base_Material.Where(w => w.Status == 0).
                Select(s => new { MaterialName = s.MaterialName, ModelNumber = s.ModelNumber });
            string result = JsonConvert.SerializeObject(list);
            context.Response.Write(result);
        }

        /// <summary>
        /// 添加单价
        /// </summary>
        /// <param name="context"></param>
        private void addMaterialPrice(HttpContext context)
        {
            int SuppliersID = Convert.ToInt32(context.Request["SuppliersID"]);//供应商
            string CompanyName = context.Request["CompanyName"] + "",  //供应商名称              
                ModelNumber = context.Request["ModelNumber"] + "";
            var data = db.domain_MaterialPrice.Where(w => w.SuppliersID == SuppliersID && w.ModelNumber == ModelNumber);
            if (data.Count() > 0)//已存在此单价记录
            {
                context.Response.Write("{\"d\":111}");
            }
            else
            {
                Model.domain_MaterialPrice mp = new domain_MaterialPrice()
              {
                  SuppliersID = SuppliersID,
                  CompanyName = CompanyName,                //供应商名称
                  ModelNumber = ModelNumber,                //物料型号
                  MaterialName = context.Request["MaterialName"] + "",              //物料名称
                  UnitPrice = Convert.ToInt32(context.Request["UnitPrice"] + ""),   //单价
                  Remark = context.Request["Remark"] + "",                          //备注
                  AddBy = UserInfo.UserName,                                        //添加人
                  AddTime = DateTime.Now
              };
                db.domain_MaterialPrice.Add(mp);
                int num = db.SaveChanges();
                if (num == 1)
                {
                    num = 1;
                    Model.domain_Log log = new Model.domain_Log()
                    {
                        DoID = Convert.ToInt32(ModelNumber),
                        DoType = 1,
                        DoContent = "添加单价 " + mp.CompanyName + "  " + mp.UnitPrice,
                        DoBy = UserInfo.UserName,
                        DoTime = DateTime.Now
                    };
                    db.domain_Log.Add(log);
                    db.SaveChanges();
                }
                context.Response.Write("{\"d\":" + num + "}");
            }
        }
        /// <summary>
        /// 编辑单价
        /// </summary>
        /// <param name="context"></param>
        private void editMaterialPrice(HttpContext context)
        {
            int ID = Convert.ToInt32(context.Request["ID"]);
            decimal UnitPrice = Convert.ToDecimal(context.Request["UnitPrice"] + "");
            Model.domain_MaterialPrice mp = db.domain_MaterialPrice.Where(w => w.ID == ID).First();
            mp.SuppliersID = Convert.ToInt32(context.Request["SuppliersID"]);//供应商
            mp.CompanyName = context.Request["CompanyName"] + "";                //供应商名称
            mp.ModelNumber = context.Request["ModelNumber"] + "";                //物料型号
            mp.MaterialName = context.Request["MaterialName"] + "";              //物料名称
            mp.UnitPrice = UnitPrice;   //单价
            mp.Remark = context.Request["Remark"] + "";                          //备注
            mp.LastUpdateBy = UserInfo.UserName;
            mp.LastUpdateTime = DateTime.Now;
            int num = db.SaveChanges();
            if (num == 1)
            {
                num = 1;
                Model.domain_Log log = new Model.domain_Log()
                {
                    DoID = Convert.ToInt32(mp.ModelNumber),
                    DoType = 1,
                    DoContent = "编辑单价 " + mp.CompanyName + "  " + mp.UnitPrice,
                    DoBy = UserInfo.UserName,
                    DoTime = DateTime.Now
                };
                db.domain_Log.Add(log);
                db.SaveChanges();
            }
            context.Response.Write("{\"d\":" + num + "}");
        }
        /// <summary>
        /// 删除单价
        /// </summary>
        /// <param name="context"></param>
        private void delMaterialPrice(HttpContext context)
        {
            int ID = Convert.ToInt32(context.Request["ID"]);
            Model.domain_MaterialPrice mp = db.domain_MaterialPrice.Where(w => w.ID == ID).First();
            db.domain_MaterialPrice.Remove(mp);
            int num = db.SaveChanges();
            if (num == 1)
            {
                num = 1;
                Model.domain_Log log = new Model.domain_Log()
                {
                    DoID = Convert.ToInt32(mp.ModelNumber),
                    DoType = 1,
                    DoContent = "删除单价 " + mp.CompanyName + "  " + mp.UnitPrice,
                    DoBy = UserInfo.UserName,
                    DoTime = DateTime.Now
                };
                db.domain_Log.Add(log);
                db.SaveChanges();
            }
            context.Response.Write("{\"d\":" + num + "}");
        }

        /// <summary>
        /// 获取物料调价记录
        /// </summary>
        /// <param name="context"></param>
        private void getPriceRecord(HttpContext context)
        {
            int ModelNumber = Convert.ToInt32(context.Request["ModelNumber"] + "");
            var list = db.domain_Log.Where(w => w.DoType == 1 && w.DoID == ModelNumber).OrderByDescending(o => o.DoTime)
                .ToList().Select(d => new { d.DoBy, d.DoContent, DoTime = d.DoTime == null ? "" : DateTime.Parse(d.DoTime.ToString()).ToString("yyyy-mm-dd hh:mm:ss"), d.DoType, d.ID }); ;
            //var list = db.domain_Log.Where(w => w.DoType == 1).OrderByDescending(o => o.DoTime);
            string result = JsonConvert.SerializeObject(list);
            context.Response.Write(result);
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