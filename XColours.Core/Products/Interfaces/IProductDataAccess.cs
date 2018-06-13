using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XColours.Core.Products.Dtos;

namespace XColours.Core.Products.Interfaces
{
    public interface IProductDataAccess
    {
        IEnumerable<ProductDto> GetAll();
        IEnumerable<ProductDto> GetWithStock();
        ProductDto GetById(int id);
        ProductDto GetByCode(string code);
        ProductDto GetByBarcode(string barcode);
    }
}
