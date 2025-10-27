using System.ComponentModel.DataAnnotations;

public class Author
{
    [Key]
    public int Id { get; set; }
    [Required(ErrorMessage = "Please Enter Author Name")]
    public string Name { get; set; }

}