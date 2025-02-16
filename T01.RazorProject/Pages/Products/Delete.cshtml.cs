using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using T01.RazorProject.Data;
using T01.RazorProject.Models;
using T01.RazorProject.Services;

namespace T01.RazorProject.Pages.Products
{
    public class DeleteModel : PageModel
    {
        // private readonly T01.RazorProject.Data.ApplicationDbContext _context;

        private readonly IProductService _productService;

        public DeleteModel(IProductService productService)
        {
            _productService = productService;
        }

        //public DeleteModel(T01.RazorProject.Data.ApplicationDbContext context)
        //{
        //    _context = context;
        //}



        [BindProperty]
        public Product Product { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _productService.GetByIdAsync(id);

            if (product == null)
            {
                return NotFound();
            }
            else
            {
                Product = product;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            await _productService.DeleteAsync(id);
           

            return RedirectToPage("./Index");
        }
    }
}
