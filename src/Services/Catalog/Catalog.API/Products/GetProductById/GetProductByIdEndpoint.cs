
using Catalog.API.Products.CreateProduct;

namespace Catalog.API.Products.GetProductById
{

    public record GetProductbyIdResponse(Product Product);
    public class GetProductByIdEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/products/id/{id}", async (Guid id, ISender sender) =>
            {
                var result = await sender.Send(new GetProductByIdQuery(id));
                var response = result.Adapt<GetProductbyIdResponse>();
                return Results.Ok(response);
            })
            .WithName("GetProductById")
            .Produces<CreateProductResposnse>(StatusCodes.Status201Created)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithSummary("Get Product By Id")
            .WithDescription("Get Product By Id");

        }
    }
}
