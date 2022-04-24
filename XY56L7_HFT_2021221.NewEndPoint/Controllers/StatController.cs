using Microsoft.AspNetCore.Mvc;
using XY56L7_HFT_2021221.Logic.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace XY56L7_HFT_2021221.NewEndPoint.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class StatController : ControllerBase
    {
        IPhoneLogic cl;
        IBrandLogic bl;
        public StatController(IPhoneLogic cl, IBrandLogic bl)
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
