using System.Collections.Generic;
using XY56L7_HFT_2021221.Models;

namespace XY56L7_HFT_2021221.Logic.Interfaces
{
    public interface IOSYSTEMLogic
    {
        void Create(OSYSTEM PhoneAZ);
        void Delete(int id);
        OSYSTEM Read(int id);
        IEnumerable<OSYSTEM> ReadAll();
        void Update(OSYSTEM oSYSTEM);
    }
}