using CRAH52_HFT_2021221.Logic;
using CRAH52_HFT_2021221.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace CRAH52_HFT_2021221.Endpoint.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class StatController : ControllerBase
    {
        IClubsLogic cl;
        IGuestsLogic gl;
        IEventsLogic el;
        public StatController(IEventsLogic el, IGuestsLogic gl, IClubsLogic cl)
        {
            this.cl = cl;
            this.gl = gl;
            this.el = el;
        }
        [HttpGet]
        public IEnumerable<Clubs> ClubsThatHeldEventsInTheSummer()
        {
            return cl.ClubsThatHeldEventsInTheSummer();
        }
        [HttpGet]
        public IEnumerable<Events> MostExpensiveEvents()
        {
            return el.MostExpensiveEvents();
        }
        [HttpGet]
        public IEnumerable<Events> TheMostPopularEvent()
        {
            return el.TheMostPopularEvent();
        }
        [HttpGet]
        public IEnumerable<Events> EventsWithPresident()
        {
            return el.EventsWithPresident();
        }
        [HttpGet]
        public IEnumerable<Guests> YoungestPersonOnCoronita()
        {
            return gl.YoungestPersonOnCoronita();
        }


    }
}
