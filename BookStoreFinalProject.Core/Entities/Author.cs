using System.ComponentModel.DataAnnotations;
using BookStoreFinalProject.Core.Enums;

namespace BookStoreFinalProject.Core.Entities;

public class Author
{
    public int Id { get; set; }
    
    [Required, StringLength(30)] 
    public string Name { get; set; }

    [Required, StringLength(80), EmailAddress]
    public string Email { get; set; }

    public GenderType Gender { get; set; }
    
    public string Address { get; set; }
    
    public ICollection<Book> Books { get; set; }
}