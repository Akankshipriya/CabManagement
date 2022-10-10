using CabManagement.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CabManagement.Controllers
{
    public class DriverController : Controller
    {

        private CabManagementDBContext _cmDB;
        public DriverController(CabManagementDBContext cmDB)
        {
            _cmDB = cmDB;
        }
        public IActionResult Create(driver d)
        {
            _cmDB.Drivers.Add(d);
            _cmDB.SaveChanges();
            return View();
        }

        public IActionResult Display()
        {

            return View(_cmDB.Drivers);
        }

        public ActionResult Edit(int Id)
        {

            var std = _cmDB.Drivers.Where(s => s.driverId == Id).FirstOrDefault();

            return View(std);
        }

        [HttpPost]
        public ActionResult Edit(driver c)
        {

            var driver = _cmDB.Drivers.Where(s => s.driverId == c.driverId).FirstOrDefault();
            _cmDB.Drivers.Remove(driver);
            _cmDB.Drivers.Add(c);
            _cmDB.SaveChanges();

            return View();
        }
        public IActionResult Delete(int Id)
        {
            var driver = _cmDB.Drivers.Where(s => s.driverId == Id).FirstOrDefault();
            _cmDB.Drivers.Remove(driver);

            _cmDB.SaveChanges();

            return View("DisplayCar", _cmDB.Drivers);
        }
        public IActionResult Details(int Id)
        {


            var driver = _cmDB.Drivers.Where(s => s.driverId == Id).FirstOrDefault();

            return View(driver);
        }


    }
}
