using System.Collections.Generic;
using BookStoreFinalProject.Core.Entities;
using BookStoreFinalProject.Core.Enums;
using BookStoreFinalProject.Data.Repositories.Authors;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookStoreFinalProject.Pages.Authors;

public class List : PageModel
{
    public IEnumerable<Author> Authors { get; set; } = new List<Author>();
    private readonly IAuthorRepository _authorRepository;

    public List(IAuthorRepository authorRepository)
    {
        _authorRepository = authorRepository;
    }
    
    public void OnGet()
    {
        Authors = _authorRepository.GetAll();
    }

    public void OnDelete()
    {
        
    }
}