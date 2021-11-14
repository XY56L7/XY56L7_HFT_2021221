using System.Linq;
using XY56L7_HFT_2021221.Models;

namespace XY56L7_HFT_2021221.Repository
{
    interface IOSYSTEMRepository
    {
        void Create(OSYSTEM Osystem);
        void Delete(int id);
        OSYSTEM Read(int id);
        IQueryable<OSYSTEM> ReadAll();
        void Update(OSYSTEM oSYSTEM);
    }
}