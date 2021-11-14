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
        //meg be kell fejeznem
        public void Update(Brand Brand)
        {
            brandRepo.Update(Brand);




        }
    }
}
