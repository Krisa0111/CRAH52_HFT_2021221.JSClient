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
    public class GuestsLogic : IGuestsLogic
    {
        IGuestsRepository repo;
        public GuestsLogic(IGuestsRepository guestsRepository)
        {
            repo = guestsRepository;
        }
        public void Create(Guests guest)
        {
            if (guest.GuestID<0)
            {
                throw new IndexOutOfRangeException();
            }
            else
            {
                repo.Create(guest);
            }
            
        }

        public void Delete(int id)
        {
            repo.Delete(id);
        }

        

        public IQueryable<Guests> ReadAll()
        {
            return repo.ReadAll();
        }

        public Guests ReadOne(int id)
        {
            return repo.ReadOne(id);
        }

        public void Update(Guests guest)
        {
            repo.Update(guest);
        }

        public IEnumerable<Guests> YoungestPersonOnCoronita()
        {
            yield return repo.ReadAll()
                            .Select(x => x)
                            .Where(y => y.Event.EventName.ToUpper() == "CORONITA")
                            .OrderByDescending(y => y.BirthYear).ToList().First();
        }
    }
}
