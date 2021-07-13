namespace Calculator.Helpers
{
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Threading.Tasks;
    using Calculator.Models;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Serialization;

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

                // create string list for possible errors during json processing
                var errors = new List<string>();
                var settings = new JsonSerializerSettings()
                {
                    Error = delegate (object? sender, ErrorEventArgs args)
                    {
                        // put registered errors in created string list
                        errors.Add(args.ErrorContext.Error.Message);
                        args.ErrorContext.Handled = true;
                    }
                };

                // deserialize received json
                var jsonObj = JsonConvert.DeserializeObject<CurrencyApiJson>(json, settings);

                if (errors.Count > 0)
                {
                    throw new Exception($"JSON deserialization failed.{Environment.NewLine}" +
                                        $"{string.Join(Environment.NewLine, errors)}");
                }
                else if (jsonObj != null && !jsonObj.Success && jsonObj.Error != null)
                {
                    throw new Exception(jsonObj.Error.ToString());
                }

                if (jsonObj != null)
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
}
