using System.Data.Entity.Migrations;
using Abp.MultiTenancy;
using Abp.Zero.EntityFramework;
using CarFactory.EntityFramework;
using CarFactory.Migrations.SeedData;
using EntityFramework.DynamicFilters;

namespace CarFactory.Migrations
{
    public sealed class Configuration : DbMigrationsConfiguration<CarFactoryDbContext>, IMultiTenantSeed
    {
        public AbpTenantBase Tenant { get; set; }

        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "CarFactory";
            SetSqlGenerator("MySql.Data.MySqlClient",new MySql.Data.Entity.MySqlMigrationSqlGenerator());
        }

        protected override void Seed(CarFactoryDbContext context)
        {
            context.DisableAllFilters();

            if (Tenant == null)
            {
                //Host seed
                new InitialHostDbBuilder(context).Create();

                //Default tenant seed (in host database).
                new DefaultTenantCreator(context).Create();
                new TenantRoleAndUserBuilder(context, 1).Create();
            }
            else
            {
                //You can add seed for tenant databases and use Tenant property...
            }

            context.SaveChanges();
        }
    }
}
