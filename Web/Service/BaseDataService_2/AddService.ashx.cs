using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Web.Model;

namespace Web.Service.BaseDataService_2
{
    /// <summary>
    /// 添加基础数据的服务类
    /// </summary>
    public class AddService : BaseService
    {
        
        public override void ProcessRequest(HttpContext context)
        {
            base.ProcessRequest(context);

            context.Response.ContentType = "application/json";
            //opr请求执行的程序名称
            string opr = context.Request["opr"]+"";
            switch(opr.ToLower()){
                case "warehouse":
                AddWareHouse(context);
                break;
                case "materialcategory":
                AddMaterialCategory(context);
                break;
                case "unit":
                AddUnit(context);
                break;
                case "materialattribute":
                AddMaterialAttribute(context);
                break;
                case "material":
                AddMaterial(context);
                break;
            }
        }
        /// <summary>
        /// 添加仓库
        /// </summary>
        private void AddWareHouse(HttpContext context)
        {
            Model.base_WareHouse wh = new Model.base_WareHouse() {
             WareHouseName=context.Request["WareHouseName"]+"",//仓库名称
             CategoryIDs=context.Request["CategoryIDs"]+"",
             CategoryNames = context.Request["CategoryNames"] + "",
             Position = context.Request["Position"]+"",//位置
             Status =1,//状态
             Remark = context.Request["Remark"] + "",//备注
             AddBy = UserInfo.UserName,//添加人
             AddTime = DateTime.Now//添加时间         
            };
            db.base_WareHouse.Add(wh);
            int num = db.SaveChanges();
            context.Response.Write("{\"d\":" + num + "}");
        }
        /// <summary>
        /// 添加物料分类
        /// </summary>
        private void AddMaterialCategory(HttpContext context)
        {
            string CategoryName = context.Request["CategoryName"] + "";
            string ParentName = context.Request["ParentName"]+"";
            Model.base_MaterialCategory mCategory = new Model.base_MaterialCategory() {
                CategoryName = CategoryName,//分类名称
                Status = 1,//状态
                AddBy = UserInfo.UserName,//添加人
                AddTime = DateTime.Now//添加时间    
            };
            //如果输入上一级不为空，填充ParentID
            if (!string.IsNullOrEmpty(ParentName.Trim()))
            {
                List<Model.base_MaterialCategory> list = db.base_MaterialCategory.Where(w => w.CategoryName == ParentName).Select(s => s).ToList();
                if (list.Count==0)
                {
                    var obj = new {d=0,msg="上一级输入错误，不存在！" };
                    context.Response.Write(JsonConvert.SerializeObject(obj));
                    return;
                }
                else
                {
                    mCategory.ParentID = list[0].ID;
                    mCategory.ParentName = ParentName;
                }
            }
            //录入数据库
            db.base_MaterialCategory.Add(mCategory);
            int num = db.SaveChanges();
            context.Response.Write("{\"d\":" + num + "}");
        }
        /// <summary>
        /// 添加物料属性
        /// </summary>
        private void AddMaterialAttribute(HttpContext context) {
            Model.base_MaterialAttribute ma = new Model.base_MaterialAttribute()
            {
                AttributeName = context.Request["AttributeName"] + "",//物料属性
                Status = 1,//状态
                AddBy = UserInfo.UserName,//添加人
                AddTime = DateTime.Now//添加时间         
            };
            db.base_MaterialAttribute.Add(ma);
            int num = db.SaveChanges();
            context.Response.Write("{\"d\":" + num + "}");
        }
        /// <summary>
        /// 添加计量单位
        /// </summary>
        private void AddUnit(HttpContext context)
        {
            Model.base_Unit unit = new Model.base_Unit()
            {
                UnitName = context.Request["UnitName"] + "",//物料属性
                Status = 1,//状态
                AddBy = UserInfo.UserName,//添加人
                AddTime = DateTime.Now//添加时间         
            };
            db.base_Unit.Add(unit);
            int num = db.SaveChanges();
            context.Response.Write("{\"d\":" + num + "}");
        }
        /// <summary>
        /// 添加物料信息
        /// </summary>
        private void AddMaterial(HttpContext context)
        {
            string ModelNumber = context.Request["ModelNumber"] + "";
            //判断型号是否已经存在
            List<int> listM = db.base_Material.Where(w => w.ModelNumber == ModelNumber).Select(s => s.ID).ToList();
            if (listM.Count > 0)
            {
                context.Response.Write("{\"d\":-1,\"msg\":\"型号【" + ModelNumber + "】已存在！\"}");
                return;
            }
            string MaterialName = context.Request["MaterialName"] + "";
            int CategoryID = NCore.DataConvert.ToInt(context.Request["CategoryID"]+"", 0);
            string CategoryName = context.Request["CategoryName"] + "";
            int AttributeID = NCore.DataConvert.ToInt(context.Request["AttributeID"] + "", 0);
            string AttributeName = context.Request["AttributeName"] + "";
            int UnitID = NCore.DataConvert.ToInt(context.Request["UnitID"] + "", 0);
            string UnitName = context.Request["UnitName"] + "";
            int UpperLimit = NCore.DataConvert.ToInt(context.Request["UpperLimit"] + "", 0);
            int LowerLimit = NCore.DataConvert.ToInt(context.Request["LowerLimit"] + "", 0);
            string TechnicalParameter = context.Request["TechnicalParameter"] + "";
            int Status = NCore.DataConvert.ToInt(context.Request["Status"] + "", 0);

            Model.base_Material m = new Model.base_Material()
            {
                MaterialName = MaterialName,
                ModelNumber = ModelNumber,
                CategoryID = CategoryID,
                CategoryName = CategoryName,
                AttributeID = AttributeID,
                AttributeName = AttributeName,
                UnitID = UnitID,
                UnitName = UnitName,
                UpperLimit = UpperLimit,
                LowerLimit = LowerLimit,
                TechnicalParameter = TechnicalParameter,
                Status = Status,
                AddBy = UserInfo.UserName,//添加人
                AddTime = DateTime.Now//添加时间    
            };

            db.base_Material.Add(m);
            int num = db.SaveChanges();
            //如果>0保存成功
            if (num > 0)
            {
                string Material_WareHouse = context.Request["Material_WareHouse"] ?? "";
                if (!string.IsNullOrEmpty(Material_WareHouse))
                {
                    //把json字符串转换成对象
                    List<Model.domain_Material_WareHouse> listMW = NCore.Json.JsonToListOnDCJS<Model.domain_Material_WareHouse>(Material_WareHouse);
                    if (listMW != null && listMW.Count > 0)
                    {
                        foreach (Model.domain_Material_WareHouse mw in listMW)
                        {
                            mw.MaterialModelNumber = ModelNumber;
                            mw.MaterialName = MaterialName;
                            db.domain_Material_WareHouse.Add(mw);
                        }

                        db.SaveChanges();
                    }
                }
                context.Response.Write("{\"d\":1}");
            }
            else
            {
                context.Response.Write("{\"d\":0,\"msg\":\"保存失败！\"}");
            }
            
        }
    }
}