using BookStoreFinalProject.Core.Entities;
using BookStoreFinalProject.Data.Repositories.Authors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookStoreFinalProject.Pages.Authors;

public class Edit : PageModel
{
    private readonly IAuthorRepository _authorRepository;
    
    [BindProperty(SupportsGet = true)]
    public Author Author { get; set; } = new Author();

    public Edit(IAuthorRepository authorRepository)
    {
        _authorRepository = authorRepository;
    }
    
    public void OnGet(int authorId)
    {
        Author = _authorRepository.GetById(authorId);
    }

    public IActionResult OnPost()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        _authorRepository.Edit(Author);
        _authorRepository.Commit();

        return RedirectToPage("./List");
    }
}