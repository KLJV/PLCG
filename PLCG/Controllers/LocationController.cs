using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PLCG.Models;
using PLCG.Concrete;
using System.Data.Entity;
using System.Reflection;

namespace PLCG.Controllers
{
    public class LocationController : Controller
    {
        private EFDbContext _efDbContext = new EFDbContext();

        #region Read

        public ActionResult Index()
        {
            return View(_efDbContext.Locations);
        }

        #endregion

        #region Delete

        public RedirectToRouteResult Delete(Location location, string returnUrl)
        {
            Location loc = _efDbContext.Locations.FirstOrDefault(l => l.LocationID == location.LocationID);
            if (loc != null)
            {
                _efDbContext.Locations.Remove(loc);
            }
            _efDbContext.SaveChanges();
            return RedirectToAction("Index", new { returnUrl });
        }

        #endregion

        #region Create

        public ViewResult Create()
        {
            return View(new Location());
        }

        [HttpPost]
        public ActionResult Create(Location location, string returnUrl)
        {
            Location loc = new Location
            {
                LocationCity = location.LocationCity,
                LocationCountry = location.LocationCountry,
                LocationState = location.LocationState,
                LocationZip = location.LocationZip,
                LocationRadius = location.LocationRadius
            };

            _efDbContext.Locations.Add(loc);
            _efDbContext.SaveChanges();
            return RedirectToAction("Index", new { returnUrl });
        }

        #endregion

        #region Update

        public ActionResult Update()
        {
            return View(new Location());
        }

        public ActionResult Update(Location location, string returnUrl)
        {
            Location loc = _efDbContext.Locations.FirstOrDefault(l => l.LocationID == location.LocationID);

            if (loc != null)
            {
                loc.LocationCity = location.LocationCity;
                loc.LocationZip = location.LocationZip;
                loc.LocationState = location.LocationState;
                loc.LocationCountry = location.LocationCountry;
                loc.LocationRadius = location.LocationRadius;
            }
            _efDbContext.SaveChanges();
            return RedirectToAction("Index", new { returnUrl });
        }

        #endregion
    }
}