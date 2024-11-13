using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumericTypesConverter.MVVM.Models;

public static class NumericConverterModel
{
    #region Decimal
    //decimal to binary
    public static string DecToBin(string value)
    {
        if (string.IsNullOrEmpty(value))
            return string.Empty;
        if (value.StartsWith('.'))
            value = '0' + value;

        string intergerPart;
        string fractionalPart;
        decimal intPart;
        decimal fracPart;
        if (value.Contains('.'))
        {

            var vals = value.Split('.');

            intPart = Convert.ToDecimal(vals[0]);
            fracPart = Convert.ToDecimal($"0.{vals[1]}");

            intergerPart = DivideBinary(intPart);
            fractionalPart = MultiplyBinary(fracPart);
            if (value.Contains('-'))
                return $"-{intergerPart}.{fractionalPart}";
            return $"{intergerPart}.{fractionalPart}";
        }
        else
        {
            intPart = Convert.ToDecimal(value);
            string val = DivideBinary(intPart);
            return val;
        }
    }

    private static string DivideBinary(decimal value)
    {
        decimal div = value;
        List<decimal> reminders = [];
        while (div > 0)
        {
            reminders.Add(div % 2);
            div = Math.Truncate(div / 2.0m);
        }
        reminders.Reverse();

        return string.Join("", reminders);
    }

    private static string MultiplyBinary(decimal value)
    {
        decimal mul = value;
        List<decimal> decimals = [];
        for (int i = 0; i < 6; i++)
        {
            decimal val = Math.Truncate(mul * 2.0m);
            mul = (mul * 2.0m) - val;
            decimals.Add(val);
        }
        return string.Join("", decimals);
    }

    //decimal to hexadecimal
    public static string DecToHex(string value)
    {
        if (string.IsNullOrEmpty(value))
            return string.Empty;
        if (value.StartsWith('.'))
            value = '0' + value;

        string intergerPart;
        string fractionalPart;
        decimal intPart;
        decimal fracPart;
        if (value.Contains('.'))
        {
            var vals = value.Split('.');
            intPart = Convert.ToDecimal(vals[0]);
            fracPart = Convert.ToDecimal($"0.{vals[1]}");
            intergerPart = DivideHexadecimal(intPart);
            fractionalPart = MultiplyHexadecimal(fracPart);
            return $"{intergerPart}.{fractionalPart}";
        }
        else
        {
            intPart = Convert.ToDecimal(value);
            return DivideHexadecimal(intPart);
        }

    }

    private static string DivideHexadecimal(decimal value)
    {
        decimal div = value;
        List<decimal> reminders = [];
        while (div > 0)
        {
            decimal reminder = div / 16.0m;
            decimal val = reminder - Math.Truncate(reminder);
            reminders.Add(val * 16.0m);
            div = Math.Truncate(reminder);
        }
        reminders.Reverse();
        return InHexadecimal(reminders);
    }

    private static string MultiplyHexadecimal(decimal value)
    {
        decimal mul = value;
        List<decimal> decimals = [];
        for (int i = 0; i < 6; i++)
        {
            decimal val = Math.Truncate(mul * 16.0m);
            mul = (mul * 16.0m) - val;
            decimals.Add(val);
        }
        return InHexadecimal(decimals);
    }

    private static string InHexadecimal(List<decimal> value)
    {
        Dictionary<decimal, char> HexValues = new() { { 0, '0' }, { 1, '1' }, { 2, '2' }, { 3, '3' }, { 4, '4' }, { 5, '5' }, { 6, '6' }, { 7, '7' }, { 8, '8' }, { 9, '9' }, { 10, 'A' }, { 11, 'B' }, { 12, 'C' }, { 13, 'D' }, { 14, 'E' }, { 15, 'F' } };
        List<char> values = [];
        foreach (var val in value)
        {
            HexValues.TryGetValue(val, out var hexValue);
            values.Add(hexValue);
        }

        return string.Join("", values);
    }

    // decimal to octal
    public static string DecToOct(string value)
    {
        if (string.IsNullOrEmpty(value))
            return string.Empty;
        if (value.StartsWith('.'))
            value = '0' + value;

        string intergerPart;
        string fractionalPart;
        decimal intPart;
        decimal fracPart;
        if (value.Contains('.'))
        {
            var vals = value.Split('.');
            intPart = Convert.ToDecimal(vals[0]);
            fracPart = Convert.ToDecimal($"0.{vals[1]}");
            intergerPart = DivideOctal(intPart);
            fractionalPart = MultiplyOctal(fracPart);
            return $"{intergerPart}.{fractionalPart}";
        }
        else
        {

            intPart = Convert.ToDecimal(value);
            return DivideOctal(intPart);
        }
    }

