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
    public class OsystemRepository : Repository<OSYSTEM>, IRepository<OSYSTEM>
    {
        public OsystemRepository(PhoneDbContext ctx) : base(ctx)
        {
        }
        public override OSYSTEM Read(int id)
        {
            return ctx.OSES.FirstOrDefault(t => t.OSId == id);
        }

        public override void Update(OSYSTEM item)
        {
            //var old = Read(item.OSId);
            //foreach (var prop in old.GetType().GetProperties())
            //{
            //    prop.SetValue(old, prop.GetValue(item));
            //}
            //ctx.SaveChanges();


            var old = Read(item.OSId);
            if (old == null)
            {
                throw new ArgumentException("Item not exist..");
            }
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
