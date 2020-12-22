using ApplicationCore;
using DomainModels.Entities;
using Repository.Abstruction;
using Repository.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
     public class UnitOfWork : IUnitOfWork
    {
        DatabaseContext db;
       
        public UnitOfWork()
        {
            db = new DatabaseContext();
        }
        private IAuthenticationRepository _AuthenticationRepository;

        public IAuthenticationRepository AuthenticationRepository
        {

            get
            {
                if (_AuthenticationRepository == null)
                {
                    _AuthenticationRepository = new AuthenticationRepository(db);
                }
                return _AuthenticationRepository;
            }

        }
        

        private IRepository<Category> _CategoryRepository;

        public IRepository<Category> CategoryRepository
        {

            get {
                if (_CategoryRepository == null)
                {
                    _CategoryRepository = new Repository<Category>(db);
                }
                return _CategoryRepository; }
            
        }
        private IRepository<Product> _ProductRepository;

        public IRepository<Product> ProductRepository
        {

            get
            {
                if (_ProductRepository == null)
                {
                    _ProductRepository = new Repository<Product>(db);
                }
                return _ProductRepository;
            }

        }

        public int SaveChanges()
        {
            return db.SaveChanges();
        }
    }
}
