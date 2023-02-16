namespace Licenta;
using Licenta.Models;
public partial class EmployeeEntryPage : ContentPage
{
	public EmployeeEntryPage()
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