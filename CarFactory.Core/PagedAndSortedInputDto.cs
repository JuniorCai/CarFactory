using System.ComponentModel.DataAnnotations;
using Abp.Application.Services.Dto;

namespace CarFactory.Core
{
    public class PagedAndSortedInputDto : IPagedResultRequest, ISortedResultRequest
    {
        public string Sorting { get; set; }

        public PagedAndSortedInputDto()
        {
            MaxResultCount = CarFactoryConsts.DefaultPageSize; 
        }

        [Range(1, CarFactoryConsts.MaxPageSize)]
        public int MaxResultCount { get; set; }

        [Range(0, int.MaxValue)]
        public int SkipCount { get; set; }


    }
}
