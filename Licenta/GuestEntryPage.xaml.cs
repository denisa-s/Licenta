using Licenta.Models;

namespace Licenta;

public partial class GuestEntryPage : ContentPage
{
	public GuestEntryPage()
	{
		InitializeComponent();
	}
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        listView.ItemsSource = await App.Database.GetEmployeesAsync();
    }
    async void OnEmployeeAddedClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new EmployeePage
        {
            BindingContext = new Employee()
        });
    }
    async void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        if (e.SelectedItem != null)
        {
            await Navigation.PushAsync(new EmployeePage
            {
                BindingContext = e.SelectedItem as Employee
            });
        }
    }
}