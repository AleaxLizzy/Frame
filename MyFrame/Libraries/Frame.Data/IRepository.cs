using Frame.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Frame.Data
{
    public interface IRepository<T> where T : BaseEntity
    {
        T Get(object id);

        int Delete(T entity);


        int Insert(T entity);

        int Update(T entity);

        IQueryable<T> Table { get; }

        int Update(Expression<Func<T, bool>> filterExpression, Expression<Func<T, T>> updateExpression);

        int Delete(Expression<Func<T, bool>> filterExpression);
    }
}
