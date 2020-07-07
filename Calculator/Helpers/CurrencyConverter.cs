using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Calculator.Models;
using Newtonsoft.Json;

namespace Calculator.Helpers
{
    public class CurrencyConverter
    {
        const string API_BASE_URL = "http://data.fixer.io/api/";
        const string API_LATEST = "latest?access_key=f864890aa3760d6e4a3bdd0a33e655be&base=EUR";

        static readonly HttpClient _httpClient = new HttpClient
        {
            BaseAddress = new Uri(API_BASE_URL),
            Timeout = new TimeSpan(0, 0, 5)
        };

        public decimal RateTo { get; private set; }
        public decimal AmountFrom { get; private set; }
        public decimal AmountTo { get; private set; }
        public CurrencyApiJson JSON { get; private set; } = new CurrencyApiJson()
        {
            // initial/default json model values
            Timestamp = 1593858126,
            Base = "EUR",
            Date = DateTime.Parse("2020-07-04"),
            Rates = new Dictionary<string, decimal> { { "EUR", 1.0M }, { "GBP", 0.900756M }, { "USD", 1.1245M } }
        };

        public CurrencyConverter()
        {
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task GetDataAsync()
        {
            var response = await _httpClient.GetAsync(API_LATEST);

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"HTTP response: {response.ReasonPhrase}");
            }

            string json = await response.Content.ReadAsStringAsync();
            JSON = JsonConvert.DeserializeObject<CurrencyApiJson>(json);

            if (!JSON.Success && JSON.Error != null)
            {
                throw new Exception(JSON.Error.ToString());
            }
        }

        public void CalculateConversionRateTo(string currencyFrom, string currencyTo)
        {
            RateTo = JSON.Rates[JSON.Base] / JSON.Rates[currencyFrom] * JSON.Rates[currencyTo];
        }

        public void ConvertCurrency(decimal amountFrom)
        {
            AmountFrom = amountFrom;
            AmountTo = AmountFrom * RateTo;
        }

        public void SwitchAmounts()
        {
            decimal tmpAmountFrom = AmountFrom;
            AmountFrom = AmountTo;
            AmountTo = tmpAmountFrom;
        }
    }
}
