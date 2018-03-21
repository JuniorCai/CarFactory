using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using Abp.Zero.EntityFramework;
using CarFactory.Core.Authorization.Roles;
using CarFactory.Core.Authorization.Users;
using CarFactory.Core.CustomDomain.Category;
using CarFactory.Core.CustomDomain.Company;
using CarFactory.Core.CustomDomain.Products;
using CarFactory.Core.CustomDomain.Report;
using CarFactory.Core.CustomDomain.Seo;
using CarFactory.Core.MultiTenancy;
using CarFactory.EntityFramework.EntityMapper.Company;
using CarFactory.EntityFramework.EntityMapper.Products;
using CarFactory.EntityFramework.EntityMapper.Report;
using CarFactory.EntityFramework.EntityMapper.Seo;

namespace CarFactory.EntityFramework.EntityFramework
{
    [DbConfigurationType(typeof(MySql.Data.Entity.MySqlEFConfiguration))]
    public class CarFactoryDbContext : AbpZeroDbContext<Tenant, Role, User>
    {
        //TODO: Define an IDbSet for your Entities...
        public IDbSet<Category> Categorys { get; set; }

        public IDbSet<Product> Products { get; set; }

        public IDbSet<Company> Companys { get; set; }

        public IDbSet<Report> Reports { get; set; }

        public IDbSet<Seo> Seos { get; set; }




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
            modelBuilder.Configurations.Add(new CompanyCfg());
            modelBuilder.Configurations.Add(new ReportCfg());
            modelBuilder.Configurations.Add(new SeoCfg());


            modelBuilder.Entity<User>().Property(u => u.EmailAddress).IsOptional();
            base.OnModelCreating(modelBuilder);
        }

        public override int SaveChanges()
        {
            try
            {
                return base.SaveChanges();
            }
            catch (DbEntityValidationException exception)
            {
                var errorMessages =
                    exception.EntityValidationErrors
                        .SelectMany(validationResult => validationResult.ValidationErrors)
                        .Select(m => m.ErrorMessage);

                var fullErrorMessage = string.Join(", ", errorMessages);
                //记录日志
                //Log.Error(fullErrorMessage);
                var exceptionMessage = string.Concat(exception.Message, " 验证异常消息是：", fullErrorMessage);

                throw new DbEntityValidationException(exceptionMessage, exception.EntityValidationErrors);
            }

            //其他异常throw到上层
        }
    }
}