    private static string DivideOctal(decimal value)
    {
        decimal div = value;
        List<decimal> reminders = [];
        while (div > 0)
        {
            decimal reminder = div / 8.0m;
            decimal val = reminder - Math.Truncate(reminder);
            reminders.Add(val * 8.0m);
            div = Math.Truncate(reminder);
        }
        reminders.Reverse();
        return InOctal(reminders);
    }

    private static string MultiplyOctal(decimal value)
    {
        decimal mul = value;
        List<decimal> decimals = [];
        for (int i = 0; i < 6; i++)
        {
            decimal val = Math.Truncate(mul * 8.0m);
            mul = (mul * 8.0m) - val;
            decimals.Add(val);
        }
        return InOctal(decimals);
    }

    private static string InOctal(List<decimal> value)
    {
        Dictionary<decimal, char> OctValues = new() { { 0, '0' }, { 1, '1' }, { 2, '2' }, { 3, '3' }, { 4, '4' }, { 5, '5' }, { 6, '6' }, { 7, '7' } };
        List<char> values = [];
        foreach (var val in value)
        {
            OctValues.TryGetValue(val, out var octValue);
            values.Add(octValue);
        }

        return string.Join("", values);
    }
    #endregion

    #region Binary
    //binary to decimal, octal and hexadecimal
    public static string BinToDec(string value)
    {
        if (string.IsNullOrEmpty(value))
            return string.Empty;
        if (value.StartsWith('.'))
            value = '0' + value;


        var Arr = value.Split('.');
        string integralPart = Arr[0];
        string fractionalPart = string.Empty;
        if (Arr.Length == 2)
            fractionalPart = Arr[1];

        if (value.Contains('.'))
        {
            var integralArr = integralPart.ToCharArray();
            var fractionalArr = fractionalPart.ToCharArray();
            int intCount = integralArr.Length - 1;
            int fraCount = 1;
            decimal intValue = 0m;
            decimal fracValue = 0m;
            List<KeyValuePair<char, decimal>> intPairs = [];
            List<KeyValuePair<char, decimal>> fracPairs = [];
            foreach (char element in integralArr)
            {
                intPairs.Add(new(element, (decimal)Math.Pow(2d, intCount)));
                intCount--;
            }
            foreach (char element in fractionalArr)
            {
                fracPairs.Add(new(element, 1m / (decimal)Math.Pow(2d, fraCount)));
                fraCount++;
            }

            foreach (var element in intPairs)
            {
                if (element.Key == '1')
                {
                    intValue += element.Value;
                }
            }
            foreach (var element in fracPairs)
            {
                if (element.Key == '1')
                {
                    fracValue += element.Value;
                }
            }

            return $"{intValue + fracValue}";

        }
        else
        {
            var integralArr = integralPart.ToCharArray();
            int intCount = integralArr.Length - 1;
            decimal intValue = 0m;
            List<KeyValuePair<char, decimal>> intPairs = [];
            foreach (char element in integralArr)
            {
                intPairs.Add(new(element, (decimal)Math.Pow(2d, intCount)));
                intCount--;
            }
            foreach (var element in intPairs)
            {
                if (element.Key == '1')
                    intValue += element.Value;
            }

            return intValue.ToString();

        }

    }

    public static string BinToHex(string value)
    {
        if (string.IsNullOrEmpty(value))
            return string.Empty;
        if (value.StartsWith('.'))
            value = '0' + value;

        var val = BinToDec(value);
        return DecToHex(val);
    }

    public static string BinToOct(string value)
    {
        if (string.IsNullOrEmpty(value))
            return string.Empty;
        if (value.StartsWith('.'))
            value = '0' + value;

        var val = BinToDec(value);
        return DecToOct(val);
    }
    #endregion

    #region Octal
    //octal to decimal, octal and hexadecimal
    public static string OctTODec(string value)
    {
        if (string.IsNullOrEmpty(value))
            return string.Empty;
        if (value.StartsWith('.'))
            value = '0' + value;


        var Arr = value.Split('.');
        string integralPart = Arr[0];
        string fractionalPart = string.Empty;
        if (Arr.Length == 2)
            fractionalPart = Arr[1];

        if (value.Contains('.'))
        {
            var integralArr = integralPart.ToCharArray();
            var fractionalArr = fractionalPart.ToCharArray();
            int intCount = integralArr.Length - 1;
            int fraCount = 1;
            decimal intValue = 0m;
            decimal fracValue = 0m;
            List<KeyValuePair<char, decimal>> intPairs = [];
            List<KeyValuePair<char, decimal>> fracPairs = [];
            foreach (char element in integralArr)
            {
                intPairs.Add(new(element, (decimal)Math.Pow(8d, intCount)));
                intCount--;
            }
            foreach (char element in fractionalArr)
            {
                fracPairs.Add(new(element, 1m / (decimal)Math.Pow(8d, fraCount)));
                fraCount++;
            }

            foreach (var element in intPairs)
                intValue += element.Value * FromOctal(element.Key);

            foreach (var element in fracPairs)
                fracValue += element.Value * FromOctal(element.Key);

            return $"{intValue + fracValue}";

        }
        else
        {
            var integralArr = integralPart.ToCharArray();
            int intCount = integralArr.Length - 1;
            decimal intValue = 0m;
            List<KeyValuePair<char, decimal>> intPairs = [];
            foreach (char element in integralArr)
            {
                intPairs.Add(new(element, (decimal)Math.Pow(8d, intCount)));
                intCount--;
            }
            foreach (var element in intPairs)
                intValue += element.Value * FromOctal(element.Key);

            return intValue.ToString();

        }
    }

