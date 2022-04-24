using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using XY56L7_HFT_2021221.Logic;
using XY56L7_HFT_2021221.Logic.Interfaces;
using XY56L7_HFT_2021221.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace XY56L7_HFT_2021221.NewEndPoint.Controllers
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
        [HttpGet]
        public IEnumerable<Brand> Create()
        {
            return cl.ReadAll();
        }

        // GET /brand
        [HttpGet("{id}")]
        public Brand Read(int id)
        {
            return cl.Read(id);
        }

        // POST /brand
        [HttpPost]
        public void Create([FromBody] Brand value)
        {
            cl.Create(value);
        }

        // PUT /brand
        [HttpPut]
        public void Uodate([FromBody] Brand value)
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
