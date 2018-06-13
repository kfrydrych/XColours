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
	public partial class FindProduct : ContentPage
	{
        private readonly IProductDataAccess _productDataAccess;

        public FindProduct()
        {
            _productDataAccess = new ProductDataAccess();

            InitializeComponent();

            var products = _productDataAccess.GetWithStock();

            DrawProductItems(products);
        }

        public void DrawProductItems(IEnumerable<ProductDto> products)
        {
            var columnIndex = 0;
            var rowIndex = 0;

            foreach (var product in products)
            {
                var button = new Button { Text = product.Code, BindingContext = product };
                button.Clicked += ProductButton_Clicked;

                productsGrid.Children.Add(button, columnIndex, rowIndex);
                productsGrid.RowDefinitions.Add(new RowDefinition { Height = 100 });
                columnIndex++;

                if (columnIndex == 3)
                {
                    columnIndex = 0;
                    rowIndex++;
                }
            }

        }

        private async void ProductButton_Clicked(object sender, EventArgs e)
        {
            var button = (Button)sender;
            var productContext = (ProductDto)button.BindingContext;
            var product = _productDataAccess.GetById(productContext.Id);
            await Navigation.PushModalAsync(new DisposalModal(product));
        }
    }
}