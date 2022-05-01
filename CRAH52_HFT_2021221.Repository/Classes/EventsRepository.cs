using CRAH52_HFT_2021221.Data;
using CRAH52_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRAH52_HFT_2021221.Repository
{
    public class EventsRepository : IEventsRepository
    {
        ClubsDbContext Context;
        public EventsRepository(ClubsDbContext context)
        {
            this.Context = context;
        }
        public void Create(Events events)
        {
            
            events.EventID = 0;
            Context.Events.Add(events);
            Context.SaveChanges();
        }

        public void Delete(int id)
        {
            Events events = Context
                .Events
                .FirstOrDefault(x => x.EventID == id);



            Context.Events.Remove(events);
            Context.SaveChanges();
        }

        public IQueryable<Events> ReadAll()
        {
            return Context.Events;
        }

        public Events ReadOne(int id)
        {
            return Context
                .Events
                .FirstOrDefault(x => x.EventID == id);
        }

        public void Update(Events events)
        {
            Events old = Context
                .Events
                .FirstOrDefault(x => x.EventID == events.EventID);
            if (old != null) //TEST THIS NULL CHECK, IMPORTANT!!! 
            {
                old.ClubID = events.ClubID;
                old.Clubs = events.Clubs;
                old.Date = events.Date;
                old.EventName = events.EventName;
                old.EventShortDesc = events.EventShortDesc;
                old.Guests = events.Guests;
            }
            Context.SaveChanges();
        }
    }
}
