using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Web.Model;

namespace Web.Service.BaseDataService_2
{
    /// <summary>
    /// searchService 的摘要说明
    /// </summary>
    public class SearchService : BaseService
    {

        public override void ProcessRequest(HttpContext context)
        {
            base.ProcessRequest(context);

            context.Response.ContentType = "application/json";
            string opr = context.Request["opr"]+"";
            switch (opr.ToLower())
            {
                case "warehouse":
                SearchWareHouse(context);
                break;
                case "materialcategory":
                SearchMaterialCategory(context);
                break;
                case "materialcategory_combotree":
                SearchMaterialCategory_ComboTree(context);
                break;
                case "unit":
                SearchUnit(context);
                break;
                case "materialattribute":
                SearchMaterialAttribute(context);
                break;
                case "materialattribute_combobox":
                SearchMaterialAttribute_Combobox(context);
                break;
                case "unit_combobox":
                SearchUnit_Combobox(context);
                break;
                case "warehouse_grid":
                Warehouse_Grid(context);
                break;
                case "material":
                SearchMaterial(context);
                break;
                case "material_warehouse":
                SearchMaterial_WareHouse(context);
                break;

            }
        }

        /// <summary>
        /// 查询库房
        /// </summary>
        private void SearchWareHouse(HttpContext context)
        {
            int pageSize = NCore.DataConvert.ToInt(context.Request["rows"] + "", 20);
            int pageIndex = NCore.DataConvert.ToInt(context.Request["page"] + "", 1);
            string wareHouseName = context.Request["WareHouseName"]+"";
            int total = db.base_WareHouse.Count();
            IQueryable<base_WareHouse> list = db.base_WareHouse.OrderByDescending(o => o.ID);
            if (!string.IsNullOrEmpty(wareHouseName))
            {
                list = list.Where(w => w.WareHouseName.Contains(wareHouseName)==true);
            }

            list = list.Skip((pageIndex - 1) * pageSize).Take(pageSize);

            var obk = new { total = total, rows = list.ToList() };
            //序列化json字符串
           string result = JsonConvert.SerializeObject(obk);
           context.Response.Write(result);
        }
        /// <summary>
        /// 查询物料类别
        /// </summary>
        private void SearchMaterialCategory(HttpContext context)
        {
            int pageSize = NCore.DataConvert.ToInt(context.Request["rows"] + "", 20);
            int pageIndex = NCore.DataConvert.ToInt(context.Request["page"] + "", 1);
            string wareHouseName = context.Request["CategoryName"] + "";
            int total = db.base_WareHouse.Count();
            IQueryable<base_MaterialCategory> list = db.base_MaterialCategory.OrderByDescending(o => o.ID);
            if (!string.IsNullOrEmpty(wareHouseName))
            {
                list = list.Where(w => w.CategoryName.Contains(wareHouseName) == true);
            }

            list = list.Skip((pageIndex - 1) * pageSize).Take(pageSize);

            var obk = new { total = total, rows = list.Select(s => new { ID = s.ID, CategoryName = s.CategoryName, _parentId = s.ParentID, ParentName = s.ParentName }) };
            //序列化json字符串
            string result = JsonConvert.SerializeObject(obk);
            context.Response.Write(result);
        }
        /// <summary>
        /// 查询物料属性
        /// </summary>
        private void SearchMaterialAttribute(HttpContext context)
        {
            int pageSize = NCore.DataConvert.ToInt(context.Request["rows"] + "", 20);
            int pageIndex = NCore.DataConvert.ToInt(context.Request["page"] + "", 1);
            string AttributeName = context.Request["AttributeName"] + "";
            int total = db.base_MaterialAttribute.Count();
            IQueryable<base_MaterialAttribute> list = db.base_MaterialAttribute.OrderByDescending(o => o.ID);
            if (!string.IsNullOrEmpty(AttributeName))
            {
                list = list.Where(w => w.AttributeName.Contains(AttributeName) == true);
            }

            list = list.Skip((pageIndex - 1) * pageSize).Take(pageSize);

            var obk = new { total = total, rows = list.ToList() };
            //序列化json字符串
            string result = JsonConvert.SerializeObject(obk);
            context.Response.Write(result);
        }
        /// <summary>
        /// 查询计量单位
        /// </summary>
        private void SearchUnit(HttpContext context)
        {
            int pageSize = NCore.DataConvert.ToInt(context.Request["rows"] + "", 20);
            int pageIndex = NCore.DataConvert.ToInt(context.Request["page"] + "", 1);
            string UnitName = context.Request["UnitName"] + "";
            int total = db.base_Unit.Count();
            IQueryable<base_Unit> list = db.base_Unit.OrderByDescending(o => o.ID);
            if (!string.IsNullOrEmpty(UnitName))
            {
                list = list.Where(w => w.UnitName.Contains(UnitName) == true);
            }

            list = list.Skip((pageIndex - 1) * pageSize).Take(pageSize);

            var obk = new { total = total, rows = list.ToList() };
            //序列化json字符串
            string result = JsonConvert.SerializeObject(obk);
            context.Response.Write(result);
        }
        /// <summary>
        /// 物料类别--绑定下拉树
        /// </summary>
        private void SearchMaterialCategory_ComboTree(HttpContext context)
        {
            List<string> CategoryIDs = (context.Request["CategoryIDs"] + "").Split(',').ToList();

            var listAll = db.base_MaterialCategory.OrderByDescending(o => o.ID).ToList();
            var listChildren = listAll.Where(w=>!string.IsNullOrEmpty(w.ParentID+"")).ToList();

            ArrayList arr = new ArrayList();
           foreach(base_MaterialCategory mc in listAll)
           {   
               if (string.IsNullOrEmpty(mc.ParentID + ""))
               {
                   ArrayList children = new ArrayList();
                   foreach (base_MaterialCategory mc2 in listChildren)
                   { 
                       if(mc.ID==mc2.ParentID){
                           children.Add(new { id = mc2.ID, text = mc2.CategoryName, CHECKED = CategoryIDs.Contains(mc2.ID + "") });
                       }
                   }
                   arr.Add(new { id = mc.ID, text = mc.CategoryName, children = children, CHECKED = CategoryIDs.Contains(mc.ID + "") });
               }
           }
            //序列化json字符串
           string result = JsonConvert.SerializeObject(arr).Replace("CHECKED", "checked");
           context.Response.Write(result);
        }
        /// <summary>
        /// 查询物料属性-绑定Combobox
        /// </summary>
        private void SearchMaterialAttribute_Combobox(HttpContext context) 
        {
            IQueryable<base_MaterialAttribute> list = db.base_MaterialAttribute.OrderByDescending(o => o.ID);
            //序列化json字符串
            string result = JsonConvert.SerializeObject(list.ToList());
            context.Response.Write(result);
        }
        /// <summary>
        /// 查询计量单位-绑定Combobox
        /// </summary>
        private void SearchUnit_Combobox(HttpContext context) 
        {
            IQueryable<base_Unit> list = db.base_Unit.OrderByDescending(o => o.ID);
            //序列化json字符串
            string result = JsonConvert.SerializeObject(list.ToList());
            context.Response.Write(result);
        }
        /// <summary>
        /// 库房-grid
        /// </summary>
        /// <param name="context"></param>
        private void Warehouse_Grid(HttpContext context) 
        {
            string CategoryName = context.Request["CategoryName"] + "";
            if (string.IsNullOrEmpty(CategoryName.Trim())) return;
            var listWH = db.base_WareHouse.Where(w => w.CategoryNames.Contains(CategoryName)==true).
                                                                   Select(s => new { WareHouseID= s.ID,s.WareHouseName,KuCun=0}).ToList();
            var obk = new { total = listWH.Count, rows = listWH };
            //序列化json字符串
            string result = JsonConvert.SerializeObject(obk);
            context.Response.Write(result);
        }
        /// <summary>
        /// 物料信息
        /// </summary>
        private void SearchMaterial(HttpContext context) 
        {
            int pageSize = NCore.DataConvert.ToInt(context.Request["rows"] + "", 20);
            int pageIndex = NCore.DataConvert.ToInt(context.Request["page"] + "", 1);
            string MaterialName = context.Request["MaterialName"] + "";
            string ModelNumber = context.Request["ModelNumber"] + "";
            string CategoryName = context.Request["CategoryName"] + "";
            int total = db.base_Material.Count();
            IQueryable<base_Material> list = db.base_Material.OrderByDescending(o => o.ID);
            if (!string.IsNullOrEmpty(MaterialName))
            {
                list = list.Where(w => w.MaterialName.Contains(MaterialName) == true);
            }
            if (!string.IsNullOrEmpty(ModelNumber))
            {
                list = list.Where(w => w.ModelNumber.Contains(ModelNumber) == true);
            }
            if (!string.IsNullOrEmpty(CategoryName))
            {
                list = list.Where(w => w.CategoryName.Contains(CategoryName) == true);
            }
                     
            list = list.Skip((pageIndex - 1) * pageSize).Take(pageSize);

            var obk = new { total = total, rows = list.ToList() };
            //序列化json字符串
            string result = JsonConvert.SerializeObject(obk);
            context.Response.Write(result);
        }
        /// <summary>
        /// 查询物料库存
        /// </summary>
        private void SearchMaterial_WareHouse(HttpContext context)
        {
            string ModelNumber = context.Request["ModelNumber"] ?? "";
            string MaterialName = context.Request["MaterialName"] ?? "";
            IQueryable<domain_Material_WareHouse> list = db.domain_Material_WareHouse
                                                                                             .Where(w => w.MaterialModelNumber == ModelNumber && w.MaterialName == MaterialName);
            //序列化json字符串
            string result = JsonConvert.SerializeObject(list.ToList());
            context.Response.Write(result);
        }
    }
}