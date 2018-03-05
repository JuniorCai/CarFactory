using Abp.Domain.Entities;
using Abp.EntityFramework;
using Abp.EntityFramework.Repositories;

namespace CarFactory.EntityFramework.Repositories
{
    public abstract class CarFactoryRepositoryBase<TEntity, TPrimaryKey> : EfRepositoryBase<CarFactoryDbContext, TEntity, TPrimaryKey>
        where TEntity : class, IEntity<TPrimaryKey>
    {
        protected CarFactoryRepositoryBase(IDbContextProvider<CarFactoryDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        //add common methods for all repositories
    }

    public abstract class CarFactoryRepositoryBase<TEntity> : CarFactoryRepositoryBase<TEntity, int>
        where TEntity : class, IEntity<int>
    {
        protected CarFactoryRepositoryBase(IDbContextProvider<CarFactoryDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        //do not add any method here, add to the class above (since this inherits it)
    }
}
