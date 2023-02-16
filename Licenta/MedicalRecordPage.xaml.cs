namespace Licenta;

public partial class MedicalRecordPage : ContentPage
{
	public MedicalRecordPage()
	{
		InitializeComponent();
	}
    async void OnSaveButtonClicked(object sender, EventArgs e)
    {
        var slist = (Employee)BindingContext;
        await App.Database.SaveEmployeeAsync(slist);
        await Navigation.PopAsync();
    }
    async void OnDeleteButtonClicked(object sender, EventArgs e)
    {
        var slist = (Employee)BindingContext;
        await App.Database.DeleteEmployeeAsync(slist);
        await Navigation.PopAsync();
    }
}