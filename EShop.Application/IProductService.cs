using EShop.Domain.Models;
using Microsoft.EntityFrameworkCore.Migrations.Operations;

namespace EShop.Application;

public interface IProductService
{
    public Task<List<Product>> GetAllAsync();
    Task<Product> GetAsync(int id);
    Task<Product> UpdateAsync(Product product);
    Task<Product> AddAsync(Product product);
    
    //do ćwiczeń
    Product Add(Product product);
}
