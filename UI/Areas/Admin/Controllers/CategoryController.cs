using DomainModels.Entities;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UI.Areas.Admin.Controllers
{
    public class CategoryController : BaseController
    {
        public CategoryController(IUnitOfWork uow) : base(uow)
        {
        }

        // GET: Admin/Category
        public ActionResult Index()
        {
            IEnumerable<Category> dataList = _uow.CategoryRepository.GetAll();
            return View(dataList);
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Category model)
        {
            try
            {
                _uow.CategoryRepository.Add(model);
                int rowEffecet = _uow.SaveChanges();
                if (rowEffecet > 0)
                {
                    return RedirectToAction("Index");
                }
                return View();
            }
            catch (Exception ex)
            {

                return View();
            }
            
        }

    }
}