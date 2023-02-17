using Licenta.Models;

namespace Licenta;

public partial class MedicinePage : ContentPage
{
	public MedicinePage()
	{
		InitializeComponent();
	}
    async void OnSaveButtonClicked(object sender, EventArgs e)
    {
        var slist = (Medicine)BindingContext;
        await App.Database.SaveMedicineAsync(slist);
        await Navigation.PopAsync();
    }
    async void OnDeleteButtonClicked(object sender, EventArgs e)
    {
        var slist = (Medicine)BindingContext;
        await App.Database.DeleteMedicineAsync(slist);
        await Navigation.PopAsync();
    }
}