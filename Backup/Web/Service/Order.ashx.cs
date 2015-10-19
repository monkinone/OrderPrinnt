using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Web;
using OrderPrintSystem.BLL;
using OrderPrintSystem.Model;
using OrderPrintSystem.Modules;

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
        /// <param name="proType"></param>
        /// <param name="orderNum"></param>
        /// <returns></returns>
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

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}