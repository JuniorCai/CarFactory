using System.Data.Entity;
using System.Reflection;
using Abp.Modules;
using CarFactory.EntityFramework;

namespace CarFactory.Migrator
{
    [DependsOn(typeof(CarFactoryDataModule))]
    public class CarFactoryMigratorModule : AbpModule
    {
        public override void PreInitialize()
        {
            Database.SetInitializer<CarFactoryDbContext>(null);

            Configuration.BackgroundJobs.IsJobExecutionEnabled = false;
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}