using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Core_API.Models;
using Core_API.Services;
using System;

namespace Core_API.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IDbService<Department, int> deptServ;
        public DepartmentController(IDbService<Department, int> serv)
        {
            deptServ = serv;
        }
        
        [HttpGet]
        public IActionResult Get()
        {
            var response = deptServ.Get();
            return Ok(response);
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        { 
            var response = deptServ.Get(id);
            return Ok(response);
        }
        [HttpPost]
        public IActionResult Post(Department data)
        {
            //try
            //{
                // Check for the Model Validations
                // if yes accept
                if (ModelState.IsValid)
                {
                    // throw exception based on condition
                    if (data.Capacity < 0) throw new Exception("Capacity Cannot be -ve");
                    var response = deptServ.Create(data);
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
        public IActionResult Put(int id, Department data)
        {
            if (ModelState.IsValid)
            {
                var response = deptServ.Update(id, data);
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
            var response = deptServ.Delete(id);
            return Ok(response);
        }
    }
}
