using BuildingBlocks.Exceptions;
using Catalog.API.Products.CreateProduct;
using Marten.Linq.QueryHandlers;
using Marten.Linq.SoftDeletes;

namespace Catalog.API.Products.GetProductByCategory
{
    public record GetProductByCategoryQuery(string Category) : IQuery<GetProductByCategoryResult>;
    public record GetProductByCategoryResult(IEnumerable<Product> Products);

    public class GetProductByCategoryQueryHandler(IDocumentSession session) 
        : IQueryHandler<GetProductByCategoryQuery, GetProductByCategoryResult>
    {
        public async Task<GetProductByCategoryResult> Handle(GetProductByCategoryQuery query, CancellationToken cancellationToken)
        {

            var products = await session.Query<Product>().Where(P => P.Category.Contains(query.Category)).ToListAsync();
            
            if (products == null)
            {
                throw new Exception("Not found!");
            }
            return new GetProductByCategoryResult(products);
        }
    }
}
