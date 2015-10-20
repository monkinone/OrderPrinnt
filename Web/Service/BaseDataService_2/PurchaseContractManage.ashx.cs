using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Web.Service;
using Web.Model;

namespace Web.BaseDataUI_2
{
    /// <summary>
    /// PurchaseContractManage 的摘要说明
    /// </summary>
    public class PurchaseContractManage : BaseService
    {

        public override void ProcessRequest(HttpContext context)
        {
            base.ProcessRequest(context);
            context.Response.ContentType = "application/json";
            string opr = context.Request["opr"] + "";
            switch (opr)
            {
                //获取合同id
                case "getID":
                    getHTID(context);
                    break;
                //获取未加至合同的采购订单详情
                case "getOrderlist":
                    getOrderList(context);
                    break;
                case "addPurchaseContract"://添加合同
                    addPurchaseContract(context);
                    break;
                case "searchPrice"://查询价格
                    searchPrice(context);
                    break;
                case "getSuppliersList"://获取供应商
                    getSuppliersList(context);
                    break;
                case "delPurchaseContract"://删除合同
                    delPurchaseContract(context);
                    break;
                case "getPurchaseContractList"://获取合同列表
                    getPurchaseContractList(context);
                    break;

            }
        }
        //生成合同id
        private void getHTID(HttpContext context)
        {
            var supried = context.Request["Suppliersid"] + "";//供应商编号
            var ids = db.domain_PurchaseContract.Select(s => s.ID);
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
            string OrderID = "HT" + now + "-" + supried + "-" + (id + 1);
            context.Response.Write("{\"id\":\"" + OrderID + "\"}");
        }
        //获取未生成合同的订单
        private void getOrderList(HttpContext context)
        {
            string orderid = context.Request["orderid"];//采购订单编号
            string sql = @"select * from domain_PurchaseOrdersItem where OrderID='" + orderid +
           @"' and ModelNumber+CategoryName not in (select ModelNumber+CategoryName 
    from domain_PurchaseContractItem where OrderID='" + orderid + "')";
            var list = db.Database.SqlQuery<Model.domain_PurchaseOrdersItem>(sql);
            int total = list.Count();
            var obk = new { total = total, rows = list };
            //序列化json字符串
            string result = JsonConvert.SerializeObject(obk);
            context.Response.Write(result);
        }


