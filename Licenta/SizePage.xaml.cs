namespace Licenta;

using Licenta.Models;
using Size = Licenta.Models.Size;
public partial class SizePage : ContentPage
{
    Dog sl;
    public SizePage(Dog slist)
    {
        InitializeComponent();
        sl = slist;
    }
    async void OnSaveButtonClicked(object sender, EventArgs e)
    {
        var product = (Size)BindingContext;
        await App.Database.SaveSizeAsync(product);
        listView.ItemsSource = await App.Database.GetSizesAsync();
    }
    async void OnDeleteButtonClicked(object sender, EventArgs e)
    {
        var product = (Size)BindingContext;
        await App.Database.DeleteSizeAsync(product);
        listView.ItemsSource = await App.Database.GetSizesAsync();
    }
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        listView.ItemsSource = await App.Database.GetSizesAsync();
    }
    async void OnAddButtonClicked(object sender, EventArgs e)
    {
        Size p;
        if (listView.SelectedItem != null)
        {
            p = listView.SelectedItem as Size;
            var lp = new ListSize()
            {
                DogID = sl.ID,
                SizeID = p.ID
            };
            await App.Database.SaveListSizeAsync(lp);
            p.ListSizes = new List<ListSize> { lp };
            await Navigation.PopAsync();
        }
    }
}