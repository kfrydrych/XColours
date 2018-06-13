using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XColours.Core.Products.Dtos;
using XColours.Core.Products.Interfaces;
using XColours.Core.Products.Services;

namespace XColours
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ProductStock : ContentPage
	{
        private readonly IProductDataAccess _productDataAccess;

		public ProductStock ()
		{
            _productDataAccess = new ProductDataAccess();
            var products = _productDataAccess.GetAll();

			InitializeComponent ();

            BindListWith(products);
		}

        private void OnDetailsClick(object sender, EventArgs e)
        {

        }

        private async void OnDisposeClick(object sender, EventArgs e)
        {
            var menuItem = sender as MenuItem;
            var productContext = menuItem.CommandParameter as ProductDto;
            var product = _productDataAccess.GetById(productContext.Id);
            await Navigation.PushModalAsync(new DisposalModal(product));

        }

        private void BindListWith(IEnumerable<ProductDto> products)
        {
            productList.ItemsSource = products;
        }
	}
}