using System;
using System.Linq;
using XY56L7_HFT_2021221.Data;
using XY56L7_HFT_2021221.Models;

namespace XY56L7_HFT_2021221.Repository
{
    public class BrandRepository : IBrandRepository
    {
        PhoneDbContext db;
        public BrandRepository(PhoneDbContext db)
        {
            this.db = db;
        }
        public void Create(Brand brand)
        {
            db.Brands.Add(brand);
            db.SaveChanges();
        }
        public Brand Read(int id)
        {
            return db.Brands
                .FirstOrDefault(t => t.BrandId == id);

        }
        public IQueryable<Brand> ReadAll()
        {
            return db.Brands;
        }
        public void Delete(int id)
        {
            db.Remove(Read(id));
            db.SaveChanges();
        }
        //meg be kell fejeznem
        public void Update(Brand brand)
        {
            var oldBrand = Read(brand.BrandId);
            oldBrand.Category = brand.Category;
            oldBrand.Rating = brand.Rating;

            db.SaveChanges();

        }
    }
}
