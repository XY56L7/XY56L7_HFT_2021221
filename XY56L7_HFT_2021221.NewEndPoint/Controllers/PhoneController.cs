using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System.Collections.Generic;
using XY56L7_HFT_2021221.Logic;
using XY56L7_HFT_2021221.Logic.Interfaces;
using XY56L7_HFT_2021221.Models;
using XY56L7_HFT_2021221.NewEndPoint.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace XY56L7_HFT_2021221.NewEndPoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PhoneController : ControllerBase
    {
        IHubContext<SignalRHub> hub;
        IPhoneLogic cl;
        public PhoneController(IPhoneLogic cl, IHubContext<SignalRHub> hub)
        {
            this.hub = hub;
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
            this.hub.Clients.All.SendAsync("PhoneCreated", value);
        }

        // PUT /phone
        [HttpPut]
        public void Update([FromBody] Phone value)
        {
            cl.Update(value);
            this.hub.Clients.All.SendAsync("PhoneUpdated", value);
        }

        // DELETE /phone
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var PhoneToDelete = this.cl.Read(id);
            this.cl.Delete(id);
            this.hub.Clients.All.SendAsync("PhoneDeleted", PhoneToDelete);
        }
    }
}
