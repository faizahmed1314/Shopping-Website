using DomainModels.Entities;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Service.Controllers
{
    public class StoreController : ApiController
    {
        IUnitOfWork _uow = new UnitOfWork();

        [HttpGet]
        public IEnumerable<Product> GetProducts()
        {
            return _uow.ProductRepository.GetAll();
        }
    }
}
