using System.Collections.Generic;
using System.Data.Entity.Migrations;

namespace CarFactory.Migrations
{
    public partial class CreateTables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                    "dbo.Product",
                    c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(unicode: false),
                        Img = c.String(unicode: false),
                        Url = c.String(unicode: false),
                        CategoryId = c.Int(nullable: false),
                        IsShow = c.Boolean(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        DeleterUserId = c.Long(),
                        DeletionTime = c.DateTime(precision: 0),
                        LastModificationTime = c.DateTime(precision: 0),
                        LastModifierUserId = c.Long(),
                        CreationTime = c.DateTime(nullable: false, precision: 0),
                        CreatorUserId = c.Long(),
                    },
                    annotations: new Dictionary<string, object>
                    {
                        { "DynamicFilter_Product_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Category", t => t.CategoryId, cascadeDelete: true)
                .Index(t => t.CategoryId);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "CategoryId", "dbo.Category");
            DropIndex("dbo.Products", new[] { "CategoryId" });
            DropTable("dbo.Products",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_Product_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
        }
    }
}
