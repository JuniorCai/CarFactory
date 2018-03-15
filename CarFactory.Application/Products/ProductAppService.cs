using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.AutoMapper;
using Abp.Domain.Repositories;
using Abp.Domain.Uow;
using Abp.Linq.Extensions;
using CarFactory.Application.Products.Dtos;
using CarFactory.Core.CustomDomain.Products;
using CarFactory.Core.CustomDomain.Products.Authorization;

namespace CarFactory.Application.Products
{
    /// <summary>
    /// 产品信息服务实现
    /// </summary>
    //[AbpAuthorize(ProductAppPermissions.Product)]
    public class ProductAppService : CarFactoryAppServiceBase, IProductAppService
    {
        private readonly IRepository<Product, int> _productRepository;


        private readonly ProductManage _productManage;

        /// <summary>
        /// 构造方法
        /// </summary>
        public ProductAppService(IRepository<Product, int> productRepository,
            ProductManage productManage)
        {
            _productRepository = productRepository;
            _productManage = productManage;

        }

        public async Task<ProductListDto> GetFirstOrDefaultAsync<TOrderKey>(Expression<Func<Product, bool>> predicate, Func<Product, TOrderKey> orderPredicate, bool isAsc)
        {
            var entityTask = await _productRepository.GetAllListAsync(predicate);

            Product entity = isAsc ? entityTask.OrderBy(orderPredicate).FirstOrDefault() : entityTask.OrderByDescending(orderPredicate).FirstOrDefault();

            ProductListDto infoDto = entity.MapTo<ProductListDto>();
            return infoDto;
        }


        #region 实体的自定义扩展方法

        private IQueryable<Product> _productRepositoryAsNoTrack => _productRepository.GetAll().AsNoTracking();


        #endregion


        #region 产品信息管理

        /// <summary>
        /// 根据查询条件获取产品信息分页列表
        /// </summary>
        public async Task<PagedResultDto<ProductListDto>> GetPagedProductsAsync(GetProductInput input)
        {

            var query = _productRepositoryAsNoTrack;
            //TODO:根据传入的参数添加过滤条件

            query = query.WhereIf(input.CategoryId > 0, p => p.CategoryId == input.CategoryId)
                .WhereIf(!string.IsNullOrEmpty(input.FilterText),
                    p => p.Title.Contains(input.FilterText))
                .WhereIf(input.Id != null, p => p.Id == input.Id)
                .WhereIf(input.Status != null, p => p.IsShow == input.Status)
                .WhereIf(input.BeginDate != null, p => p.CreationTime >= input.BeginDate)
                .WhereIf(input.EndDate != null, p => p.CreationTime <= input.EndDate);


            var productCount = await query.CountAsync();

            var products = await query
                .OrderByDescending(p=>p.CreationTime)
                .PageBy(input)
                .ToListAsync();

            var productListDtos = products.MapTo<List<ProductListDto>>();
            return new PagedResultDto<ProductListDto>(
                productCount,
                productListDtos
            );
        }

        /// <summary>
        /// 通过Id获取产品信息信息进行编辑或修改 
        /// </summary>
        public async Task<GetProductForEditOutput> GetProductForEditAsync(NullableIdDto<int> input)
        {
            var output = new GetProductForEditOutput();

            ProductEditDto productEditDto;

            if (input.Id.HasValue)
            {
                var entity = await _productRepository.GetAsync(input.Id.Value);
                productEditDto = entity.MapTo<ProductEditDto>();
            }
            else
            {
                productEditDto = new ProductEditDto();
            }

            output.Product = productEditDto;
            return output;
        }


        /// <summary>
        /// 通过指定id获取产品信息ListDto信息
        /// </summary>
        public async Task<ProductListDto> GetProductByIdAsync(EntityDto<int> input)
        {
            var entity = await _productRepository.GetAsync(input.Id);

            return entity.MapTo<ProductListDto>();
        }


        /// <summary>
        /// 新增或更改产品信息
        /// </summary>
        public async Task CreateOrUpdateProductAsync(CreateOrUpdateProductInput input)
        {
            if (input.ProductEditDto.Id.HasValue && input.ProductEditDto.Id > 0)
            {
                await UpdateProductAsync(input.ProductEditDto);
            }
            else
            {
                await CreateProductAsync(input.ProductEditDto);
            }
        }

        /// <summary>
        /// 新增产品信息
        /// </summary>
        //[AbpAuthorize(ProductAppPermissions.Product_CreateProduct)]
        public virtual async Task<ProductEditDto> CreateProductAsync(ProductEditDto input)
        {
            //TODO:新增前的逻辑判断，是否允许新增

            var entity = input.MapTo<Product>();

            entity = await _productRepository.InsertAsync(entity);
            return entity.MapTo<ProductEditDto>();
        }

        /// <summary>
        /// 编辑产品信息
        /// </summary>
        //[AbpAuthorize(ProductAppPermissions.Product_EditProduct)]
        public virtual async Task UpdateProductAsync(ProductEditDto input)
        {
            //TODO:更新前的逻辑判断，是否允许更新

            var entity = await _productRepository.GetAsync(input.Id.Value);
            input.MapTo(entity);

            await _productRepository.UpdateAsync(entity);
        }

        public virtual void BatchUpdateStatusAsync(List<int> input, bool status)
        {
            foreach (var product in _productRepository.GetAll().Where(r => input.Contains(r.Id)).ToList())
            {
                product.IsShow = status;
                _productRepository.Update(product);
            }
        }

        /// <summary>
        /// 删除产品信息
        /// </summary>
        //[AbpAuthorize(ProductAppPermissions.Product_DeleteProduct)]
        public async Task DeleteProductAsync(EntityDto<int> input)
        {
            //TODO:删除前的逻辑判断，是否允许删除
            await _productRepository.DeleteAsync(input.Id);
        }

        /// <summary>
        /// 批量删除产品信息
        /// </summary>
        //[AbpAuthorize(ProductAppPermissions.Product_DeleteProduct)]
        public async Task BatchDeleteProductAsync(List<int> input)
        {
            //TODO:批量删除前的逻辑判断，是否允许删除
            await _productRepository.DeleteAsync(s => input.Contains(s.Id));
        }

        #endregion
    }
}
