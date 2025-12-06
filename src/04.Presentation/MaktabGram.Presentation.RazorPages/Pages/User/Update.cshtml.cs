using MaktabGram.Domain.ApplicationServices.UserAgg;
using MaktabGram.Domain.Core.UserAgg.Contracts.User;
using MaktabGram.Domain.Core.UserAgg.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace MaktabGram.Presentation.RazorPages.Pages.User
{
    public class UpdateModel(IUserApplicationService userApplicationService) : PageModel
    {
        [BindProperty]
        public UpdateGetUserDto model { get; set; }
        public async Task OnGet(int id,CancellationToken cancellationToken)
        {
            model = await userApplicationService.GetUpdateUserDetails(id, cancellationToken);
        }

        public async Task<IActionResult> OnPost(CancellationToken cancellationToken)
        {
            var result = await userApplicationService.Update(model.Id, model, cancellationToken);
            if (result.IsSuccess)
            {
                return RedirectToPage("Index");
            }

            return Page();
        }
    }
}