        //添加合同
        private void addPurchaseContract(HttpContext context)
        {

            int SuppliersID = Convert.ToInt32(context.Request["SuppliersID"] + "");//供应商id
            string CompanyName = context.Request["CompanyName"] + "";//供应商名称
            int GoodsMethods = Convert.ToInt32(context.Request["GoodsMethods"] + "");//发货方式 1直接发，2等款，3现生产，4待通知         
            string Items = context.Request["Items"] + "";
            if (!string.IsNullOrEmpty(Items))
            {
                List<Model.domain_PurchaseContractItem> pcorderItem =
                    JsonConvert.DeserializeObject<List<Model.domain_PurchaseContractItem>>(Items);
                int ItemCount = pcorderItem.Count;
                if (ItemCount > 0)
                {

                    for (int i = 0, max = pcorderItem.Count; i < max; i++)
                    {
                        Model.domain_PurchaseContractItem porderitem = pcorderItem[i];
                        db.domain_PurchaseContractItem.Add(porderitem);
                    }
                    string OrderID = pcorderItem[0].OrderID;
                    string ContractID = pcorderItem[0].ContractID;
                    Model.domain_PurchaseContract pc = new Model.domain_PurchaseContract()
                    {
                        OrderID = OrderID,
                        ContractID = ContractID,
                        SuppliersID = SuppliersID,
                        CompanyName = CompanyName,
                        GoodsMethods = GoodsMethods,
                        AddBy = UserInfo.UserName,
                        AddTime = DateTime.Now,
                        Status = 0
                    };
                    //采购订单详情数量
                    int cgitem = db.domain_PurchaseOrdersItem.Where(w => w.OrderID == OrderID).Count();
                    int htfinish = db.domain_PurchaseContractItem.Where(w => w.OrderID == OrderID).Count();
                    Model.domain_PurchaseOrders order = db.domain_PurchaseOrders.
                        Where(w => w.OrderID == OrderID).FirstOrDefault();
                    if (htfinish + ItemCount >= cgitem)
                    {
                        order.isFinished = 2;//全部生成合同
                    }
                    else
                    {
                        order.isFinished = 1;//部分生成合同
                    }
                    db.domain_PurchaseContract.Add(pc);
                }

            }
            int num = db.SaveChanges();
            context.Response.Write("{\"d\":" + num + "}");
        }
        //查询供应商所选物料价格
        private void searchPrice(HttpContext context)
        {
            int SuppliersID = Convert.ToInt32(context.Request["SuppliersID"] + "");
            string ModelNumber = context.Request["ModelNumber"] + "";
            var list = db.domain_MaterialPrice.Where(w => w.SuppliersID == SuppliersID && w.ModelNumber == ModelNumber)
                .Select(s => s.UnitPrice);
            string result = JsonConvert.SerializeObject(list);
            context.Response.Write(result);
        }
        //获取供应商列表
        private void getSuppliersList(HttpContext context)
        {
            var list = db.base_Suppliers.Where(w => w.Status == 0).Select(s => new { s.ID, s.CompanyName });
            string result = JsonConvert.SerializeObject(list);
            context.Response.Write(result);
        }
        //删除合同
        private void delPurchaseContract(HttpContext context)
        {
            int ID = Convert.ToInt32(context.Request["ID"]);
            Model.domain_PurchaseContract pc = db.domain_PurchaseContract.Where(w => w.ID == ID).First();
            pc.Status = 1;//删除
            string ContractID = pc.ContractID;
            string OrderID = pc.OrderID;
            List<Model.domain_PurchaseContractItem> list = db.domain_PurchaseContractItem.Where(w => w.ContractID == ContractID).ToList();
            for (int i = 0; i < list.Count(); i++)
            {
                db.domain_PurchaseContractItem.Remove(list[i]);
            }
            //采购订单详情数量
            int cgitem = db.domain_PurchaseOrdersItem.Where(w => w.OrderID == OrderID).Count();
         
            //订单实体
            Model.domain_PurchaseOrders order = db.domain_PurchaseOrders.
                            Where(w => w.OrderID == OrderID).FirstOrDefault();
            if (cgitem == list.Count)
            {
                order.isFinished = 0;//未生成合同
            }
            else if (cgitem - list.Count > 0)
            {
                order.isFinished = 1;//部分生成合同
            }
            int num = db.SaveChanges();
            context.Response.Write("{\"d\":" + num + "}");
        }

        //获取合同列表
        private void getPurchaseContractList(HttpContext context)
        {
            int pageSize = NCore.DataConvert.ToInt(context.Request["rows"] + "", 20);
            int pageIndex = NCore.DataConvert.ToInt(context.Request["page"] + "", 1);
            string ContractID = context.Request["ContractID"] + "";
            string OrderID = context.Request["OrderID"] + "";
            string CompanyName = context.Request["CompanyName"] + "";//供应商名称
            string SupplierId = context.Request["SupplierId"] + "";
            int total;////总条数

            var list = db.domain_PurchaseContract.Where(w => w.Status == 0).OrderByDescending(O => O.ID).ToList()
                .Select(s => new
                {
                    s.ID,
                    s.OrderID,
                    s.SuppliersID,
                    s.ContractID,
                    s.CompanyName,
                    AddTime = s.AddTime == null ? "" : DateTime.Parse(s.AddTime.ToString()).ToString("yyyy-mm-dd hh:mm:ss")
                });
            if (!string.IsNullOrEmpty(ContractID))
            {
                list = list.Where(w => w.ContractID.Contains(ContractID));
            }
            if (!string.IsNullOrEmpty(OrderID))
            {
                list = list.Where(w => w.OrderID.Contains(OrderID));
            }
            if (!string.IsNullOrEmpty(SupplierId))
            {
                list = list.Where(w => w.SuppliersID == Convert.ToInt32(SupplierId));
            }
            //if (!string.IsNullOrEmpty(CompanyName))
            //{
            //    list = list.Where(w => w.CompanyName.Contains(CompanyName));
            //}

            total = list.Count();
            list = list.Skip((pageIndex - 1) * pageSize).Take(pageSize);

            var obk = new { total = total, rows = list.ToList() };
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
    }
}