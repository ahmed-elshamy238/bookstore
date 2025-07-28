using Xunit;
using Moq;
using System.Threading.Tasks;
using System.Collections.Generic;
using BLL.Services;
using BLL.DTOs;
using DAL;
using System.Linq;

namespace UnitTests.BLL
{
    public class FavoriteServiceTests
    {
        [Fact]
        public async Task GetFavoritesByUserIdAsync_ReturnsFavoriteDtos_WhenFavoritesExist()
        {
            // Arrange
            var favorites = new List<Favorite> { new Favorite { Id = 1, UserId = 1, BookId = 1 } };
            var books = new List<Book> { new Book { Id = 1, Title = "Book1" } };
            var mockUnitOfWork = new Mock<IUnitOfWork>();
            mockUnitOfWork.Setup(u => u.Favorites.FindAsync(It.IsAny<System.Linq.Expressions.Expression<System.Func<Favorite, bool>>>())).ReturnsAsync(favorites);
            mockUnitOfWork.Setup(u => u.Books.GetAllAsync()).ReturnsAsync(books);
            var service = new FavoriteService(mockUnitOfWork.Object);

            // Act
            var result = await service.GetFavoritesByUserIdAsync(1);

            // Assert
            Assert.Single(result);
            Assert.Equal("Book1", result.First().BookTitle);
        }
    }
}
