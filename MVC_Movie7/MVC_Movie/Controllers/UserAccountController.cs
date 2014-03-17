using BLL;
using MVC_Movie.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_Movie.Controllers
{
    public class UserAccountController : Controller
    {
        static List<UserAccount> accounts = new List<UserAccount>();
        static List<UserAccount> finalAccounts = new List<UserAccount>();
        //
        // GET: /UserAccount/
        public ActionResult Index()
        {
            List<UserAccount> accountList = GetAllAccounts();
            return View(accountList);
        }
        public List<UserAccount> GetAllAccounts()
        {
            List<UserAccount> accountList = new List<UserAccount>();
            List<AccountVM> newAccount = new List<AccountVM>();
            Logic logic = new Logic();
            UserAccount account = new UserAccount();
            newAccount = logic.GetAllAccounts();
            foreach (AccountVM accountVm in newAccount)
            {
                account = ConvertAccountVmToUserAccount(accountVm);
                bool x = accountList.Contains(account);
                if (x == false)
                {
                    accountList.Add(account);
                }
            }
            return accountList;
        }
        public UserAccount ConvertAccountVmToUserAccount(AccountVM accountVm)
        {
            UserAccount account = new UserAccount();
            if (accountVm != null)
            {
                account.id = accountVm.id;
                account.lastName = accountVm.lastName;
                account.firstName = accountVm.firstName;
                account.email = accountVm.email;
                account.street = accountVm.street;
                account.city = accountVm.city;
                account.state = accountVm.state;
                account.zip = accountVm.zip;
                account.addressType = accountVm.addressType;
                account.number = accountVm.number;
                account.phoneType = accountVm.phoneType;
                account.title = accountVm.title;
                account.releaseDate = accountVm.releaseDate;
                account.genre = accountVm.genre;
            }
            return account;
        }
        //
        // GET: /UserAccount/Details/5
        public ActionResult Details(UserAccount account)
        {
            return View(account);
        }

        //
        // GET: /UserAccount/Create
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /UserAccount/Create
        [HttpPost]
        public ActionResult Create(UserAccount account)
        {
            Logic logic = new Logic();
            if (!ModelState.IsValid)
            {
                return View("Create", account);
            }
            logic.CreateAccount(account.lastName, account.firstName, account.email, 
                account.street, account.city, account.state, account.zip, account.addressType, 
                account.number, account.phoneType, account.title, account.releaseDate, account.genre);
            accounts.Add(account);
            return RedirectToAction("Index");
        }

        //
        // GET: /UserAccount/Edit/5
        public ActionResult Edit(UserAccount account)
        {
            return View(account);
        }

        //
        // POST: /UserAccount/Edit/5
        [HttpPost]
        public ActionResult Edit(UserAccount account, FormCollection collection)
        {
            List<UserAccount> accountList = GetAllAccounts();
            Logic logic = new Logic();
            if (!ModelState.IsValid)
            {
                return View("Edit", account);
            }
            foreach (UserAccount ua in accountList)
            {
                if (ua.id == account.id)
                {
                    ua.id = account.id;
                    ua.lastName = account.lastName ?? "";
                    ua.firstName = account.firstName ?? "";
                    ua.email = account.email ?? "";
                    ua.street = account.street ?? "";
                    ua.city = account.city ?? "";
                    ua.state = account.state ?? "";
                    ua.zip = account.zip ?? "";
                    ua.addressType = account.addressType ?? "";
                    ua.number = account.number ?? "";
                    ua.phoneType = account.phoneType ?? "";
                    ua.title = account.title ?? "";
                    ua.releaseDate = account.releaseDate;
                    ua.genre = account.genre ?? "";
                    //logic.UpdateAccount(ua.id, ua.lastName, ua.firstName, ua.email, 
                      //  ua.street, ua.city, ua.state, ua.zip, ua.addressType, 
                        //ua.number, ua.phoneType, ua.title, ua.releaseDate, ua.genre);
                }
            }
            return RedirectToAction("Index");
        }

        //
        // GET: /UserAccount/Delete/5
        public ActionResult Delete(UserAccount account)
        {
            return View(account);
        }

        //
        // POST: /UserAccount/Delete/5
        [HttpPost]
        public ActionResult Delete(UserAccount ua, FormCollection collection)
        {
            List<AccountVM> newAccount = new List<AccountVM>();
            Logic logic = new Logic();
            newAccount = logic.GetAllAccounts();
            foreach (AccountVM account in newAccount)
            {
                if (account.id == ua.id)
                {
                    logic.DeleteAccount(account.id);
                }
            }
            return RedirectToAction("Index");
        }
    }
}
