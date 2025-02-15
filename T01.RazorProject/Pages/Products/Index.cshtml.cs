using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using T01.RazorProject.Data;
using T01.RazorProject.Models;

namespace T01.RazorProject.Pages.Products
{
    public class IndexModel : PageModel
    {
        private readonly T01.RazorProject.Data.ApplicationDbContext _context;

        public IndexModel(T01.RazorProject.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Product> Product { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Product = await _context.Products.ToListAsync();
        }
    }
}
