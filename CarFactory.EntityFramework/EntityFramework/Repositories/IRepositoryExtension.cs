using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Abp.Domain.Entities;
using Abp.Domain.Repositories;
using Castle.DynamicProxy.Generators.Emitters.SimpleAST;

namespace CarFactory.EntityFramework.EntityFramework.Repositories
{
    public static class RepositoryExtension
    {
        public static void BatchUpdateAsync<TEntity>(this IRepository<TEntity> entityRepository,Expression<Func<TEntity,bool>> predicate) 
            where TEntity : class, IEntity<int>
        {
//            foreach (TEntity entity in entityRepository.GetAll().Where(predicate).ToList())
//            {
//                entityRepository.u
//            }
        }
    }
}
