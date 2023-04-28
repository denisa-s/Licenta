using Licenta.Models;
using System.Xml;
namespace Licenta;

public partial class AboutPage : ContentPage
{
	public AboutPage()
	{
		InitializeComponent();
        emailLabel.Text = App.GlobalObject.UserName;
        var loginData = App.Database.RetrieveDataFromDatabase(emailLabel.Text);
        LoginModel result = loginData.Result;
        firstLabel.Text = result.FirstName;
        secondLabel.Text = result.LastName;
        thirdLabel.Text = result.PhoneNumber;
    }
}