namespace eShopWeb.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class createTable001 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                    "dbo.GoodDetails",
                    c => new
                    {
                        Id = c.Guid(nullable: false),
                        ImgUrl = c.String(nullable: false),
                        GoodsId = c.Guid(),
                        CreateTime = c.DateTime(nullable: false),
                        IsRemoved = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Goods", t => t.GoodsId)
                .Index(t => t.GoodsId);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.GoodDetails", "GoodsId", "dbo.Goods");
            DropIndex("dbo.GoodDetails", new []{ "GoodsId" });
            DropTable("dbo.GoodDetails");
        }
    }
}
