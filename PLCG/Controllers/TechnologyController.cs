using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PLCG.Models;
using PLCG.Concrete;

namespace PLCG.Controllers
{
    public class TechnologyController : Controller
    {
        private EFDbContext _efDbContext = new EFDbContext();

        #region Select

        public ActionResult Index()
        {
            return View(_efDbContext.Technologies);
        }
        #endregion

        #region Delete

        public RedirectToRouteResult Delete(Technology technology, string returnUrl)
        {
            Technology tech = _efDbContext.Technologies.FirstOrDefault(t => t.TechnologyID == technology.TechnologyID);

            if (tech != null)
            {
                _efDbContext.Technologies.Remove(tech);
            }
            _efDbContext.SaveChanges();
            return RedirectToAction("Index", new { returnUrl });
        }

        #endregion

        #region Create

        public ViewResult Create()
        {
            return View(new Technology());
        }

        [HttpPost]
        public ActionResult Create(Technology technology, string returnUrl)
        {
            Technology tech = new Technology
            {
                TechnologyName = technology.TechnologyName,
                TechnologyType = technology.TechnologyType
            };

            _efDbContext.Technologies.Add(tech);
            _efDbContext.SaveChanges();
            return RedirectToAction("Index", new { returnUrl });
        }

        #endregion

        #region Update

        public ActionResult Update()
        {
            return View(new Technology());
        }

        public ActionResult Update(Technology technology, string returnUrl)
        {
            Technology tech = _efDbContext.Technologies.FirstOrDefault(t => t.TechnologyID == technology.TechnologyID);

            if (tech != null)
            {
                tech.TechnologyName = technology.TechnologyName;
                technology.TechnologyType = technology.TechnologyType;
            }
            _efDbContext.SaveChanges();
            return RedirectToAction("Index", new { returnUrl });
        }

        #endregion
    }
}