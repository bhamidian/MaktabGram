using MaktabGram.Domain.ApplicationServices.UserAgg;
using MaktabGram.Domain.Core.UserAgg.Contracts.User;
using MaktabGram.Domain.Core.UserAgg.Dtos;
using MaktabGram.Presentation.RazorPages.Extentions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MaktabGram.Presentation.RazorPages.Pages.User
{
    public class IndexModel(IUserApplicationService userApplicationService) : BasePageModel
    {
        public List<GetUserSummaryDto> Users { get; set; }

        public async Task OnGet(CancellationToken cancellationToken)
        {
            Users = await userApplicationService.GetUsersSummary(cancellationToken);
        }


        public IActionResult OnGetActive(int id,CancellationToken cancellationToken)
        {
            userApplicationService.Active(id, cancellationToken);

            return RedirectToPage("Index");
        }


        public IActionResult OnGetDeActive(int id,CancellationToken cancellationToken)
        {
            userApplicationService.DeActive(id, cancellationToken);

            return RedirectToPage("Index");
        }
    }
}
