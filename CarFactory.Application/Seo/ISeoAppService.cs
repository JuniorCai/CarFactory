using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using CarFactory.Application.Seo.Dtos;

namespace CarFactory.Application.Seo
{
	/// <summary>
    /// SEO设置服务接口
    /// </summary>
    public interface ISeoAppService : IApplicationService
    {
        #region SEO设置管理


        /// <summary>
        /// 通过Id获取SEO设置信息进行编辑或修改 
        /// </summary>
        Task<GetSeoForEditOutput> GetSeoForEditAsync(NullableIdDto<int> input);

		  /// <summary>
        /// 通过指定id获取SEO设置ListDto信息
        /// </summary>
		Task<SeoListDto> GetSeoByIdAsync(EntityDto<int> input);



        /// <summary>
        /// 新增或更改SEO设置
        /// </summary>
        Task CreateOrUpdateSeoAsync(CreateOrUpdateSeoInput input);


        Task<SeoListDto> GetDefaultSeoAsync();



        /// <summary>
        /// 新增SEO设置
        /// </summary>
        Task<SeoEditDto> CreateSeoAsync(SeoEditDto input);

        /// <summary>
        /// 更新SEO设置
        /// </summary>
        Task UpdateSeoAsync(SeoEditDto input);

        /// <summary>
        /// 删除SEO设置
        /// </summary>
        Task DeleteSeoAsync(EntityDto<int> input);

        #endregion




    }
}
