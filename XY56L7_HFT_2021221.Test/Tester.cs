using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using XY56L7_HFT_2021221.Logic;
using XY56L7_HFT_2021221.Models;
using XY56L7_HFT_2021221.Repository;

namespace XY56L7_HFT_2021221.Test
{
    [TestFixture]
    public class Tester
    {
        class FakeBrandRepository : IBrandRepository
        {
            public void Create(Brand brand)
            {
                throw new NotImplementedException();
            }

            public void Delete(int id)
            {
                throw new NotImplementedException();
            }

            public Brand Read(int id)
            {
                throw new NotImplementedException();
            }

            public IQueryable<Brand> ReadAll()
            {
               return new List<Brand>() 
                {
                    new Brand()
                    {
                        Category = "Billentyűs",
                        Rating = 3,
                        trust_level = 7
                    },new Brand()
                    {
                        Category = "Billentyűs",
                        Rating = 9,
                        trust_level = 7
                    }
                }.AsQueryable();
            }

            public void Update(Brand brand)
            {
                throw new NotImplementedException();
            }
        }
        BrandLogic cl;
        public Tester()
        {
            var brands = new List<Brand>()
                {
                    new Brand()
                    {
                        Category = "Billentyűs",
                        Rating = 3,
                        trust_level = 7
                    },new Brand()
                    {
                        Category = "Billentyűs",
                        Rating = 9,
                        trust_level = 7
                    }
                }.AsQueryable();
            
            var mockBrandRepo =
                new Mock<IBrandRepository>();
            mockBrandRepo.Setup((t) => t.ReadAll()).Returns(brands);
            cl = new BrandLogic(
                mockBrandRepo.Object);
        }
        [Test]
        public void BestPriceTest() 
        {
            //ACT
            var result = cl.AVGRating();
            //ASSERT
            Assert.That(result, Is.EqualTo(6));
        }
        [Test]
        public void WorstPriceTest()
        {
            //ACT
            var result = cl.WorstRating();
            //ASSERT
            Assert.That(result, Is.EqualTo(3));
        }
        [Test]
        public void AVGPriceTest()
        {
            //ACT
            var result = cl.BestRating();
            //ASSERT
            Assert.That(result, Is.EqualTo(9));
        }
    }
}
