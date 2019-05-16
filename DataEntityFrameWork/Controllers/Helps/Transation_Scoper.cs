namespace DataEntityFrameWork.Controllers.Helps
{
    using DataEntityFrameWork.Models.Helps;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.ChangeTracking;
    using Microsoft.EntityFrameworkCore.Storage;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Threading.Tasks;

    public class Transation_Scoper: IDisposable
    {
        private DbContext Context { get; }
        private IDbContextTransaction Transaction { get; set; }

        public Transation_Scoper(DbContext context)
        {
            Context = context;
            Transaction = Context.Database.BeginTransaction();
        }
        public Transation_Scoper DoInsert<TEntity>(TEntity entity) where TEntity : class
        {
            Context.Set<TEntity>().Add(entity);
            return this;
        }
        public Transation_Scoper DoInsertRange<T>(List<T> entity) where T : class
        {
            foreach (var item in entity)
                Context.Set<T>().Add(item);
            return this;         
        }
        public Transation_Scoper DoGet<TEntity>(TEntity entity) where TEntity : class
        {
            Context.Set<TEntity>().ToList();
            return this;
        }
        public Transation_Scoper DoInsert<TEntity>(TEntity entity, out EntityEntry inserted) where TEntity : class
        {
            inserted = Context.Set<TEntity>().Add(entity);
            return this;
        }
        public Transation_Scoper DoUpdate<TEntity>(TEntity entity) where TEntity : class
        {
            Context.Entry(entity).State = EntityState.Modified;
            return this;
        }
        public Transation_Scoper DoUpdateRange<T>(List<T> entity) where T : class
        {
            foreach (var models in entity)
                Context.Entry(models).State = EntityState.Modified;
            return this;
        }
        public Transation_Scoper DoInsertIfNotExists<TEntity>(Func<TEntity, object> predicate, TEntity entities) where TEntity : class
        {
            var newValues = predicate.Invoke(entities);
            Expression<Func<TEntity, bool>> compare = arg => predicate(arg).Equals(newValues);
            var compiled = compare.Compile();
            var existing = Context.Query<TEntity>().FirstOrDefault(compiled);

            if (existing == null)
                Context.Add(entities);
            else
                Context.Entry(entities).State = EntityState.Modified;
            return this;
        }
        public Transation_Scoper DoSincronizar<TEntity>(Func<TEntity, object> predicate, TEntity entities) where TEntity : class
        {
            var newValues = predicate.Invoke(entities);
            Expression<Func<TEntity, bool>> compare = arg => predicate(arg).Equals(newValues);
            var compiled = compare.Compile();
            var existing = Context.Query<TEntity>().FirstOrDefault(compiled);

            if (existing == null)
                Context.Add(entities);
            else
                Context.Entry(entities).State = EntityState.Modified;
            return this;
        }
        public Transation_Scoper DoUpdate<TEntity>(TEntity entityOriginal, TEntity enttityModif) where TEntity : class
        {
            Context.Entry(entityOriginal).State = EntityState.Modified;
            Context.Entry(entityOriginal).CurrentValues.SetValues(enttityModif);
            return this;
        }
        public Transation_Scoper DoUpdate(string SQL)
        {
            Context.Database.ExecuteSqlCommand(SQL);
            return this;
        }
        public Transation_Scoper DoDelete<TEntity>(TEntity entity) where TEntity : class
        {
            Context.Entry(entity).State = EntityState.Deleted;
            return this;
        }
        public Transation_Scoper DoDelete<TEntity>(int entity) where TEntity : class
        {
            var values = Context.Set<TEntity>().Find(entity);
            Context.Entry(values).State = EntityState.Deleted;
            return this;
        }
        public Transation_Scoper DoDelete<TEntity>(List<TEntity> entity) where TEntity : class
        {
            Context.Entry(entity).State = EntityState.Deleted;
            return this;
        }
        public Transation_Scoper SaveAndContinue()
        {
            try
            {
                Context.SaveChanges();
            }
            catch (Exception)
            {
                RollBack();
            }
            return this;
        }
        public async Task<EstadoEntityFrameWork> EndTransaction()
        {
            try
            {
                await Context.SaveChangesAsync();
                Transaction.Commit();
            }
            catch (Exception exe)
            {
                RollBack();
                return new EstadoEntityFrameWork
                {
                    estado = false,
                    Exception = exe,
                };
            }
            return new EstadoEntityFrameWork
            {
                estado = true,
                Exception = null,
            };
        }
        private void RollBack()
        {
            Transaction.Rollback();
            Dispose();
        }
        public void Dispose()
        {
            Transaction?.Dispose();
            Context?.Dispose();
        }

        //public Transation_Scoper IEnumerable<T> GetAll()
        //{
        //    return this.Context.ToList();
        //}
        //public virtual T GetById(object id)
        //{
        //    return this.DbSet.Find(id);
        //}
        //public virtual IEnumerable<T> Where(Expression<Func<T, bool>> expression)
        //{
        //    return this.DbSet.Where(expression);
        //}
        //public  IEnumerable<T> OrderBy(Expression<Func<T, bool>> expression)
        //{
        //    return this.DbSet.OrderBy(expression);
        //}
    }
}
