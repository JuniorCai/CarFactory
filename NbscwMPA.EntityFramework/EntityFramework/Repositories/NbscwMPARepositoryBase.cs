using Abp.Domain.Entities;
using Abp.EntityFramework;
using Abp.EntityFramework.Repositories;

namespace NbscwMPACarFactory.EntityFramework.Repositories
{
    public abstract class NbscwMPARepositoryBase<TEntity, TPrimaryKey> : EfRepositoryBase<NbscwMPADbContext, TEntity, TPrimaryKey>
        where TEntity : class, IEntity<TPrimaryKey>
    {
        protected NbscwMPARepositoryBase(IDbContextProvider<NbscwMPADbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        //add common methods for all repositories
    }

    public abstract class NbscwMPARepositoryBase<TEntity> : NbscwMPARepositoryBase<TEntity, int>
        where TEntity : class, IEntity<int>
    {
        protected NbscwMPARepositoryBase(IDbContextProvider<NbscwMPADbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        //do not add any method here, add to the class above (since this inherits it)
    }
}
