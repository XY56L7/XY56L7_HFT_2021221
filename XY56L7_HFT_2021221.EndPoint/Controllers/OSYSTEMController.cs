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
    public class OSYSTEMController : ControllerBase
    {
        IOSYSTEMLogic cl;
        public OSYSTEMController(IOSYSTEMLogic cl )
        {
            this.cl = cl;
        }
        // GET: /OSYSTEM
        [HttpGet]
        public IEnumerable<OSYSTEM> Get()
        {
            return cl.ReadAll(); ;
        }

        // GET /OSYSTEM
        [HttpGet("{id}")]
        public OSYSTEM Get(int id)
        {
            return cl.Read(id);
        }

        // POST /OSYSTEM
        [HttpPost]
        public void Post([FromBody] OSYSTEM value)
        {
            cl.Create(value);
        }

        // PUT /OSYSTEM
        [HttpPut("{id}")]
        public void Put([FromBody] OSYSTEM value)
        {
            cl.Update(value);
        }

        // DELETE /OSYSTEM
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            cl.Delete(id);
        }
    }
}
