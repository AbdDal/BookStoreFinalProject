using System;
using BookStoreFinalProject.Core.Entities;
using BookStoreFinalProject.Data.Repositories.Authors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookStoreFinalProject.Pages.Authors;

public class Add : PageModel
{
    private readonly IAuthorRepository _authorRepository;
    
    [BindProperty]
    public Author Author { get; set; } = new Author();

    public Add(IAuthorRepository authorRepository)
    {
        _authorRepository = authorRepository;
    }
    
    public void OnGet()
    {
        
    }

    public IActionResult OnPost()
    {
        if (!ModelState.IsValid)
        {
            return RedirectToPage("/NotFound");
        }

        Console.WriteLine(Author.Name);
        Console.WriteLine(Author.Email);
        _authorRepository.Add(Author);
        _authorRepository.Commit();

        return RedirectToPage("./List");
    }
}