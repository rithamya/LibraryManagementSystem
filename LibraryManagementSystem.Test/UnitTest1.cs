using LibraryManagementSystem.Repository;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace LibraryManagementSystem.Test
{
    public class AuthorTests
    {
        [Fact]
        public void Author_Properties_Should_Set_Correctly()
        {
            var author = new Author
            {
                Id = 1,
                Name = "J.K. Rowling"
            };

            Assert.Equal(1, author.Id);
            Assert.Equal("J.K. Rowling", author.Name);
        }
    }

    public class BookServiceTests
    {
        [Fact]
        public void AddBook_ShouldIncreaseBookCount()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase(databaseName: "LIBTestDB").Options;

            using (var context = new ApplicationDbContext(options))
            {
                var book = new Book
                {
                    Name = "test1",
                    PublishedYear = 1988,
                    IsAvailable = true
                };
                context.Books.Add(book);
                context.SaveChanges();

                var initialCount = context.Books.Count();

                var book2 = new Book
                {
                    Name = "test2",
                    PublishedYear = 1988,
                    IsAvailable = true
                };
                context.Books.Add(book2);
                context.SaveChanges();

                var finalCount = context.Books.Count();
                Assert.Equal(initialCount + 1, finalCount);

            }
        }

    }
}