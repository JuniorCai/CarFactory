using System.ComponentModel.DataAnnotations;
using Abp.Application.Services.Dto;

namespace CarFactory.Core
{
    public class PagedAndSortedInputDto : IPagedResultRequest, ISortedResultRequest
    {
        public string Sorting { get; set; }

        public PagedAndSortedInputDto()
        {
            MaxResultCount = 10; //PhoneBookConsts.DefaultPageSize;
        }

        //[Range(1, PhoneBookConsts.MaxPageSize)]
        [Range(1, 10)]
        public int MaxResultCount { get; set; }

        [Range(0, int.MaxValue)]
        public int SkipCount { get; set; }


    }
}
