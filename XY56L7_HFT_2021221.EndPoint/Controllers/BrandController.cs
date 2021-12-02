using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XY56L7_HFT_2021221.Logic;
using XY56L7_HFT_2021221.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace XY56L7_HFT_2021221.EndPoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class BrandController : ControllerBase
    {
        IBrandLogic cl;
        public BrandController(IBrandLogic cl)
        {
            this.cl = cl;
        }
        // GET: /brand
        // [HttpGet]
        public IEnumerable<Brand> Get()
        {
            return cl.ReadAll();
        }

        // GET /brand
        [HttpGet("{id}")]
        public Brand Get(int id)
        {
            return cl.Read(id);
        }

        // POST /brand
        [HttpPost]
        public void Post([FromBody] Brand value)
        {
            cl.Create(value);
        }

        // PUT /brand
        [HttpPut]
        public void Put([FromBody] Brand value)
        {
            cl.Update(value);
        }

        // DELETE /brand
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            cl.Delete(id);
        }
    }
}
