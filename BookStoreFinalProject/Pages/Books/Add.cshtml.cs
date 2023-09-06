using System.Collections.Generic;
using BookStoreFinalProject.Core.Entities;
using BookStoreFinalProject.Data.Repositories.Authors;
using BookStoreFinalProject.Data.Repositories.Books;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookStoreFinalProject.Pages.Books;

public class Add : PageModel
{
    private readonly IAuthorRepository _authorRepository;
    private readonly IBookRepository _bookRepository;

    [BindProperty(SupportsGet = true)]
    public Book Book { get; set; }

    public IEnumerable<Author> Authors { get; set; } = new List<Author>();

    public Add(IBookRepository bookRepository, IAuthorRepository authorRepository)
    {
        _authorRepository = authorRepository;
        _bookRepository = bookRepository;
    }
    
    public void OnGet()
    {
        Authors = _authorRepository.GetAll();
    }

    public IActionResult OnPost()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        _bookRepository.Add(Book);
        _bookRepository.Commit();

        return RedirectToPage("./List");
    }
}