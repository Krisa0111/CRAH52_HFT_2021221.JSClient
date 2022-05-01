using CRAH52_HFT_2021221.Models;
using CRAH52_HFT_2021221.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRAH52_HFT_2021221.Logic
{
    public class EventsLogic : IEventsLogic
    {
        IEventsRepository repo;
        public EventsLogic(IEventsRepository eventsRepository)
        {
            this.repo = eventsRepository;
        }
        public void Create(Events events)
        {
            if (events.EventID<0)
            {
                throw new IndexOutOfRangeException();
            }
            else
            {
                repo.Create(events);
            }
            
        }

        public void Delete(int id)
        {
            repo.Delete(id);
        }

        public IEnumerable<Events> MostExpensiveEvents()
        {
            return repo.ReadAll()
                .Select(x => x)
                .Where(y => y.Clubs.BaseTicketPrice == repo.ReadAll().Max(z => z.Clubs.BaseTicketPrice));
            
        }
        public IEnumerable<Events> EventsWithPresident()
        {
            return repo.ReadAll()
                .Select(x => x)
                .Where(y => y.Clubs.President != "unkown");
        }

        public IQueryable<Events> ReadAll()
        {
            return repo.ReadAll();
        }

        public Events ReadOne(int id)
        {
            return repo.ReadOne(id);
        }

        public IEnumerable<Events> TheMostPopularEvent()
        {
            return repo.ReadAll()
                .Include("Guests")
                .AsEnumerable()
                .Select(x => x)
                .GroupBy(y => y.Guests.Count())
                .Last();
        }

        public void Update(Events events)
        {
            repo.Update(events);
        }
    }
}
