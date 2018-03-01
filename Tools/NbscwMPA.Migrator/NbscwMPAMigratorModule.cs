using System.Data.Entity;
using System.Reflection;
using Abp.Modules;
using NbscwMPACarFactory.EntityFramework;

namespace NbscwMPACarFactory.Migrator
{
    [DependsOn(typeof(NbscwMPADataModule))]
    public class NbscwMPAMigratorModule : AbpModule
    {
        public override void PreInitialize()
        {
            Database.SetInitializer<NbscwMPADbContext>(null);

            Configuration.BackgroundJobs.IsJobExecutionEnabled = false;
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}