                          
 
using Abp.Domain.Repositories;
using Abp.Domain.Services;
using System;

namespace CarFactory.Core.CustomDomain.Seo
{
    /// <summary>
    /// SEO设置业务管理
    /// </summary>
    public class SeoManage : IDomainService
    {
        private readonly IRepository<Seo, int> _seoRepository;

        /// <summary>
        /// 构造方法
        /// </summary>
        public SeoManage(IRepository<Seo, int> seoRepository)
        {
            _seoRepository = seoRepository;
        }

        //TODO:编写领域业务代码


        /// <summary>
        ///     初始化
        /// </summary>
        private void Init()
        {




        }


    }
}
