using System;
using System.Collections.Generic;
using System.Text;
using Clothes_Online_Shop.Models;
using Clothes_Shop.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Xunit;

namespace UnitTest
{
    [TestClass]
    public class FeaturesControllerTest
    {

        [TestMethod]
        [Fact]
        public void testFeaturesConstructor()
        {
            Category cat = new Category("1e", "Shirts");
            Features ff = new Features("1b", "Good", "XL", "White", "Denim", "USA");
            Gender gg = new Gender("1c", "Male");
            Item i = new Item("1x", "Levis", cat, ff, gg, 77.2, "Image");
            IdentityUser us = new IdentityUser();
            Cart c = new Cart("1p", i, us);

            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual("1b", ff.Id);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual("Good", ff.Description);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual("XL", ff.Size);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual("White", ff.Color);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual("Denim", ff.Material);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual("USA", ff.Country);
            
        }


        [TestMethod]
        [Fact]
        public async System.Threading.Tasks.Task testFeaturesAddAsync()
        {

            var fakeRepository = Mock.Of<IFeaturesRepository>();
            var featuresService = new FeaturesService(fakeRepository);

            var features = new Features() { Id = "test" };
            await featuresService.AddAndSave(features);
        }

        [TestMethod]
        [Fact]
        public async System.Threading.Tasks.Task testFeaturesGetAsync()
        {
            var features = new List<Features>
            {
                new Features() { Id = "test1" },
                new Features() { Id = "test2" },
            };

            var fakeRepositoryMock = new Mock<IFeaturesRepository>();
            fakeRepositoryMock.Setup(x => x.GetAll()).ReturnsAsync(features);


            var featuresService = new FeaturesService(fakeRepositoryMock.Object);

            var resultFeatures = await featuresService.GetFeatures();

            Xunit.Assert.Collection(resultFeatures, features =>
            {
                Xunit.Assert.Equal("test1", features.Id);
            },
            features =>
            {
                Xunit.Assert.Equal("test2", features.Id);
            });
        }


    }
}
