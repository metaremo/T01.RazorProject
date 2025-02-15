using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using T01.RazorProject.Data;
using T01.RazorProject.Models;
using T01.RazorProject.Services;

namespace T01.RazorProject.Pages.Products
{
    public class UpdateModel : PageModel
    {
        //private readonly T01.RazorProject.Data.ApplicationDbContext _context;

        //public UpdateModel(T01.RazorProject.Data.ApplicationDbContext context)
        //{
        //    _context = context;
        //}

        private readonly IProductService _productService;

        public UpdateModel(IProductService productService)
        {
            _productService = productService;
        }

        [BindProperty]
        public Product Product { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _productService.GetByIdAsync(id);

            //var product =  await _context.Products.FirstOrDefaultAsync(m => m.Id == id);
            //if (product == null)
            //{
            //    return NotFound();
            //}
            if (product == null)
            {
                return NotFound();
            }

            Product = product;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _productService.UpdateAsync(Product);

            //_context.Attach(Product).State = EntityState.Modified;

            //try
            //{
            //    await _context.SaveChangesAsync();
            //}
            //catch (DbUpdateConcurrencyException)
            //{
            //    if (!ProductExists(Product.Id))
            //    {
            //        return NotFound();
            //    }
            //    else
            //    {
            //        throw;
            //    }
            //}

            return RedirectToPage("./Index");
        }

        //private bool ProductExists(int id)
        //{
        //    return  _context.Products.Any(e => e.Id == id);
        //}
    }
}
