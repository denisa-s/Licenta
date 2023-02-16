using Licenta.Models;

namespace Licenta;

public partial class MedicalRecordEntryPage : ContentPage
{
	public MedicalRecordEntryPage()
	{
		InitializeComponent();
	}
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        listView.ItemsSource = await App.Database.GetMedicalRecordsAsync();
    }
    async void OnMedicalRecordAddedClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new MedicalRecordPage
        {
            BindingContext = new MedicalRecord()
        });
    }
    async void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        if (e.SelectedItem != null)
        {
            await Navigation.PushAsync(new MedicalRecordPage
            {
                BindingContext = e.SelectedItem as MedicalRecord
            });
        }
    }
}