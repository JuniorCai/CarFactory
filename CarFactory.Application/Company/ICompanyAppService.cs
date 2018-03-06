using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using CarFactory.Application.Company.Dtos;

namespace CarFactory.Application.Company
{
    /// <summary>
    /// 公司信息服务接口
    /// </summary>
    public interface ICompanyAppService : IApplicationService
    {
        #region 公司信息管理

        /// <summary>
        /// 获取首条公司信息
        /// </summary>
        /// <returns></returns>
        Task<CompanyListDto> GetDefaultCompanyAsync();

        /// <summary>
        /// 通过Id获取公司信息信息进行编辑或修改 
        /// </summary>
        Task<GetCompanyForEditOutput> GetCompanyForEditAsync(NullableIdDto<int> input);

        /// <summary>
        /// 通过指定id获取公司信息ListDto信息
        /// </summary>
        Task<CompanyListDto> GetCompanyByIdAsync(EntityDto<int> input);



        /// <summary>
        /// 新增或更改公司信息
        /// </summary>
        Task CreateOrUpdateCompanyAsync(CreateOrUpdateCompanyInput input);



        /// <summary>
        /// 新增公司信息
        /// </summary>
        Task<CompanyEditDto> CreateCompanyAsync(CompanyEditDto input);

        /// <summary>
        /// 更新公司信息
        /// </summary>
        Task UpdateCompanyAsync(CompanyEditDto input);

        /// <summary>
        /// 删除公司信息
        /// </summary>
        Task DeleteCompanyAsync(EntityDto<int> input);

        /// <summary>
        /// 批量删除公司信息
        /// </summary>
        Task BatchDeleteCompanyAsync(List<int> input);

        #endregion

    }
}
