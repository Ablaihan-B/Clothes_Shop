using System;
using System.Collections.Generic;
using System.Text;
using Clothes_Shop.Models;
using Clothes_Shop.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Xunit;

namespace UnitTest
{
    [TestClass]
    public class CommentsControllerTest
    {

        [TestMethod]
        [Fact]
        public void testCommentsConstructor()
        {
           
            Category cat = new Category("1e", "Shirts");
            Features ff = new Features("1b", "Good", "XL", "White", "Denim", "USA");
            Gender gg = new Gender("1c", "Male");
            Item i = new Item("1x", "Levis", cat, ff, gg, 77.2, "Image");
            IdentityUser us = new IdentityUser();
            Cart c = new Cart("1p", i, us);

            Comments com = new Comments("2f", "I like it", i,us);

            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual("2f", com.Id);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual("I like it", com.Content);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(i, com.Item);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(us, com.Author);
        }



        [TestMethod]
        [Fact]
        public async System.Threading.Tasks.Task testCategoriesAddAsync()
        {

            var fakeRepository = Mock.Of<ICommentsRepository>();
            var commentsService = new CommentsService(fakeRepository);

            var commments = new Comments() { Id = "test" };
            await commentsService.AddAndSave(commments);
        }

        [TestMethod]
        [Fact]
        public async System.Threading.Tasks.Task testCategoriesGetAsync()
        {
            var comments = new List<Comments>
            {
                new Comments() { Id = "test1" },
                new Comments() { Id = "test2" },
            };

            var fakeRepositoryMock = new Mock<ICommentsRepository>();
            fakeRepositoryMock.Setup(x => x.GetAll()).ReturnsAsync(comments);


            var commentsService = new CommentsService(fakeRepositoryMock.Object);

            var resltComments = await commentsService.GetComments();

            Xunit.Assert.Collection(resltComments, comments =>
            {
                Xunit.Assert.Equal("test1", comments.Id);
            },
            comments =>
            {
                Xunit.Assert.Equal("test2", comments.Id);
            });
        }


    }
}
