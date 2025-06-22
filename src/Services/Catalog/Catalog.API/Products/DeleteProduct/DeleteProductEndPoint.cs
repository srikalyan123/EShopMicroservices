
using Catalog.API.Products.CreateProduct;

namespace Catalog.API.Products.DeleteProduct
{
    public record DeleteProductResponse(bool isSucess);
    public class DeleteProductEndPoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {

            app.MapPost("/product/delete/{id}", async (Guid id, ISender sender) =>
            {
                var result = await sender.Send(new DeleteProductCommandRequest(id));
                var response = result.Adapt<DeleteProductResult>();
                return Results.Ok(response);
            })
            .WithName("DeleteProduct")
            .Produces<CreateProductResposnse>(StatusCodes.Status201Created)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithSummary("Delete Product")
            .WithDescription("Delete Product");

        }
    }
}
