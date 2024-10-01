using Microsoft.Extensions.Logging;
using Store.Data.Contexts;
using Store.Data.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Store.Reposatrys
{
    public class SeedingContext
    {
        public static async Task SeedAsync(StoreDBcontext context, ILoggerFactory factory)
        {
            try
            {
                if (context.ProductBrands != null && !context.ProductBrands.Any())
                {
                    var Data = File.ReadAllText("../Store.Reposatrys/SeedData/brands.json");
                    var brands = JsonSerializer.Deserialize<List<ProductBrand>>(Data);
                    if (brands is not null)
                    {
                        await context.ProductBrands.AddRangeAsync(brands);
                    }

                }
                if (context.ProductTypes != null && !context.ProductTypes.Any())
                {
                    var Data = File.ReadAllText("../Store.Reposatrys/SeedData/types.json");
                    var Types = JsonSerializer.Deserialize<List<ProductType>>(Data);
                    if (Types is not null)
                    {
                        await context.ProductTypes.AddRangeAsync(Types);
                    }

                }
                if (context.Products != null && !context.Products.Any())
                {
                    var Data = File.ReadAllText("../Store.Reposatrys/SeedData/products.json");
                    var products = JsonSerializer.Deserialize<List<Product>>(Data);
                    if (products is not null)
                    {
                        await context.Products.AddRangeAsync(products);
                    }

                }
                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                var loger = factory.CreateLogger<SeedingContext>();
                loger.LogError(ex.Message);

                if (ex.InnerException != null)
                {
                    Console.WriteLine("Inner Exception: " + ex.InnerException.Message);
                }
            }
        }
    }
}
