namespace Licenta;
using System;
using Licenta.Data;
using System.IO;
public partial class App : Application
{
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
}
