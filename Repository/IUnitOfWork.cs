using ApplicationCore;
using DomainModels.Entities;
using Repository.Abstruction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public interface IUnitOfWork
    {
       

        IAuthenticationRepository AuthenticationRepository { get; }
        IRepository<Category> CategoryRepository { get; }
        IRepository<Product> ProductRepository { get; }

        int SaveChanges();
    }
}
