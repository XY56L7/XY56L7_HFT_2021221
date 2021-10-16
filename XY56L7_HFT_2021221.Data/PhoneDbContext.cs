using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XY56L7_HFT_2021221.Models;


namespace XY56L7_HFT_2021221.Data
{
    public class PhoneDbContext : DbContext
    {
        public virtual DbSet<Brand> Brands { get; set; }
        public virtual DbSet<Phone> Phones { get; set; }
        public virtual DbSet<OSYSTEM> OSES { get; set; }

        public PhoneDbContext()
        {
            this.Database.EnsureCreated();
        }
        //public virtual DbSet<HR> HRS_ { get; set; }
        //public virtual DbSet<Futár> Futar_ { get; set; }
        //public virtual DbSet<Auditor> Auditor_ { get; set; }
        //public virtual DbSet<Diszpécser> Diszpecser_ { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder 
            optionsBuilder) 
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    .UseLazyLoadingProxies()
                    .UseSqlServer(@"Data Source = (LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database.mdf;Integrated Security = True");
            }
        }
        //Data Source = (LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|
        //\Database.mdf;Integrated Security = True

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //fluent api-Brand-Phones
            modelBuilder.Entity<Phone>(entity =>
           {
               entity.HasOne(phone => phone.Brand)
               .WithMany(Brand => Brand.Phones)
               .HasForeignKey(phone => phone.BrandId)
               .OnDelete(DeleteBehavior.ClientSetNull);
           });
            //fluent api-OS-Phones
            modelBuilder.Entity<Phone>(entity =>
            {
                entity.HasOne(phone => phone.OSYSTEM)
                .WithMany(OSYSTEM => OSYSTEM.Phones_OS)
                .HasForeignKey(phone => phone.OSId)
                .OnDelete(DeleteBehavior.ClientSetNull);
            });
            PhoneDbContext db = new PhoneDbContext();
            #region INIT
            //Phone Brands
            Brand Iphone = new Brand() { BrandId = 22, Category = "Okos telefon", Rating = 8 };
            Brand Samsung = new Brand() { BrandId = 33, Category = "Okos telefon", Rating = 6 };
            Brand Huawei = new Brand() { BrandId = 44, Category = "Okos telefon", Rating = 7 };
            Brand Motorola = new Brand() { BrandId = 55, Category = "Gombos telefon", Rating = 2 };

            //Phone Types
            Phone SE = new Phone() { OSId = 101, BrandId = 22 };
            Phone X = new Phone() { OSId = 101, BrandId = 22 };

            Phone P40 = new Phone() { OSId = 100, BrandId = 44 };
            Phone S21 = new Phone() { OSId = 100, BrandId = 33 };
            Phone W510 = new Phone() { OSId = 102, BrandId = 55 };
            //Phone's Operating System
            OSYSTEM Android = new Models.OSYSTEM() { OSId = 100, OS = "Android" };
            OSYSTEM IOS = new Models.OSYSTEM() { OSId = 101, OS = "IOS" };
            OSYSTEM MOS = new Models.OSYSTEM() { OSId = 102, OS = "MOS" };
            
            #endregion
            #region connections
            //Brands connections
            Iphone.BrandId = SE.BrandId;
            Iphone.BrandId = X.BrandId;
            Samsung.BrandId = S21.BrandId;
            Huawei.BrandId = P40.BrandId;
            Motorola.BrandId = W510.BrandId;
            //OS Connections
            Android.OSId = P40.OSId;
            Android.OSId = S21.OSId;
            IOS.OSId = SE.OSId;
            IOS.OSId = X.OSId;
            MOS.OSId = W510.OSId;
            #endregion
            db.Brands.Add(Iphone);
            db.Brands.Add(Samsung);
            db.Brands.Add(Huawei);
            db.Brands.Add(Motorola);

            db.OSES.Add(Android);
            db.OSES.Add(IOS);
            db.OSES.Add(MOS);

            db.Phones.Add(SE);
            db.Phones.Add(X);
            db.Phones.Add(P40);
            db.Phones.Add(S21);
            db.Phones.Add(W510);

            modelBuilder.Entity<Brand>().HasData(Iphone,Samsung,Huawei,Motorola);
            modelBuilder.Entity<Phone>().HasData(SE,X,P40,S21,W510);
            modelBuilder.Entity<OSYSTEM>().HasData(Android,IOS,MOS);
            
        }
    }
}
