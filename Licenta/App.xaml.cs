namespace Licenta;
using System;
using Licenta.Data;
using System.IO;
using Licenta.Models;
public partial class App : Application
{
    public static LoginModel GlobalObject { get; set; }
    static AdoptionDatabase database;
    public static AdoptionDatabase Database
    {
        get
        {
            if (database == null)
            {
                database = new
                AdoptionDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.
                LocalApplicationData), "Adoption.db3"));
            }
            return database;
        }
    }
    public App()
	{
		InitializeComponent();
        
		MainPage = new AppShell();
	}
    protected override void OnStart()
    {
        // Initialize the global object
        LoginModel globalObject = new LoginModel();

        // Store the global object in the static property
        GlobalObject = globalObject;
    }
}
