namespace Calculator.Helpers;

using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Calculator.Configuration;
using Calculator.Models;

public static class CurrencyConverter
{
    private static readonly HttpClient Client = new()
    {
        BaseAddress = new Uri("http://data.fixer.io/api/"),
        Timeout = new TimeSpan(0, 0, 60),
    };

    public static decimal RateTo { get; private set; }

    public static decimal AmountFrom { get; private set; }

    public static decimal AmountTo { get; private set; }

    public static CurrencyApiJson Currencies { get; private set; } = new CurrencyApiJson()
    {
        // initial/default json model values
        Timestamp = 1593858126,
        Base = "EUR",
        Date = DateTime.Parse("2020-07-04"),
        Rates = new Dictionary<string, decimal> { { "EUR", 1.0M }, { "GBP", 0.900756M }, { "USD", 1.1245M } }
    };

    public static async Task UpdateCurrenciesAsync()
    {
        if (string.IsNullOrEmpty(AppSettings.CurrencyConverterApiKey))
        {
            throw new ArgumentNullException(nameof(AppSettings.CurrencyConverterApiKey));
        }

        using var response = await Client.GetAsync($"latest?access_key={AppSettings.CurrencyConverterApiKey}");

        if (response.IsSuccessStatusCode)
        {
            // read response in json format
            string json = await response.Content.ReadAsStringAsync();

            // deserialize received json
            var jsonObj = System.Text.Json.JsonSerializer.Deserialize<CurrencyApiJson>(json);

            if (jsonObj is null)
            {
                throw new Exception("JSON deserialization failed");
            }
            else if (!jsonObj.Success && jsonObj.Error is not null)
            {
                throw new Exception(jsonObj.Error.ToString());
            }
            else
            {
                // all checks passed successfully
                Currencies = jsonObj;
            }
        }
        else
        {
            throw new Exception(response.ReasonPhrase);
        }
    }

    public static void CalculateConversionRateTo(string currencyFrom, string currencyTo) => RateTo = Currencies.Rates[Currencies.Base] / Currencies.Rates[currencyFrom] * Currencies.Rates[currencyTo];

    public static void ConvertCurrency(decimal amountFrom) => (AmountFrom, AmountTo) = (amountFrom, amountFrom * RateTo);

    public static void SwapAmounts() => (AmountFrom, AmountTo) = (AmountTo, AmountFrom);
}
