using NumericTypesConverter.MVVM.ViewModels;
using WinUIEx;

namespace NumericTypesConverter;


public sealed partial class Main : Window
{
    public MainViewModel ViewModel { get; private set; }
    public Main()
    {
        InitializeComponent();
        ViewModel = new();
        var windowManager = WindowManager.Get(this);
        windowManager.IsMaximizable = false;
        windowManager.IsMinimizable = false;
        windowManager.IsResizable = false;
        windowManager.Width = 400;
        windowManager.Height = 450;
        AppWindow.SetIcon("AppIcon.ico");
        Title = "HNTC";
        ExtendsContentIntoTitleBar = true;
        SetTitleBar(AppTitleBar);
    }

    private void MinClick(object sender, RoutedEventArgs e)
    {
        this.Minimize();
    }
}
