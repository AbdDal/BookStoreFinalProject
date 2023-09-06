using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookStoreFinalProject.Core.Entities;

public class Book
{
    public int Id { get; set; }
    
    [Required, StringLength(50)]
    public string Title { get; set; }

    [StringLength(200)]
    public string Description { get; set; }

    [ForeignKey(nameof(Author))]
    public int AuthorId { get; set; }
    public Author Author { get; set; }
    
}