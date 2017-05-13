using Frame.Core.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityFramework.Extensions;
namespace Frame.Data
{
    public class EfRepository<T> : IRepository<T> where T : BaseEntity
    {
         private readonly IDbContext _dbContext;
        private IDbSet<T> _dbSet;

        public EfRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        protected virtual IDbSet<T> Entities
        {
            get
            {
                return _dbSet = _dbSet ?? _dbContext.Set<T>();
            }
        }

        #region Get
        /// <summary>
        /// 根据Id获取实体类
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public T Get(object id)
        {
            return Entities.Find(id);
        }


        /// <summary>
        /// 获取表
        /// </summary>
        public IQueryable<T> Table
        {
            get { return Entities; }
        }

        #endregion Get

        #region Delete
        /// <summary>
        /// 删除一个实体类
        /// </summary>
        /// <param name="entity"></param>
        public int Delete(T entity)
        {
            try
            {
                if (entity == null)
                    throw new ArgumentNullException("entity");

                Entities.Remove(entity);

             return   _dbContext.SaveChanges();
            }
            catch (DbEntityValidationException dbEx)
            {
                throw new Exception(GetFullErrorText(dbEx), dbEx);
            }
        }
        #endregion Delete

        #region Insert
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="entity"></param>
        public int Insert(T entity)
        {
            try
            {
                if (entity == null)
                    throw new ArgumentNullException("entity");

                Entities.Add(entity);
             return   _dbContext.SaveChanges();
            }
            catch (DbEntityValidationException dbEx)
            {
                throw new Exception(GetFullErrorText(dbEx), dbEx);
            }
        }
        #endregion Insert

        #region Update
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="entity"></param>
        public int Update(T entity)
        {
            try
            {
                if (entity == null)
                    throw new ArgumentNullException("entity");
          return      _dbContext.SaveChanges();
            }
            catch (DbEntityValidationException dbEx)
            {
                throw new Exception(GetFullErrorText(dbEx), dbEx);
            }
        }
        #endregion Update

        #region exception
        /// <summary>
        /// exception
        /// </summary>
        /// <param name="exc"></param>
        /// <returns></returns>
        protected string GetFullErrorText(DbEntityValidationException exc)
        {
            return exc.EntityValidationErrors
                .SelectMany(validationErrors => validationErrors.ValidationErrors)
                .Aggregate(string.Empty,
                    (current, error) =>
                        current + string.Format("Property: {0} Error: {1}", error.PropertyName, error.ErrorMessage) +
                        Environment.NewLine);
        }
        #endregion exception





        public int Update(System.Linq.Expressions.Expression<Func<T, bool>> filterExpression, System.Linq.Expressions.Expression<Func<T, T>> updateExpression)
        {
            return Entities.Where(filterExpression).Update(updateExpression);
        }

        public int Delete(System.Linq.Expressions.Expression<Func<T, bool>> filterExpression)
        {
            return Entities.Where(filterExpression).Delete();
        }
    }
}
