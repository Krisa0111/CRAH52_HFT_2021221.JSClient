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
    public class ClubsLogic : IClubsLogic
    {
        IClubsRepository repo;
        public ClubsLogic(IClubsRepository clubsRepository)
        {
            this.repo = clubsRepository;
        }
        public IEnumerable<Clubs> ClubsThatHeldEventsInTheSummer()
        {

            var result = repo.ReadAll()
                .Include("Events")
                .AsEnumerable()
                .Select(y => y)
                .Where(x =>x!= null && x.Events!= null && x.Events.Date[5] == '0' && (x.Events.Date[6] == '6' || x.Events.Date[6] == '7' || x.Events.Date[6] == '8')).ToList();
                                 
            return result;
        }

        public void Create(Clubs club)
        {
            if (club.ClubID<0)
            {
                throw new IndexOutOfRangeException();
            }
            else
            {
                repo.Create(club);
            }
            
        }

        public void Delete(int id)
        {
            repo.Delete(id);
        }

        public IQueryable<Clubs> ReadAll()
        {
            return repo.ReadAll();
        }

        public Clubs ReadOne(int id)
        {
            return repo.ReadOne(id);
        }

        public void Update(Clubs club)
        {
            repo.Update(club);
        }
    }
}
