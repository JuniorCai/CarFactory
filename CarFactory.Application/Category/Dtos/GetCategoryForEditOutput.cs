namespace CarFactory.Application.Category.Dtos
{
    /// <summary>
    /// 用于添加或编辑 产品类别时使用的DTO
    /// </summary>
    public class GetCategoryForEditOutput
    {
        
        /// <summary>
        /// Category编辑状态的DTO
        /// </summary>
        public CategoryEditDto Category { get; set; }
        
    }
}