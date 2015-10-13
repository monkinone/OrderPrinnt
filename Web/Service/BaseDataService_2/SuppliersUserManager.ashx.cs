using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Service.BaseDataService_2
{
    /// <summary>
    /// SuppliersUserManager 的摘要说明
    /// </summary>
    public class SuppliersUserManager : BaseService
    {

        public override void ProcessRequest(HttpContext context)
        {
            base.ProcessRequest(context);
            context.Response.ContentType = "application/json";
            string opr = context.Request["opr"] + "";
            switch (opr)
            {
                case "getlist"://获取登录用户列表
                    getSupplierUserList(context);
                    break;
                case "addUser":
                    addUser(context);
                    break;
                case "editUser":
                    editUser(context);
                    break;
                case "delUser":
                    delUser(context);
                    break;
            }
        }
        /// <summary>
        /// 获取供应商用户列表
        /// </summary>
        /// <param name="context"></param>
        private void getSupplierUserList(HttpContext context)
        {
            int pageSize = NCore.DataConvert.ToInt(context.Request["rows"] + "", 20);
            int pageIndex = NCore.DataConvert.ToInt(context.Request["page"] + "", 1);
            int total;
            var list =
                from user in db.userManage.Where(w => w.userType == 9)
                join sup in db.base_Suppliers.Where(w => w.Status == 0)
                on user.userId equals sup.LoginUserID into temp
                from item in temp.DefaultIfEmpty()
                select new
                {
                    CompanyName = item.CompanyName ?? "",
                    user.userId,
                    user.userName,
                    user.phone,
                    user.userPass,
                    user.trueName,
                    user.loginNum
                } into s
                group s by s.userId into g
                select new
                {
                    userPass = g.Select(d => d.userPass).FirstOrDefault(),
                    userName = g.Select(d => d.userName).FirstOrDefault(),
                    trueName = g.Select(d => d.trueName).FirstOrDefault(),
                    phone = g.Select(d => d.phone).FirstOrDefault(),
                    loginNum = g.Select(d => d.loginNum).FirstOrDefault(),
                    userId = g.Select(d => d.userId).FirstOrDefault(),
                    CompanyName = g.Select(d => d.CompanyName)
                };

            //     )
            //group item by item.userId into g
            //select new
            //{
            //    g.Key,
            //    ID = g.Select(s => s.userId).FirstOrDefault(),
            //    userName = g.Select(s => s.userName).FirstOrDefault(),
            //    trueName = g.Select(s => s.trueName).FirstOrDefault(),
            //    phone = g.Select(s => s.phone).FirstOrDefault(),
            //    loginNum = g.Select(s => s.loginNum).FirstOrDefault(),
            //    CompanyName = g.Select(s => s.CompanyName)
            //};
            total = list.Count();
            list = list.OrderBy(o => o.userId).Skip((pageIndex - 1) * pageSize).Take(pageSize);

            var obk = new { total = total, rows = list.ToList() };
            //序列化json字符串
            string result = JsonConvert.SerializeObject(obk);
            context.Response.Write(result);
        }


        /// <summary>
        /// 添加用户
        /// </summary>
        /// <param name="context"></param>
        private void addUser(HttpContext context)
        {
            string userName = context.Request["userName"] + "";
            var data = db.userManage.Where(w => w.userName == userName);
            if (data.Count() > 0)
            {
                context.Response.Write("{\"d\":111}");
            }
            else
            {
                Model.userManage user = new Model.userManage()
               {
                   userName = userName,
                   trueName = context.Request["trueName"] + "",
                   phone = context.Request["phone"] + "",
                   userType = 9,//供应商用户
                   userPass = context.Request["userPass"] + "",
                   loginNum = 0
               };
                db.userManage.Add(user);
                int num = db.SaveChanges();
                context.Response.Write("{\"d\":" + num + "}");
            }
        }
        /// <summary>
        /// 编辑用户
        /// </summary>
        /// <param name="context"></param>
        private void editUser(HttpContext context)
        {
            int userId = Convert.ToInt32(context.Request["userId"]);
            string userName = context.Request["userName"] + "";
            var users = db.userManage.Where(w => w.userId != userId && w.userName == userName);
            if (users.Count() == 0)
            {
                var user = db.userManage.Where(w => w.userId == userId).First();
                user.userName = userName;
                user.trueName = context.Request["trueName"] + "";
                user.phone = context.Request["phone"] + "";
                //user.userType = Convert.ToInt32(context.Request["userType"] + "");
                user.userPass = context.Request["userPass"] + "";
                //user.loginNum = Convert.ToInt32(context.Request["loginNum"] + "");
                int num = db.SaveChanges();
                context.Response.Write("{\"d\":" + num + "}");
            }
            else
            {
                context.Response.Write("{\"d\":111}");
            }
        }
        /// <summary>
        /// 删除供应商用户
        /// </summary>
        /// <param name="context"></param>
        private void delUser(HttpContext context)
        {
            int userId = Convert.ToInt32(context.Request["userId"]);

            var user = db.userManage.Where(w => w.userId == userId).FirstOrDefault();
            db.userManage.Remove(user);
            int num = db.SaveChanges();
            if (num == 1)
            {
                //将相关联的供应商用户的 登录用户id清空
                var supliers = db.base_Suppliers.Where(w => w.LoginUserID == userId);
                if (supliers.Count() > 0)
                {
                    foreach (var item in supliers)
                    {
                        item.LoginUserID = null;
                    }
                    db.SaveChanges();
                }
            }
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