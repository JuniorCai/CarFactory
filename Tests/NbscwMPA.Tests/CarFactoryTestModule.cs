﻿using Abp.Modules;
using Abp.MultiTenancy;
using Abp.TestBase;
using Abp.Zero.Configuration;
using CarFactory.Application;
using CarFactory.EntityFramework;
using Castle.MicroKernel.Registration;
using NSubstitute;

namespace CarFactory.Tests
{
    [DependsOn(
        typeof(CarFactoryApplicationModule),
        typeof(CarFactoryDataModule),
        typeof(AbpTestBaseModule))]
    public class CarFactoryTestModule : AbpModule
    {
        public override void PreInitialize()
        {
            //Use database for language management
            Configuration.Modules.Zero().LanguageManagement.EnableDbLocalization();

            //Registering fake services

            IocManager.IocContainer.Register(
                Component.For<IAbpZeroDbMigrator>()
                    .UsingFactoryMethod(() => Substitute.For<IAbpZeroDbMigrator>())
                    .LifestyleSingleton()
                );
        }
    }
}
