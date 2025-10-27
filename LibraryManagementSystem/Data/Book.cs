using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Book
{
    [Key]
    public int Id { get; set; }
    [Required (ErrorMessage ="Please Enter Book Name")]
    public string Name { get; set; }
    [Required]
    public int AuthorId { get; set; }
    public int? BorrowerId { get; set; }
    public bool IsAvailable { get; set; } = true;
    public int? PublishedYear { get; set; }
    public Author Author { get; set; } 
    public Borrower Borrower { get; set; }
}