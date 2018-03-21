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
                "dbo.Seo",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SiteTitle = c.String(nullable: false, maxLength: 50, storeType: "nvarchar"),
                        SiteKeywords = c.String(maxLength: 200, storeType: "nvarchar"),
                        SiteDescription = c.String(maxLength: 1000, storeType: "nvarchar"),
                        SiteBannerImgs = c.String(nullable: false, maxLength: 1000, storeType: "nvarchar"),
                        WatermarkAble = c.Boolean(nullable: false),
                        Watermark = c.String(maxLength: 50, storeType: "nvarchar"),
                        IcpNumber = c.String(maxLength: 50, storeType: "nvarchar"),
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
                    { "DynamicFilter_Seo_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Seo",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_Seo_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
        }
    }
}
