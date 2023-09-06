using BookStoreFinalProject.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookStoreFinalProject.Data.Repositories.Authors;

public class AuthorRepository : IAuthorRepository
{
    private readonly ApplicationDbContext _dbContext;

    public AuthorRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public IEnumerable<Author> GetAll()
    {
        return _dbContext.Authors
            .Include(x=>x.Books)
            .ToList();
    }

    public Author GetById(int id)
    {
        return _dbContext.Authors
            .Include(x=>x.Books)
            .FirstOrDefault(x => x.Id == id);
    }

    public Author Add(Author author)
    {
        var addedEntity = _dbContext.Authors.Add(author);

        return addedEntity.Entity;
    }

    public Author Edit(Author author)
    {
        var editedEntity = _dbContext.Authors.Update(author);

        return editedEntity.Entity;
    }

    public void Delete(int id)
    {
        var deletedEntity = _dbContext.Authors.SingleOrDefault(x => x.Id == id);

        if (deletedEntity != null)
        {
            _dbContext.Authors.Remove(deletedEntity);
        }
    }

    public int Commit()
    {
        return _dbContext.SaveChanges();
    }
}