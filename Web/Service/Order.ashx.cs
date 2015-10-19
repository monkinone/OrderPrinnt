using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Web;
using OrderPrintSystem.BLL;
using OrderPrintSystem.Model;
using OrderPrintSystem.Modules;
using System.Data;

namespace Web.Service
{
    /// <summary>
    /// Order 的摘要说明
    /// </summary>
    public class Order : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
              string operation=context.Request["opr"];
              switch (operation.ToLower())
              {
                  case "getprintsgdcount"://获取随工单打印次数
                      GetPrintSGDCount(context);
                      break;
                  case "updateismodify":
                      UpdateIsModify(context);//将修改外壳图片状态改为0
                      break;                
                  case "getbiaoshiimg"://获取标识图片
                      GetBiaoshiImg(context);
                      break;
                  case "getwaikwimg"://获取外壳图片
                      GetWaikwImg(context);
                      break;
                  case "isupdatebiaoshiimg"://根据产品型号查询是否修改了标示图片、标示编号
                      isUpdateBiaoshiImg(context);
                      break;
                  case "isupdatewaikeimg"://根据产品型号查询是否修改了外壳图片，外壳编号
                      isUpdateWaikeImg(context);
                      break;
                  case "updateproordersdetail"://修改订单详情
                      UpdateProOrdersDetail(context);
                      break;
                  case "getprice"://获取单价
                      GetPrice(context);
                      break;
                  case "isshowprint"://根据客户编号控制打印合同按钮是否显示
                      IsShowPrint(context);
                      break;
                  case "isexistordernum"://判断订单编号是否存在
                      isExistOrderNum(context);
                      break;
                  case "gethetongtishi"://获取合同提示
                      GetHetongTishi(context);
                      break;
                  case "isexistcustom"://判断客户编号是否存在
                      isExistCustom(context);
                      break;
                  case "isexistprotype"://判断产品型号是否存在
                      isExistProType(context);
                      break;
                  case "isadd"://判断是否已经录入客户信息
                      isAdd(context);
                      break;
                  case "isaddxianchang"://判断是否已经录入线长
                      isAddXianchang(context);
                      break;
              }
        }
        /// <summary>
        /// 修改订单详情
        /// </summary>
        /// <param name="context"></param>
        private void UpdateProOrdersDetail(HttpContext context)
        {
           string id=context.Request["id"]+"";
           string PiHao = context.Request["PiHao"] + "";
           string PlanSendTime = context.Request["PlanSendTime"] + "";
           string ProductAddress = context.Request["ProductAddress"] + "";
           string withWorkNo = context.Request["withWorkNo"] + "";

           int result = 0;
           //修改订单详情
           if (id != "")
           {
               ProOrdersDetailMOD orderDetail = null;
               //加载订单基本信息
               orderDetail = ProOrdersDetailBLL.GetModel(Convert.ToInt32(id));
               orderDetail.PiHao = PiHao.Trim();
               try
               {
                   orderDetail.PlanSendTime = Convert.ToDateTime(PlanSendTime.Trim());
               }
               catch (Exception) { }
               orderDetail.ProductAddress = ProductAddress.Trim();
               orderDetail.withWorkNo = withWorkNo.Trim();

               result=ProOrdersDetailBLL.Update(orderDetail);
           }
           context.Response.Write(result);
        }

        /// <summary>
        /// 获取随工单打印次数
        /// </summary>
        private void GetPrintSGDCount(HttpContext context)
        {
            int count = 0;
            string proType = context.Request["proType"] + "";
            string orderNum = context.Request["orderNum"] + "";
            ProOrdersDetailMOD orderDetailMod = ProOrdersDetailBLL.GetModel(proType, orderNum);
            if (orderDetailMod != null)
            {
                count = orderDetailMod.PrintSGDCount;
            }
            context.Response.Write("{\"d\":"+count+"}");
        }

        /// <summary>
        /// 将修改外壳图片状态改为0
        /// </summary>
        public void UpdateIsModify(HttpContext context)
        {
            int num = 0;
            string proType = context.Request["proType"]+"";
            try
            {
                ProductsMOD productMod = ProductsBLL.GetModel(proType);
                if (productMod != null)
                {
                    string waiKeNo = productMod.waiKeNo;
                    WaiKeImgBLL.Updatemod(waiKeNo);
                }
                ProductsBLL.Update(proType);
                num = 1;
            }
            catch (Exception ex)
            {
                num = 0;
            }
            context.Response.Write("{\"d\":" + num + "}");
        }

        /// <summary>
        /// 获取标示图片
        /// </summary>
        public void GetBiaoshiImg(HttpContext context)
        {
            string url = "";
            string proType = context.Request["proType"]+"";
            ProductsMOD productMod = ProductsBLL.GetModel(proType);
            if (productMod != null)
            {
                url = productMod.biaoShiPicture;
            }
            context.Response.Write("{\"d\":\"" + url + "\"}");
        }
        /// <summary>
        /// 获取外壳图片
        /// </summary>
        /// <param name="proType"></param>
        /// <returns></returns>
        public void GetWaikwImg(HttpContext context)
        {
            string url = "";
            string proType = context.Request["proType"] + "";
            ProductsMOD productMod = ProductsBLL.GetModel(proType);
            if (productMod != null)
            {
                string waiKeNo = productMod.waiKeNo;
                WaiKeImgMOD imgMod = WaiKeImgBLL.GetmodByid(waiKeNo);
                if (imgMod != null)
                {
                    url = imgMod.WaiKeImg;
                }
            }
            context.Response.Write("{\"d\":\"" + url + "\"}");
        }

        /// <summary>
        /// 根据产品型号查询是否修改了标示图片、标示编号
        /// </summary>
        /// <param name="customerNum"></param>
        /// <returns>1修改  0未修改</returns>
        public void isUpdateBiaoshiImg(HttpContext context)
        {
            int isUpdate = 0;
            string proType = context.Request["proType"] + "";
            ProductsMOD productMod = ProductsBLL.GetModel(proType);
            if (productMod != null)
            {
                isUpdate = Convert.ToInt32(productMod.isModifyTZ);
            }
            context.Response.Write("{\"d\":" + isUpdate + "}");
        }

        /// <summary>
        /// 根据产品型号查询是否修改了外壳图片，外壳编号
        /// </summary>
        /// <param name="customerNum"></param>
        /// <returns>1修改  0未修改</returns>
        public void isUpdateWaikeImg(HttpContext context)
        {
            int isUpdate = 0;
            string proType = context.Request["proType"] + "";
            ProductsMOD productMod = ProductsBLL.GetModel(proType);
            if (productMod != null)
            {
                isUpdate = Convert.ToInt32(productMod.IsModifyWaikeNo);
                if (isUpdate == 0)
                {
                    string waiKeNo = productMod.waiKeNo;
                    WaiKeImgMOD imgMod = WaiKeImgBLL.GetmodByid(waiKeNo);
                    if (imgMod != null)
                    {
                        isUpdate = imgMod.IsModify;
                    }
                }
            }
            context.Response.Write("{\"d\":" + isUpdate + "}");
        }
        /// <summary>
        /// 获取单价
        /// </summary>
        public void GetPrice(HttpContext context)
        {
            string price = "";
            string customerNum = context.Request["customerNum"]+"";
            string proType = context.Request["proType"] + "";
            DataSet ds = PriceManageBLL.GetmodAll(" and customNo='" + customerNum + "' and productNo='" + proType + "'");
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                price = ds.Tables[0].Rows[0]["price"].ToString();
            }
            context.Response.Write("{\"d\":\"" + price + "\"}");
        }
        /// <summary>
        /// 根据客户编号控制打印合同按钮是否显示
        /// </summary>
        /// <returns></returns>
        public void IsShowPrint(HttpContext context)
        {
            string isShow = "";
            string customerNum = context.Request["customerNum"]+"";
            DataSet ds = CustomerManageBLL.GetcustomerAll(" and customerNo='" + customerNum + "'");
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                isShow = ds.Tables[0].Rows[0]["isFanben"].ToString();
            }
            context.Response.Write("{\"d\":" + isShow + "}");
        }
        /// <summary>
        /// 判断订单编号是否存在
        /// </summary>
        /// <returns></returns>
        public void isExistOrderNum(HttpContext context)
        {
            int num = 0;
            string orderNum = context.Request["orderNum"] + "";
            ProOrdersMOD mod = ProOrdersBLL.GetModel(orderNum);
            if (mod != null)
            {
                num = 1;
            }
            context.Response.Write("{\"d\":" + num + "}");
        }
        /// <summary>
        /// 获取合同提示
        /// </summary>
        public void GetHetongTishi(HttpContext context)
        {
            string str = "";
            string customerNum = context.Request["customerNum"] + "";
            CustomerManageMod customer = CustomerManageBLL.GetcustomerByid(customerNum);
            if (customer != null)
            {
                if (customer.IsFanben == 0)
                {
                    str = "本客户自己提供合同模板，请使用签订客户合同";
                }
            }
            context.Response.Write("{\"d\":\"" + str + "\"}");
        }
        /// <summary>
        /// 判断客户编号是否存在
        /// </summary>
        public void isExistCustom(HttpContext context)
        {
            string huikuan = "无";
            string customerNum = context.Request["customerNum"] + "";
            CustomerManageMod mod = CustomerManageBLL.GetcustomerByid(customerNum);
            if (mod != null)
            {
                huikuan = mod.BackMethod;
            }
            context.Response.Write("{\"d\":\"" + huikuan + "\"}");
        }
        /// <summary>
        /// 判断产品型号是否存在
        /// </summary>
        public void isExistProType(HttpContext context)
        {
            int num = 0;
            string proType = context.Request["proType"]+"";
            ProductsMOD mod = ProductsBLL.GetModel(proType);
            if (mod != null)
            {
                num = 1;
            }
            context.Response.Write("{\"d\":" + num + "}");
        }

        /// <summary>
        /// 判断是否已经录入客户信息
        /// </summary>
        public void isAdd(HttpContext context)
        {
            string num = "";
            string customNum = context.Request["customNum"] + "";
            CustomerManageMod customerMod = CustomerManageBLL.GetcustomerByid(customNum.Trim());
            if (customerMod != null)
            {
                if (customerMod.IsAddInfo+"" != "")
                {
                    num = customerMod.IsAddInfo.ToString();
                }
            }
            context.Response.Write("{\"d\":" + num + "}");
        }
        /// <summary>
        /// 判断是否已经录入线长
        /// </summary>
        public void isAddXianchang(HttpContext context)
        {
            string str = "";
            string customerNum = context.Request["customerNum"] + "";
            string proType = context.Request["proType"] + "";
            ProductParamMOD mod = ProductParamBLL.GetmodByid(customerNum, proType);
            if (mod != null)
            {
                str= mod.IsWriteFahuoInfo + "|" + mod.IsWriteXianChang;
            }
            context.Response.Write("{\"d\":\"" + str + "\"}");
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