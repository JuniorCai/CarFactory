using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using CarFactory.Application.Roles.Dto;

namespace CarFactory.Application.Roles
{
    public interface IRoleAppService : IAsyncCrudAppService<RoleDto, int, PagedResultRequestDto, EditRoleDto, EditRoleDto>
    {
        Task<ListResultDto<PermissionDto>> GetAllPermissions();
    }
}
