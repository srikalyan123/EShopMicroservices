﻿
using Catalog.API.Products.CreateProduct;

namespace Catalog.API.Products.UpdateProduct
{

    public record UpdateProductRequest(Guid Id, string Name, List<string> Category, string Description, string ImageFile, decimal Price);
    public record UpdateProductResponse(bool IsSuccess);
    public class UpdateProductEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPut("/product/update", async (UpdateProductRequest request, ISender sender) =>
            {
                var command = request.Adapt<UpdateProductCommandRequest>();
                var result = await sender.Send(command);
                var resposne = result.Adapt<UpdateProductResponse>();
                return Results.Ok(resposne);
            })
            .WithName("Update Product")
            .Produces<CreateProductResposnse>(StatusCodes.Status201Created)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithSummary("Update Product")
            .WithDescription("Update Product");
        }
    }
}
