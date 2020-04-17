using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CovidTP.Models;
using CovidTP.DAL;
using CovidTP.DAL.EntityModels;
using Microsoft.AspNetCore.Http;

namespace CovidTP.Controllers
{
    public class HomeController : Controller
    {
        private CovidTPContext _context = new CovidTPContext();

        public IActionResult Index()
        {
            if (HttpContext.Session.IsAvailable)
            {
                ViewBag.Name = HttpContext.Session.GetString("UserFirstName");
            }

            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult LoginUser(LoginViewModel model)
        {
            var user = _context.Users.Where(x => x.EmailAddress == model.EmailAddress).FirstOrDefault();
            if(!ReferenceEquals(user, null))
            {
                HttpContext.Session.SetInt32("UserId", user.Id);
                HttpContext.Session.SetString("UserFirstName", user.FirstName);
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Login");
            }
        }
        
        public IActionResult RegisterUser()
        {
            return View();
        }

        [HttpPost]
        public IActionResult MakeNewUser([Bind("FirstName,LastName,EmailAddress,UserName,AccountBalance")] RegisterUserViewModel model)
        {
            if (ModelState.IsValid)
            {
                using (var context = new CovidTPContext())
                {
                    var user = new User()
                    {
                        FirstName = model.FirstName,
                        LastName = model.LastName,
                        EmailAddress = model.EmailAddress,
                        UserName = model.UserName,
                        AccountBalance = model.AccountBalance
                    };
                    context.Users.Add(user);
                    context.SaveChanges();
                }

                return RedirectToAction("Index");
            }
            return RedirectToAction("RegisterUser");
        }

        public IActionResult Items()
        {
            var items = _context.Items.ToList();
            List<ItemViewModel> itemsForView = new List<ItemViewModel>();
            int userId = 0;
            if (HttpContext.Session.IsAvailable)
            {
                userId = (int)(HttpContext.Session.GetInt32("UserId"));
            }
            var user = _context.Users.Find(userId);
            foreach(var item in items)
            {
                var tempItem = new ItemViewModel()
                {
                    Id = item.Id,
                    Name = item.Name,
                    Description = item.Description,
                    Price = item.Price,
                    UserId = userId,
                    RemaingingBalance = user.AccountBalance
                };
                itemsForView.Add(tempItem);
            }

            return View(itemsForView);
        }

        public IActionResult Buy(int? itemid, int? userid)
        {
            var user = _context.Users.Find(userid);
            var item = _context.Items.Find(itemid);
            if(item.Price < user.AccountBalance)
            {
                user.AccountBalance = user.AccountBalance - item.Price;
                var userItem = new UserItems()
                {
                    UserId = user.Id,
                    ItemId = item.Id
                };
                _context.Users.Update(user);
                _context.UserItems.Add(userItem);
                _context.SaveChanges();
                return RedirectToAction("Items");
            }
            else
            {
                return RedirectToAction("BuyError");
            }
        }

        public IActionResult ItemsByUser()
        {
            int userId = 0;
            if (HttpContext.Session.IsAvailable)
            {
                userId = (int)(HttpContext.Session.GetInt32("UserId"));
            }
            var userItems = _context.UserItems.Where(x => x.UserId == userId).ToList();
            List<Item> items = new List<Item>();
            foreach(var id in userItems)
            {
                var tempItem = _context.Items.Find(id.ItemId);
                items.Add(tempItem);
            }
            List<SpecificUserItems> itemsForView = new List<SpecificUserItems>();
            foreach(var item in items)
            {
                var model = new SpecificUserItems()
                {
                    Id = item.Id,
                    Name = item.Name,
                    Description = item.Description,
                    Price = item.Price
                };
                itemsForView.Add(model);
            }

            return View(itemsForView);
        }

        public IActionResult BuyError()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
