﻿//------------------------------------------------------------------------------
// <auto-generated>
//    此代码是根据模板生成的。
//
//    手动更改此文件可能会导致应用程序中发生异常行为。
//    如果重新生成代码，则将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace OrderPrintWeb.Model
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class GTEntities : DbContext
    {
        public GTEntities()
            : base("name=GTEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<BiaoShiImg> BiaoShiImg { get; set; }
        public DbSet<customer> customer { get; set; }
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
    }
}
