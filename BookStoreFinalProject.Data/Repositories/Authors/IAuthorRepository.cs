using BookStoreFinalProject.Core.Entities;

namespace BookStoreFinalProject.Data.Repositories.Authors;

public interface IAuthorRepository
{
    IEnumerable<Author> GetAll();
    Author GetById(int id);
    Author Add(Author author);
    Author Edit(Author author);
    void Delete(int id);
    int Commit();
}