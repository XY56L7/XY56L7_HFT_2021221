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
        //TEST(1)
        [Test]
        public void BestPriceTest() 
        {
            //ACT
            var result = cl.AVGRating();
            //ASSERT
            Assert.That(result, Is.EqualTo(6));
        }
        //TEST(2)
        [Test]
        public void WorstPriceTest()
        {
            //ACT
            var result = cl.WorstRating();
            //ASSERT
            Assert.That(result, Is.EqualTo(3));
        }
        //TEST(3)
        [Test]
        public void AVGPriceTest()
        {
            //ACT
            var result = cl.BestRating();
            //ASSERT
            Assert.That(result, Is.EqualTo(9));
        }
        //TEST(4)
        [Test]
        public void CreateBrandCategoryTest()
        {
            //ACT+  ASSERT
            Assert.That(() => cl.Create( new Brand() 
            {
               Category = "",
               Rating = 3,
               trust_level = 7

            }),Throws.Exception);
        }
        //TEST(5)
        [Test]
        public void CreateBrandRatingTest()
        {
            //ACT+  ASSERT
            Assert.That(() => cl.Create(new Brand()
            {
                Category = "Ujj lenyomat érzékelős",
                Rating = -2,
                trust_level = 7

            }), Throws.Exception);
        }
        //TEST(6)
        [Test]
        public void CreateBrandTrustLevelTest()
        {
            //ACT+  ASSERT
            Assert.That(() => cl.Create(new Brand()
            {
                Category = "Arc felismerős",
                Rating = 6,
                trust_level = -3

            }), Throws.Exception);
        }
        //TEST(7)
        [Test]
        public void CreateBrandTrustLevelTwoTest()
        {
            //ACT+  ASSERT
            Assert.That(() => cl.Create(new Brand()
            {
                Category = "Kihajthatós",
                Rating = 4,
                trust_level = 11

            }), Throws.Exception);
        }
        //TEST(8)
        [Test]
        public void CreateBrandRatingTwoTest()
        {
            //ACT+  ASSERT
            Assert.That(() => cl.Create(new Brand()
            {
                Category = "Kihajthatós",
                Rating = 40,
                trust_level = 5

            }), Throws.Exception);
        }
        //TEST(9)
        [Test]
        public void CountTest()
        {
            //ACT
            var result = cl.Count();
            //ASSERT
            Assert.That(result, Is.EqualTo(2));
        }
        //TEST(10)
        [Test]
        public void Sum_Rating_Test()
        {
            //ACT
            var result = cl.Sum_Rating();
            //ASSERT
            Assert.That(result, Is.EqualTo(12));
        }
        //TEST(11)
        [Test]
        public void Best_Trusting_level_test()
        {
            //ACT
            var result = cl.Besttrustinglevel();
            //ASSERT
            Assert.That(result, Is.EqualTo(7));
        }
        //TEST(12)
        [Test]
        public void Worst_Trusting_level_test()
        {
            //ACT
            var result = cl.Worsttrustinglevel();
            //ASSERT
            Assert.That(result, Is.EqualTo(7));
        }
    }
}
