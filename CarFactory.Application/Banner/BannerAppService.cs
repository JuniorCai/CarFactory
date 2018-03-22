using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.AutoMapper;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using CarFactory.Application.Banner.Dtos;
using CarFactory.Core.CustomDomain.Banner;
using CarFactory.Core.CustomDomain.Banner.Authorization;




namespace CarFactory.Application.Banner
{
    /// <summary>
    /// 首页Banner服务实现
    /// </summary>
    public class BannerAppService : CarFactoryAppServiceBase, IBannerAppService
    {
        private readonly IRepository<Core.CustomDomain.Banner.Banner, int> _bannerRepository;


        private readonly BannerManage _bannerManage;

        /// <summary>
        /// 构造方法
        /// </summary>
        public BannerAppService(IRepository<Core.CustomDomain.Banner.Banner, int> bannerRepository,
            BannerManage bannerManage

        )
        {
            _bannerRepository = bannerRepository;
            _bannerManage = bannerManage;

        }


        #region 实体的自定义扩展方法

        private IQueryable<Core.CustomDomain.Banner.Banner> _bannerRepositoryAsNoTrack =>
            _bannerRepository.GetAll().AsNoTracking();


        #endregion


        #region 首页Banner管理

        /// <summary>
        /// 根据查询条件获取首页Banner分页列表
        /// </summary>
        public async Task<PagedResultDto<BannerListDto>> GetPagedBannersAsync(GetBannerInput input)
        {

            var query = _bannerRepositoryAsNoTrack;
            //TODO:根据传入的参数添加过滤条件

            var bannerCount = await query.CountAsync();

            var banners = await query
                .OrderBy(b=>b.Sort)
                .ThenBy(b=>b.IsShow)
                .PageBy(input)
                .ToListAsync();

            var bannerListDtos = banners.MapTo<List<BannerListDto>>();
            return new PagedResultDto<BannerListDto>(
                bannerCount,
                bannerListDtos
            );
        }

        /// <summary>
        /// 通过Id获取首页Banner信息进行编辑或修改 
        /// </summary>
        public async Task<GetBannerForEditOutput> GetBannerForEditAsync(NullableIdDto<int> input)
        {
            var output = new GetBannerForEditOutput();

            BannerEditDto bannerEditDto;

            if (input.Id.HasValue)
            {
                var entity = await _bannerRepository.GetAsync(input.Id.Value);
                bannerEditDto = entity.MapTo<BannerEditDto>();
            }
            else
            {
                bannerEditDto = new BannerEditDto();
            }

            output.Banner = bannerEditDto;
            return output;
        }


        /// <summary>
        /// 通过指定id获取首页BannerListDto信息
        /// </summary>
        public async Task<BannerListDto> GetBannerByIdAsync(EntityDto<int> input)
        {
            var entity = await _bannerRepository.GetAsync(input.Id);

            return entity.MapTo<BannerListDto>();
        }



        /// <summary>
        /// 新增或更改首页Banner
        /// </summary>
        public async Task CreateOrUpdateBannerAsync(CreateOrUpdateBannerInput input)
        {
            if (input.BannerEditDto.Id.HasValue && input.BannerEditDto.Id > 0)
            {
                await UpdateBannerAsync(input.BannerEditDto);
            }
            else
            {
                await CreateBannerAsync(input.BannerEditDto);
            }
        }

        /// <summary>
        /// 新增首页Banner
        /// </summary>
        [AbpAuthorize(BannerAppPermissions.Banner)]
        public virtual async Task<BannerEditDto> CreateBannerAsync(BannerEditDto input)
        {
            //TODO:新增前的逻辑判断，是否允许新增

            var entity = input.MapTo<Core.CustomDomain.Banner.Banner>();

            entity = await _bannerRepository.InsertAsync(entity);
            return entity.MapTo<BannerEditDto>();
        }

        /// <summary>
        /// 编辑首页Banner
        /// </summary>
        [AbpAuthorize(BannerAppPermissions.Banner)]
        public virtual async Task UpdateBannerAsync(BannerEditDto input)
        {
            //TODO:更新前的逻辑判断，是否允许更新

            var entity = await _bannerRepository.GetAsync(input.Id.Value);
            input.MapTo(entity);

            await _bannerRepository.UpdateAsync(entity);
        }

        /// <summary>
        /// 删除首页Banner
        /// </summary>
        [AbpAuthorize(BannerAppPermissions.Banner)]
        public async Task DeleteBannerAsync(EntityDto<int> input)
        {
            //TODO:删除前的逻辑判断，是否允许删除
            await _bannerRepository.DeleteAsync(input.Id);
        }

        /// <summary>
        /// 批量删除首页Banner
        /// </summary>
        [AbpAuthorize(BannerAppPermissions.Banner)]
        public async Task BatchDeleteBannerAsync(List<int> input)
        {
            //TODO:批量删除前的逻辑判断，是否允许删除
            await _bannerRepository.DeleteAsync(s => input.Contains(s.Id));
        }

        #endregion


    }
}