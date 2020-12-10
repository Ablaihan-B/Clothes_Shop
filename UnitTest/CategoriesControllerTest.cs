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
    public class CategoriesControllerTest
    {

        [TestMethod]
        [Fact]
        public void testCategoriesConstructor()
        {
            Category cat = new Category("1e", "Shirts");
   
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual("1e", cat.Id);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual("Shirts", cat.Name);

        }



        [TestMethod]
        [Fact]
        public async System.Threading.Tasks.Task testCategoriesAddAsync()
        {

            var fakeRepository = Mock.Of<ICategoriesRepository>();
            var categoriesService = new CategoriesService(fakeRepository);

            var category = new Category() { Id = "test" };
            await categoriesService.AddAndSave(category);
        }

        [TestMethod]
        [Fact]
        public async System.Threading.Tasks.Task testCategoriesGetAsync()
        {
            var categories = new List<Category>
            {
                new Category() { Id = "test1" },
                new Category() { Id = "test2" },
            };

            var fakeRepositoryMock = new Mock<ICategoriesRepository>();
            fakeRepositoryMock.Setup(x => x.GetAll()).ReturnsAsync(categories);


            var categoriesService = new CategoriesService(fakeRepositoryMock.Object);

            var resultCategories = await categoriesService.GetCategories();

            Xunit.Assert.Collection(resultCategories, categories =>
            {
                Xunit.Assert.Equal("test1", categories.Id);
            },
            categories =>
            {
                Xunit.Assert.Equal("test2", categories.Id);
            });
        }


    }
}
