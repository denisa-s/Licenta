using Licenta.Models;

namespace Licenta;

public partial class MedicalRecordPage : ContentPage
{
	public MedicalRecordPage()
	{
		InitializeComponent();
	}
    async void OnSaveButtonClicked(object sender, EventArgs e)
    {
        var slist = (MedicalRecord)BindingContext;
        await App.Database.SaveMedicalRecordAsync(slist);
        await Navigation.PopAsync();
    }
    async void OnDeleteButtonClicked(object sender, EventArgs e)
    {
        var slist = (MedicalRecord)BindingContext;
        await App.Database.DeleteMedicalRecordAsync(slist);
        await Navigation.PopAsync();
    }
}