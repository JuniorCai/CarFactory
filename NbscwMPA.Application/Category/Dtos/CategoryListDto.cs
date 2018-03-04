using System;
using System.ComponentModel;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;


namespace NbscwMPACarFactory.Category.Dtos
{
	/// <summary>
    /// 产品类别列表Dto
    /// </summary>
    [AutoMapFrom(typeof(CustomDomain.Category.Category))]
    public class CategoryListDto : EntityDto<int>
    {
        public      string Name { get; set; }
        public      string ShortName { get; set; }
        public      bool IsActive { get; set; }
        public      int Sort { get; set; }
        //public      Product> Products { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        [DisplayName("创建时间")]
        public      DateTime CreationTime { get; set; }
    }
}
