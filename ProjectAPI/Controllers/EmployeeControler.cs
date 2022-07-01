using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ProjectAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeControler : ControllerBase
    {

        private static List<EmployeeClass> employees = new List<EmployeeClass>
        {
       new EmployeeClass { Id =1, FirstName = "Prabhu", LastName ="Rout", Place ="Bhubaneswar"}
        };


        [HttpPost]
        public async Task<ActionResult<List<EmployeeClass>>> Add([FromBody] EmployeeClass employee)
        {
            employees.Add(employee);
            return Ok(employee);
        }
        [HttpGet]

        public async Task<ActionResult<List<EmployeeClass>>> GetAll()
        {
            return Ok(employees);
        }

        [HttpGet ("{Id}")]
        public async Task<ActionResult<List<EmployeeClass>>> GetById(int Id)
        {
            var employee = employees.Find(h => h.Id == Id);
            if (employee == null)
            {
                return BadRequest("Employee Not Found");
            }
            return Ok(employee);
        }

        [HttpPut]

        public async Task<ActionResult<List<EmployeeClass>>> Update(EmployeeClass request)
        {
            var employee = employees.Find(h => h.Id == request.Id);
            if (employee == null)
            {
                return BadRequest("Employee Not Found");
            }
          
                employee.FirstName = request.FirstName;
                employee.LastName = request.LastName;
                employee.Place = request.Place;
            return Ok(employee);
        }

        [HttpDelete("{Id}")]

        public async Task<ActionResult<List<EmployeeClass>>> Delete(int  Id)
        {
            var employee = employees.Find(h => h.Id == Id);
            if (Id == null)
            {
                return BadRequest("Employee Not Found");
            }
            employees.Remove(employee);

            return Ok(employee);
        }
    }
}
