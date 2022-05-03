using CRAH52_HFT_2021221.Data;
using CRAH52_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRAH52_HFT_2021221.Repository
{
    public class ClubsRepository : IClubsRepository
    {
        ClubsDbContext Context;
        public ClubsRepository(ClubsDbContext context)
        {
            this.Context = context;
        }
        public void Create(Clubs club)
        {
            club.ClubID = 0;
            Context.Clubs.Add(club);
            Context.SaveChanges();
        }

        public void Delete(int id)
        {
            Clubs club = Context
                .Clubs
                .FirstOrDefault(x => x.ClubID == id);
            if (club!= null)
            {
                if (club.Events != null)
                {
                    club.Events.ClubID = null;
                }
            }
            Context.Clubs.Remove(club);
            Context.SaveChanges();
        }

        public IQueryable<Clubs> ReadAll()
        {
            return Context.Clubs;
        }

        public Clubs ReadOne(int id)
        {
            return Context
                .Clubs
                .FirstOrDefault(x => x.ClubID == id);
        }

        public void Update(Clubs club)
        {
            Clubs old = Context
                .Clubs
                .FirstOrDefault(x => x.ClubID == club.ClubID);
            if (old != null) //TEST THIS NULL CHECK, IMPORTANT!!! 
            {
                old.BaseTicketPrice = club.BaseTicketPrice;
                old.Capacity = club.Capacity;
                old.ClubName = club.ClubName;
                old.Events = club.Events;
                old.President = club.President;
                old.ShortDesc = club.ShortDesc;
            }
            Context.SaveChanges();
            //var oldclub = ReadOne(club.ClubID);
            //oldclub.ClubName = club.ClubName;
            //oldclub.ClubID = club.ClubID;
            //oldclub.BaseTicketPrice = club.BaseTicketPrice;
            //oldclub.Capacity = club.Capacity;
            //oldclub.Events = club.Events;
            //oldclub.ShortDesc = club.ShortDesc;
        }
    }
}
