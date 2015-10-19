using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Service.BaseDataService_2
{
    /// <summary>
    /// DeleteService 的摘要说明
    /// </summary>
    public class DeleteService:BaseService
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
                    DeleteWareHouse(context);
                    break;
                case "materialcategory":
                    DeletematerialCategory(context);
                    break;
                case "unit":
                    DeleteUnit(context);
                    break;
                case "materialattribute":
                    DeleteMaterialAttribute(context);
                    break;
                case "material":
                    DeleteMaterial(context);
                    break;
            }

        }
        /// <summary>
        /// 删除仓库
        /// </summary>
        /// <param name="context"></param>
        private void DeleteWareHouse(HttpContext context)
        {
            //需要一个实体对象参数
            //1,创建要删除的对象
            Model.base_WareHouse wh = new Model.base_WareHouse() 
            {
                ID = int.Parse(context.Request["ID"] + ""),//仓库ID
            };
            //2,将对象添加到EF管理容器中
            db.base_WareHouse.Attach(wh);
            //3,修改对象的包装类对象标识为删除状态
            db.base_WareHouse.Remove(wh);
            //4,更新到数据库
            int num = db.SaveChanges();
            context.Response.Write("{\"d\":" + num + "}");
        }
        /// <summary>
        /// 删除物料类别
        /// </summary>
        private void DeletematerialCategory(HttpContext context)
        {
            //需要一个实体对象参数
            //1,创建要删除的对象
            Model.base_MaterialCategory mc = new Model.base_MaterialCategory()
            {
                ID = int.Parse(context.Request["ID"] + ""),//仓库ID
            };
            //2,将对象添加到EF管理容器中
            db.base_MaterialCategory.Attach(mc);
            //3,修改对象的包装类对象标识为删除状态
            db.base_MaterialCategory.Remove(mc);
            //4,更新到数据库
            int num = db.SaveChanges();
            context.Response.Write("{\"d\":" + num + "}");
        }
        /// <summary>
        /// 删除原料属性
        /// </summary>
        private void DeleteMaterialAttribute(HttpContext context) 
        {
            //需要一个实体对象参数
            //1,创建要删除的对象
            Model.base_MaterialAttribute ma = new Model.base_MaterialAttribute()
            {
                ID = int.Parse(context.Request["ID"] + ""),//仓库ID
            };
            //2,将对象添加到EF管理容器中
            db.base_MaterialAttribute.Attach(ma);
            //3,修改对象的包装类对象标识为删除状态
            db.base_MaterialAttribute.Remove(ma);
            //4,更新到数据库
            int num = db.SaveChanges();
            context.Response.Write("{\"d\":" + num + "}");
        }
        /// <summary>
        /// 删除计量单位
        /// </summary>
        private void DeleteUnit(HttpContext context)
        {
            //需要一个实体对象参数
            //1,创建要删除的对象
            Model.base_Unit ma = new Model.base_Unit()
            {
                ID = int.Parse(context.Request["ID"] + ""),//仓库ID
            };
            //2,将对象添加到EF管理容器中
            db.base_Unit.Attach(ma);
            //3,修改对象的包装类对象标识为删除状态
            db.base_Unit.Remove(ma);
            //4,更新到数据库
            int num = db.SaveChanges();
            context.Response.Write("{\"d\":" + num + "}");
        }
        /// <summary>
        /// 删除物料
        /// </summary>
        private void  DeleteMaterial(HttpContext context)
        {
            //需要一个实体对象参数
            //1,创建要删除的对象
            Model.base_Material m = new Model.base_Material()
            {
                ID = int.Parse(context.Request["ID"] + ""),//仓库ID
            };
            //2,将对象添加到EF管理容器中
            db.base_Material.Attach(m);
            //3,修改对象的包装类对象标识为删除状态
            db.base_Material.Remove(m);
            //4,更新到数据库
            int num = db.SaveChanges();
            if (num > 0)
            {
                string ModelNumber = context.Request["ModelNumber"] + "";
                string MaterialName = context.Request["MaterialName"] + "";
                //删除物料库存表的记录
                foreach (var item in
                              db.domain_Material_WareHouse.Where(w => w.MaterialModelNumber == ModelNumber && w.MaterialName == MaterialName))
                {
                    //2,将对象添加到EF管理容器中
                    db.domain_Material_WareHouse.Attach(item);
                    //3,修改对象的包装类对象标识为删除状态
                    db.domain_Material_WareHouse.Remove(item);
                }
            }
            db.SaveChanges();
            context.Response.Write("{\"d\":" + num + "}");
        }
    }
}