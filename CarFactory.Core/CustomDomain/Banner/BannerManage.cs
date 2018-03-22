using Abp.Domain.Repositories;
using Abp.Domain.Services;
using System;

namespace CarFactory.Core.CustomDomain.Banner
{
    /// <summary>
    /// 首页Banner业务管理
    /// </summary>
    public class BannerManage : IDomainService
    {
        private readonly IRepository<Banner, int> _bannerRepository;

        /// <summary>
        /// 构造方法
        /// </summary>
        public BannerManage(IRepository<Banner, int> bannerRepository)
        {
            _bannerRepository = bannerRepository;
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
