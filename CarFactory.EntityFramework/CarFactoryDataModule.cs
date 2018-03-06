using System.Data.Entity;
using System.Reflection;
using Abp.Modules;
using Abp.Zero.EntityFramework;
using CarFactory.Core;
using CarFactory.EntityFramework.EntityFramework;

namespace CarFactory.EntityFramework
{
    [DependsOn(typeof(AbpZeroEntityFrameworkModule), typeof(CarFactoryCoreModule))]
    public class CarFactoryDataModule : AbpModule
    {
        public override void PreInitialize()
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<CarFactoryDbContext>());

            Configuration.DefaultNameOrConnectionString = "Default";
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}
