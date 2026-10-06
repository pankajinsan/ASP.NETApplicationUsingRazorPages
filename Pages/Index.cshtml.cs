using CRUDApplicationUsingRazorPages.Entity;
using CRUDApplicationUsingRazorPages.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUDApplicationUsingRazorPages.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        IRepository _productRepository;
        public IndexModel(IRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [BindProperty]
        public List<Entity.Customer> productList { get; set; }

        [BindProperty]
        public Entity.Customer customer { get; set; }

        [TempData]
        public string Message { get; set; }
        public void OnGet()
        {
            productList = _productRepository.FindAll();
        }
        public ActionResult OnPost(ProductSearchModel prod)
        {
            productList = _productRepository.FindByName(prod);
            return Page();
        }
        public IActionResult OnPostDelete(int id)
        {
            if (id > 0)
            {
                _productRepository.Remove(id);

                Message = "Product Deleted Successfully !";
                return RedirectToPage("/Index");

            }

            return Page();

        }
    }
}
