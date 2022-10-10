using CabManagement.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CabManagement.Controllers
{
    public class RouteController : Controller
    {

        private CabManagementDBContext _cmDB;
        public RouteController(CabManagementDBContext cmDB)
        {
            _cmDB = cmDB;
        }
        public IActionResult Create(Route r)
        {
            _cmDB.Routes.Add(r);
            _cmDB.SaveChanges();
            return View();
        }

        public IActionResult Display()
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

