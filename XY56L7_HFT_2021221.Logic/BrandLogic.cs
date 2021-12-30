using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XY56L7_HFT_2021221.Models;
using XY56L7_HFT_2021221.Repository;

namespace XY56L7_HFT_2021221.Logic
{
    public class BrandLogic : IBrandLogic
    {
        IBrandRepository brandRepo;
        public BrandLogic(IBrandRepository brandRepo)
        {
            this.brandRepo = brandRepo;
        }
        public void Create(Brand PhoneAZ)
        {
            if (PhoneAZ.Rating < 1)
            {
                throw new ArgumentException("Minus number is not allowed");
            }
            else if (PhoneAZ.Category == "")
            {
                throw new ArgumentException("Category can not be empty");
            }
            else if (PhoneAZ.trust_level < 1)
            {
                throw new ArgumentException("Minus number is not allowed");
            }
            else if (PhoneAZ.trust_level > 10)
            {
                throw new ArgumentException("The number can not be bigger than ten");
            }
            else if (PhoneAZ.Rating > 10)
            {
                throw new ArgumentException("The number can not be bigger than ten");
            }
            brandRepo.Create(PhoneAZ);
        }
        public Brand Read(int id)
        {
            return brandRepo.Read(id);
        }
        public IEnumerable<Brand> ReadAll()
        {
            return brandRepo.ReadAll();
        }
        public void Delete(int id)
        {
            brandRepo.Delete(id);
        }
       
       
        public void Update(Brand Brand)
        {
            brandRepo.Update(Brand);




        }
        //non-crud metódus
        public double AVGRatingBrand()
        {
            return brandRepo.ReadAll().Average(t => t.Rating);
        }
        public int WorstRating()
        {
            return brandRepo.ReadAll().Min(t => t.Rating);
        }
        public int BestRating()
        {
            return brandRepo.ReadAll().Max(t => t.Rating);
        }
        public int Count()
        {
            return brandRepo.ReadAll().Count();
        }
        public int Sum_Rating()
        {
            return brandRepo.ReadAll().Sum(t => t.Rating);
        }
        public int Worsttrustinglevel()
        {
            return brandRepo.ReadAll().Min(t => t.trust_level);
        }
        public int Besttrustinglevel()
        {
            return brandRepo.ReadAll().Max(t => t.trust_level);
        }

    }
}
