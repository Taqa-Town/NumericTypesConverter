global using Microsoft.UI.Xaml;
global using Microsoft.UI.Xaml.Controls;
global using System;
using NumericTypesConverter.MVVM.Views;

namespace NumericTypesConverter;


public partial class App : Application
{
    public Main MainWindow { get; private set; }

    public App()
    {
        InitializeComponent();
    }

    
    protected override void OnLaunched(Microsoft.UI.Xaml.LaunchActivatedEventArgs args)
    {
        MainWindow = new Main();
        MainWindow.Activate();
    }

    
}
