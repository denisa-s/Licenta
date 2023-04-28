using Licenta.Models;

namespace Licenta;

public partial class LoginPage : ContentPage
{
    public LoginPage()
    {
        InitializeComponent();
        this.BindingContext = new LoginViewModel(this.Navigation);
    }
    private void OnLoginButtonClicked(object sender, EventArgs e)
    {
        LoginModel globalObject = App.GlobalObject;
        globalObject.UserName = emailEntry.Text;
        Navigation.PushAsync(new MainPage());
    }
    private void OnRegisterButtonClicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new RegisterPage());
    }
}