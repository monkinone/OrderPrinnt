﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using Web.Model;

namespace Web.Service.DomainService_2
{
    /// <summary>
    /// EnterWareHouse 的摘要说明
    /// </summary>
    public class EnterWareHouse : BaseService
    {
        public override void ProcessRequest(HttpContext context)
        {
            base.ProcessRequest(context);

            context.Response.ContentType = "application/json";
            //opr请求执行的程序名称
            string opr = context.Request["opr"] + "";
            switch (opr.ToLower())
            {
                case "searchenterwarehouselog":
                    SearchEnterWareHouseLog(context);
                    break;
                case "addenterwarehouse":
                    AddEnterWareHouse(context);
                    break;
            }
        }
        /// <summary>
        ///  查询入仓日志
        /// </summary>
        private void SearchEnterWareHouseLog(HttpContext context)
        {
            int pageSize = NCore.DataConvert.ToInt(context.Request["rows"] + "", 20);
            int pageIndex = NCore.DataConvert.ToInt(context.Request["page"] + "", 1);
            string OrderID = context.Request["OrderID"] ?? ""; //采购订单编号
            string MaterialName = context.Request["MaterialName"] ?? "";//物料名称
            string ModelNumber = context.Request["ModelNumber"] ?? "";//物料编号
            string WareHouseName = context.Request["WareHouseName"] ?? "";//仓库名称
            int total = db.domain_EnterWareHouseLog.Count();
            IQueryable<domain_EnterWareHouseLog> list = db.domain_EnterWareHouseLog.OrderByDescending(o => o.ID);
            if (!string.IsNullOrEmpty(OrderID))
            {
                list = list.Where(w => w.OrderID.Contains(OrderID)==true);
            }
            if (!string.IsNullOrEmpty(MaterialName))
            {
                list = list.Where(w => w.MaterialName.Contains(MaterialName) == true);
            }
            if (!string.IsNullOrEmpty(ModelNumber))
            {
                list = list.Where(w => w.ModelNumber.Contains(ModelNumber) == true);
            }
            if (!string.IsNullOrEmpty(WareHouseName))
            {
                list = list.Where(w => w.WareHouseName.Contains(WareHouseName) == true);
            }

            list = list.Skip((pageIndex - 1) * pageSize).Take(pageSize);

            var obk = new { total = total, rows = list.ToList() };
            //序列化json字符串
            string result = JsonConvert.SerializeObject(obk);
            context.Response.Write(result);
        }
        /// <summary>
        /// 添加物料入仓
        /// </summary>
        private void AddEnterWareHouse(HttpContext context)
        {
            int  WareHouseID = NCore.DataConvert.ToInt(context.Request["WareHouseID"],0);
            string WareHouseName = context.Request["WareHouseName"] ?? "";
            string MaterialName = context.Request["MaterialName"]??"";
            string ModelNumber = context.Request["ModelNumber"] ?? "";
            decimal Amout = decimal.Parse(context.Request["Amout"] ?? "");

            Model.domain_EnterWareHouseLog log = new Model.domain_EnterWareHouseLog()
            {
                OrderID = context.Request["OrderID"]??"",
                MaterialName = MaterialName,
                ModelNumber = ModelNumber,
                CategoryName = context.Request["CategoryName"] ?? "",
                UnitName = context.Request["UnitName"]??"",
                Amout = Amout,
                WareHouseID = WareHouseID,
                WareHouseName = WareHouseName,
                Suppliers = context.Request["Suppliers"]??"",
                Remark = context.Request["Remark"]??"",
                DealWithBy = context.Request["DealWithBy"] ?? "",
                Department = context.Request["Department"] ?? "",
                DoBy = context.Request["DoBy"] ?? "",
                DoTime = DateTime.Now
            };
            db.domain_EnterWareHouseLog.Add(log);
            int num = db.SaveChanges();
            if (num > 0) //日志录入成功
            {
                List<domain_Material_WareHouse> list = db.domain_Material_WareHouse
                                                                                     .Where(w => w.WareHouseID == WareHouseID
                                                                                                  && w.MaterialName == MaterialName
                                                                                                  && w.MaterialModelNumber == ModelNumber)
                                                                                     .ToList();
                if (list.Count > 0)
                {  //物料库存表中存在
                    domain_Material_WareHouse mw = list[0];
                    //增加库存量
                    mw.KuCun += Amout;
                    //先将实体附加到实体上下文中
                    db.domain_Material_WareHouse.Attach(mw);
                    //手动修改实体的状态
                    db.Entry(mw).State = EntityState.Modified;
                    int r1= db.SaveChanges();
                    if(r1>0)
                    {
                        context.Response.Write("{\"d\":1}");
                    }
                    else
                    {
                        context.Response.Write("{\"d\":0,\"msg\":\"保存失败！\"}");
                    }
                }
                else
                { //物料库存表中不存在
                    domain_Material_WareHouse mw = new domain_Material_WareHouse()
                    {
                        KuCun = Amout,
                        MaterialModelNumber = ModelNumber,
                        MaterialName = MaterialName,
                        WareHouseID = WareHouseID,
                        WareHouseName = WareHouseName
                    };
                    db.domain_Material_WareHouse.Add(mw);
                    int r1 = db.SaveChanges();
                    if (r1 > 0)
                    {
                        context.Response.Write("{\"d\":1}");
                    }
                    else
                    {
                        context.Response.Write("{\"d\":0,\"msg\":\"保存失败！\"}");
                    }
                }
            }
            else 
            {
                context.Response.Write("{\"d\":0,\"msg\":\"保存失败！\"}");
            }
        }
        
    }
}