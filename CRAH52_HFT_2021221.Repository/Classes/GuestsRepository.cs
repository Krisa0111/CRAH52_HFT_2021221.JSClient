using CRAH52_HFT_2021221.Data;
using CRAH52_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRAH52_HFT_2021221.Repository
{
    public class GuestsRepository : IGuestsRepository
    {
        ClubsDbContext Context;
        public GuestsRepository(ClubsDbContext context)
        {
            this.Context = context;
        }
        public void Create(Guests guest)
        {
            guest.GuestID = 0;
            Context.Guests.Add(guest);
            Context.SaveChanges();
        }

        public void Delete(int id)
        {
            Guests guest = Context
                .Guests
                .FirstOrDefault(x => x.GuestID == id);



            Context.Guests.Remove(guest);
            Context.SaveChanges();
        }

        public IQueryable<Guests> ReadAll()
        {
            return Context.Guests;
        }

        public Guests ReadOne(int id)
        {
            return Context
                .Guests
                .FirstOrDefault(x => x.GuestID == id);
        }

        public void Update(Guests guest)
        {
            Guests old = Context
                .Guests
                .FirstOrDefault(x => x.GuestID == guest.GuestID);
            if (old != null) //TEST THIS NULL CHECK, IMPORTANT!!! 
            {
                old.BirthYear = guest.BirthYear;
                old.Email = guest.Email;
                old.Event = guest.Event;
                old.EventID = guest.EventID;
                old.Name = guest.Name;
            }
            Context.SaveChanges();
        }
    }
}
