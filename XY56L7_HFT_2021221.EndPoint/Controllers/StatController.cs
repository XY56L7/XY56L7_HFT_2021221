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
    [Route("[controller]/[action]")]
    [ApiController]
    public class StatController : ControllerBase
    {
        IPhoneLogic cl;
        IBrandLogic bl;
        public StatController(IPhoneLogic cl,IBrandLogic bl)
        {
            this.cl = cl;
            this.bl = bl;
        }
        // GET: /stat/avgrating
        [HttpGet]
        public double AVGRating()
        {
            return cl.AVGRating();
        }
        // GET: /stat/avgratingbrand
        [HttpGet]
        public double AVGRatingBrand()
        {
            return bl.AVGRatingBrand();
        }
        // GET: /stat/bestrating
        [HttpGet]
        public double BestRating()
        {
            return bl.BestRating();
        }
        // GET: /stat/worstrating
        [HttpGet]
        public double WorstRating()
        {
            return bl.WorstRating();
        }
        // GET: /stat/count
        [HttpGet]
        public double Count()
        {
            return bl.Count();
        }
        // GET: /stat/besttrustinglevel
        [HttpGet]
        public double Besttrustinglevel()
        {
            return bl.Besttrustinglevel();
        }
        // GET: /stat/worsttrustinglevel
        [HttpGet]
        public double Worsttrustinglevel()
        {
            return bl.Worsttrustinglevel();
        }


    }
}
