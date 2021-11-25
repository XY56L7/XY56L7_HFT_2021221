using System.Collections.Generic;
using XY56L7_HFT_2021221.Models;

namespace XY56L7_HFT_2021221.Logic
{
    public interface IBrandLogic
    {
        void Create(Brand PhoneAZ);
        void Delete(int id);
        Brand Read(int id);
        IEnumerable<Brand> ReadAll();
        void Update(Brand Brand);
    }
}