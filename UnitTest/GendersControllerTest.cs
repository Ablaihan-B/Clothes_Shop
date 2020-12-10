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
    public class GendersControllerTest
    {

        [TestMethod]
        [Fact]
        public void testGendersConstructor()
        {
            Category cat = new Category("1e", "Shirts");
            Features ff = new Features("1b", "Good", "XL", "White", "Denim", "USA");
            Gender gg = new Gender("1c", "Male");
            Item i = new Item("1x", "Levis", cat, ff, gg, 77.2, "Image");
            IdentityUser us = new IdentityUser();
            Cart c = new Cart("1p", i, us);

            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual("1c", gg.Id);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual("Male",gg.Name);
            
        }



        [TestMethod]
        [Fact]
        public async System.Threading.Tasks.Task testGendersAddAsync()
        {

            var fakeRepository = Mock.Of<IGendersRepository>();
            var gendersService = new GendersService(fakeRepository);

            var genders = new Gender() { Id = "test" };
            await gendersService.AddAndSave(genders);
        }

        [TestMethod]
        [Fact]
        public async System.Threading.Tasks.Task testGendersGetAsync()
        {
            var genders = new List<Gender>
            {
                new Gender() { Id = "test1" },
                new Gender() { Id = "test2" },
            };

            var fakeRepositoryMock = new Mock<IGendersRepository>();
            fakeRepositoryMock.Setup(x => x.GetAll()).ReturnsAsync(genders);


            var gendersService = new GendersService(fakeRepositoryMock.Object);

            var resultGenders = await gendersService.GetGenders();

            Xunit.Assert.Collection(resultGenders, genders =>
            {
                Xunit.Assert.Equal("test1", genders.Id);
            },
            genders =>
            {
                Xunit.Assert.Equal("test2", genders.Id);
            });
        }

    }
}
