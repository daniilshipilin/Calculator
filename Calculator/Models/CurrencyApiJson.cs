namespace Calculator.Models;

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

// fixer.io api description:
// "latest" endpoint - request the most recent exchange rate data.
// url example:
// http://data.fixer.io/api/latest?access_key=1234567890&base=EUR&symbols=EUR,GBP,USD
//
// successful response json example:
//{
//    "success":true,
//    "timestamp":1593858126,
//    "base":"EUR",
//    "date":"2020-07-04",
//    "rates": {
//        "EUR":1,
//        "GBP":0.900756,
//        "USD":1.1245
//    }
//}
//
// error json response example:
//{
//    "success":false,
//    "error": {
//        "code": 101,
//        "type": "invalid_access_key",
//        "info": "You have not supplied a valid API Access Key. [Technical Support: support@apilayer.com]"
//    }
//}

public class CurrencyApiJson
{
    /// <summary>
    /// Returns true or false depending on whether or not your API request has succeeded.
    /// </summary>
    [JsonPropertyName("success")]
    public bool Success { get; set; }

    /// <summary>
    /// Returns the exact date and time (UNIX time stamp) the given rates were collected.
    /// </summary>
    [JsonPropertyName("timestamp")]
    public int Timestamp { get; set; }

    /// <summary>
    /// Returns the three-letter currency code of the base currency used for this request.
    /// </summary>
    [JsonPropertyName("base")]
    public string Base { get; set; } = string.Empty;

    /// <summary>
    /// The date the given exchange rate data was collected.
    /// </summary>
    [JsonPropertyName("date")]
    public DateTime Date { get; set; }

    /// <summary>
    /// Returns exchange rate data for the currencies you have requested.
    /// </summary>
    [JsonPropertyName("rates")]
    public Dictionary<string, decimal> Rates { get; set; } = new();

    /// <summary>
    /// Whenever a requested resource is not available or an API call fails for another reason, a JSON error is returned.
    /// </summary>
    [JsonPropertyName("error")]
    public APIError? Error { get; set; }

    /// <summary>
    /// Returns timestamp as local DateTime (converts from Unix timestamp).
    /// </summary>
    public DateTime TimestampLocalDateTime => new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc).AddSeconds(this.Timestamp).ToLocalTime();
}

public class APIError
{
    [JsonPropertyName("code")]
    public int Code { get; set; }

    [JsonPropertyName("type")]
    public string Type { get; set; } = string.Empty;

    [JsonPropertyName("info")]
    public string Info { get; set; } = string.Empty;

    public override string ToString() => $"{this.Code}{Environment.NewLine}{this.Type}{Environment.NewLine}{this.Info}";
}
