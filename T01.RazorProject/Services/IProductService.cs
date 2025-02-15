using System.Security.Policy;
using T01.RazorProject.Models;

namespace T01.RazorProject.Services
{
    public interface IProductService
    {
        Task<List<Product>> GetAllAsync();
        Task<Product?> GetByIdAsync(int? id);
        Task UpdateAsync(Product product);
        Task AddAsync(Product product);
        Task DeleteAsync(int?  id);
    }
}
