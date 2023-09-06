using BookStoreFinalProject.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookStoreFinalProject.Data.Repositories.Books;

public class BookRepository : IBookRepository
{
    private readonly ApplicationDbContext _dbContext;

    public BookRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public IEnumerable<Book> GetAll()
    {
        return _dbContext.Books
            .Include(x=>x.Author)
            .ToList();
    }

    public Book GetById(int id)
    {
        return _dbContext.Books
            .Include(x=>x.Author)
            .FirstOrDefault(x => x.Id == id);
    }

    public Book Add(Book book)
    {
        var addedEntity = _dbContext.Books.Add(book);

        return addedEntity.Entity;
    }

    public Book Edit(Book book)
    {
        var editedEntity = _dbContext.Books.Update(book);

        return editedEntity.Entity;
    }

    public void Delete(int id)
    {
        var deletedEntity = _dbContext.Books.SingleOrDefault(x => x.Id == id);

        if (deletedEntity != null)
        {
            _dbContext.Books.Remove(deletedEntity);
        }
    }

    public int Commit()
    {
        return _dbContext.SaveChanges();
    }
}