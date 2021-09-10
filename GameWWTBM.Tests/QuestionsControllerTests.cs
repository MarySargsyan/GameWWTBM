using System;
using System.Collections.Generic;
using System.Text;
using
using Xunit;
using System.Web.Mvc;

namespace GameWWTBM.Tests
{
    class QuestionsControllerTests
    {
        [Fact]
        public void IndexViewDataMessage()
        {
            // Arrange
            QuestionsController controller = new QuestionsController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.Equal("Hello world!", result?.ViewData["Message"]);
        }
    }
}
