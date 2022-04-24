using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using XY56L7_HFT_2021221.Models;
using XY56L7_HFT_2021221.Repository.DataBase;
using XY56L7_HFT_2021221.Repository.GenericRepository;

namespace XY56L7_HFT_2021221.Repository.ModellRepositories
{
    public class PhoneRepository : Repository<Phone>, IRepository<Phone>
    {
        public PhoneRepository(PhoneDbContext ctx) : base(ctx)
        {

        }
        public override Phone Read(int id)
        {
            return ctx.Phones.FirstOrDefault(t => t.PhoneId == id);
        }

        public override void Update(Phone item)
        {
            var old = Read(item.PhoneId);
            foreach (var prop in old.GetType().GetProperties())
            {
                if (prop.GetAccessors().FirstOrDefault(t => t.IsVirtual) == null)
                {
                    prop.SetValue(old, prop.GetValue(item));
                }
            }
            ctx.SaveChanges();
        }
    }
}
