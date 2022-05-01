using CRAH52_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRAH52_HFT_2021221.Repository
{
    public interface IEventsRepository
    {
        void Create(Events events);
        Events ReadOne(int id);
        IQueryable<Events> ReadAll();
        void Update(Events events);
        void Delete(int id);
    }
}
