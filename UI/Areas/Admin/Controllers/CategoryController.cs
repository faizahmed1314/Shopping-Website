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

        public ActionResult Edit(int id)
        {
            try
            {
                var category = _uow.CategoryRepository.GetById(id);
                return View(category);
            }
            catch (Exception ex)
            {
                return View();
               
            }
        }
        [HttpPost]
        public ActionResult Edit(Category model)
        {
            try
            {
                model.UpdateDate = DateTime.Now;
               _uow.CategoryRepository.Update(model);
                _uow.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View();

            }
        }

        public ActionResult Delete(int id)
        {
            try
            {
                
                _uow.CategoryRepository.DeleteById(id);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {

                return View();
            }
        }

    }
}