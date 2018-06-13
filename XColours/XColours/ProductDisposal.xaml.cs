using System;
using System.Collections.Generic;
using System.Drawing;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XColours.Core.Products.Dtos;
using XColours.Core.Products.Interfaces;
using XColours.Core.Products.Services;
using ZXing.Net.Mobile.Forms;


namespace XColours
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ProductDisposal : ContentPage
	{
        private readonly IProductDataAccess _productDataAccess;
        private ProductDto _selectedProduct;

        public ProductDisposal()
        {
            _productDataAccess = new ProductDataAccess();

            InitializeComponent();
        }

        public async void OnScanBarcodeClick(object sender, EventArgs e)
        {
            try
            {
                var scanPage = new ZXingScannerPage();

                scanPage.OnScanResult += (result) => {
                    // Stop scanning
                    scanPage.IsScanning = false;

                    // Pop the page and show the result
                    Device.BeginInvokeOnMainThread(() => {
                        Navigation.PopAsync();
                        OnScannedProduct(result.Text);
                        
                    });
                };

                // Navigate to our scanner page
                await Navigation.PushAsync(scanPage);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

        }

        public async void OnFindProductClick(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new FindProduct());
        }

        public void OnScannedProduct(string barcode)
        {
            _selectedProduct = _productDataAccess.GetByBarcode(barcode);

            if (_selectedProduct != null)
            {
                Navigation.PushModalAsync(new DisposalModal(_selectedProduct));
            }
            else
                DisplayAlert("Error", "Cannot find product with this barcode", "OK");

        }
    }
}