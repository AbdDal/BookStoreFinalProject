using BookStoreFinalProject.Core.Entities;
using BookStoreFinalProject.Data.Repositories.Books;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookStoreFinalProject.Pages.Books;

public class Delete : PageModel
{
    private readonly IBookRepository _bookRepository;
    
    [BindProperty(SupportsGet = true)]
    public Book Book { get; set; } = new Book();

    public Delete(IBookRepository bookRepository)
    {
        _bookRepository = bookRepository;
    }
    
    public void OnGet()
    {
    }

    public IActionResult OnPost(int bookId)
    {
        _bookRepository.Delete(bookId);
        _bookRepository.Commit();

        return RedirectToPage("./List");
    }
}