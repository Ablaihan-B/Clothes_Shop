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
    public class ItemsControllerTest
    {

        [TestMethod]
        [Fact]
        public void testItemsConstructor()
        {
            Category cat = new Category("1e", "Shirts");
            Features ff = new Features("1b", "Good", "XL", "White", "Denim", "USA");
            Gender gg = new Gender("1c", "Male");
            Item i = new Item("1x", "Levis", cat, ff, gg, 77.2, "Image");
            IdentityUser us = new IdentityUser();
            Cart c = new Cart("1p", i, us);

            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual("1x", i.Id);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual("Levis", i.Name);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(cat, i.Category);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(ff, i.Features);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(gg, i.Gender);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(77.2, i.Price);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual("Image", i.Image);
        }


        [TestMethod]
        [Fact]
        public async System.Threading.Tasks.Task testItemsAddAsync()
        {

            var fakeRepository = Mock.Of<IItemsRepository>();
            var itemsService = new ItemsService(fakeRepository);

            var items = new Item() { Id = "test" };
            await itemsService.AddAndSave(items);
        }

        [TestMethod]
        [Fact]
        public async System.Threading.Tasks.Task testItemsGetAsync()
        {
            var items = new List<Item>
            {
                new Item() { Id = "test1" },
                new Item() { Id = "test2" },
            };

            var fakeRepositoryMock = new Mock<IItemsRepository>();
            fakeRepositoryMock.Setup(x => x.GetAll()).ReturnsAsync(items);


            var itemsService = new ItemsService(fakeRepositoryMock.Object);

            var resultItems = await itemsService.GetItems();

            Xunit.Assert.Collection(resultItems, items =>
            {
                Xunit.Assert.Equal("test1", items.Id);
            },
            items =>
            {
                Xunit.Assert.Equal("test2", items.Id);
            });
        }

    }
}
