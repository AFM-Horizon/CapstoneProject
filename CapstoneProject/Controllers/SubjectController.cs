﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace CapstoneProject.Controllers
{
    public class SubjectController : Controller
    {
        [HttpGet]
        public IActionResult SubjectList()
        {
            return View(nameof(SubjectList));
        }

        [HttpGet]
        public IActionResult SubjectDetails()
        {
            return View(nameof(SubjectDetails));
        }
    }
}