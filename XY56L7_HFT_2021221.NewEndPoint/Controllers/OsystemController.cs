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
    public class OSYSTEMController : ControllerBase
    {
        IOSYSTEMLogic cl;
        IHubContext<SignalRHub> hub;
        public OSYSTEMController(IOSYSTEMLogic cl, IHubContext<SignalRHub> hub)
        {
            this.cl = cl;
            this.hub = hub;
        }
        // GET: /OSYSTEM
        [HttpGet]
        public IEnumerable<OSYSTEM> ReadAll()
        {
            return cl.ReadAll(); ;
        }

        // GET /OSYSTEM
        [HttpGet("{id}")]
        public OSYSTEM Read(int id)
        {
            return cl.Read(id);

        }

        // POST /OSYSTEM
        [HttpPost]
        public void Create([FromBody] OSYSTEM value)
        {
            cl.Create(value);
            this.hub.Clients.All.SendAsync("OSYSTEMCreated", value);
        }

        // PUT /OSYSTEM
        [HttpPut]
        public void Update([FromBody] OSYSTEM value)
        {
            cl.Update(value);
            this.hub.Clients.All.SendAsync("OSYSTEMUpdated", value);
        }

        // DELETE /OSYSTEM
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var OSToDelete = this.cl.Read(id);
            cl.Delete(id);
            this.hub.Clients.All.SendAsync("OSYSTEMDeleted", OSToDelete);
        }
    }
}
