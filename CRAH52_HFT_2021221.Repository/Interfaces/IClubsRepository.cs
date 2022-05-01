using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRAH52_HFT_2021221.Models;

namespace CRAH52_HFT_2021221.Repository
{
    public interface IClubsRepository
    {
        void Create(Clubs club);
        Clubs ReadOne(int id);
        IQueryable<Clubs> ReadAll();
        void Update(Clubs club);
        void Delete(int id);

    }
}
