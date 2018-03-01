using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using NbscwMPACarFactory.Roles.Dto;
using NbscwMPACarFactory.Users.Dto;

namespace NbscwMPACarFactory.Users
{
    public interface IUserAppService : IAsyncCrudAppService<UserDto, long, PagedResultRequestDto, CreateUserDto, UpdateUserDto>
    {
        Task<ListResultDto<RoleDto>> GetRoles();
    }
}