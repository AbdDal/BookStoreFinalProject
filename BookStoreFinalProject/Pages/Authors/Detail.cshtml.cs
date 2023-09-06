using BookStoreFinalProject.Core.Entities;
using BookStoreFinalProject.Data.Repositories.Authors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookStoreFinalProject.Pages.Authors;

public class Detail : PageModel
{
    private readonly IAuthorRepository _authorRepository;
    public Author Author { get; set; } = new Author();

    public Detail(IAuthorRepository authorRepository)
    {
        _authorRepository = authorRepository;
    }
    
    public void OnGet(int authorId)
    {
        Author = _authorRepository.GetById(authorId);
    }

    public IActionResult ReturnToPage()
    {
        return RedirectToPage("./List");
    }
}