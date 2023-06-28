namespace Licenta.Views;
using CommunityToolkit.Mvvm.Input;
using Licenta.Models;
using Licenta.ViewModels;
using Licenta.Views;
public partial class ProductPage : ContentPage
{
    public ProductPageViewModel viewModel;

    public ProductPage()
    {
    }

    public ProductPage(ProductPageViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }
}