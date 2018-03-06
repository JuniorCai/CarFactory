using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using CarFactory.Application.Products.Dtos;
using CarFactory.Core.CustomDomain.Products;

namespace CarFactory.Application.Products
{
	/// <summary>
    /// 产品信息服务接口
    /// </summary>
    public interface IProductAppService : IApplicationService
	{
	    Task<ProductListDto> GetFirstOrDefaultAsync(Expression<Func<Product, bool>> predicate);


        #region 产品信息管理

        /// <summary>
        /// 根据查询条件获取产品信息分页列表
        /// </summary>
        Task<PagedResultDto<ProductListDto>> GetPagedProductsAsync(GetProductInput input);

        /// <summary>
        /// 通过Id获取产品信息信息进行编辑或修改 
        /// </summary>
        Task<GetProductForEditOutput> GetProductForEditAsync(NullableIdDto<int> input);

		  /// <summary>
        /// 通过指定id获取产品信息ListDto信息
        /// </summary>
		Task<ProductListDto> GetProductByIdAsync(EntityDto<int> input);



        /// <summary>
        /// 新增或更改产品信息
        /// </summary>
        Task CreateOrUpdateProductAsync(CreateOrUpdateProductInput input);

        

        /// <summary>
        /// 新增产品信息
        /// </summary>
        Task<ProductEditDto> CreateProductAsync(ProductEditDto input);

        /// <summary>
        /// 更新产品信息
        /// </summary>
        Task UpdateProductAsync(ProductEditDto input);

        /// <summary>
        /// 删除产品信息
        /// </summary>
        Task DeleteProductAsync(EntityDto<int> input);

        /// <summary>
        /// 批量删除产品信息
        /// </summary>
        Task BatchDeleteProductAsync(List<int> input);

        #endregion
       
    }
}
