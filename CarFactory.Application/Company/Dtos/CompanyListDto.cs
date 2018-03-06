using System;
using System.ComponentModel;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;

namespace CarFactory.Application.Company.Dtos
{
    /// <summary>
    /// 公司信息列表Dto
    /// </summary>
    [AutoMapFrom(typeof(Core.CustomDomain.Company.Company))]
    public class CompanyListDto : EntityDto<int>
    {
        public string CompanyName { get; set; }
        public string Phone { get; set; }
        public string Tel { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Longitude { get; set; }
        public string Latitude { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        [DisplayName("创建时间")]
        public DateTime CreationTime { get; set; }
    }
}
