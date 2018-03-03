using System.Data.Common;
using System.Data.Entity;
using Abp.Zero.EntityFramework;
using NbscwMPACarFactory.Authorization.Roles;
using NbscwMPACarFactory.Authorization.Users;
using NbscwMPACarFactory.CustomDomain.Products;
using NbscwMPACarFactory.CustomDomain.Products.EntityMapper.Products;
using NbscwMPACarFactory.MultiTenancy;

namespace NbscwMPACarFactory.EntityFramework
{
    [DbConfigurationType(typeof(MySql.Data.Entity.MySqlEFConfiguration))]
    public class NbscwMPADbContext : AbpZeroDbContext<Tenant, Role, User>
    {
        //TODO: Define an IDbSet for your Entities...
        public IDbSet<Category> Categorys { get; set; }

        public IDbSet<Product> Products { get; set; }

        /* NOTE: 
         *   Setting "Default" to base class helps us when working migration commands on Package Manager Console.
         *   But it may cause problems when working Migrate.exe of EF. If you will apply migrations on command line, do not
         *   pass connection string name to base classes. ABP works either way.
         */
        public NbscwMPADbContext()
            : base("Default")
        {

        }

        /* NOTE:
         *   This constructor is used by ABP to pass connection string defined in NbscwMPADataModule.PreInitialize.
         *   Notice that, actually you will not directly create an instance of NbscwMPADbContext since ABP automatically handles it.
         */
        public NbscwMPADbContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {

        }

        //This constructor is used in tests
        public NbscwMPADbContext(DbConnection existingConnection)
         : base(existingConnection, false)
        {

        }

        public NbscwMPADbContext(DbConnection existingConnection, bool contextOwnsConnection)
         : base(existingConnection, contextOwnsConnection)
        {

        }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new CategoryCfg());

            base.OnModelCreating(modelBuilder);
        }
    }
}
