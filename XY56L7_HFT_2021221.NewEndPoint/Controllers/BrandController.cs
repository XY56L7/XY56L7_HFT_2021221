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
    public class BrandController : ControllerBase
    {
        IBrandLogic cl;
        IHubContext<SignalRHub> hub;
        public BrandController(IBrandLogic cl, IHubContext<SignalRHub> hub)
        {
            this.cl = cl;
            this.hub = hub;
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
            this.cl.Create(value);
            this.hub.Clients.All.SendAsync("BrandCreated", value);
        }

        // PUT /brand
        [HttpPut]
        public void Update([FromBody] Brand value)
        {
            this.cl.Update(value);
            this.hub.Clients.All.SendAsync("BrandUpdated", value);
        }

        // DELETE /brand
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var brandToDelete = this.cl.Read(id);
            cl.Delete(id);
            this.hub.Clients.All.SendAsync("BrandDeleted", brandToDelete);
        }
    }
}
