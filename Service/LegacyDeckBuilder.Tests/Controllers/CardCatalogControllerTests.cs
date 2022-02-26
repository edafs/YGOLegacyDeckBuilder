using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using LegacyDeckBuilder.Controllers;
using LegacyDeckBuilder.Models.Data;
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

        [Fact]
        public void FindCard_BadParams()
        {
            // Arrange
            Mock<ICardCatalogService> service = new Mock<ICardCatalogService>();

            // Act
            CardCatalogController controller = new CardCatalogController(service.Object);
            IActionResult nullResult = controller.FindCard(null).Result;
            IActionResult emptyResult = controller.FindCard(string.Empty).Result;

            // Assert
            ObjectResult nullObj = nullResult as ObjectResult;
            Assert.Equal((int)HttpStatusCode.BadRequest, nullObj.StatusCode);
            Assert.Equal("Enter a valid search.", nullObj.Value);

            ObjectResult emptyObj = emptyResult as ObjectResult;
            Assert.Equal((int)HttpStatusCode.BadRequest, emptyObj.StatusCode);
            Assert.Equal("Enter a valid search.", emptyObj.Value);
        }

        [Fact]
        public void FindCard_NoCardFound()
        {
            // Arrange
            Mock<ICardCatalogService> service = new Mock<ICardCatalogService>();
            service
                .Setup(srv => srv.SearchByCardName(It.IsAny<string>()))
                .Returns(Task.FromResult(new List<CardCatalog>()));

            // Act
            CardCatalogController controller = new CardCatalogController(service.Object);
            IActionResult result = controller.FindCard("Something").Result;

            // Assert
            ObjectResult obj = result as ObjectResult;
            Assert.Equal((int)HttpStatusCode.NotFound, obj.StatusCode);
            Assert.Equal("No cards could be found.", obj.Value);
        }

        [Fact]
        public void FindCard_CardFound()
        {
            // Arrange
            Mock<ICardCatalogService> service = new Mock<ICardCatalogService>();
            service
                .Setup(srv => srv.SearchByCardName(It.IsAny<string>()))
                .Returns(Task.FromResult(
                    new List<CardCatalog>() {
                        new CardCatalog
                        {
                            CardId = 1337,
                            CardName = "Sample",
                            ImageUrl = "http://duckduckgo.com/",
                            Edison = 0,
                            Sept2011 = 1
                        }
                    }
                  ));

            // Act
            CardCatalogController controller = new CardCatalogController(service.Object);
            IActionResult result = controller.FindCard("Something").Result;

            // Assert
            ObjectResult obj = result as ObjectResult;
            List<CardCatalog> cards = obj.Value as List<CardCatalog>;
            CardCatalog card = cards.FirstOrDefault();

            Assert.Equal((int)HttpStatusCode.OK, obj.StatusCode);
            Assert.Equal(1337, card.CardId);
            Assert.Equal("Sample", card.CardName);
            Assert.Equal("http://duckduckgo.com/", card.ImageUrl);
            Assert.Equal(0, card.Edison);
            Assert.Equal(1, card.Sept2011);
        }
    }
}
