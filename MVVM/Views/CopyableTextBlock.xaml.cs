using Windows.ApplicationModel.DataTransfer;


namespace NumericTypesConverter.MVVM.Views;

public sealed partial class CopyableTextBlock : UserControl
{

    private readonly string _copyIcon = "🗎";
    private readonly string _checkIcon = "✓";
    private readonly DispatcherTimer _timer = new();

    public CopyableTextBlock()
    {
        InitializeComponent();
    }

    public string TitleText
    {
        get { return (string)GetValue(TitleTextProperty); }
        set { SetValue(TitleTextProperty, value); }
    }


    public static readonly DependencyProperty TitleTextProperty =
        DependencyProperty.Register(nameof(TitleText), typeof(string), typeof(CopyableTextBlock), new PropertyMetadata("Title"));


    public string ContianerText
    {
        get { return (string)GetValue(ContianerTextProperty); }
        set { SetValue(ContianerTextProperty, value); }
    }

    public static readonly DependencyProperty ContianerTextProperty =
       DependencyProperty.Register(nameof(ContianerText), typeof(string), typeof(CopyableTextBlock), new PropertyMetadata(0));

    private void CopyButton_Click(object sender, RoutedEventArgs e)
    {
        var package = new DataPackage();
        package.SetText(ContianerText);
        Clipboard.SetContent(package);

        CopyButton.Content = _checkIcon;
        _timer.Interval = TimeSpan.FromSeconds(1);
        _timer.Tick += Time_Tick;
        _timer.Start();
    }

    private void Time_Tick(object sender, object e)
    {
        CopyButton.Content = _copyIcon;
        _timer.Stop();
    }

    
}
