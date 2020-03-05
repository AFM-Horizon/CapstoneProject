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
            return View(nameof(UnitList));
        }

        [HttpGet]
        public IActionResult UnitDetails()
        {
            return View(nameof(UnitDetails));
        }
    }
}