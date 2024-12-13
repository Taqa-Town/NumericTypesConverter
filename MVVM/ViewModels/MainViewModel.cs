using CommunityToolkit.Mvvm.ComponentModel;
using NumericTypesConverter.MVVM.Models;
using System.Linq;

namespace NumericTypesConverter.MVVM.ViewModels;


public partial class MainViewModel : ObservableObject
{
    [ObservableProperty]
    public partial string FilteredText { get; set; }
    

    [ObservableProperty]
    public partial string ValidChars { get; set; } = ".0123456789";
    

    [ObservableProperty]
    public partial bool CBIsChecked { get; set; } = false;
   

    [ObservableProperty]
    public partial string FirstTitle { get; set; } = "Binary";
    

    [ObservableProperty]
    public partial string SecondTitle { get; set; } = "Hexadecimal";
    

    [ObservableProperty]
    public partial string ThirdTitle { get; set; } = "Octal";

    [ObservableProperty]
    public partial string FirstText { get; set; } = string.Empty;

    [ObservableProperty]
    public partial string SecondText { get; set; } = string.Empty;

    [ObservableProperty]
    public partial string ThirdText { get; set; } = string.Empty;

    [ObservableProperty]
    public partial InputTypesModel InputTypes { get; set; } = InputTypesModel.Decimal;

    public void FilterInput(TextBox sender, TextBoxBeforeTextChangingEventArgs args)
    {
        if (!string.IsNullOrEmpty(args.NewText))
        {
            if (args.NewText.Length > 25)
                args.Cancel = true;
            int count = 0;
            foreach (char c in args.NewText)
            {
                if (!ValidChars.Contains(c))
                    args.Cancel = true;

                count = args.NewText.Count(c => c == '.');
                if (count > 1)
                    args.Cancel = true;
                else if (!ValidChars.Contains(c))
                    args.Cancel = true;
            }
        }
    }

    public void ChangeInputType(object sender, SelectionChangedEventArgs e)
    {
        ComboBox comboBox = sender as ComboBox;
        ComboBoxItem selectedItem = comboBox.SelectedItem as ComboBoxItem;
        if (selectedItem is not null)
        {
            FilteredText = string.Empty;
            FirstText = string.Empty;
            SecondText = string.Empty;
            ThirdText = string.Empty;
            CBIsChecked = false;
            string content = selectedItem.Content.ToString();
            if (content.Contains("Decimal"))
            {
                InputTypes = InputTypesModel.Decimal;
                ValidChars = ".0123456789";
                FirstTitle = "Binary";
                SecondTitle = "Hexadecimal";
                ThirdTitle = "Octal";
            }

            if (content.Contains("Binary"))
            {
                InputTypes = InputTypesModel.Binary;
                ValidChars = ".01";
                FirstTitle = "Decimal";
                SecondTitle = "Hexadecimal";
                ThirdTitle = "Octal";
            }

            if (content.Contains("Hexadecimal"))
            {
                InputTypes = InputTypesModel.Hexadecimal;
                ValidChars = ".0123456789abcdefABCDEF";
                FirstTitle = "Decimal";
                SecondTitle = "Binary";
                ThirdTitle = "Octal";
            }

            if (content.Contains("Octal"))
            {
                InputTypes = InputTypesModel.Octal;
                ValidChars = ".01234567";
                FirstTitle = "Decimal";
                SecondTitle = "Binary";
                ThirdTitle = "Hexadecimal";
            }
        }
    }

    public void Convert(object sender, TextChangedEventArgs e)
    {
        if (string.IsNullOrEmpty(FilteredText))
            CBIsChecked = false;
        if (!string.IsNullOrEmpty(FilteredText))
        {
            var tb = sender as TextBox;
            int current = tb.SelectionStart;
            string toupper = string.Empty;
            foreach (char c in FilteredText)
                toupper += char.ToUpper(c);
            FilteredText = toupper;
            tb.SelectionStart = current;
        }

        switch (InputTypes)
        {
            case InputTypesModel.Decimal:
                FirstText = NumericConverterModel.DecToBin(FilteredText);
                SecondText = NumericConverterModel.DecToHex(FilteredText);
                ThirdText = NumericConverterModel.DecToOct(FilteredText);
                break;

            case InputTypesModel.Binary:
                FirstText = NumericConverterModel.BinToDec(FilteredText);
                SecondText = NumericConverterModel.BinToHex(FilteredText);
                ThirdText = NumericConverterModel.BinToOct(FilteredText);
                break;

            case InputTypesModel.Hexadecimal:
                FirstText = NumericConverterModel.HexToDec(FilteredText);
                SecondText = NumericConverterModel.HexToBin(FilteredText);
                ThirdText = NumericConverterModel.HexToOct(FilteredText);
                break;

            case InputTypesModel.Octal:
                FirstText = NumericConverterModel.OctTODec(FilteredText);
                SecondText = NumericConverterModel.OctToBin(FilteredText);
                ThirdText = NumericConverterModel.OctToHex(FilteredText);
                break;
        }
    }


}