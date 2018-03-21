using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.AutoMapper;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using CarFactory.Application.Seo.Dtos;
using CarFactory.Core.CustomDomain.Seo;
using CarFactory.Core.CustomDomain.Seo.Authorization;

namespace CarFactory.Application.Seo
{
    /// <summary>
    /// SEO设置服务实现
    /// </summary>
    [AbpAuthorize(SeoAppPermissions.Seo)]


    public class SeoAppService : CarFactoryAppServiceBase, ISeoAppService
    {
        private readonly IRepository<Core.CustomDomain.Seo.Seo, int> _seoRepository;


        private readonly SeoManage _seoManage;

        /// <summary>
        /// 构造方法
        /// </summary>
        public SeoAppService(IRepository<Core.CustomDomain.Seo.Seo, int> seoRepository,
            SeoManage seoManage

        )
        {
            _seoRepository = seoRepository;
            _seoManage = seoManage;

        }


        #region 实体的自定义扩展方法

        private IQueryable<Core.CustomDomain.Seo.Seo> _seoRepositoryAsNoTrack => _seoRepository.GetAll().AsNoTracking();


        #endregion


        #region SEO设置管理


        /// <summary>
        /// 通过Id获取SEO设置信息进行编辑或修改 
        /// </summary>
        public async Task<GetSeoForEditOutput> GetSeoForEditAsync(NullableIdDto<int> input)
        {
            var output = new GetSeoForEditOutput();

            SeoEditDto seoEditDto;

            if (input.Id.HasValue)
            {
                var entity = await _seoRepository.GetAsync(input.Id.Value);
                seoEditDto = entity.MapTo<SeoEditDto>();
            }
            else
            {
                seoEditDto = new SeoEditDto();
            }

            output.Seo = seoEditDto;
            return output;
        }


        /// <summary>
        /// 通过指定id获取SEO设置ListDto信息
        /// </summary>
        public async Task<SeoListDto> GetSeoByIdAsync(EntityDto<int> input)
        {
            var entity = await _seoRepository.GetAsync(input.Id);

            return entity.MapTo<SeoListDto>();
        }







        /// <summary>
        /// 新增或更改SEO设置
        /// </summary>
        public async Task CreateOrUpdateSeoAsync(CreateOrUpdateSeoInput input)
        {
            if (input.SeoEditDto.Id.HasValue)
            {
                await UpdateSeoAsync(input.SeoEditDto);
            }
            else
            {
                await CreateSeoAsync(input.SeoEditDto);
            }
        }

        /// <summary>
        /// 新增SEO设置
        /// </summary>
        [AbpAuthorize(SeoAppPermissions.Seo_CreateSeo)]
        public virtual async Task<SeoEditDto> CreateSeoAsync(SeoEditDto input)
        {
            //TODO:新增前的逻辑判断，是否允许新增

            var entity = input.MapTo<Core.CustomDomain.Seo.Seo>();

            entity = await _seoRepository.InsertAsync(entity);
            return entity.MapTo<SeoEditDto>();
        }

        /// <summary>
        /// 编辑SEO设置
        /// </summary>
        [AbpAuthorize(SeoAppPermissions.Seo_EditSeo)]
        public virtual async Task UpdateSeoAsync(SeoEditDto input)
        {
            //TODO:更新前的逻辑判断，是否允许更新

            var entity = await _seoRepository.GetAsync(input.Id.Value);
            input.MapTo(entity);

            await _seoRepository.UpdateAsync(entity);
        }

        /// <summary>
        /// 删除SEO设置
        /// </summary>
        [AbpAuthorize(SeoAppPermissions.Seo_DeleteSeo)]
        public async Task DeleteSeoAsync(EntityDto<int> input)
        {
            //TODO:删除前的逻辑判断，是否允许删除
            await _seoRepository.DeleteAsync(input.Id);
        }

        #endregion

    }
}
