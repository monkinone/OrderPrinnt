using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Service.BaseDataService_2
{
    /// <summary>
    /// EvaluationLevelManager 的摘要说明
    /// 供应商评定等级
    /// </summary>
    public class EvaluationLevelManager : BaseService
    {

        public override void ProcessRequest(HttpContext context)
        {
            base.ProcessRequest(context);
            context.Response.ContentType = "application/json";
            string opr = context.Request["opr"] + "";
            switch (opr)
            {
                case "Levellist"://列表
                    getLevelList(context);
                    break;
                case "addLevel":
                    addLevel(context);
                    break;
                case "editLevel":
                    editLevel(context);
                    break;
                case "delLevel":
                    delLevel(context);
                    break;
                case "getLevelRecord"://获取调价记录
                    getLevelRecord(context);
                    break;

            }

        }
        /// <summary>
        /// 获取等级列表
        /// </summary>
        /// <param name="context"></param>
        private void getLevelList(HttpContext context)
        {
            int pageSize = NCore.DataConvert.ToInt(context.Request["rows"] + "", 20);
            int pageIndex = NCore.DataConvert.ToInt(context.Request["page"] + "", 1);
            IQueryable<Model.domain_EvaluationLevel> List = db.domain_EvaluationLevel.OrderByDescending(o => o.AddTime);
            int total;
            if (!string.IsNullOrEmpty(context.Request["SuppliersID"]))
            { //供应商id
                int SuppliersID = Convert.ToInt32(context.Request["SuppliersID"]);
                List = List.Where(w => w.SuppliersID == SuppliersID);
            }
            total = List.Count();
            var data = new { total = total, rows = List.ToList() };
            //序列化json字符串
            string result = JsonConvert.SerializeObject(data);
            context.Response.Write(result);
        }
        /// <summary>
        /// 添加评级信息
        /// </summary>
        /// <param name="context"></param>
        private void addLevel(HttpContext context)
        {
            int SuppliersID = Convert.ToInt32(context.Request["SuppliersID"]);
            var data = db.domain_EvaluationLevel.Where(w => w.SuppliersID == SuppliersID);
            if (data.Count() > 0)
            {
                context.Response.Write("{\"d\":111}");//此评级信息已存在
            }
            else
            {
                Model.domain_EvaluationLevel el = new Model.domain_EvaluationLevel()
               {
                   SuppliersID = SuppliersID,
                   CompanyName = context.Request["CompanyName"] + "",
                   Level = context.Request["Level"] + "",
                   AddBy = UserInfo.UserName,
                   AddTime = DateTime.Now
               };
                db.domain_EvaluationLevel.Add(el);
                Model.base_Suppliers sup = db.base_Suppliers.Where(w => w.ID == SuppliersID).First();
                sup.AssessmentLevel = el.Level;
                int num = db.SaveChanges();
                if (num == 2)
                {
                    num = 1;
                    Model.domain_Log log = new Model.domain_Log()
                                  {
                                      DoID = SuppliersID,
                                      DoType = 2,
                                      DoContent = "添加 " + el.Level,
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
        /// 编辑评级信息
        /// </summary>
        /// <param name="context"></param>
        private void editLevel(HttpContext context)
        {
            int num;
            int ID = Convert.ToInt32(context.Request["ID"]);
            int SuppliersID = Convert.ToInt32(context.Request["SuppliersID"]);
            string Level = context.Request["Level"] + "";
            Model.domain_EvaluationLevel el = db.domain_EvaluationLevel.Where(w => w.ID == ID).First();
            if (SuppliersID == el.SuppliersID && Level == el.Level)//信息未更改
            {
                num = 1;
            }
            else
            {
                el.SuppliersID = SuppliersID;
                el.CompanyName = context.Request["CompanyName"] + "";
                el.Level = Level;
                el.LastUpdateBy = UserInfo.UserName;
                el.LastUpdateTime = DateTime.Now;
                Model.base_Suppliers sup = db.base_Suppliers.Where(w => w.ID == el.SuppliersID).First();
                sup.AssessmentLevel = el.Level;
                num = db.SaveChanges();
                if (num == 2)
                {
                    num = 1;
                    Model.domain_Log log = new Model.domain_Log()
                    {
                        DoID = (int)el.SuppliersID,
                        DoType = 2,
                        DoContent = "编辑 " + el.Level,
                        DoBy = UserInfo.UserName,
                        DoTime = DateTime.Now
                    };
                    db.domain_Log.Add(log);
                    db.SaveChanges();
                }
            }
            context.Response.Write("{\"d\":" + num + "}");
        }
        /// <summary>
        /// 删除评级信息
        /// </summary>
        /// <param name="context"></param>
        private void delLevel(HttpContext context)
        {
            int ID = Convert.ToInt32(context.Request["ID"]);
            Model.domain_EvaluationLevel el = db.domain_EvaluationLevel.Where(w => w.ID == ID).First();
            db.domain_EvaluationLevel.Remove(el);
            Model.base_Suppliers sup = db.base_Suppliers.Where(w => w.ID == el.SuppliersID).First();
            sup.AssessmentLevel = "";
            int num = db.SaveChanges();
            if (num == 2)
            {
                num = 1;
                Model.domain_Log log = new Model.domain_Log()
               {
                   DoID = (int)el.SuppliersID,
                   DoType = 2,
                   DoContent = "删除 " + el.Level,
                   DoBy = UserInfo.UserName,
                   DoTime = DateTime.Now
               };
                db.domain_Log.Add(log);
                db.SaveChanges();
            }
            context.Response.Write("{\"d\":" + num + "}");
        }
        /// <summary>
        /// 获取供应商评级记录
        /// </summary>
        /// <param name="context"></param>
        private void getLevelRecord(HttpContext context)
        {
            int SuppliersID = Convert.ToInt32(context.Request["SuppliersID"] + "");
            var list = db.domain_Log.Where(w => w.DoType == 2 && w.DoID == SuppliersID).OrderByDescending(o => o.DoTime)
                .ToList().Select(d => new { d.DoBy, d.DoContent, DoTime = d.DoTime == null ? "" : DateTime.Parse(d.DoTime.ToString()).ToString("yyyy-mm-dd hh:mm:ss"), d.DoType, d.ID });
            //var list = db.domain_Log.Where(w => w.DoType == 2 ).OrderByDescending(o => o.DoTime);
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