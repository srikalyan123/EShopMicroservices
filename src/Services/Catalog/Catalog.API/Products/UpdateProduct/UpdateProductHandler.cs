
using Catalog.API.Products.CreateProduct;
using JasperFx.Core;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Catalog.API.Products.UpdateProduct
{

    public record UpdateProductCommandRequest(Guid Id, string Name, List<string> Category, string Description, string ImageFile, decimal Price) 
        : ICommand<UpdateProductResult>;

    public record UpdateProductResult(bool IsSuccess);

    public class UpdateProductCommandValidator : AbstractValidator<UpdateProductCommandRequest>
    {
        public UpdateProductCommandValidator()
        {
            RuleFor(command => command.Id).NotEmpty().WithMessage("Product Id is required");
            RuleFor(command => command.Name).NotEmpty().WithMessage("Name is required")
                .Length(2, 150).WithMessage("Name must be between 2 and 150 characters");
            RuleFor(command => command.Price)
                .GreaterThan(0).WithMessage("Price must be greater than 0");


        }
    }


    public class UpdateProductHandler(IDocumentSession session)
        : ICommandHandler<UpdateProductCommandRequest, UpdateProductResult>
    {
        private readonly IDocumentSession _session = session;

        public async Task<UpdateProductResult> Handle(UpdateProductCommandRequest command, CancellationToken cancellationToken)
        {
            try
            {
                var product = await _session.LoadAsync<Product>(command.Id, cancellationToken);

                if (product == null)
                {
                    throw new ProductNotFoundException(command.Id);
                }
                product.Name = command.Name;
                product.Category = command.Category;
                product.Description = command.Description;
                product.Price = command.Price;
                product.ImageFile = command.ImageFile;
                product.Id = command.Id;

                _session.Store(product);

                await _session.SaveChangesAsync(cancellationToken);
                return new UpdateProductResult(true);

            }
            catch (Exception ex)
            {
                return new UpdateProductResult(false);
            }
            
            
        }
    }
}
