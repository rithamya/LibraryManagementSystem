using LibraryManagementSystem.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Repository
{
    public class AuthorRepository : IRepository<Author>
    {
        private readonly ApplicationDbContext _db;

        public AuthorRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public void Add(string title)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(title))
                {
                    throw new Exception("Author Name cannot be empty or null. Please provide a valid name.");
                }

                var author = new Author
                {
                    Name = title,
                };

                _db.Authors.Add(author);
                _db.SaveChanges();

                Console.WriteLine("New Author Details Added Successfully");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return;
            }
        }

        //public void Delete(int Id)
        //{
        //    var authorid = _db.Authors.Find(Id);
        //    if (authorid == null)
        //    {
        //        Console.WriteLine("Author not found!");
        //        return;
        //    }
        //    _db.Authors.Remove(authorid);
        //    _db.SaveChanges();
        //    Console.WriteLine("Author Details Deleted Successfully");

        //}

        public void ListItems()
        {
           var authorlist = _db.Authors.ToList();
            if (authorlist.Any())
            {
                Console.WriteLine("Author Details:");
                foreach (var author in authorlist)
                {
                    Console.WriteLine($"Author Id:{author.Id}\t Author Name: {author.Name}");
                }
            }
            else
            {
                Console.WriteLine("No Author details are Available.");
            }
        }

        //public void Update(int Id, string newTitle)
        //{
        //    var author = _db.Authors.Find(Id);
        //    if (author == null)
        //    {
        //        Console.WriteLine("Author not found!");
        //        return;
        //    }
        //    author.Name = newTitle;
        //    _db.SaveChanges();
        //    Console.WriteLine("Author Details Updated Successfully");
        //}
    }
}
