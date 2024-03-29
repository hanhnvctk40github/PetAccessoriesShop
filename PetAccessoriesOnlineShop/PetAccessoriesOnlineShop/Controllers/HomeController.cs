﻿using Model.DAO;
using PetAccessoriesOnlineShop.Common;
using PetAccessoriesOnlineShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PetAccessoriesOnlineShop.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            var productDao = new ProductDao();
            ViewBag.ListNewProductFood = productDao.ListNewProduct(10,1);
            ViewBag.ListNewProductFoodContainers = productDao.ListNewProduct(10, 2);
            ViewBag.ListNewProductBelts = productDao.ListNewProduct(10, 3);
            ViewBag.ListNewProductCages = productDao.ListNewProduct(10, 4);
            ViewBag.ListNewProductAll = productDao.ListAllProduct(10);
            return View();
        }

        //
        [ChildActionOnly]
        public ActionResult MainMenu()
        {
            var model = new MenuDao().ListByGroupId(1);
            return PartialView(model);
        }

        [ChildActionOnly]
        public PartialViewResult HeaderCart()
        {
            var cart = Session[CommonConstants.CartSession];
            var list = new List<CartItem>();
            if (cart != null)
            {
                list = (List<CartItem>)cart;
            }
            return PartialView(list);
        }

        [ChildActionOnly]
        public PartialViewResult HeaderContact()
        {
            return PartialView();
        }
    }
}