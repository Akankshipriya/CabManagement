using CabManagement.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CabManagement.Controllers
{
    public class CarController : Controller
    {
        private CabManagementDBContext _cmDB;
        public CarController(CabManagementDBContext cmDB)
        {
            _cmDB = cmDB;
        }
        public IActionResult Create(Cars c)
        {
            _cmDB.Cars.Add(c);
            _cmDB.SaveChanges();
            return View();
        }

        public IActionResult DisplayCar()
        {
            
            return View(_cmDB.Cars);
        }



        public ActionResult Edit(int Id)
        {

            var std = _cmDB.Cars.Where(s => s.CarId == Id).FirstOrDefault();

            return View(std);
        }

        [HttpPost]
        public ActionResult Edit(Cars c)
        {
            
            var car = _cmDB.Cars.Where(s => s.CarId == c.CarId).FirstOrDefault();
            _cmDB.Cars.Remove(car);
            _cmDB.Cars.Add(c);
            _cmDB.SaveChanges();

            return View();
        }
        public IActionResult Delete(int Id)
        {
            var car = _cmDB.Cars.Where(s => s.CarId == Id).FirstOrDefault();
            _cmDB.Cars.Remove(car);

            _cmDB.SaveChanges();

            return View("DisplayCar",_cmDB.Cars);
        }
        public IActionResult Details(int Id)
        {


            var car = _cmDB.Cars.Where(s => s.CarId == Id).FirstOrDefault();

            return View(car);
        }
    }
}
