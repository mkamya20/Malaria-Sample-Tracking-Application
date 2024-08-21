using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Prismproject_A.Views
{
    [Authorize(Roles = "client")]
    public class ClientModel : PageModel
    {
        public void OnGet()
        {
        }
    }
}
