﻿namespace Licenta;
using Licenta.Models;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
        this.BindingContext = new AppShellViewModel();
    }
   
}
