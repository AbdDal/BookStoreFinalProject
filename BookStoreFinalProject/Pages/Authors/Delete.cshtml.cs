using BookStoreFinalProject.Core.Entities;
using BookStoreFinalProject.Data.Repositories.Authors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookStoreFinalProject.Pages.Authors;

public class Delete : PageModel
{
    private readonly IAuthorRepository _authorRepository;
    
    [BindProperty(SupportsGet = true)]
    public Author Author { get; set; }

    public Delete(IAuthorRepository authorRepository)
    {
        _authorRepository = authorRepository;
    }
    
    public void OnGet()
    {
    }

    public IActionResult OnPost(int authorId)
    {
        _authorRepository.Delete(authorId);
        _authorRepository.Commit();

        return RedirectToPage("./List");
    }
}