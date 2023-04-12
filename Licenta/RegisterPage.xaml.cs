using Licenta.Models;
namespace Licenta;

public partial class RegisterPage : ContentPage
{
	public RegisterPage()
	{
		InitializeComponent();
        this.BindingContext = new RegisterViewModel(this.Navigation);
    }
    private void OnRegisterButtonClicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new MainPage());
    }
    private void OnSignButtonClicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new LoginPage());
    }
}