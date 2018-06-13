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
    public class ProductDataAccess : IProductDataAccess
    {
        private const string _baseUrl = "http://www.fakeaddress.com/api/";
        private readonly HttpClient _client;

        public ProductDataAccess()
        {
            _client = new HttpClient();
        }

        public IEnumerable<ProductDto> GetWithStock()
        {
            var content = _client.GetStringAsync(_baseUrl + "productswithstock").Result;
            return JsonConvert.DeserializeObject<IEnumerable<ProductDto>>(content);
        }

        public ProductDto GetById(int id)
        {
            var response = _client.GetAsync(_baseUrl + "products/" + id).Result;

            if (response.IsSuccessStatusCode)
                return JsonConvert.DeserializeObject<ProductDto>(response.Content.ReadAsStringAsync().Result);

            return null;
        }

        public ProductDto GetByCode(string code)
        {
            var response = _client.GetAsync(_baseUrl + "products?code=" + code).Result;

            if (response.IsSuccessStatusCode)
                return JsonConvert.DeserializeObject<ProductDto>(response.Content.ReadAsStringAsync().Result);

            return null;
        }

        public ProductDto GetByBarcode(string barcode)
        {
            var response = _client.GetAsync(_baseUrl + "products?barcode=" + barcode).Result;

            if (response.IsSuccessStatusCode)
                return JsonConvert.DeserializeObject<ProductDto>(response.Content.ReadAsStringAsync().Result);

            return null;       
        }

        public IEnumerable<ProductDto> GetAll()
        {
            var content = _client.GetStringAsync(_baseUrl + "products").Result;
            return JsonConvert.DeserializeObject<IEnumerable<ProductDto>>(content);
        }
    }
}
