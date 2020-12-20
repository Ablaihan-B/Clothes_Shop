using Clothes_Shop.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Xunit;
using Moq;
using Clothes_Shop.Services;
using System.Collections.Generic;

namespace UnitTest
{
    [TestClass]
    public class CartControllerTest
    {
        [TestMethod]
        [Fact]
        public void testCartConstructor() {
            Category cat = new Category("1e","Shirts");
            Features ff = new Features("1b", "Good", "XL", "White", "Denim", "USA");
            Gender gg = new Gender("1c","Male");
            Item i = new Item("1x", "Levis", cat, ff, gg, 77.2, "Image");
            IdentityUser us = new IdentityUser(); 
            Cart c = new Cart("1p", i, us);

            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(i, c.Item);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual("1p", c.Id);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(us, c.User);
        }

        [TestMethod]
        [Fact]
        public async System.Threading.Tasks.Task testCartAddAsync()
        {

            var fakeRepository = Mock.Of<ICartsRepository>();
            var cartService = new CartsService(fakeRepository);

            var cart = new Cart() { Id = "test" };
            await cartService.AddAndSave(cart);
        }

        [TestMethod]
        [Fact]
        public async System.Threading.Tasks.Task testCartGetAsync()
        {
            var carts = new List<Cart>
            {
                new Cart() { Id = "test1" },
                new Cart() { Id = "test2" },
            };

            var fakeRepositoryMock = new Mock<ICartsRepository>();
            fakeRepositoryMock.Setup(x => x.GetAll()).ReturnsAsync(carts);


            var cartService = new CartsService(fakeRepositoryMock.Object);

            var resultCarts = await cartService.GetCarts();

            Xunit.Assert.Collection(resultCarts, cart =>
            {
                Xunit.Assert.Equal("test1", cart.Id);
            },
            cart =>
            {
                Xunit.Assert.Equal("test2", cart.Id);
            });
        }

    }
}
