using System.Data.Entity;
using System.Reflection;
using Abp.Modules;
using Abp.Zero.EntityFramework;
using NbscwMPACarFactory.EntityFramework;

namespace NbscwMPACarFactory
{
    [DependsOn(typeof(AbpZeroEntityFrameworkModule), typeof(NbscwMPACoreModule))]
    public class NbscwMPADataModule : AbpModule
    {
        public override void PreInitialize()
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<NbscwMPADbContext>());

            Configuration.DefaultNameOrConnectionString = "Default";
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}
