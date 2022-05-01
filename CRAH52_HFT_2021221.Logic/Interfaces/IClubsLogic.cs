using CRAH52_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRAH52_HFT_2021221.Logic
{
    public interface IClubsLogic
    {
        void Create(Clubs club);
        Clubs ReadOne(int id);
        IQueryable<Clubs> ReadAll();
        void Update(Clubs club);
        void Delete(int id);
        //NONCRUD
        IEnumerable<Clubs> ClubsThatHeldEventsInTheSummer();
    }
}
