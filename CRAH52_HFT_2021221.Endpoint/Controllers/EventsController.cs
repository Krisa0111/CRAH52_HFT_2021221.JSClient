using CRAH52_HFT_2021221.Endpoint.Services;
using CRAH52_HFT_2021221.Logic;
using CRAH52_HFT_2021221.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CRAH52_HFT_2021221.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class EventsController : ControllerBase
    {
        IEventsLogic logic;
        IHubContext<SignalRHub> hub;
        public EventsController(IEventsLogic logic, IHubContext<SignalRHub> hub)
        {
            this.logic = logic;
            this.hub = hub;
        }
        // GET: api/<EventsController>
        [HttpGet]
        public IEnumerable<Events> Get()
        {
            return logic.ReadAll();
        }
        [HttpGet("{id}")]
        public Events Get(int id)
        {
            return logic.ReadOne(id);
        }
        [HttpPost]
        public void Post([FromBody] Events events)
        {
            logic.Create(events);
            this.hub.Clients.All.SendAsync("EventCreated", events);
        }
        [HttpPut]
        public void Put([FromBody] Events events)
        {
            logic.Update(events);
            this.hub.Clients.All.SendAsync("EventUpdated", events);
        }
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var eventToDelete = this.logic.ReadOne(id);
            logic.Delete(id);
            this.hub.Clients.All.SendAsync("EventDeleted", eventToDelete);
        }
    }
}
