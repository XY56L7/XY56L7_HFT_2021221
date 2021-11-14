using System.Linq;
using XY56L7_HFT_2021221.Models;

namespace XY56L7_HFT_2021221.Repository
{
   public  interface IPhoneRepository
    {
        void Create(Phone Phone);
        void Delete(int id);
        Phone Read(int id);
        IQueryable<Phone> ReadAll();
        void Update(Phone phone);
    }
}