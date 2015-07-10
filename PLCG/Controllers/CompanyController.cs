using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations.Model;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PLCG.Models;
using PLCG.Concrete;

namespace PLCG.Controllers
{
    public class CompanyController : Controller
    {
        private EFDbContext _efDbContext = new EFDbContext();

        #region Read

        public ActionResult Index()
        {
            return View(_efDbContext.Companies);
        }

        #endregion

        #region Delete

        public RedirectToRouteResult Delete(Company company, string returnUrl)
        {
            Company comp = _efDbContext.Companies.FirstOrDefault(c => c.CompanyID == company.CompanyID);

            if (comp != null)
            {
                _efDbContext.Companies.Remove(comp);
            }
            _efDbContext.SaveChanges();
            return RedirectToAction("Index", new { returnUrl });
        }

        #endregion

        #region Create

        public ViewResult Create()
        {
            return View(new Company());
        }

        [HttpPost]
        public ActionResult Create(Company company, string returnUrl)
        {
            Company comp = new Company
            {
                CompanyName = company.CompanyName,
                CompanyAddress = company.CompanyAddress
            };

            _efDbContext.Companies.Add(comp);
            _efDbContext.SaveChanges();
            return RedirectToAction("Index", new { returnUrl });
        }

        #endregion

        #region Update

        public ActionResult Update()
        {
            return View(new Company());
        }

        [HttpPost]
        public ActionResult Update(Company company, string returnUrl)
        {
            Company comp = _efDbContext.Companies.FirstOrDefault(c => c.CompanyID == company.CompanyID);

            if (comp != null)
            {
                comp.CompanyName = company.CompanyName;
                comp.CompanyAddress = company.CompanyAddress;
            }
            _efDbContext.SaveChanges();
            return RedirectToAction("Index", new { returnUrl });
        }

        #endregion
    }
}