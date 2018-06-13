using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using XColours.Core.Products.Dtos;
using XColours.Core.Products.Interfaces;

namespace XColours.Core.Products.Services
{
    public class ProductService : IProductService
    {
        private const string _baseUrl = "http://www.fakeaddress.com/api/";
        private readonly HttpClient _client;

        public ProductService()
        {
            _client = new HttpClient();
        }

        public bool Dispose(ProductDto product)
        {
            var content = JsonConvert.SerializeObject(product);

            var response = _client.PostAsync(_baseUrl + "products/dispose/" + product.Id, new StringContent(content));

            return (response.Result.IsSuccessStatusCode) ? true : false;
        }
    }
}
