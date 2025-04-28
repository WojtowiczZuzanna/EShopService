using Microsoft.EntityFrameworkCore;
using EShop.Domain.Models;
using EShop.Domain.Repositories;


namespace EShop.Domain.Seeders;

public class EShopSeeder(DataContext context) : IEShopSeeder
{
    public async Task Seed()
    {

        //if (!context.Category.Any())
        //{
        //    var categories = new List<Category>
        //    {
        //        new Category {Name = "Category1"}
        //    };
        //}


        if (!context.Set<Product>().Any())
        {
            var products = new List<Product>
            {
                new Product
                {
                    Name = "Product1",
                    Ean = "1111111111111",
                    Price = 10,
                    Stock = 10,
                    Sku = "PROD001",

                },
                new Product
                {
                    Name = "Product2",
                    Ean = "2222222222222",
                    Price = 20,
                    Stock = 20,
                    Sku = "PROD002",

                },
                new Product
                {
                    Name = "Product3",
                    Ean = "3333333333333",
                    Price = 30,
                    Stock = 3,
                    Sku = "PROD003",
                }
            };

            context.Set<Product>().AddRange(products);
            context.SaveChanges();
        }
    }
}