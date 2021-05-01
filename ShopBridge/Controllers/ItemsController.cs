using ShopBridge.Models;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShopBridge.ViewModels;
using System;

namespace ShopBridge.Controllers
{
    public class ItemsController : Controller
    {
        private MyDbContext _context;

        public ItemsController()
        {
            _context = new MyDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Items
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult New()
        {
            var category = _context.Categories.ToList();
            var viewModel = new ItemsViewModel
            {
                Items = new Item(),
                Categories = category
            };
            return View("AddItem", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Item items)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    var viewModel = new ItemsViewModel
                    {
                        Items = items,
                        Categories = _context.Categories.ToList()
                    };
                    return View("AddItem", viewModel);
                }
                if (items.Id == 0)
                    _context.Items.Add(items);
                else
                {
                    var itemInDb = _context.Items.Single(c => c.Id == items.Id);
                    itemInDb.Id = items.Id;
                    itemInDb.Name = items.Name;
                    itemInDb.Price = items.Price;
                    itemInDb.CategoryId = items.CategoryId;
                }
                _context.SaveChanges();
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
            return RedirectToAction("Index", "Items");
        }

        public ActionResult Edit(int id)
        {
            try
            {
                var item = _context.Items.FirstOrDefault(c => c.Id == id);
                //if (customer == null)
                //    return HttpNotFound();

                var viewModel = new ItemsViewModel
                {
                    Items = item,
                    Categories = _context.Categories.ToList()
                };

                return View("AddItem", viewModel);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public ActionResult Details(int id)
        {
            var item = _context.Items.SingleOrDefault(x => x.Id == id);

            if(item == null)
            {
                return HttpNotFound();
            }
            return View(item);
        }
    }
}