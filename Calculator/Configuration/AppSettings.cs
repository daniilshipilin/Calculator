namespace Calculator.Configuration;

using System.Collections.Generic;
using Microsoft.Win32;

public static class AppSettings
{
    public const string RegistryBaseKey = @"SOFTWARE\Illuminati Software Inc.";

    public const string RegistryCalculatorKey =
#if DEBUG
        RegistryBaseKey + "\\Calculator [Debug]";
#else
        RegistryBaseKey + "\\Calculator";
#endif

    public const int CurrentConfigVersion = 11;

    private static readonly RegistryKey RegKeyCalculator = Registry.CurrentUser.CreateSubKey(RegistryCalculatorKey);

    private static readonly IReadOnlyDictionary<string, object> DefaultSettingsDict = new Dictionary<string, object>()
    {
        { nameof(ConfigVersion), CurrentConfigVersion },
        { nameof(CurrencyConverterApiKey), "" },
        { nameof(HexDelimiter), "0x" },
        { nameof(Base64Mode), "Text" },
        { nameof(Crc32Checked), true },
        { nameof(Elf32Checked), true },
        { nameof(Md5Checked), true },
        { nameof(Sha1Checked), true },
        { nameof(Sha256Checked), true },
        { nameof(Sha384Checked), true },
        { nameof(Sha512Checked), true },
        { nameof(RandomQty), 1000 },
        { nameof(RandomMin), -1000000 },
        { nameof(RandomMax), 1000000 },
        { nameof(PasswordQty), 10 },
        { nameof(PasswordLength), 16 },
        { nameof(PasswordCharset), "PasswordCharset" },
    };

    public static int? ConfigVersion
    {
        get => (int?)RegKeyCalculator.GetValue(nameof(ConfigVersion));

        set => RegKeyCalculator.SetValue(nameof(ConfigVersion), value ?? 0);
    }

    public static string CurrencyConverterApiKey
    {
        get => (string?)RegKeyCalculator.GetValue(nameof(CurrencyConverterApiKey)) ?? string.Empty;

        set => RegKeyCalculator.SetValue(nameof(CurrencyConverterApiKey), value);
    }

    public static string HexDelimiter
    {
        get => (string?)RegKeyCalculator.GetValue(nameof(HexDelimiter)) ?? string.Empty;

        set => RegKeyCalculator.SetValue(nameof(HexDelimiter), value);
    }

    public static string Base64Mode
    {
        get => (string?)RegKeyCalculator.GetValue(nameof(Base64Mode)) ?? string.Empty;

        set => RegKeyCalculator.SetValue(nameof(Base64Mode), value);
    }

    public static bool Crc32Checked
    {
        get => bool.Parse((string?)RegKeyCalculator.GetValue(nameof(Crc32Checked)) ?? string.Empty);

        set => RegKeyCalculator.SetValue(nameof(Crc32Checked), value);
    }

    public static bool Elf32Checked
    {
        get => bool.Parse((string?)RegKeyCalculator.GetValue(nameof(Elf32Checked)) ?? string.Empty);

        set => RegKeyCalculator.SetValue(nameof(Elf32Checked), value);
    }

    public static bool Md5Checked
    {
        get => bool.Parse((string?)RegKeyCalculator.GetValue(nameof(Md5Checked)) ?? string.Empty);

        set => RegKeyCalculator.SetValue(nameof(Md5Checked), value);
    }

    public static bool Sha1Checked
    {
        get => bool.Parse((string?)RegKeyCalculator.GetValue(nameof(Sha1Checked)) ?? string.Empty);

        set => RegKeyCalculator.SetValue(nameof(Sha1Checked), value);
    }

    public static bool Sha256Checked
    {
        get => bool.Parse((string?)RegKeyCalculator.GetValue(nameof(Sha256Checked)) ?? string.Empty);

        set => RegKeyCalculator.SetValue(nameof(Sha256Checked), value);
    }

    public static bool Sha384Checked
    {
        get => bool.Parse((string?)RegKeyCalculator.GetValue(nameof(Sha384Checked)) ?? string.Empty);

        set => RegKeyCalculator.SetValue(nameof(Sha384Checked), value);
    }

    public static bool Sha512Checked
    {
        get => bool.Parse((string?)RegKeyCalculator.GetValue(nameof(Sha512Checked)) ?? string.Empty);

        set => RegKeyCalculator.SetValue(nameof(Sha512Checked), value);
    }

    public static int RandomQty
    {
        get => (int?)RegKeyCalculator.GetValue(nameof(RandomQty)) ?? 0;

        set => RegKeyCalculator.SetValue(nameof(RandomQty), value);
    }

    public static int RandomMin
    {
        get => (int?)RegKeyCalculator.GetValue(nameof(RandomMin)) ?? 0;

        set => RegKeyCalculator.SetValue(nameof(RandomMin), value);
    }

    public static int RandomMax
    {
        get => (int?)RegKeyCalculator.GetValue(nameof(RandomMax)) ?? 0;

        set => RegKeyCalculator.SetValue(nameof(RandomMax), value);
    }

    public static int PasswordQty
    {
        get => (int?)RegKeyCalculator.GetValue(nameof(PasswordQty)) ?? 0;

        set => RegKeyCalculator.SetValue(nameof(PasswordQty), value);
    }

    public static int PasswordLength
    {
        get => (int?)RegKeyCalculator.GetValue(nameof(PasswordLength)) ?? 0;

        set => RegKeyCalculator.SetValue(nameof(PasswordLength), value);
    }

    public static string PasswordCharset
    {
        get => (string?)RegKeyCalculator.GetValue(nameof(PasswordCharset)) ?? string.Empty;

        set => RegKeyCalculator.SetValue(nameof(PasswordCharset), value);
    }

    public static void CheckSettings()
    {
        if (ConfigVersion is null or not CurrentConfigVersion)
        {
            ResetSettings();
        }
    }

    public static void ResetSettings()
    {
        // clear root config reg keys
        ClearRegistryKey(RegKeyCalculator);

        // set default values
        foreach (var pair in DefaultSettingsDict)
        {
            RegKeyCalculator.SetValue(pair.Key, pair.Value);
        }
    }

    private static void ClearRegistryKey(RegistryKey regKey)
    {
        foreach (string? key in regKey.GetValueNames())
        {
            regKey.DeleteValue(key);
        }
    }
}
