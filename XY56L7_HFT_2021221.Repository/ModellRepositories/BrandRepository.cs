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
    public class BrandRepository : Repository<Brand>, IRepository<Brand>
    {
        public BrandRepository(PhoneDbContext ctx):base(ctx)
        {

        }
        public override Brand Read(int id)
        {
            return ctx.Brands.FirstOrDefault(t => t.BrandId == id);
        }

        public override void Update(Brand item)
        {

            //var old = Read(item.BrandId);

            //if (old == null)
            //{
            //    throw new ArgumentException("Item not exist..");
            //}
            //old.BrandName = item.BrandName;
            //old.trust_level = item.trust_level;
            //old.Category = item.Category;
            //old.Rating = item.Rating;
            //ctx.SaveChanges();
            var old = Read(item.BrandId);
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
