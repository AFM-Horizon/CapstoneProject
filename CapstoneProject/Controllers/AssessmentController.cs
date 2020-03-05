using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace CapstoneProject.Controllers
{
    public class AssessmentController : Controller
    {
        [HttpGet]
        public IActionResult Assessment()
        {
            return View(nameof(Assessment));
        }
    }
}