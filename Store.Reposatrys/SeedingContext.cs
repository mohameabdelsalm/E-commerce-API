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
        public static async Task SeedAsync(StoreDbcontext context, ILoggerFactory factory)
        {
            try
            {
                if (context.productBrands != null && !context.productBrands.Any())
                {
                    var Data = File.ReadAllText("../Store.Reposatrys/SeedData/brands.json");
                    var brands = JsonSerializer.Deserialize<List<ProductBrand>>(Data);
                    if (brands is not null)
                    {
                        await context.productBrands.AddRangeAsync(brands);
                    }

                }
                if (context.productTypes != null && !context.productTypes.Any())
                {
                    var Data = File.ReadAllText("../Store.Reposatrys/SeedData/types.json");
                    var Types = JsonSerializer.Deserialize<List<ProductType>>(Data);
                    if (Types is not null)
                    {
                        await context.productTypes.AddRangeAsync(Types);
                    }

                }
                if (context.products != null && !context.products.Any())
                {
                    var Data = File.ReadAllText("../Store.Reposatrys/SeedData/products.json");
                    var products = JsonSerializer.Deserialize<List<Product>>(Data);
                    if (products is not null)
                    {
                        await context.products.AddRangeAsync(products);
                    }

                }
				if (context.deliveryMethods != null && !context.deliveryMethods.Any())
				{
					var deliveryMethodsData = File.ReadAllText("../Store.Reposatrys/SeedData/delivery.json");
					var deliveryMethods = JsonSerializer.Deserialize<List<DeliveryMethod>>(deliveryMethodsData);
					if (deliveryMethods is not null)
					{
						await context.deliveryMethods.AddRangeAsync(deliveryMethods);
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
