using CRAH52_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRAH52_HFT_2021221.Repository
{
    public interface IGuestsRepository
    {
        void Create(Guests guest);
        Guests ReadOne(int id);
        IQueryable<Guests> ReadAll();
        void Update(Guests guest);
        void Delete(int id);
    }
}
