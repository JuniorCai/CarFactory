namespace CarFactory.EntityFramework.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Infrastructure.Annotations;
    using System.Data.Entity.Migrations;
    
    public partial class initialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Report",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ReportName = c.String(maxLength: 50, storeType: "nvarchar"),
                        Img = c.String(maxLength: 50, storeType: "nvarchar"),
                        RelativeId = c.String(maxLength: 11, storeType: "nvarchar"),
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
                    { "DynamicFilter_Report_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id);
            
            AlterColumn("dbo.Category", "CategoryName", c => c.String(nullable: false, maxLength: 50, storeType: "nvarchar"));
            AlterColumn("dbo.Category", "ShortName", c => c.String(nullable: false, maxLength: 50, storeType: "nvarchar"));
            AlterColumn("dbo.Product", "Title", c => c.String(nullable: false, maxLength: 50, storeType: "nvarchar"));
            AlterColumn("dbo.Product", "Img", c => c.String(nullable: false, maxLength: 100, storeType: "nvarchar"));
            AlterColumn("dbo.Product", "Url", c => c.String(maxLength: 50, storeType: "nvarchar"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Product", "Url", c => c.String(maxLength: 4000, storeType: "nvarchar"));
            AlterColumn("dbo.Product", "Img", c => c.String(nullable: false, maxLength: 4000, storeType: "nvarchar"));
            AlterColumn("dbo.Product", "Title", c => c.String(nullable: false, maxLength: 4000, storeType: "nvarchar"));
            AlterColumn("dbo.Category", "ShortName", c => c.String(nullable: false, maxLength: 4000, storeType: "nvarchar"));
            AlterColumn("dbo.Category", "CategoryName", c => c.String(nullable: false, maxLength: 4000, storeType: "nvarchar"));
            DropTable("dbo.Report",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_Report_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
        }
    }
}
