using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using LibraryManagementSystem.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace LibraryManagementSystem.Repository
{
    public class BookRepository : IRepository<Book>
    {
        private readonly ApplicationDbContext _db;

        public BookRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public void Borrow(int Id, int borrowerId)
        {
            try
            {
                if (borrowerId == 0 || borrowerId == null)
                {
                    throw new Exception("Author Name cannot be empty or null. Please provide a valid name.");
                }

                var book = _db.Books.Find(Id);
                var borrowerid = _db.Borrowers.Find(borrowerId);
                if (book == null)
                {
                    Console.WriteLine("Book not found!");
                    Console.WriteLine();
                    return;
                }
                if (!book.IsAvailable)
                {
                    Console.WriteLine("Book is already borrowed!");
                    Console.WriteLine();
                }
                if (borrowerid != null)
                {
                    if (book.IsAvailable)
                    {
                        book.BorrowerId = borrowerId;
                        book.IsAvailable = false;
                        _db.SaveChanges();
                        Console.WriteLine("Book borrowed successfully!");
                        Console.WriteLine();
                    }
                }
                else
                {
                    Console.WriteLine("Borrower id not found! Please Register borrower details.");
                    Console.WriteLine();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return;
            }
        }

        public void Delete(int Id)
        {
            try
            {
                if (Id == 0 || Id == null)
                {
                    throw new Exception("Book Id cannot be 0. Enter a Valid Input.");
                }

                var bookid = _db.Books.Find(Id);
                if (bookid == null)
                {
                    Console.WriteLine("Book not found!");
                    Console.WriteLine();
                    return;
                }
                _db.Books.Remove(bookid);
                _db.SaveChanges();
                Console.WriteLine("Book Details Deleted Successfully!");
                Console.WriteLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return;
            }
        }

        public void ListItems()
        {
            var books = _db.Books.Include(b => b.Author).Include(b => b.Borrower).ToList();

            if (books.Any())
            {
                Console.WriteLine("Book Details:");
                foreach (var book in books)
                {
                    Console.WriteLine($"Bood Id:{book.Id}\t  Name: {book.Name}\t Author Name: {book.Author?.Name ?? "No Author"}\t Borrower Name: {book.Borrower?.Name ?? "Not Borrowed" }");
                }
                Console.WriteLine();

            }
            else
            {
                Console.WriteLine("No Books Available At this Time. Please get back later");
                Console.WriteLine();

            }
        }

        public void UpdateTitle(int Id, string newTitle)
        {
            try
            {
                if(Id == 0 || Id == null)
                {
                    throw new Exception("Book Id cannot be 0. Enter a valid input.");
                }
                if(string.IsNullOrWhiteSpace(newTitle))
                {
                    throw new Exception("Book Name cannot be empty or null. Please provide a valid name.");
                }
                var book = _db.Books.Find(Id);
                if (book == null)
                {
                    Console.WriteLine("Book not found!");
                    Console.WriteLine();
                    return;
                }
                if (book != null)
                {
                    book.Name = newTitle;
                    _db.SaveChanges();
                    Console.WriteLine("Book Name Updated Successfully!");
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine("Book Id not Found! Please Create Book Details.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return;
            }

        }
        public void UpdateAuthor(int Id, int AuthorId)
        {
            try
            {
                if (Id == 0 || Id == null)
                {
                    throw new Exception("Book Id cannot be 0. Enter a Valid Input.");
                }
                if (AuthorId == 0 || AuthorId == null)
                {
                    throw new Exception("Author Id cannot be 0. Enter a Valid Input.");
                }

                var book = _db.Books.Find(Id);
                var authorid = _db.Authors.Find(AuthorId);
                if (book == null)
                {
                    Console.WriteLine("Book not found!");
                    Console.WriteLine();
                    return;
                }
                if (authorid != null)
                {
                    book.AuthorId = AuthorId;
                    _db.SaveChanges();
                    Console.WriteLine("Author Details Updated in Book Successfully!");
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine("Author Id not Found! Please Create Auther Details.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return;
            }

        }

        public void ReturnBook(int Id)
        {
            try
            {
                if (Id == 0 || Id == null)
                {
                    throw new Exception("Book Id cannot be 0. Enter a Valid Input.");
                }

                var book = _db.Books.Find(Id);
                if (book == null)
                {
                    Console.WriteLine("Book not found!");
                    Console.WriteLine();
                    return;
                }
                if (!book.IsAvailable)
                {
                    book.IsAvailable = true;
                    _db.SaveChanges();
                    Console.WriteLine("Book Returned Successfully!");
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine("Book Already returned.");
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return;
            }
        }

        public void Add(string title, int authorId, int? year = null)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(title))
                {
                    throw new Exception("Author Name cannot be empty or null. Please provide a valid name.");
                }

                var authid = _db.Authors.Find(authorId);
                var book = new Book
                {
                    Name = title,
                    AuthorId = authorId,
                    PublishedYear = year
                };
                if (authid != null && authorId != 0)
                {
                    _db.Books.Add(book);
                    _db.SaveChanges();
                    Console.WriteLine("New Book Details Added Successfully!");
                    Console.WriteLine();
                }
                else
                {
                    if (authorId == 0 || authorId == null)
                    {
                        throw new Exception("Author Id cannot be 0. Enter a Valid Input.");
                    }
                    else
                    {
                        Console.WriteLine("Author Id not found! Please Register Author details.");
                        Console.WriteLine();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return;
            }
        }
    }
}
