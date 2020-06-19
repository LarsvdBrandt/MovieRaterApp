using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MovieRater.Models;
using MovieRater.ViewModels;
using MovieRater.Controllers;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using LogicFactory;

using Microsoft.AspNetCore.Mvc.ActionConstraints;
using Logic;
using LogicTypes;

namespace MovieRater.Controllers
{
    public class AccountController : Controller
    {
        private Account account;
        private AccountCollection accountCollection;


        public AccountController( )
        {
            accountCollection = new Factory().GetAccountCollection(Context.Database);
        }

        [HttpPost]
        public async Task<IActionResult> AddAccount(AddAccountViewModel model)
        {
            account = new Account();

            account.UserID = model.UserID;
            account.UserName = model.UserName;
            account.FirstName = model.FirstName;
            account.LastName = model.LastName;
            account.Email = model.Email;
            account.PhoneNumber = model.PhoneNumber;
            account.Password = model.Password;

            int rowcount = accountCollection.CreateAccount(account);

            if (rowcount == 1)
                return RedirectToAction("RegistrationSuccessPage");
            else
                return RedirectToAction("FailPage");
        }


        public IActionResult Register()
        {
            return View();
        }

        public IActionResult RegistrationSuccessPage()
        {
            return View();
        }

        public IActionResult LoginSuccessPage()
        {
            return View();
        }

        public IActionResult FailPage()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

    }
}
