using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XColours.Core.Products.Dtos;

namespace XColours.Core.Products.Interfaces
{
    public interface IProductService
    {
        bool Dispose(ProductDto product);
    }
}
