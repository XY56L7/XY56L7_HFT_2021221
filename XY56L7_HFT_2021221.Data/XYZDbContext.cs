using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using XY56L7_HFT_2021221.Models;

namespace XY56L7_HFT_2021221.Data
{
    public class XYZDbContext : DbContext
    {
        public XYZDbContext()
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
    }
}