    private static decimal FromOctal(char key)
    {
        Dictionary<decimal, char> HexValues = new() { { 0, '0' }, { 1, '1' }, { 2, '2' }, { 3, '3' }, { 4, '4' }, { 5, '5' }, { 6, '6' }, { 7, '7' } };
        foreach (var keyValuePair in HexValues)
            if (keyValuePair.Value == key)
                return keyValuePair.Key;

        return 0;
    }

    public static string OctToBin(string value)
    {
        if (string.IsNullOrEmpty(value))
            return string.Empty;
        if (value.StartsWith('.'))
            value = '0' + value;

        var val = OctTODec(value);
        return DecToBin(val);
    }

    public static string OctToHex(string value)
    {
        if (string.IsNullOrEmpty(value))
            return string.Empty;
        if (value.StartsWith('.'))
            value = '0' + value;

        var val = OctTODec(value);
        return DecToHex(val);
    }
    #endregion

    #region Hexadecimal

    //hexadecimal to decimal, octal and binary
    public static string HexToDec(string value)
    {
        if (string.IsNullOrEmpty(value))
            return string.Empty;
        if (value.StartsWith('.'))
            value = '0' + value;

        var Arr = value.Split('.');
        string integralPart = Arr[0];
        string fractionalPart = string.Empty;
        if (Arr.Length == 2)
            fractionalPart = Arr[1];

        if (value.Contains('.'))
        {
            var integralArr = integralPart.ToCharArray();
            var fractionalArr = fractionalPart.ToCharArray();
            int intCount = integralArr.Length - 1;
            int fraCount = 1;
            decimal intValue = 0m;
            decimal fracValue = 0m;
            List<KeyValuePair<char, decimal>> intPairs = [];
            List<KeyValuePair<char, decimal>> fracPairs = [];
            foreach (char element in integralArr)
            {
                intPairs.Add(new(element, (decimal)Math.Pow(16d, intCount)));
                intCount--;
            }
            foreach (char element in fractionalArr)
            {
                fracPairs.Add(new(element, 1m / (decimal)Math.Pow(16d, fraCount)));
                fraCount++;
            }

            foreach (var element in intPairs)
                intValue += element.Value * FromHex(element.Key);

            foreach (var element in fracPairs)
                fracValue += element.Value * FromHex(element.Key);

            return $"{intValue + fracValue}";

        }
        else
        {
            var integralArr = integralPart.ToCharArray();
            int intCount = integralArr.Length - 1;
            decimal intValue = 0m;
            List<KeyValuePair<char, decimal>> intPairs = [];
            foreach (var element in integralArr)
            {
                intPairs.Add(new(element, (decimal)Math.Pow(16d, intCount)));
                intCount--;
            }
            foreach (var element in intPairs)
                intValue += element.Value * FromHex(element.Key);

            return intValue.ToString();

        }
    }
    private static decimal FromHex(char key)
    {
        Dictionary<decimal, char> HexValues = new() { { 0, '0' }, { 1, '1' }, { 2, '2' }, { 3, '3' }, { 4, '4' }, { 5, '5' }, { 6, '6' }, { 7, '7' }, { 8, '8' }, { 9, '9' }, { 10, 'A' }, { 11, 'B' }, { 12, 'C' }, { 13, 'D' }, { 14, 'E' }, { 15, 'F' } };
        foreach (var keyValuePair in HexValues)
            if (keyValuePair.Value == key)
                return keyValuePair.Key;

        return 0;
    }

    public static string HexToBin(string value)
    {
        if (string.IsNullOrEmpty(value))
            return string.Empty;
        if (value.StartsWith('.'))
            value = '0' + value;

        var val = HexToDec(value);
        return DecToBin(val);
    }

    public static string HexToOct(string value)
    {
        if (string.IsNullOrEmpty(value))
            return string.Empty;
        if (value.StartsWith('.'))
            value = '0' + value;

        var val = HexToDec(value);
        return DecToOct(val);
    }

    #endregion
}
