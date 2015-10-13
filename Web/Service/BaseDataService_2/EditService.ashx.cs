using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Web.Service.BaseDataService_2
{
    /// <summary>
    /// EditService 的摘要说明
    /// </summary>
    public class EditService :BaseService
    {

        public override void ProcessRequest(HttpContext context)
        {
            base.ProcessRequest(context);

            context.Response.ContentType = "application/json";
            //opr请求执行的程序名称
            string opr = context.Request["opr"] + "";
            switch (opr.ToLower())
            {
                case "warehouse":
                    EditWareHouse(context);
                    break;
                case "materialcategory":
                    EditMaterialCategory(context);
                    break;
                case "unit":
                    EditUnit(context);
                    break;
                case "materialattribute":
                    EditMaterialAttribute(context);
                    break;
                case "material":
                    EditMaterial(context);
                    break;
            }
        }
        /// <summary>
        /// 编辑仓库名称
        /// </summary>
        private void EditWareHouse(HttpContext context) 
        {
            Model.base_WareHouse wh = new Model.base_WareHouse()
            {
                ID = int.Parse(context.Request["ID"] + ""),//仓库ID
                WareHouseName = context.Request["WareHouseName"] + "",//仓库名称
                CategoryIDs = context.Request["CategoryIDs"] + "",
                CategoryNames = context.Request["CategoryNames"] + "",
                Position = context.Request["Position"] + "",//位置
                Status = 1,//状态
                Remark = context.Request["Remark"] + "",//备注
                LastUpdateBy = UserInfo.UserName,//编辑人
                LastUpdateTime = DateTime.Now//编辑时间         
            };
            //先将实体附加到实体上下文中
            db.base_WareHouse.Attach(wh);
            //手动修改实体的状态
            db.Entry(wh).State = EntityState.Modified;
            int num = db.SaveChanges();
            context.Response.Write("{\"d\":" + num + "}");
        }
        /// <summary>
        /// 编辑物料类别
        /// </summary>
        private void EditMaterialCategory(HttpContext context)
        {
            int ID = int.Parse(context.Request["ID"] + "");//仓库ID
            string CategoryName = context.Request["CategoryName"] + "";
            string ParentName = context.Request["ParentName"] + "";
            Model.base_MaterialCategory mc = new Model.base_MaterialCategory()
            {
                ID = ID,
                CategoryName= CategoryName,
                Status = 1,//状态
                LastUpdateBy = UserInfo.UserName,//编辑人
                LastUpdateTime = DateTime.Now//编辑时间         
            };
            //如果输入上一级不为空，填充ParentID
            if (!string.IsNullOrEmpty(ParentName.Trim()))
            {
                List<Model.base_MaterialCategory> list = db.base_MaterialCategory.Where(w => w.CategoryName == ParentName).Select(s => s).ToList();
                if (list.Count == 0)
                {
                    var obj = new { d = 0, msg = "上一级输入错误，不存在！" };
                    context.Response.Write(JsonConvert.SerializeObject(obj));
                    return;
                }
                else
                {
                    mc.ParentID = list[0].ID;
                    mc.ParentName = ParentName;
                }
            }
            //先将实体附加到实体上下文中
            db.base_MaterialCategory.Attach(mc);
            //手动修改实体的状态
            db.Entry(mc).State = EntityState.Modified;
            int num = db.SaveChanges();
            context.Response.Write("{\"d\":" + num + "}");
        }
        /// <summary>
        /// 编辑原料属性
        /// </summary>
        private void EditMaterialAttribute(HttpContext context) {
            Model.base_MaterialAttribute ma = new Model.base_MaterialAttribute()
            {
                ID = int.Parse(context.Request["ID"] + ""),//原料属性ID
                AttributeName = context.Request["AttributeName"] + "",
                Status = 1,//状态
                LastUpdateBy = UserInfo.UserName,//编辑人
                LastUpdateTime = DateTime.Now//编辑时间         
            };
            //先将实体附加到实体上下文中
            db.base_MaterialAttribute.Attach(ma);
            //手动修改实体的状态
            db.Entry(ma).State = EntityState.Modified;
            int num = db.SaveChanges();
            context.Response.Write("{\"d\":" + num + "}");
        }
        /// <summary>
        /// 变价计量单位
        /// </summary>
        private void EditUnit(HttpContext context) 
        {
            Model.base_Unit unit = new Model.base_Unit()
            {
                ID = int.Parse(context.Request["ID"] + ""),//原料属性ID
                UnitName = context.Request["UnitName"] + "",
                Status = 1,//状态
                LastUpdateBy = UserInfo.UserName,//编辑人
                LastUpdateTime = DateTime.Now//编辑时间         
            };
            //先将实体附加到实体上下文中
            db.base_Unit.Attach(unit);
            //手动修改实体的状态
            db.Entry(unit).State = EntityState.Modified;
            int num = db.SaveChanges();
            context.Response.Write("{\"d\":" + num + "}");
        }
        /// <summary>
        /// 编辑物料
        /// </summary>
        private void EditMaterial(HttpContext context)
        { 
            int ID = NCore.DataConvert.ToInt(context.Request["ID"],0);
            string ModelNumber = context.Request["ModelNumber"] + "";
            string ModelNumber_old = context.Request["ModelNumber_old"] + "";
            //新输入的型号和原来的型号不一致，才执行。
            if(!ModelNumber.Equals(ModelNumber_old))
            {
            //判断型号是否已经存在
            List<int> listM = db.base_Material.Where(w => w.ModelNumber == ModelNumber).Select(s => s.ID).ToList();
            if (listM.Count > 0)
            {
                context.Response.Write("{\"d\":-1,\"msg\":\"型号【" + ModelNumber + "】已存在！\"}");
                return;
            }
            }
            string MaterialName = context.Request["MaterialName"] + "";
            string MaterialName_old = context.Request["MaterialName_old"] + "";
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
                ID =ID,
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
                LastUpdateBy = UserInfo.UserName,//添加人
                LastUpdateTime = DateTime.Now//添加时间    
            };

            //先将实体附加到实体上下文中
            db.base_Material.Attach(m);
            //手动修改实体的状态
            db.Entry(m).State = EntityState.Modified;
            int num = db.SaveChanges();
            //删除物料库存表的记录
            foreach (var item in 
                          db.domain_Material_WareHouse.Where(w => w.MaterialModelNumber == ModelNumber_old && w.MaterialName==MaterialName_old))
            {
                 //2,将对象添加到EF管理容器中
                db.domain_Material_WareHouse.Attach(item);
                //3,修改对象的包装类对象标识为删除状态
                db.domain_Material_WareHouse.Remove(item);
            }
            db.SaveChanges();
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