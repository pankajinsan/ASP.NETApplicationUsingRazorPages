using CRUDApplicationUsingRazorPages.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;

namespace CRUDApplicationUsingRazorPages.Pages
{
    public class LoginModel : PageModel
    {
        [BindProperty]
        public Entity.LoginViewModel login { get; set; }
        public void OnGet()
        {
        }
        public IActionResult OnPost(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                //var userdetails = "";
                if (!(model.Username == "admin" && model.Password == "admin"))
                {
                    ModelState.AddModelError("Password", "Invalid login attempt.");
                    return Page();
                }
                else
                {
                    HttpContext.Session.SetString("userId", model.Username);
                    return RedirectToPage("/Index");
                }

            }
            ModelState.AddModelError("", "Invalid login attempt");
            return Page();
           
        }
        public IActionResult OnPostLogout()
        {
            HttpContext.Session.Clear();
            return RedirectToPage("/Index");
        }
    }
}
