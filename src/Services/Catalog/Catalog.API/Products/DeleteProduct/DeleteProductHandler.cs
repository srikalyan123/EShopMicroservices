
using Catalog.API.Products.UpdateProduct;
using Microsoft.AspNetCore.Http;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Catalog.API.Products.DeleteProduct
{

    public record DeleteProductCommandRequest(Guid Id) : ICommand<DeleteProductResult>;
    public record DeleteProductResult(bool IsSuccess);

    public class DeleteProductCommandValidator : AbstractValidator<DeleteProductCommandRequest>
    {
        public DeleteProductCommandValidator()
        {
            RuleFor(command => command.Id).NotEmpty().WithMessage("Id is required");
        }
    }
    public class DeleteProductHandler(IDocumentSession session)
        : ICommandHandler<DeleteProductCommandRequest, DeleteProductResult>
    {
        public async Task<DeleteProductResult> Handle(DeleteProductCommandRequest command, CancellationToken cancellationToken)
        {
            try
            {
                var product = await session.LoadAsync<Product>(command.Id, cancellationToken);

                if (product == null)
                {
                    return new DeleteProductResult(false);
                }

                session.Delete(product);
                await session.SaveChangesAsync(cancellationToken);

                return new DeleteProductResult(true);
            }
            catch (Exception ex)
            {
                return new DeleteProductResult(false);
            }
        }

        
    }
}
