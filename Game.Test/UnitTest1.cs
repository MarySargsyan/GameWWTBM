using Microsoft.VisualStudio.TestTools.UnitTesting;
using GameWWTBM.Controllers;
using Xunit;

namespace Game.Test
{
    [TestClass]
    public class UnitTest1
    {
        [Fact]
        public void IndexViewDataMessage()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.Equal("Hello world!", result?.ViewData["Message"]);
        }
    }
}
