using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Service.BaseDataService_2
{
    /// <summary>
    /// DeliverGoodsManager 供应商发货明细的摘要说明
    /// </summary>
    public class DeliverGoodsManager : BaseService
    {

        public override void ProcessRequest(HttpContext context)
        {
            base.ProcessRequest(context);
            context.Response.ContentType = "application/json";
            string opr = context.Request["opr"] + "";
            switch (opr)
            {
                case "getDeliverGoodsList": //获取供应商发货明细
                    getDeliverGoodsList(context);
                    break;
                case "getAllDeliverGoodsList":  //获取所有供应商发货明细
                    getAllDeliverGoodsList(context);
                    break;
                case "getOrderlist":   //获取此供应商的订单列表
                    getOrderlist(context);
                    break;
                case "addDeliverGoods":   //添加发货明细
                    addDeliverGoods(context);
                    break;
            }
        }
        //获取供应商发货明细
        private void getDeliverGoodsList(HttpContext context)
        {
            if (UserInfo.UserType == 9)
            {
                int pageSize = NCore.DataConvert.ToInt(context.Request["rows"] + "", 10);
                int pageIndex = NCore.DataConvert.ToInt(context.Request["page"] + "", 1);
                int total;////总条数
                //UserInfo.UserId

                string SuppliersID = "";
                //获取登录的供应商id
                Model.base_Suppliers Suppliers = db.base_Suppliers.Where(w => w.LoginUserID == UserInfo.UserId).FirstOrDefault();
                if (Suppliers != null && !string.IsNullOrEmpty(Suppliers.ID + ""))
                {
                    SuppliersID = Suppliers.ID + "";
                    string OrderID = context.Request["OrderID"] + "";//采购订单id
                    string ModelNumber = context.Request["ModelNumber"] + "";//产品型号
                    string isDelivered = context.Request["isDelivered"] + "";//是否发货 0 未发货 1 已发货

                    string sql = @" select  domain_DeliverGoods.ID, domain_PurchaseContractItem.OrderID,
domain_PurchaseContract.CompanyName,
domain_PurchaseContract.SuppliersID,
domain_PurchaseContractItem.MaterialName,
domain_PurchaseContractItem.ModelNumber,
Amout,TechnicalParameters,TheDeliveryAmout,Number,
Requirement,
 ISNULL(domain_DeliverGoods.LastUpdateTime, domain_DeliverGoods.AddTime)  DeliverGoodsTime,
DeliveryNum,LogisticsCompany,
ISNULL((select SUM(TheDeliveryAmout) from 
domain_DeliverGoods dd where domain_PurchaseContractItem.OrderID=dd.OrderID 
and domain_PurchaseContractItem.ModelNumber=dd.ModelNumber),0) AllDeliverCount
from domain_PurchaseContractItem inner join domain_PurchaseContract
on domain_PurchaseContractItem.OrderID=domain_PurchaseContract.OrderID
inner join domain_DeliverGoods on  
domain_PurchaseContractItem.OrderID = domain_DeliverGoods.OrderID and 
domain_PurchaseContractItem.ModelNumber = domain_DeliverGoods.ModelNumber
and domain_PurchaseContractItem.MaterialName = domain_DeliverGoods.MaterialName
where domain_PurchaseContract.SuppliersID='" + SuppliersID + "'";
                    var list = db.Database.SqlQuery<DeliverGoods_View>(sql);
                    if (!string.IsNullOrEmpty(OrderID))
                    {
                        list = list.Where(w => w.OrderID == OrderID);
                    }
                    if (!string.IsNullOrEmpty(ModelNumber))
                    {
                        list = list.Where(w => w.ModelNumber == ModelNumber);
                    }
                    if (isDelivered == "0")//未发货
                    {
                        list = list.Where(w => w.AllDeliverCount == 0);
                    }
                    else if (isDelivered == "1")//已发货
                    {
                        list = list.Where(w => w.AllDeliverCount > 0);
                    }
                    total = list.Count();
                    list = list.Skip((pageIndex - 1) * pageSize).Take(pageSize);
                    var obk = new { total = total, rows = list.ToList() };
                    //序列化json字符串
                    string result = JsonConvert.SerializeObject(obk);
                    context.Response.Write(result);
                }
                else
                {
                    context.Response.Write("");
                }
            }
            else
            {
                context.Response.Write("");
            }

        }

        //获取所有供应商发货明细
        private void getAllDeliverGoodsList(HttpContext context)
        {

            int pageSize = NCore.DataConvert.ToInt(context.Request["rows"] + "", 10);
            int pageIndex = NCore.DataConvert.ToInt(context.Request["page"] + "", 1);
            int total;////总条数


            string OrderID = context.Request["OrderID"] + "";//采购订单id
            string ModelNumber = context.Request["ModelNumber"] + "";//产品型号
            string CompanyName = context.Request["CompanyName"] + "";//供应商名称

            string sql = @" select  domain_DeliverGoods.ID, domain_PurchaseContractItem.OrderID,
domain_PurchaseContract.CompanyName,
domain_PurchaseContract.SuppliersID,
domain_PurchaseContractItem.MaterialName,
domain_PurchaseContractItem.ModelNumber,
Amout,TechnicalParameters,TheDeliveryAmout,Number,
Requirement,
 ISNULL(domain_DeliverGoods.LastUpdateTime, domain_DeliverGoods.AddTime)  DeliverGoodsTime,
DeliveryNum,LogisticsCompany,
ISNULL((select SUM(TheDeliveryAmout) from 
domain_DeliverGoods dd where domain_PurchaseContractItem.OrderID=dd.OrderID 
and domain_PurchaseContractItem.ModelNumber=dd.ModelNumber),0) AllDeliverCount
from domain_PurchaseContractItem inner join domain_PurchaseContract
on domain_PurchaseContractItem.OrderID=domain_PurchaseContract.OrderID
inner join domain_DeliverGoods on  
domain_PurchaseContractItem.OrderID = domain_DeliverGoods.OrderID and 
domain_PurchaseContractItem.ModelNumber = domain_DeliverGoods.ModelNumber
and domain_PurchaseContractItem.MaterialName = domain_DeliverGoods.MaterialName";
            var list = db.Database.SqlQuery<DeliverGoods_View>(sql);
            if (!string.IsNullOrEmpty(OrderID))
            {
                list = list.Where(w => w.OrderID == OrderID);
            }
            if (!string.IsNullOrEmpty(ModelNumber))
            {
                list = list.Where(w => w.ModelNumber == ModelNumber);
            }
            if (!string.IsNullOrEmpty(CompanyName))
            {
                list = list.Where(w => w.CompanyName.Contains(CompanyName));
            }
            total = list.Count();
            list = list.Skip((pageIndex - 1) * pageSize).Take(pageSize);
            var obk = new { total = total, rows = list.ToList() };
            //序列化json字符串
            string result = JsonConvert.SerializeObject(obk);
            context.Response.Write(result);
        }



        //获取此供应商的订单列表
        private void getOrderlist(HttpContext context)
        {

            //获取登录的供应商id
            Model.base_Suppliers Suppliers = db.base_Suppliers.Where(w => w.LoginUserID == UserInfo.UserId).First();
            if (!string.IsNullOrEmpty(Suppliers.ID + ""))
            {
                string sql = @"select domain_PurchaseContractItem.OrderID,MaterialName,ModelNumber from domain_PurchaseContract inner join domain_PurchaseContractItem
on domain_PurchaseContract.ContractID=domain_PurchaseContractItem.ContractID where domain_PurchaseContract.SuppliersID=" + Suppliers.ID;
                var list = db.Database.SqlQuery<orderinfo>(sql); ;
                //序列化json字符串
                string result = JsonConvert.SerializeObject(list);
                context.Response.Write(result);
            }
            else
            {
                context.Response.Write("");
            }
        }


        //添加发货明细
        private void addDeliverGoods(HttpContext context)
        {
            string ID = context.Request["ID"] + "";//发货明细id
            string OrderID = context.Request["OrderID"] + "";//采购订单编号
            string ModelNumber = context.Request["ModelNumber"] + "";//物料型号
            string MaterialName = context.Request["MaterialName"] + "";//物料名称
            string TheDeliveryAmout = context.Request["TheDeliveryAmout"] + "";//发货数量
            string Number = context.Request["Number"] + "";//件数
            string DeliveryNum = context.Request["DeliveryNum"] + "";//发货单号
            string LogisticsCompany = context.Request["LogisticsCompany"] + "";//发货公司
            if (string.IsNullOrEmpty(ID))
            {
                Model.domain_DeliverGoods de = new Model.domain_DeliverGoods
                {
                    OrderID = OrderID,
                    ModelNumber = ModelNumber,
                    MaterialName = MaterialName,
                    TheDeliveryAmout = Convert.ToDecimal(TheDeliveryAmout),
                    Number = Convert.ToDecimal(Number),
                    DeliveryNum = DeliveryNum,
                    LogisticsCompany = LogisticsCompany,
                    AddBy = UserInfo.UserName,
                    AddTime = DateTime.Now

                };
                db.domain_DeliverGoods.Add(de);
            }
            else
            {
                int Id = Convert.ToInt32(ID);
                Model.domain_DeliverGoods de = db.domain_DeliverGoods.Where(w => w.ID == Id).FirstOrDefault();
                de.OrderID = OrderID;
                de.ModelNumber = ModelNumber;
                de.MaterialName = MaterialName;
                if (!string.IsNullOrEmpty(TheDeliveryAmout))
                {
                    de.TheDeliveryAmout = Convert.ToDecimal(TheDeliveryAmout);
                }
                if (!string.IsNullOrEmpty(Number))
                {
                    de.Number = Convert.ToDecimal(Number);
                }
                if (!string.IsNullOrEmpty(DeliveryNum))
                {
                    de.DeliveryNum = DeliveryNum;
                }
                if (!string.IsNullOrEmpty(LogisticsCompany))
                {
                    de.LogisticsCompany = LogisticsCompany;
                }
                de.LastUpdateBy = UserInfo.UserName;
                de.LastUpdateTime = DateTime.Now;
            }
            int num = db.SaveChanges();
            context.Response.Write("{\"d\":" + num + "}");

        }



        //发货信息
        public class DeliverGoods_View
        {
            public int? ID { get; set; }//明细编号
            public string OrderID { get; set; }// 采购订单编号
            public string MaterialName { get; set; }// 物料名称
            public string ModelNumber { get; set; }//物料型号
            public string CompanyName { get; set; }//供应商名称
            public int? SuppliersID { get; set; }//供应商id
            public decimal? Amout { get; set; }//采购数量
            public string TechnicalParameters { get; set; }//技术参数
            public decimal? Number { get; set; }//件数
            public string Requirement { get; set; }//特殊雪球
            public string DeliveryNum { get; set; }//发货单号
            public string LogisticsCompany { get; set; }//发货公司
            public decimal? AllDeliverCount { get; set; }//已发货数量    
            public decimal? TheDeliveryAmout { get; set; }//本次发货数量   
            public DateTime? DeliverGoodsTime { get; set; }//发货时间   

        }
        public class orderinfo
        {
            public string OrderID { get; set; }// 采购订单编号
            public string MaterialName { get; set; }// 物料名称
            public string ModelNumber { get; set; }//物料型号
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