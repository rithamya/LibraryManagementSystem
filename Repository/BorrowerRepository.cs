using LibraryManagementSystem.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Repository
{
    public class BorrowerRepository : IRepository<Borrower>
    {
        private readonly ApplicationDbContext _db;

        public BorrowerRepository(ApplicationDbContext db)
        {
          _db = db; 
        }

        public void Add(string title, string? phno = null, string? address = null)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(title))
                {
                    throw new Exception("Borrower Name cannot be empty or null. Please provide a valid name.");
                }
                if (phno?.Length != 10)
                {
                    throw new Exception("Invalid Phone Number Format. Please enter a valid 10 digit Phone Number.");
                }
                var borrower = new Borrower
                {
                    Name = title,
                    phonenumber = phno,
                    Address = address
                };
                _db.Borrowers.Add(borrower);
                _db.SaveChanges();
                Console.WriteLine("New Borrower Details Added Successfully");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return;
            }
        }

        //public void Delete(int Id)
        //{
        //    var borrowerid = _db.Borrowers.Find(Id);
        //    if (borrowerid == null)
        //    {
        //        Console.WriteLine("Borrower not found!");
        //        return;
        //    }
        //    _db.Borrowers.Remove(borrowerid);
        //    _db.SaveChanges();
        //    Console.WriteLine("Borrower Details Deleted Successfully");

        //}

        public void ListItems()
        {
            var borrowerlist = _db.Borrowers.ToList();
            if (borrowerlist.Any())
            {
                Console.WriteLine("Borrower Details:");
                foreach (var borrower in borrowerlist)
                {
                    Console.WriteLine($"Name: {borrower.Name}\t Address: {borrower.Address}\t Phone Number: {borrower.phonenumber}");
                }
            }
            else
            {
                Console.WriteLine("No Borrower Details Available.");
            }
        }

        //public void Update(int Id, string newTitle)
        //{
        //    var borrower = _db.Borrowers.Find(Id);
        //    if (borrower == null)
        //    {
        //        Console.WriteLine("Borrower not found!");
        //        return;
        //    }
        //    borrower.Name = newTitle;
        //    _db.SaveChanges();
        //    Console.WriteLine("Borrower Details Updated Successfully");
        //}
    }
}
