using Core_API.Models;
using Core_API.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IDbService<Employee, int> empServ;
        public EmployeeController(IDbService<Employee, int> serv)
        {
            empServ = serv;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var response =empServ.Get();
            return Ok(response);
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var response = empServ.Get(id);
            return Ok(response);
        }
        [HttpPost]
        public IActionResult Post(Employee data)
        {
            //try
            //{
            // Check for the Model Validations
            // if yes accept
            if (ModelState.IsValid)
            {
                // throw exception based on condition
                //if (data.Capacity < 0) throw new Exception("Capacity Cannot be -ve");
                var response = empServ.Create(data);
                return Ok(response);
            }
            else
            {
                // else generate validation error response
                return BadRequest(ModelState);
            }
            //}
            //catch (Exception ex)
            //{
            //    // Catch the exception  and return BAdRequest response
            //    return BadRequest(ex.Message);
            //}

        }
        [HttpPut("{id}")]
        public IActionResult Put(int id, Employee data)
        {
            if (ModelState.IsValid)
            {
                var response = empServ.Update(id, data);
                return Ok(response);
            }
            else
            {
                // else generate validation error response
                return BadRequest(ModelState);
            }
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var response = empServ.Delete(id);
            return Ok(response);
        }
    }
}

