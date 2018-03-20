using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using CarFactory.Core.Authorization.Users;

namespace CarFactory.Application.Users.Dto
{
    [AutoMapTo(typeof(User))]
    public class UserChangePwdDto : EntityDto<long>
    {
        [Required]
        public string OldPassword { get; set; }


        [Required]
        public string Password { get; set; }

    }
}
