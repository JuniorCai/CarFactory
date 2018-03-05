using System.Data.Common;
using System.Data.Entity;
using Abp.Zero.EntityFramework;
using CarFactory.Authorization.Roles;
using CarFactory.Authorization.Users;
using CarFactory.CustomDomain.Category;
using CarFactory.CustomDomain.Products;
using CarFactory.EntityMapper.Products;
using CarFactory.MultiTenancy;

namespace CarFactory.EntityFramework
{
    [DbConfigurationType(typeof(MySql.Data.Entity.MySqlEFConfiguration))]
    public class CarFactoryDbContext : AbpZeroDbContext<Tenant, Role, User>
    {
        //TODO: Define an IDbSet for your Entities...
        public IDbSet<Category> Categorys { get; set; }

        public IDbSet<Product> Products { get; set; }

        /* NOTE: 
         *   Setting "Default" to base class helps us when working migration commands on Package Manager Console.
         *   But it may cause problems when working Migrate.exe of EF. If you will apply migrations on command line, do not
         *   pass connection string name to base classes. ABP works either way.
         */
        public CarFactoryDbContext()
            : base("Default")
        {

        }

        /* NOTE:
         *   This constructor is used by ABP to pass connection string defined in CarFactoryDataModule.PreInitialize.
         *   Notice that, actually you will not directly create an instance of CarFactoryDbContext since ABP automatically handles it.
         */
        public CarFactoryDbContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {

        }

        //This constructor is used in tests
        public CarFactoryDbContext(DbConnection existingConnection)
         : base(existingConnection, false)
        {

        }

        public CarFactoryDbContext(DbConnection existingConnection, bool contextOwnsConnection)
         : base(existingConnection, contextOwnsConnection)
        {

        }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new CategoryCfg());
            modelBuilder.Configurations.Add(new ProductCfg());

            base.OnModelCreating(modelBuilder);
        }
    }
}
