using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Service.BaseDataService_2
{
    /// <summary>
    /// PurchaseOrdersManager 的摘要说明
    /// </summary>
    public class PurchaseOrdersManager : BaseService
    {

        public override void ProcessRequest(HttpContext context)
        {
            base.ProcessRequest(context);
            context.Response.ContentType = "application/json";
            string opr = context.Request["opr"] + "";
            switch (opr)
            {
                //获取订单ID
                case "getOrderId":
                    getOrderId(context);
                    break;
                //添加采购订单
                case "addOrder":
                    addOrder(context);
                    break;
                //获取物料列表
                case "MaterialList":
                    MaterialList(context);
                    break;
                case "getOrderList"://获取订单列表
                    getOrderList(context);
                    break;

            }
            context.Response.End();

        }
        //获取订单id
        private void getOrderId(HttpContext context)
        {
            var ids = db.domain_PurchaseOrders.Select(s => s.ID);
            int id;
            if (ids.Count() > 0)
            {
                id = ids.Max();
            }
            else
            {
                id = 0;
            }
            string now = DateTime.Now.ToString("yyyy-MM-dd");
            string OrderID = "CG" + now + "-" + (id + 1);
            context.Response.Write("{\"id\":\"" + OrderID + "\"}");
        }

        //添加采购订单
        private void addOrder(HttpContext context)
        {
            string OrderID = context.Request["OrderID"] + ""; ;

            Model.domain_PurchaseOrders porder = new Model.domain_PurchaseOrders()
            {
                OrderID = OrderID,
                AddBy = UserInfo.UserName,
                AddTime = DateTime.Now
            };
            db.domain_PurchaseOrders.Add(porder);
            string Items = context.Request["Items"] + "";
            if (!string.IsNullOrEmpty(Items))
            {
                List<Model.domain_PurchaseOrdersItem> orderItem =
                    JsonConvert.DeserializeObject<List<Model.domain_PurchaseOrdersItem>>(Items);

                for (int i = 0, max = orderItem.Count; i < max; i++)
                {
                    Model.domain_PurchaseOrdersItem porderitem = orderItem[i];
                    db.domain_PurchaseOrdersItem.Add(porderitem);
                }
            }
            int num = db.SaveChanges();
            context.Response.Write("{\"d\":" + num + "}");
        }
        //获取物料列表
        private void MaterialList(HttpContext context)
        {
            int pageSize = NCore.DataConvert.ToInt(context.Request["rows"] + "", 10);
            int pageIndex = NCore.DataConvert.ToInt(context.Request["page"] + "", 1);
            int total;////总条数
            string sql = @"select base_Material.ID,base_Material.MaterialName,ModelNumber,CategoryID,
CategoryName,UnitID,UnitName,TechnicalParameter,AllCount from base_Material
join (select MaterialName,MaterialModelNumber,SUM(KuCun) AllCount from domain_Material_WareHouse
 group by MaterialName,MaterialModelNumber) WareHouse  
 on base_Material.ModelNumber=WareHouse.MaterialModelNumber 
and base_Material.MaterialName=WareHouse.MaterialName
where Status=0  ";
            var list = db.Database.SqlQuery<base_Material_View>(sql);
            total = list.Count();
            list = list.Skip((pageIndex - 1) * pageSize).Take(pageSize);
            var obk = new { total = total, rows = list.ToList() };
            //序列化json字符串
            string result = JsonConvert.SerializeObject(obk);
            context.Response.Write(result);
        }
        //获取订单列表
        private void getOrderList(HttpContext context)
        {
            int pageSize = NCore.DataConvert.ToInt(context.Request["rows"] + "", 10);
            int pageIndex = NCore.DataConvert.ToInt(context.Request["page"] + "", 1);
            int total;////总条数

            //var list = db.domain_PurchaseOrders.Where(w => w.isFinished == 0);
            var list = db.domain_PurchaseOrders.OrderByDescending(o => o.ID).ToList().Select(s => new
            {
                s.OrderID,
                //s.isFinished,
                s.AddBy,
                AddTime =s.AddTime==null?"": DateTime.Parse(s.AddTime.ToString()).ToString("yyyy-mm-dd hh:mm:ss")              
            });
            total = list.Count();
            list = list.Skip((pageIndex - 1) * pageSize).Take(pageSize);
            var obk = new { total = total, rows = list };
            //序列化json字符串
            string result = JsonConvert.SerializeObject(obk);
            context.Response.Write(result);
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }


        //物料信息类
        public class base_Material_View
        {
            public int ID { get; set; }
            public string MaterialName { get; set; }
            public string ModelNumber { get; set; }
            public int? CategoryID { get; set; }
            public string CategoryName { get; set; }
            public int? UnitID { get; set; }
            public string UnitName { get; set; }
            public string TechnicalParameter { get; set; }
            public int? AllCount { get; set; }
        }
    }
}