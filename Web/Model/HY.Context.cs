﻿//------------------------------------------------------------------------------
// <auto-generated>
//    此代码是根据模板生成的。
//
//    手动更改此文件可能会导致应用程序中发生异常行为。
//    如果重新生成代码，则将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace Web.Model
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class OrderPrintEntities : DbContext
    {
        public OrderPrintEntities()
            : base("name=OrderPrintEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<base_Material> base_Material { get; set; }
        public DbSet<base_MaterialAttribute> base_MaterialAttribute { get; set; }
        public DbSet<base_MaterialCategory> base_MaterialCategory { get; set; }
        public DbSet<base_Suppliers> base_Suppliers { get; set; }
        public DbSet<base_Unit> base_Unit { get; set; }
        public DbSet<base_WareHouse> base_WareHouse { get; set; }
        public DbSet<BiaoShiImg> BiaoShiImg { get; set; }
        public DbSet<customer> customer { get; set; }
        public DbSet<domain_DeliverGoods> domain_DeliverGoods { get; set; }
        public DbSet<domain_EnterWareHouseLog> domain_EnterWareHouseLog { get; set; }
        public DbSet<domain_EvaluationLevel> domain_EvaluationLevel { get; set; }
        public DbSet<domain_Log> domain_Log { get; set; }
        public DbSet<domain_Material_WareHouse> domain_Material_WareHouse { get; set; }
        public DbSet<domain_MaterialPrice> domain_MaterialPrice { get; set; }
        public DbSet<domain_OutWareHouseLog> domain_OutWareHouseLog { get; set; }
        public DbSet<domain_PurchaseContract> domain_PurchaseContract { get; set; }
        public DbSet<domain_PurchaseContractItem> domain_PurchaseContractItem { get; set; }
        public DbSet<domain_PurchaseOrders> domain_PurchaseOrders { get; set; }
        public DbSet<domain_PurchaseOrdersItem> domain_PurchaseOrdersItem { get; set; }
        public DbSet<domain_ReturnWareHouseLog> domain_ReturnWareHouseLog { get; set; }
        public DbSet<GuanJiaoZhenImg> GuanJiaoZhenImg { get; set; }
        public DbSet<GuiGeShu> GuiGeShu { get; set; }
        public DbSet<MattersNeedingAttention> MattersNeedingAttention { get; set; }
        public DbSet<Notice> Notice { get; set; }
        public DbSet<priceManage> priceManage { get; set; }
        public DbSet<PrintSGDCount> PrintSGDCount { get; set; }
        public DbSet<ProductParam> ProductParam { get; set; }
        public DbSet<products> products { get; set; }
        public DbSet<proOrders> proOrders { get; set; }
        public DbSet<proOrdersDetail> proOrdersDetail { get; set; }
        public DbSet<SendDetail> SendDetail { get; set; }
        public DbSet<SGDRecord> SGDRecord { get; set; }
        public DbSet<userManage> userManage { get; set; }
        public DbSet<WaiKeImg> WaiKeImg { get; set; }
        public DbSet<view_NoWanChengOrder> view_NoWanChengOrder { get; set; }
        public DbSet<view_OrderList> view_OrderList { get; set; }
        public DbSet<view_SendOrder> view_SendOrder { get; set; }
    }
}
