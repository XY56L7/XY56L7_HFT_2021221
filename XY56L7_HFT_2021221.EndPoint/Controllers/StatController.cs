using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XY56L7_HFT_2021221.Logic;
using XY56L7_HFT_2021221.Models;

namespace XY56L7_HFT_2021221.EndPoint.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatController : ControllerBase
    {
        IPhoneLogic cl;
        public StatController(IPhoneLogic cl)
        {
            this.cl = cl;
        }
        // GET: /stat/avgprice
        [HttpGet]
        public double AVGRating()
        {
            return cl.AVGRating();
        }
        //// GET: /stat/avgpricebybrands
        //[HttpGet]
        //public IEnumerable<KeyValuePair<string,double>> GetAvgPriceByBrands()
        //{
        //    return cl.ReadAll();
        //}
    }
}
