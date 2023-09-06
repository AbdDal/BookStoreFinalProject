using System.Collections.Generic;
using BookStoreFinalProject.Core.Entities;
using BookStoreFinalProject.Data.Repositories.Authors;
using BookStoreFinalProject.Data.Repositories.Books;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookStoreFinalProject.Pages.Books;

public class Edit : PageModel
{
    private readonly IBookRepository _bookRepository;
    private readonly IAuthorRepository _authorRepository;
    
    [BindProperty(SupportsGet = true)]
    public Book Book { get; set; } = new Book();
    public IEnumerable<Author> Authors { get; set; } = new List<Author>();

    public Edit(IBookRepository bookRepository, IAuthorRepository authorRepository)
    {
        _bookRepository = bookRepository;
        _authorRepository = authorRepository;
    }
    
    public void OnGet(int bookId)
    {
        Authors = _authorRepository.GetAll();
        Book = _bookRepository.GetById(bookId);
    }

    public IActionResult OnPost()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        _bookRepository.Edit(Book);
        _bookRepository.Commit();

        return RedirectToPage("./List");
    }
}