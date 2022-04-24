using System.Collections.Generic;
using XY56L7_HFT_2021221.Models;

namespace XY56L7_HFT_2021221.Logic.Interfaces
{
    public interface IBrandLogic
    {
        double AVGRatingBrand();
        int BestRating();
        int Besttrustinglevel();
        int Count();
        void Create(Brand PhoneAZ);
        void Delete(int id);
        Brand Read(int id);
        IEnumerable<Brand> ReadAll();
        int Sum_Rating();
        void Update(Brand Brand);
        int WorstRating();
        int Worsttrustinglevel();
    }
}