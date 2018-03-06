using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.AutoMapper;
using Abp.Domain.Repositories;
using CarFactory.Application.Company.Dtos;
using CarFactory.Core.CustomDomain.Company;
using CarFactory.Core.CustomDomain.Company.Authorization;

namespace CarFactory.Application.Company
{
    /// <summary>
    /// 公司信息服务实现
    /// </summary>
    //[AbpAuthorize(CompanyAppPermissions.Company)]
    public class CompanyAppService : CarFactoryAppServiceBase, ICompanyAppService
    {
        private readonly IRepository<Core.CustomDomain.Company.Company, int> _companyRepository;


        private readonly CompanyManage _companyManage;

        /// <summary>
        /// 构造方法
        /// </summary>
        public CompanyAppService(IRepository<Core.CustomDomain.Company.Company, int> companyRepository,
            CompanyManage companyManage

        )
        {
            _companyRepository = companyRepository;
            _companyManage = companyManage;

        }


        #region 实体的自定义扩展方法

        private IQueryable<Core.CustomDomain.Company.Company> _companyRepositoryAsNoTrack =>
            _companyRepository.GetAll().AsNoTracking();


        #endregion


        #region 公司信息管理

        
        public async Task<CompanyListDto> GetDefaultCompanyAsync()
        {
            CompanyListDto companyListDto;

            List<Core.CustomDomain.Company.Company> entityList = await _companyRepository.GetAllListAsync();

            companyListDto = entityList.FirstOrDefault().MapTo<CompanyListDto>();

            return companyListDto;
        }

        /// <summary>
        /// 通过Id获取公司信息信息进行编辑或修改 
        /// </summary>
        public async Task<GetCompanyForEditOutput> GetCompanyForEditAsync(NullableIdDto<int> input)
        {
            var output = new GetCompanyForEditOutput();

            CompanyEditDto companyEditDto;

            if (input.Id.HasValue)
            {
                var entity = await _companyRepository.GetAsync(input.Id.Value);
                companyEditDto = entity.MapTo<CompanyEditDto>();
            }
            else
            {
                companyEditDto = new CompanyEditDto();
            }

            output.Company = companyEditDto;
            return output;
        }


        /// <summary>
        /// 通过指定id获取公司信息ListDto信息
        /// </summary>
        public async Task<CompanyListDto> GetCompanyByIdAsync(EntityDto<int> input)
        {
            var entity = await _companyRepository.GetAsync(input.Id);

            return entity.MapTo<CompanyListDto>();
        }







        /// <summary>
        /// 新增或更改公司信息
        /// </summary>
        public async Task CreateOrUpdateCompanyAsync(CreateOrUpdateCompanyInput input)
        {
            if (input.CompanyEditDto.Id.HasValue)
            {
                await UpdateCompanyAsync(input.CompanyEditDto);
            }
            else
            {
                await CreateCompanyAsync(input.CompanyEditDto);
            }
        }

        /// <summary>
        /// 新增公司信息
        /// </summary>
        [AbpAuthorize(CompanyAppPermissions.Company_CreateCompany)]
        public virtual async Task<CompanyEditDto> CreateCompanyAsync(CompanyEditDto input)
        {
            //TODO:新增前的逻辑判断，是否允许新增

            var entity = input.MapTo<Core.CustomDomain.Company.Company>();

            entity = await _companyRepository.InsertAsync(entity);
            return entity.MapTo<CompanyEditDto>();
        }

        /// <summary>
        /// 编辑公司信息
        /// </summary>
        [AbpAuthorize(CompanyAppPermissions.Company_EditCompany)]
        public virtual async Task UpdateCompanyAsync(CompanyEditDto input)
        {
            //TODO:更新前的逻辑判断，是否允许更新

            var entity = await _companyRepository.GetAsync(input.Id.Value);
            input.MapTo(entity);

            await _companyRepository.UpdateAsync(entity);
        }

        /// <summary>
        /// 删除公司信息
        /// </summary>
        [AbpAuthorize(CompanyAppPermissions.Company_DeleteCompany)]
        public async Task DeleteCompanyAsync(EntityDto<int> input)
        {
            //TODO:删除前的逻辑判断，是否允许删除
            await _companyRepository.DeleteAsync(input.Id);
        }

        /// <summary>
        /// 批量删除公司信息
        /// </summary>
        [AbpAuthorize(CompanyAppPermissions.Company_DeleteCompany)]
        public async Task BatchDeleteCompanyAsync(List<int> input)
        {
            //TODO:批量删除前的逻辑判断，是否允许删除
            await _companyRepository.DeleteAsync(s => input.Contains(s.Id));
        }

        #endregion


    }
}
