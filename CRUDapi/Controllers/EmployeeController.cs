using CRUDapi.Data;
using CRUDapi.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;

namespace CRUDapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {

        private readonly ApiDbContext _context;

        public EmployeeController(ApiDbContext context)
        {
            _context = context;
        }


        [HttpGet]
        public async Task<ActionResult<List<Employee>>> GetEmployee()
        {
            /*return Ok(await _context.Employees.ToListAsync());*/

            //Applying StoredProcedure to get all Employee
            return _context.Employees.FromSqlRaw($"SelectAllEmployees").ToList();
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<List<Employee>>> GetEmployee(int id)
        {
/*            var employee = _context.Employees.Find(id);
            if (employee == null)
            {
                return NotFound();
            }
            return employee;*/

            //SP to get Employee
            var result = await _context.Employees.FromSqlRaw($"SelectEmployee {id}").ToListAsync();
            return Ok(result);

        }


        [HttpPost]
        public async Task<ActionResult<Employee>> Create(Employee employee)
        {
            /*            _context.Add(employee);
                        await _context.SaveChangesAsync();
                        return Ok(employee);*/


            await _context.Database.ExecuteSqlRawAsync($"CreateEmployee @Name",
                new SqlParameter("@Name", employee.Name)
                // Add more parameters as needed
            );
            await _context.SaveChangesAsync();
            return Ok(employee);
        
    }



        [HttpPut("name/{id}/{name}")]
        public async Task<ActionResult<int>> UpdateEmployee(int id, string name)
        {
            var result = await _context.Database
                .ExecuteSqlRawAsync($"UpdateEmployee {id}, {name}");

            /*return Ok(result);*/

            if (result > 0)
            {
                // Delete operation was successful
                return Ok(new { message = "Employee update successfully" });
            }
            else
            {
                // Delete operation did not affect any rows
                return NotFound(new { message = "Employee not found" });
            }

        }



        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _context.Database
                .ExecuteSqlRawAsync($"DeleteEmployee {id}");

            if (result > 0)
            {
                // Delete operation was successful
                return Ok(new { message = "Employee deleted successfully" });
            }
            else
            {
                // Delete operation did not affect any rows
                return NotFound(new { message = "Employee not found" });
            }
        }


        /*        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, Employee employee)
        {
            if (id != employee.Id)
                return BadRequest();

            _context.Entry(employee).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return Ok();
            return Ok(employee);
        }*/


        /*        [HttpDelete("{id}")]
                public async Task<IActionResult> Delete(int id)
                {
                    var employee = await _context.Employees.FindAsync(id);
                    if (employee == null)
                    {
                        return NotFound();
                    }

                    _context.Employees.Remove(employee);
                    await _context.SaveChangesAsync();

                    return Ok();

                }*/


    }
}
