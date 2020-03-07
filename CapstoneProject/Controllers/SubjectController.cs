using System.Threading.Tasks;
using CapstoneProject.DataAccess.UnitOfWork;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace CapstoneProject.Controllers
{
    public class SubjectController : Controller
    {
        private readonly IUnitOfWork _unit;

        public SubjectController(IUnitOfWork unit)
        {
            _unit = unit;
        }

        [HttpGet]
        public async Task<IActionResult> SubjectList()
        {
            //This returns a list of subjects that we can use to populate the view
            var subjectList = await _unit.SubjectRepository.GetAllAsync();

            return View(nameof(SubjectList), subjectList);
        }

        [HttpGet]
        public async Task<IActionResult> SubjectDetails(string moduleCode)
        {
            //this retrieves the info for a single subject given a module code
            var subject = await _unit.SubjectRepository.GetByIdAsync(moduleCode);

            return View(nameof(SubjectDetails), subject);
        }
    }
}