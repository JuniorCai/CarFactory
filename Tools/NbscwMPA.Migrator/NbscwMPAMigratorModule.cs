using System.Data.Entity;
using System.Reflection;
using Abp.Modules;
using CarFactory;
using CarFactory.EntityFramework;

namespace NbscwMPACarFactory.Migrator
{
    [DependsOn(typeof(CarFactoryDataModule))]
    public class NbscwMPAMigratorModule : AbpModule
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