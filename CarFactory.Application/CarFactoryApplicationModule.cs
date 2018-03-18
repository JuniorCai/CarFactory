using System.Reflection;
using Abp.Authorization;
using Abp.Authorization.Roles;
using Abp.AutoMapper;
using Abp.Modules;
using CarFactory.Application.Roles.Dto;
using CarFactory.Application.Users.Dto;
using CarFactory.Core;
using CarFactory.Core.Authorization.Roles;
using CarFactory.Core.Authorization.Users;

namespace CarFactory.Application
{
    [DependsOn(typeof(CarFactoryCoreModule), typeof(AbpAutoMapperModule))]
    public class CarFactoryApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());

            // TODO: Is there somewhere else to store these, with the dto classes
            Configuration.Modules.AbpAutoMapper().Configurators.Add(cfg =>
            {
                // Role and permission
                cfg.CreateMap<Permission, string>().ConvertUsing(r => r.Name);
                cfg.CreateMap<RolePermissionSetting, string>().ConvertUsing(r => r.Name);

                cfg.CreateMap<EditRoleDto, Role>().ForMember(x => x.Permissions, opt => opt.Ignore());
                cfg.CreateMap<RoleDto, Role>().ForMember(x => x.Permissions, opt => opt.Ignore());
                
                cfg.CreateMap<UserDto, User>();
                cfg.CreateMap<UserDto, User>().ForMember(x => x.Roles, opt => opt.Ignore());

//                cfg.CreateMap<User, UserDto>();
//                cfg.CreateMap<User, UserDto>().ForMember(x => x.UserRole, opt => opt.MapFrom(input => input.Roles));
//                cfg.CreateMap<User, UserDto>().ForMember(x => x.Roles, opt => opt.Ignore());

                cfg.CreateMap<CreateUserDto, User>();
                cfg.CreateMap<CreateUserDto, User>().ForMember(x => x.Roles, opt => opt.Ignore());
            });
        }
    }
}
