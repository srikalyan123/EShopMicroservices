﻿using BuildingBlocks.Exceptions;

namespace Catalog.API.Products.Exceptions
{
    public class ProductNotFoundException : NotFoundException
    {
        public ProductNotFoundException(Guid Id) : base("Product", Id) 
        { 
            
        }
    }
}
