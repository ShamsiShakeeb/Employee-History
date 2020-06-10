using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TechTest.Models;

namespace TechTest.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly DatabaseContext _context;

        public EmployeesController(DatabaseContext context)
        {
            _context = context;
        }
        [Route("Employees/Index")]
       
        public ActionResult Index()
        {

            return View();
        }

        [Route("Employees/Update/{EID}")]
        public async Task<IActionResult> Update(int? EID)
        {
            if (EID == null)
            {
                return BadRequest();
            }

            var employee = await _context.employee.Where(x => x.EID == EID).FirstOrDefaultAsync<Employee>();
            if (employee == null)
            {
                return BadRequest();
            }

            return View(employee);
        }
       
       
       



    }
}