using Model.DAO;
using Model.EF;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PetAccessoriesOnlineShop.Areas.Admin.Controllers
{
    public class ProductController : BaseController
    {
        // GET: Admin/Product
        public ActionResult Index(string searchString, int page = 1, int pagesize = 10)
        {
            var dao = new ProductDao();
            var model = dao.ListAll(searchString, page, pagesize);
            return View(model);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Product product, HttpPostedFileBase file)
        {
            string FileNameImg = null;
            try
            {
                if (file.ContentLength > 0)
                {
                    string _FileName = Path.GetFileName(file.FileName);
                    FileNameImg = "/Assets/Client/img/" + Path.GetFileName(file.FileName);
                    string _path = Path.Combine(Server.MapPath("~/Assets/Client/img/"), _FileName);
                    file.SaveAs(_path);
                    ViewBag.Message = "File upload success!!";
                }
            }
            catch (Exception)
            {

                ViewBag.Message = "File upload failed!!";
            }

            if (ModelState.IsValid)
            {
                var dao = new ProductDao();
                product.Image = FileNameImg;
                long id = dao.Insert(product);
                if (id > 0)
                {
                    SetAlert("Add Product success!", "success");
                    return RedirectToAction("Index", "User");
                }
                else
                {
                    ModelState.AddModelError("", "Add Product is Fail!");
                }
            }
            return Redirect("index");
        }
      
    }
}