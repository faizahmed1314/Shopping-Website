using Repository.Abstruction;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Implementation
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected DbContext _db;
        public Repository(DbContext db)
        {
            _db=db;
        }
        public void Add(TEntity entity)
        {
            _db.Set<TEntity>().Add(entity);
        }

        public void DeleteById(object Id)
        {
            var entity=_db.Set<TEntity>().Find(Id);
            if (entity != null)
            {
                _db.Set<TEntity>().Remove(entity);
            }
        }

        public IEnumerable<TEntity> GetAll()
        {
           return _db.Set<TEntity>().ToList();
        }

        public TEntity GetById(object Id)
        {
            return _db.Set<TEntity>().Find(Id);
        }

        public void Update(TEntity entity)
        {
            _db.Entry<TEntity>(entity).State = EntityState.Modified;
        }
    }
}
