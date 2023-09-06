using BookStoreFinalProject.Core.Entities;

namespace BookStoreFinalProject.Data.Repositories.Books;

public interface IBookRepository
{
    IEnumerable<Book> GetAll();
    Book GetById(int id);
    Book Add(Book book);
    Book Edit(Book book);
    void Delete(int id);
    int Commit();
}