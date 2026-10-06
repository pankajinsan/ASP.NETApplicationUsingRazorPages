using CRUDApplicationUsingRazorPages.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CRUDApplicationUsingRazorPages.Pages
{
    public class AddModel : PageModel
    {
        IRepository _productRepository;
        public AddModel(IRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [BindProperty]
        public Entity.Customer customer { get; set; }
        [TempData]
        public string Message { get; set; }
        public IActionResult OnGet()
        {
            return Page();
        }
        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                _productRepository.Add(customer);

                Message = "New Product Added Successfully !";
                return RedirectToPage("/Index");

            }

            return Page();
        }
    }
}
