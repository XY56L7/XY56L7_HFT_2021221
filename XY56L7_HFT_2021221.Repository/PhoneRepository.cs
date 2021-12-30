using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XY56L7_HFT_2021221.Data;
using XY56L7_HFT_2021221.Models;


namespace XY56L7_HFT_2021221.Repository
{
    public class PhoneRepository : IPhoneRepository
    {
        PhoneDbContext db;
        public PhoneRepository(PhoneDbContext db)
        {
            this.db = db;
        }
        public void Create(Phone PhoneAZ)
        {
            db.Phones.Add(PhoneAZ);
            
            db.SaveChanges();
        }
        public Phone Read(int id)
        {
            return db.Phones.FirstOrDefault(t => t.PhoneId == id);

        }
        public IQueryable<Phone> ReadAll()
        {
            return db.Phones;
        }
        public void Delete(int id)
        {
            db.Remove(Read(id));
            db.SaveChanges();
        }
       
        public void Update(Phone phone)
        {
            var oldphone = Read(phone.PhoneId);
            oldphone.OSId = phone.OSId;
            oldphone.BrandId = phone.BrandId;
            oldphone.OSId = phone.OSId;
            oldphone.break_level = phone.break_level;

            db.SaveChanges();

        }
    }
}
