using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XY56L7_HFT_2021221.Data;
using XY56L7_HFT_2021221.Models;

namespace XY56L7_HFT_2021221.Repository
{
    public class OSYSTEMRepository : IOSYSTEMRepository
    {
        PhoneDbContext db;
        public OSYSTEMRepository(PhoneDbContext db)
        {
            this.db = db;
        }
        public void Create(OSYSTEM Osystem)
        {
            db.OSES.Add(Osystem);
            db.SaveChanges();
        }
        public OSYSTEM Read(int id)
        {
            return db.OSES
                .FirstOrDefault(t => t.OSId == id);

        }
        public IQueryable<OSYSTEM> ReadAll()
        {
            return db.OSES;
        }
        public void Delete(int id)
        {
            db.Remove(Read(id));
            db.SaveChanges();
        }
        //meg be kell fejeznem
        public void Update(OSYSTEM oSYSTEM)
        {
            var oldOS = Read(oSYSTEM.OSId);
            oldOS.OS = oSYSTEM.OS;
            oldOS.security_level = oSYSTEM.security_level;
            db.SaveChanges();

        }
    }
}
