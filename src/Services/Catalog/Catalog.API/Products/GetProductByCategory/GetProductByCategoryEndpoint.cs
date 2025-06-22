
namespace Catalog.API.Products.GetProductByCategory
{
    public record GetProductByCategoryResponse(IEnumerable<Product> Products);
    public class GetProductByCategoryEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/products/category/{category}", async (string category, ISender sender) =>
            {
                var Product = await sender.Send(new GetProductByCategoryQuery(category));
                var response = Product.Adapt<GetProductByCategoryResponse>();
                return Results.Ok(response);
            }); 
        }
    }
}
