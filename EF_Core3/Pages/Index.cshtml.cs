using EF_Core3.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EF_Core3.Pages
{
    public class IndexModel : PageModel
    {
        public void OnGet()
        {
            using var context = new Context();
            var list = context.Contacts.ToList();
        }
    }
}
