using System.Collections.Generic;
using BookStoreFinalProject.Core.Entities;
using BookStoreFinalProject.Data.Repositories.Authors;
using BookStoreFinalProject.Data.Repositories.Books;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookStoreFinalProject.Pages.Books;

public class List : PageModel
{
    private readonly IBookRepository _bookRepository;

    [BindProperty(SupportsGet = true)] 
    public IEnumerable<Book> Books { get; set; } = new List<Book>();

    public List(IBookRepository bookRepository)
    {
        _bookRepository = bookRepository;
    }
    public void OnGet()
    {
        Books = _bookRepository.GetAll();
    }
}