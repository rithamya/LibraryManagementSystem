using System.ComponentModel.DataAnnotations;

public class Borrower
{
    [Key] public int Id { get; set; }
    [Required(ErrorMessage ="Please Enter Borrower Name")]
    public string Name { get; set; }
    public string Address { get; set; }
    [MaxLength(10)]
    public string phonenumber { get; set; }

}