using DomainModels.Entities;
using DomainModels.ViewModels;
using Repository;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UI.Areas.Admin.Controllers
{
    public class ProductController : BaseController
    {
        public ProductController(IUnitOfWork uow) : base(uow)
        {
        }

        // GET: Admin/Product
        public ActionResult Index()
        {
            var productList = _uow.ProductRepository.GetAll();
            return View(productList);
        }
        public ActionResult Create()
        {
            ViewBag.Categories = _uow.CategoryRepository.GetAll();
            return View();
        }
        [HttpPost]
        public ActionResult Create(ProductViewModel model)
        {
            try
            {
                //Create folder path
                string folderPath = "~/uploads/";

                //check if folder path is exist, if not then create path
                bool exist = Directory.Exists(Server.MapPath(folderPath));
                if (!exist)
                {
                    Directory.CreateDirectory(Server.MapPath(folderPath));
                }

                string fileName = Path.GetFileName(model.File.FileName);
                string path = Path.Combine(Server.MapPath(folderPath), fileName);
                model.File.SaveAs(path);

                model.ImageName = fileName;
                model.ImagePath = "/uploads/" + fileName;

                Product product = new Product();

                product.ProductId = model.ProductId;
                product.Name = model.Name;
                product.Description = model.Description;
                product.UnitPrice = model.UnitPrice;
                product.CategoryId = model.CategoryId;
                product.ImageName = model.ImageName;
                product.ImagePath = model.ImagePath;

                _uow.ProductRepository.Add(product);
                _uow.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
               
            }
            ViewBag.Categories = _uow.CategoryRepository.GetAll();
            return View();
        }

        public ActionResult Edit(int id)
        {
            ViewBag.Categories = _uow.CategoryRepository.GetAll();
            var product=_uow.ProductRepository.GetById(id);
            var model = new ProductViewModel();

            model.ProductId = product.ProductId;
            model.CategoryId = product.CategoryId;
            model.Name = product.Name;
            model.Description = product.Description;
            model.UnitPrice = product.UnitPrice;
            model.ImageName = product.ImageName;
            model.ImagePath = product.ImagePath;

            return View(model);
        }
        [HttpPost]
        public ActionResult Edit(ProductViewModel model)
        {
            try
            {

                if (model.File != null)
                {
                    // Deleting existing one
                    var filePath = Server.MapPath(model.ImagePath);
                    if (System.IO.File.Exists(filePath))
                    {
                        System.IO.File.Delete(filePath);
                    }
                }
                // Save new one
                string fileName = Path.GetFileName(model.File.FileName);
                string path = Path.Combine(Server.MapPath("~/uploads/"), fileName);
                model.File.SaveAs(path);

                model.ImageName = fileName;
                model.ImagePath = "/uploads/" + fileName;

                Product product = new Product();

                product.ProductId = model.ProductId;
                product.Name = model.Name;
                product.Description = model.Description;
                product.UnitPrice = model.UnitPrice;
                product.CategoryId = model.CategoryId;
                
                product.ImagePath = model.ImagePath;
                product.UpdateDate = DateTime.Now;
                if (model.ImageName != null)
                {
                    product.ImageName = model.ImageName;
                }

                _uow.ProductRepository.Update(product);
                _uow.SaveChanges();
                ViewBag.Categories = _uow.CategoryRepository.GetAll();
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {

            }
            return View(model);
        }
        public ActionResult Delete(int id)
        {
            _uow.ProductRepository.DeleteById(id);
            _uow.SaveChanges();
            return RedirectToAction("Index");
        }


    }
}