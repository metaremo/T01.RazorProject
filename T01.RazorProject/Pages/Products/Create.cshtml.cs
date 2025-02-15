using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using T01.RazorProject.Data;
using T01.RazorProject.Models;
using T01.RazorProject.Services;

namespace T01.RazorProject.Pages.Products
{
    public class CreateModel : PageModel
    {
        private readonly IProductService _productService;
        //private readonly T01.RazorProject.Data.ApplicationDbContext _context;

        public CreateModel( IProductService productService)//(T01.RazorProject.Data.ApplicationDbContext context)
        {
          //  _context = context;
          _productService = productService;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Product Product { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
           await _productService.AddAsync(Product);

            //_context.Products.Add(Product);
            //await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
