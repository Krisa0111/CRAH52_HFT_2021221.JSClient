using CRAH52_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRAH52_HFT_2021221.Logic
{
    public interface IEventsLogic
    {
        void Create(Events events);
        Events ReadOne(int id);
        IQueryable<Events> ReadAll();
        void Update(Events events);
        void Delete(int id);
        //NONCRUD
        IEnumerable<Events> MostExpensiveEvents(); // according to the clubs base price
        IEnumerable<Events> TheMostPopularEvent();
        IEnumerable<Events> EventsWithPresident();
        
        
    }
}
