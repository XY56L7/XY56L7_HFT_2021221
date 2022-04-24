using System.Collections.Generic;
using XY56L7_HFT_2021221.Models;

namespace XY56L7_HFT_2021221.Logic.Interfaces
{
    public interface IPhoneLogic
    {
        double AVGRating();
        void Create(Phone PhoneAZ);
        void Delete(int id);
        Phone Read(int id);
        IEnumerable<Phone> ReadAll();
        void Update(Phone phone);
    }
}