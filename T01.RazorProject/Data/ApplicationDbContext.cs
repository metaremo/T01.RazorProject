using Microsoft.EntityFrameworkCore;
using System.Net.Http.Headers;
using T01.RazorProject.Models;

namespace T01.RazorProject.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
    }
}
