using CabManagement.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CabManagement.Controllers
{
    

    public class TravelManagerController : Controller
    {

        private CabManagementDBContext _cmDB;
        public TravelManagerController(CabManagementDBContext cmDB)
        {
            _cmDB = cmDB;
        }
        
        public IActionResult Assign()
        {
            
            return View();
        }
        [HttpPost]
        public IActionResult Assign(Relation relation)
        {
            Route r=_cmDB.Routes.SingleOrDefault(x => x.RouteID == relation.RouteId);
            r.Car = _cmDB.Cars.SingleOrDefault(x=>x.CarId==relation.CarId);
            r.Car.CarId = relation.CarId;
            _cmDB.SaveChanges();
            return View();

        }

        public IActionResult DisplayCar()
        {

            return View(_cmDB.Routes);
        }

        public ActionResult Edit(int Id)
        {

            var std = _cmDB.Routes.Where(s => s.RouteID == Id).FirstOrDefault();

            return View(std);
        }

        [HttpPost]
        public ActionResult Edit(Route r)
        {

            var route = _cmDB.Routes.Where(s => s.RouteID == r.RouteID).FirstOrDefault();
            _cmDB.Routes.Remove(route);
            _cmDB.Routes.Add(r);
            _cmDB.SaveChanges();

            return View();
        }
        public IActionResult Delete(int Id)
        {
            var route = _cmDB.Routes.Where(s => s.RouteID == Id).FirstOrDefault();
            _cmDB.Routes.Remove(route);

            _cmDB.SaveChanges();

            return View("DisplayCar", _cmDB.Routes);
        }
        public IActionResult Details(int Id)
        {


            var route = _cmDB.Routes.Where(s => s.RouteID == Id).FirstOrDefault();

            return View(route);
        }


    }
}
