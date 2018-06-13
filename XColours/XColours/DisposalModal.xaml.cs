using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XColours.Core.Products.Dtos;
using XColours.Core.Products.Interfaces;
using XColours.Core.Products.Services;

namespace XColours
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DisposalModal : ContentPage
    {
        private readonly IProductService _productService;
        private ProductDto _selectedProduct;

        public DisposalModal(ProductDto product)
        {
            _productService = new ProductService();
            _selectedProduct = product;

            InitializeComponent();

            BindProductTable(product);
        }

        private void BindProductTable(ProductDto product)
        {
            tblCode.Detail = product.Code;
            tblDescription.Detail = product.Description;
            tblBarcode.Detail = product.Barcode;
            tblQuantity.Detail = product.Quantity.ToString();
            tblManufacturer.Detail = product.ManufacturerName;
            tblType.Detail = product.ProductTypeName;
        }

        public void OnDisposeClick(object sender, EventArgs e)
        {
            if (_productService.Dispose(_selectedProduct))
            {
                DisplayAlert("Success", "Product disposed", "OK");
                Navigation.PopModalAsync();
            }
            else
                DisplayAlert("Error", "Ups... something went wrong", "OK");
        }

        public void OnCancelClick(object sender, EventArgs e)
        {
            Navigation.PopModalAsync();
        }
    }
}