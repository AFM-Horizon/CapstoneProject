using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace CapstoneProject.Controllers
{
    public class UnitController : Controller
    {
        [HttpGet]
        public IActionResult UnitList()
        {
            return View();
        }

        [HttpGet]
        public IActionResult UnitDetails()
        {
            return View();
        }
    }
}