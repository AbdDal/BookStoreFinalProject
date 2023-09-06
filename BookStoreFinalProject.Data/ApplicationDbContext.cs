using BookStoreFinalProject.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookStoreFinalProject.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
        
    }
    
    public DbSet<Book> Books { get; set; }
    public DbSet<Author> Authors { get; set; }
}