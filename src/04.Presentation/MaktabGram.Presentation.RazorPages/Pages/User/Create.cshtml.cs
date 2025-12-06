using MaktabGram.Domain.Core.UserAgg.Contracts.User;
using MaktabGram.Domain.Core.UserAgg.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MaktabGram.Presentation.RazorPages.Pages.User
{
    public class CreateModel(IUserApplicationService userApplicationService) : PageModel
    {
        [BindProperty]
        public RegisterUserInputDto model { get; set; }
        public void OnGet()
        {
        }
        public IActionResult OnPost(CancellationToken cancellationToken)
        {
            userApplicationService.Register(model, cancellationToken);
            return RedirectToPage("Index");
        }
    }
}
