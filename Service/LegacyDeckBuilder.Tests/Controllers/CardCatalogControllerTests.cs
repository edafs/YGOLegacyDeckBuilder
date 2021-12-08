using System;
using System.Net;
using System.Threading.Tasks;
using LegacyDeckBuilder.Controllers;
using LegacyDeckBuilder.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace LegacyDeckBuilder.Tests.Controllers
{
    /// <summary>
    ///     Tests for the <see cref="CardCatalogController"/>
    /// </summary>
    public class CardCatalogControllerTests
    {
        [Fact]
        public void Refresh_Failure()
        {
            // Arrange
            Mock<ICardCatalogService> cardService = new Mock<ICardCatalogService>();
            cardService
                .Setup(service => service.RefreshCardCatalog())
                .Returns(Task.FromResult(false));

            // Act
            CardCatalogController controller = new CardCatalogController(cardService.Object);
            IActionResult result = controller.RefreshCatalog().Result;

            // Assert
            ObjectResult resultObject = result as ObjectResult;
            Assert.Equal((int)HttpStatusCode.InternalServerError, resultObject.StatusCode);
            Assert.Equal("Failed to refresh the card catalog. Try again later.", resultObject.Value);
        }

        [Fact]
        public void Refresh_Success()
        {
            // Arrange
            Mock<ICardCatalogService> cardService = new Mock<ICardCatalogService>();
            cardService
                .Setup(service => service.RefreshCardCatalog())
                .Returns(Task.FromResult(true));

            // Act
            CardCatalogController controller = new CardCatalogController(cardService.Object);
            IActionResult result = controller.RefreshCatalog().Result;

            // Assert
            OkObjectResult resultObject = result as OkObjectResult;
            Assert.Equal((int)HttpStatusCode.OK, resultObject.StatusCode);
            Assert.Equal("Card catalog has been refreshed.", resultObject.Value);
        }
    }
}
