using LibraryManagementSystem.Repository;


Console.Write("Enter Login Name:");
var user = Console.ReadLine();

Console.WriteLine($"Hi {user}! Welcome to Library Management System.");

var db = new ApplicationDbContext();
var bookRepository = new BookRepository(db);
var borrowerRepository = new BorrowerRepository(db);
var authorRepository = new AuthorRepository(db);
var continueApp = true;

Console.WriteLine();

while(continueApp)
{ 
Console.WriteLine("----- Menu Details -----");
Console.WriteLine("1. List Available Books");
Console.WriteLine("2. Add Book");
Console.WriteLine("3. Update Book Name");
Console.WriteLine("12. Update Auther Id of Book");
Console.WriteLine("4. Delete Book");
Console.WriteLine("5. Borrow Book");
Console.WriteLine("11. Return Book");
Console.WriteLine("6. Add Author");
Console.WriteLine("7. List Authors");
Console.WriteLine("8. Add Borrower");
Console.WriteLine("9. List Borrowers");
Console.WriteLine("10. Exit");
Console.WriteLine("----------------------");

Console.WriteLine();

Console.Write("select one menu operation number: ");


string? option = Console.ReadLine();

    Console.WriteLine();

    //var book = db.Books.ToList();
    switch (option)
    {
        case "1":
            //if (book.Count()== 0)
            //    Console.WriteLine("No Books Available");
            //else
            //{
            //    Console.WriteLine("Available Books:");
            //    foreach (var item in book)
            //    {
            //        Console.WriteLine(item.Name);
            //    }
            //}
            //break;
            bookRepository.ListItems();
            break;

        case "2":

            Console.Write("Enter Book Name to make new entry:");
            var bookName = Console.ReadLine();
            Console.Write("Enter Author Id:");
            var authorId = int.Parse(Console.ReadLine());
            bookRepository.Add(bookName, authorId);
            break;

        case "3":
            Console.Write("Enter book Id to update:");
            var bookId = int.Parse(Console.ReadLine());
            Console.Write("Enter book Name to update:");
            var updatebookname = Console.ReadLine();
            bookRepository.UpdateTitle(bookId,updatebookname);
            break;

        case "12":
            Console.Write("Enter book Id to update:");
            var booksId = int.Parse(Console.ReadLine());
            Console.Write("Enter Auther Id to update:");
            var authId = int.Parse(Console.ReadLine());
            bookRepository.UpdateAuthor(booksId,authId);
            break;

        case "4":
            Console.Write("Enter book Id to delete:");
            var deletebook = int.Parse(Console.ReadLine());
            bookRepository.Delete(deletebook);
            break;
        case "5":
            Console.Write("Enter Book id to borrow:");
            var bookid = int.Parse(Console.ReadLine());
            Console.Write("Enter Borrower id:");
            var borrowerid = int.Parse(Console.ReadLine());
            bookRepository.Borrow(bookid, borrowerid);
            break;
        case "6":
            Console.Write("Enter Author Name to make new entry:");
            var authorName = Console.ReadLine();
            authorRepository.Add(authorName);
            break;
        case "7":
            authorRepository.ListItems();
            break;
        case "8":
            Console.Write("Enter borrower Name to make new entry:");
            var borrowerName = Console.ReadLine();
            Console.Write("Enter phone number:");
            var phno =Console.ReadLine();
            Console.Write("Enter address:");
            var address = Console.ReadLine();
            borrowerRepository.Add(borrowerName,phno , address);
            break;
        case "9":
            borrowerRepository.ListItems();
            break;

        case "10":
            Console.WriteLine("Exiting... Thank you for using Library Management System!");
            continueApp = false;
            break;
        case "11":
            Console.Write("Enter Book Id to Return:");
            var returnbookid = int.Parse(Console.ReadLine());
            bookRepository.ReturnBook(returnbookid);
            break;
        default:
            Console.WriteLine("Invalid option selected.");
            break;
    }

}