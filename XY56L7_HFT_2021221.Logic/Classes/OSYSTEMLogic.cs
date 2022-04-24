using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XY56L7_HFT_2021221.Logic.Interfaces;
using XY56L7_HFT_2021221.Models;
using XY56L7_HFT_2021221.Repository;
using XY56L7_HFT_2021221.Repository.GenericRepository;

namespace XY56L7_HFT_2021221.Logic.Classes
{
    public class OSYSTEMLogic : IOSYSTEMLogic
    {
        IRepository<OSYSTEM> OSdRepo;
        public OSYSTEMLogic(IRepository<OSYSTEM> OSdRepo)
        {
            this.OSdRepo = OSdRepo;
        }
        public void Create(OSYSTEM PhoneAZ)
        {
            OSdRepo.Create(PhoneAZ);
        }
        public OSYSTEM Read(int id)
        {
            return OSdRepo.Read(id);
        }
        public IEnumerable<OSYSTEM> ReadAll()
        {
            return OSdRepo.ReadAll();
        }
        public void Delete(int id)
        {
            OSdRepo.Delete(id);
        }
        //meg be kell fejeznem
        public void Update(OSYSTEM oSYSTEM)
        {
            OSdRepo.Update(oSYSTEM);




        }
    }
}
