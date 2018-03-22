namespace CarFactory.EntityFramework.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Infrastructure.Annotations;
    using System.Data.Entity.Migrations;
    
    public partial class initialCreate1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Banner",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Img = c.String(maxLength: 50, storeType: "nvarchar"),
                        ImgAlt = c.String(maxLength: 50, storeType: "nvarchar"),
                        ImgTitle = c.String(maxLength: 50, storeType: "nvarchar"),
                        Sort = c.Int(nullable: false),
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
                    { "DynamicFilter_Banner_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id);
            
            DropColumn("dbo.Seo", "SiteBannerImgs");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Seo", "SiteBannerImgs", c => c.String(maxLength: 1000, storeType: "nvarchar"));
            DropTable("dbo.Banner",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_Banner_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
        }
    }
}
