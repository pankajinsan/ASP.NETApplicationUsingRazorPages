using CRUDApplicationUsingRazorPages.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CRUDApplicationUsingRazorPages.Pages
{
   
    public class EditModel : PageModel
    {
        IRepository _productRepository;
        public EditModel(IRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [BindProperty]
        public Entity.Customer customer { get; set; }
        [TempData]
        public string Message { get; set; }
        public void OnGet(int id)
        {
            customer = _productRepository.FindByID(id);
        }
        public IActionResult OnPost()
        {
            var data = customer;

            if (ModelState.IsValid)
            {
                _productRepository.Update(data);

                return RedirectToPage("/Index");

            }

            return Page();
        }
    }
}
