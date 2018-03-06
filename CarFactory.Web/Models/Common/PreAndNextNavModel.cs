using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Abp.Application.Services.Dto;

namespace CarFactory.Web.Models.Common
{
    public class PreAndNextNavModel<T> where T : EntityDto<int>
    {
        public T CurrentItem { get; set; }
        
        public T PreviousItem { get; set; }

        public T NextItem { get; set; }
    }
}