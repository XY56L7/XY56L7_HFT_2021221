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
    public class PhoneController : ControllerBase
    {
        IPhoneLogic cl;
        public PhoneController(IPhoneLogic cl)
        {
            this.cl = cl;
        }
        // GET: /phone
        [HttpGet]
        public IEnumerable<Phone> Create()
        {
            return cl.ReadAll();
        }

        // GET /phone
        [HttpGet("{id}")]
        public Phone Read(int id)
        {
            return this.cl.Read(id);
        }

        // POST /phone
        [HttpPost]
        public void Create([FromBody] Phone value)
        {
            this.cl.Create(value);
        }

        // PUT /phone
        [HttpPut]
        public void Update([FromBody] Phone value)
        {
            cl.Update(value);
        }

        // DELETE /car
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            this.cl.Delete(id);
        }
    }
}
