using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XY56L7_HFT_2021221.Logic;
using XY56L7_HFT_2021221.Models;

namespace XY56L7_HFT_2021221.EndPoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PhoneController : ControllerBase
    {
        IPhoneLogic cl;
        public PhoneController(IPhoneLogic cl)
        {
            this.cl = cl;
        }
        // GET: /phone
        [HttpGet]
        public IEnumerable<Phone> Get()
        {
            return cl.ReadAll() ;
        }

        // GET /phone/3
        [HttpGet("{id}")]
        public Phone Get(int id)
        {
            return cl.Read(3);
        }

        // POST api/<PhoneController>
        [HttpPost]
        public void Post([FromBody] Phone value)
        {
            cl.Create(value);
        }

        // PUT /car/3
        [HttpPut("{id}")]
        public void Put([FromBody] Phone value)
        {
            cl.Update(value);
        }

        // DELETE /car/1
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            cl.Delete(id);
        }
    }
}
