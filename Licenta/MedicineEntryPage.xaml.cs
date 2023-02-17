using Licenta.Models;

namespace Licenta;

public partial class MedicineEntryPage : ContentPage
{
	public MedicineEntryPage()
	{
		InitializeComponent();
	}
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        listView.ItemsSource = await App.Database.GetMedicinesAsync();
    }
    async void OnMedicineAddedClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new MedicinePage
        {
            BindingContext = new Medicine()
        });
    }
    async void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        if (e.SelectedItem != null)
        {
            await Navigation.PushAsync(new MedicinePage
            {
                BindingContext = e.SelectedItem as Medicine
            });
        }
    }
}