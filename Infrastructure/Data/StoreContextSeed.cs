using System.Runtime.Serialization.Json;
using System.Text.Json;
using Core.Entities;

namespace Infrastructure.Data
{
    public class StoreContextSeed
    {
        public static async Task SeedAsync(StoreContext context) 
        {
            if(!context.ProductBrand.Any()) 
            {
                var brandsData = File.ReadAllText("../Infrastructure/Data/SeedData/brands.json");
                var brands =JsonSerializer.Deserialize<List<ProductBrand>>(brandsData);
                context.ProductBrand.AddRange(brands);
            }
            if(!context.ProductType.Any()) 
            {
                var typesData = File.ReadAllText("../Infrastructure/Data/SeedData/types.json");
                var types =JsonSerializer.Deserialize<List<ProductType>>(typesData);
                context.ProductType.AddRange(types);
            }
            if(!context.Products.Any()) 
            {
                var productsData = File.ReadAllText("../Infrastructure/Data/SeedData/products.json");
                var products =JsonSerializer.Deserialize<List<Product>>(productsData);
                context.Products.AddRange(products);
            }

            if(context.ChangeTracker.HasChanges()) await context.SaveChangesAsync(); 
        }
    }
}