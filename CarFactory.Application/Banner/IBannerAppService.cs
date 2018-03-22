using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using CarFactory.Application.Banner.Dtos;


namespace CarFactory.Application.Banner
{
    /// <summary>
    /// 首页Banner服务接口
    /// </summary>
    public interface IBannerAppService : IApplicationService
    {
        #region 首页Banner管理

        /// <summary>
        /// 根据查询条件获取首页Banner分页列表
        /// </summary>
        Task<PagedResultDto<BannerListDto>> GetPagedBannersAsync(GetBannerInput input);

        /// <summary>
        /// 通过Id获取首页Banner信息进行编辑或修改 
        /// </summary>
        Task<GetBannerForEditOutput> GetBannerForEditAsync(NullableIdDto<int> input);

        /// <summary>
        /// 通过指定id获取首页BannerListDto信息
        /// </summary>
        Task<BannerListDto> GetBannerByIdAsync(EntityDto<int> input);



        /// <summary>
        /// 新增或更改首页Banner
        /// </summary>
        Task CreateOrUpdateBannerAsync(CreateOrUpdateBannerInput input);

        /// <summary>
        /// 新增首页Banner
        /// </summary>
        Task<BannerEditDto> CreateBannerAsync(BannerEditDto input);

        /// <summary>
        /// 更新首页Banner
        /// </summary>
        Task UpdateBannerAsync(BannerEditDto input);

        /// <summary>
        /// 删除首页Banner
        /// </summary>
        Task DeleteBannerAsync(EntityDto<int> input);

        /// <summary>
        /// 批量删除首页Banner
        /// </summary>
        Task BatchDeleteBannerAsync(List<int> input);

        #endregion

    }
}
