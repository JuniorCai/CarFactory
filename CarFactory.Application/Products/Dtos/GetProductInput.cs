﻿using System;
using Abp.Runtime.Validation;
using CarFactory.Core;

namespace CarFactory.Application.Products.Dtos
{
	/// <summary>
    /// 产品信息查询Dto
    /// </summary>
    public class GetProductInput : PagedAndSortedInputDto, IShouldNormalize
    {
        //DOTO:在这里增加查询参数

		/// <summary>
	    /// 模糊查询参数
		/// </summary>
		public string FilterText { get; set; }

        public int CategoryId { get; set; }

        /// <summary>
        /// 编号查询
        /// </summary>
        public int? Id { get; set; }

        /// <summary>
        /// 日期搜索起始时间
        /// </summary>
        public DateTime? BeginDate { get; set; }

        /// <summary>
        /// 日期搜索结束时间
        /// </summary>
        public DateTime? EndDate { get; set; }

        /// <summary>
        /// 状态：展示/下架
        /// </summary>
        public bool? Status { get; set; }

        /// <summary>
        /// 分页页码
        /// </summary>
        public int? Page { get; set; }

        /// <summary>
        /// 用于排序的默认值
        /// </summary>
        public void Normalize()
        {
            if (string.IsNullOrEmpty(Sorting))
            {
                Sorting = "Id";
            }
        }
    }
}
