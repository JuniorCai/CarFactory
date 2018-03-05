using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using CarFactory.Category.Dtos;

namespace CarFactory.Category
{
	/// <summary>
    /// 产品类别服务接口
    /// </summary>
    public interface ICategoryAppService : IApplicationService
    {
        #region 产品类别管理

        /// <summary>
        /// 根据查询条件获取产品类别分页列表
        /// </summary>
        //Task<PagedResultDto<CategoryListDto>> GetPagedCategorysAsync(GetCategoryInput input);

        /// <summary>
        /// 通过Id获取产品类别信息进行编辑或修改 
        /// </summary>
        Task<GetCategoryForEditOutput> GetCategoryForEditAsync(NullableIdDto<int> input);

		  /// <summary>
        /// 通过指定id获取产品类别ListDto信息
        /// </summary>
		Task<CategoryListDto> GetCategoryByIdAsync(EntityDto<int> input);



        /// <summary>
        /// 新增或更改产品类别
        /// </summary>
        Task CreateOrUpdateCategoryAsync(CreateOrUpdateCategoryInput input);





        /// <summary>
        /// 新增产品类别
        /// </summary>
        Task<CategoryEditDto> CreateCategoryAsync(CategoryEditDto input);

        /// <summary>
        /// 更新产品类别
        /// </summary>
        Task UpdateCategoryAsync(CategoryEditDto input);

        /// <summary>
        /// 删除产品类别
        /// </summary>
        Task DeleteCategoryAsync(EntityDto<int> input);

        /// <summary>
        /// 批量删除产品类别
        /// </summary>
        Task BatchDeleteCategoryAsync(List<int> input);

        #endregion




    }
}
