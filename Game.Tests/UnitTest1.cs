using GameWWTBM.Controllers;
using GameWWTBM.Models;
using Microsoft.EntityFrameworkCore;
using System;
using Xunit;
using Moq;
using System.Web.Mvc;

namespace Game.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            var context = new Mock<ApplicationDbcontext>().Object;
            QuestionsController controller = new QuestionsController(context);
            var result = controller.Index(0);

            // // Arrange
            // string connection = Configuration.GetConnectionString("DefaultConnection");

            // DbContextOptionsBuilder options = new DbContextOptionsBuilder();
            //ApplicationDbcontext dbcontext = new ApplicationDbcontext(options.UseSqlServer(connection));
            // QuestionsController controller = new QuestionsController();
            // // Act
            // ViewResult result = controller.Index() as ViewResult;

            // // Assert
            // Assert.Equal("Hello world!", result?.ViewData["Message"]);
        }
    }
}
