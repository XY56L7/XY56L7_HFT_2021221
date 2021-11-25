using System;
using System.Collections.Generic;
using System.Linq;
using XY56L7_HFT_2021221.Models;
using XY56L7_HFT_2021221.Repository;

namespace XY56L7_HFT_2021221.Logic
{
    public class PhoneLogic : IPhoneLogic
    {
        IPhoneRepository carRepo;
        public PhoneLogic(IPhoneRepository carRepo)
        {
            this.carRepo = carRepo;
        }
        public void Create(Phone PhoneAZ)
        {
            carRepo.Create(PhoneAZ);
            
        }
        public Phone Read(int id)
        {
            return carRepo.Read(id);
        }
        public IEnumerable<Phone> ReadAll()
        {
            return carRepo.ReadAll();
        }
        public void Delete(int id)
        {
            carRepo.Delete(id);
        }
        //meg be kell fejeznem
        public void Update(Phone phone)
        {
            carRepo.Update(phone);




        }
        //non-CRUD methods

    }
}
