using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.CurrencyConverter
{
    public class CurrencyConverterEngine
    {
        #region Properties

        // values extracted from http response
        public bool SuccessStatus { get; private set; }
        public int TimeStamp { get; private set; }
        public string BaseCurrency { get; private set; }
        public DateTime LocalTimeStamp { get; private set; }

        public decimal RateTo { get; private set; }

        public decimal AmountFrom { get; private set; }
        public decimal AmountTo { get; private set; }

        public List<string> CurrenciesList { get; private set; }

        public Dictionary<string, decimal> CurrenciesDict { get; private set; }

        #endregion

        #region Fields

        readonly string _fixerUrl;
        readonly string _httpResponseFile = "latest.rates";
        readonly Encoding _httpResponseFileEncoding = Encoding.UTF8;
        readonly StringComparison _strComparison = StringComparison.InvariantCultureIgnoreCase;

        // flags, that show, if specific http response value is extracted
        bool _successStatusIsFetched;
        bool _timeStampIsFetched;
        bool _baseCurrencyIsFetched;

        // string, that contains response message from http GET request
        string _httpResponse;

        #endregion

        public CurrencyConverterEngine(string baseCurrency, Dictionary<string, decimal> baseCurrenciesDict, string fixerUrl)
        {
            BaseCurrency = baseCurrency;

            CurrenciesDict = new Dictionary<string, decimal>(baseCurrenciesDict);

            _fixerUrl = fixerUrl;
        }

        public void PopulateCurrenciesList()
        {
            CurrenciesList = new List<string>();

            // clear currencies list first
            CurrenciesList.Clear();

            // populate currencies list with currencies dictionary keys
            foreach (string key in CurrenciesDict.Keys)
            {
                CurrenciesList.Add(key);
            }
        }

        public void CalculateConversionRateTo(string currencyFrom, string currencyTo)
        {
            RateTo = CurrenciesDict[BaseCurrency] / CurrenciesDict[currencyFrom] * CurrenciesDict[currencyTo];
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

        public async Task FetchData(bool useLocalDb)
        {
            // fixer.io api description:
            // "latest" endpoint - request the most recent exchange rate data.
            // url example:
            // http://data.fixer.io/api/latest?access_key=1234567890&base=EUR&symbols=GBP,USD
            // response example:
            // {"success":true,"timestamp":1530773047,"base":"EUR","date":"2018-07-05","rates":{"GBP":0.883736,"USD":1.170683}}

            if (useLocalDb)
            {
                // read last line of file
                _httpResponse = File.ReadLines(_httpResponseFile, _httpResponseFileEncoding).Last();
            }
            else
            {
                // make http GET request asynchronously
                _httpResponse = await HttpGetAsync(_fixerUrl);

                // save latest response to a file
                File.AppendAllText(_httpResponseFile, _httpResponse + Environment.NewLine, _httpResponseFileEncoding);
            }
        }

        public void ProcessResponse()
        {
            // remove '{', '}' and '"' chars from response string
            string strippedResponse = _httpResponse.Replace("{", "").Replace("}", "").Replace("\"", "");

            string[] mainPairs = strippedResponse.Split(',');

            // unset flags before checking value pairs
            _successStatusIsFetched = _timeStampIsFetched = _baseCurrencyIsFetched = false;

            foreach (var pair in mainPairs)
            {
                ProcessPair(pair.Split(':'));

                // stop after successfully extracted 'success', 'timestamp' & 'base' values from response string
                if (_successStatusIsFetched && _timeStampIsFetched && _baseCurrencyIsFetched)
                {
                    break;
                }
            }

            // check, if success value is set after initial values fetching
            if (!SuccessStatus)
            {
                throw new Exception($"Conversion failed\nResponse: {_httpResponse}");
            }

            int index = strippedResponse.IndexOf("rates:");

            if (index != -1)
            {
                string result = strippedResponse.Substring(index + "rates:".Length);

                string[] ratesPair = result.Split(',');

                CurrenciesDict = new Dictionary<string, decimal>();

                foreach (var pair in ratesPair)
                {
                    string[] s = pair.Split(':');

                    CurrenciesDict.Add(s[0], decimal.Parse(s[1], System.Globalization.NumberStyles.Float));
                }
            }
        }

        private async Task<string> HttpGetAsync(string url)
        {
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
            httpWebRequest.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;

            using (var httpWebResponse = (HttpWebResponse)(await httpWebRequest.GetResponseAsync()))
            {
                using (var stream = httpWebResponse.GetResponseStream())
                {
                    using (var sr = new StreamReader(stream))
                    {
                        return (await sr.ReadToEndAsync());
                    }
                }
            }
        }

        private void ProcessPair(string[] pair)
        {
            if (pair.Length != 2)
            {
                SuccessStatus = false;

                return;
            }

            for (int i = 0; i < pair.Length; i++)
            {
                if (string.Equals("success", pair[i], _strComparison))
                {
                    SuccessStatus = bool.Parse(pair[i + 1]);
                    _successStatusIsFetched = true;
                }
                else if (string.Equals("timestamp", pair[i], _strComparison))
                {
                    TimeStamp = int.Parse(pair[i + 1]);
                    LocalTimeStamp = ConvertUnixTimeStampToLocalDateTime(TimeStamp);
                    _timeStampIsFetched = true;
                }
                else if (string.Equals("base", pair[i], _strComparison))
                {
                    BaseCurrency = pair[i + 1];
                    _baseCurrencyIsFetched = true;
                }
            }
        }

        private DateTime ConvertUnixTimeStampToLocalDateTime(double unixTimeStamp)
        {
            // Unix timestamp is seconds past epoch
            var localDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc).AddSeconds(unixTimeStamp).ToLocalTime();

            return (localDateTime);
        }
    }
}
