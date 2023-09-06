using BookStoreFinalProject.Core.Entities;
using BookStoreFinalProject.Data.Repositories.Books;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookStoreFinalProject.Pages.Books;

public class Detail : PageModel
{
    private readonly IBookRepository _bookRepository;
    public Book Book { get; set; } = new Book();

    public Detail(IBookRepository bookRepository)
    {
        _bookRepository = bookRepository;
    }
    
    public void OnGet(int bookId)
    {
        Book = _bookRepository.GetById(bookId);
    }
}