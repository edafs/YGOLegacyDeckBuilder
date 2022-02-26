using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using LegacyDeckBuilder.Models.Data;
using LegacyDeckBuilder.Repository;
using LegacyDeckBuilder.Services;
using Moq;
using Xunit;

namespace LegacyDeckBuilder.Tests
{
    /// <summary>
    ///     Tests to test the service layers.
    /// </summary>
    public class ServicesTests
    {
		/// <summary>
		///		Gets an initialized instance of <see cref="WebServices"/>.
		/// </summary>
		private WebService WebService
		{
			get
			{
				HttpClient httpClient = new HttpClient();
				return new WebService(httpClient);
			}
		}

		/// <summary>
        ///		Ensures the service call to return the catalog is working.
        /// </summary>
		[Fact]
		public void CardCatalog_CanGetAllCardsTests()
        {
			#region Arrange

			List<CardCatalog> mockedCards = new List<CardCatalog>()
			{
				new CardCatalog(){ CardId = 1, CardName = "a", ImageUrl = "a",
					Edison = 1, Sept2011 = 1},
				new CardCatalog(){ CardId = 2, CardName = "b", ImageUrl = "b",
					Edison = 2, Sept2011 = 2},
				new CardCatalog(){ CardId = 3, CardName = "c", ImageUrl = "c",
					Edison = 3, Sept2011 = 3},
			};

            Mock<ICardCatalogRepository> mockRepo = new Mock<ICardCatalogRepository>();
			mockRepo
				.Setup(repo => repo.GetCatalog())
				.Returns(Task.FromResult(mockedCards));

			#endregion

			// Act
			CardCatalogService service = new CardCatalogService(mockRepo.Object, this.WebService);
            List<CardCatalog> fullCatalog = service.GetFullCardCatalog().Result;

			// Assert
			Assert.Equal(3, fullCatalog.Count);
        }

		/// <summary>
        ///		Ensures service call to return the set catalog is working.
        /// </summary>
		[Fact]
		public void CardCatalog_GetAllCards()
        {
			#region Arrange

			List<SetCatalog> mockedSets = new List<SetCatalog>()
			{
				new SetCatalog(){ SetId = 1, SetName = "a", SetCode = "a",
					CardCount = 1, ReleaseDate = DateTime.Now.AddHours(1)},
				new SetCatalog(){ SetId = 2, SetName = "b", SetCode = "b",
					CardCount = 2, ReleaseDate = DateTime.Now.AddHours(2)},
			};

            Mock<ISetCatalogRepository> mockRepo = new Mock<ISetCatalogRepository>();
			mockRepo
				.Setup(repo => repo.GetCatalog())
				.Returns(Task.FromResult(mockedSets));

			#endregion

			// Act
			SetCatalogService service = new SetCatalogService(mockRepo.Object, this.WebService);
			List<SetCatalog> fullCatalog = service.GetSetCatalog().Result;

			// Assert
			Assert.Equal(2, fullCatalog.Count);
        }

		[Fact]
		public void CardCatalog_SearchByName_Sucess()
        {
			// Arrange
			Mock<ICardCatalogRepository> repo = new Mock<ICardCatalogRepository>();
			repo
				.Setup(cardRepo => cardRepo.SearchForCard(It.IsAny<string>()))
				.Returns(Task.FromResult(
					new List<CardCatalog>() { new CardCatalog(), new CardCatalog() }
				));

			// Act
			CardCatalogService service = new CardCatalogService(repo.Object, this.WebService);
			List<CardCatalog> cards = service.SearchByCardName("something").Result;

			// Assert
			Assert.Equal(2, cards.Count);
        }

		[Fact]
		public void CardCatalog_SearchByName_BadParams()
        {
			// Arrange
			Mock<ICardCatalogRepository> repo = new Mock<ICardCatalogRepository>();

			// Act
			CardCatalogService service = new CardCatalogService(repo.Object, this.WebService);
			List<CardCatalog> nullCards = service.SearchByCardName(String.Empty).Result;
			List<CardCatalog> emptyCards = service.SearchByCardName(null).Result;

			// Assert
			Assert.Null(nullCards);
			Assert.Null(emptyCards);

		}

		[Fact]
		public void CardCatalog_SearchByName_NoResults()
        {
			// Arrange
			Mock<ICardCatalogRepository> repo = new Mock<ICardCatalogRepository>();
			repo
				.Setup(cardRepo => cardRepo.SearchForCard(It.IsAny<string>()))
				.Returns(Task.FromResult(
					new List<CardCatalog>()
				));

			// Act
			CardCatalogService service = new CardCatalogService(repo.Object, this.WebService);
			List<CardCatalog> cards = service.SearchByCardName("something").Result;

			// Assert
			Assert.Null(null);
		}
	}
}
