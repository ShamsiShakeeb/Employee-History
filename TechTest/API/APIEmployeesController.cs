using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TechTest.Models;

namespace TechTest.API
{
    [ApiKeyAuth]
    public class APIEmployeesController : Controller
    {
        private readonly DatabaseContext _context;

        public APIEmployeesController(DatabaseContext context)
        {
            _context = context;
        }
       
        [Route("api/EmployeeList")]
        // GET: api/APIEmployees
        [HttpGet]
        public async Task<ActionResult<ArrayList>> Getemployee()
        {
            var data = await _context.employee.ToListAsync();
            ArrayList list = new ArrayList(data);
            return Json(new { data = list});
        }


        [Route("api/UpdateEmployee/{id}")]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmployee(int id, Employee employee)
        {
            if (id != employee.EID)
            {
                return BadRequest();
            }

            _context.Entry(employee).State = EntityState.Modified;

            try
            {
                if (ModelState.IsValid)
                {

                    await _context.SaveChangesAsync();
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeeExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }


        [Route("api/PostEmployee")]
        [HttpPost]
        public async Task<ActionResult<Employee>> PostEmployee(Employee employee)
        {

            if (ModelState.IsValid)
            {

                _context.employee.Add(employee);
                await _context.SaveChangesAsync();
                return Json(new { success = true, message = "Ok" });

            }
            else
            {
                return BadRequest();
            }
        }

        // DELETE: api/APIEmployees/5
        [Route("api/DeleteEmployee/{id}")]
        [HttpDelete("{id}")]
        public async Task<ActionResult<Employee>> DeleteEmployee(int id)
        {
            var employee = await _context.employee.FindAsync(id);
            if (employee == null)
            {
                return NotFound();
            }

            _context.employee.Remove(employee);
            await _context.SaveChangesAsync();

            return employee;
        }

        private bool EmployeeExists(int id)
        {
            return _context.employee.Any(e => e.EID == id);
        }
    }
}
