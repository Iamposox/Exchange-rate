using System;
using Newtonsoft.Json;

namespace ExchangeRate.Helper.JsonParse {
    public class RateCurrency {
        public DateTime Date { get; set; }
        public DateTime PreviousDate { get; set; }
        public string PreviousURL { get; set; }
        public DateTime Timestamp { get; set; }

        [JsonProperty("Valute")]
        public Currency Currencies { get; set; }
    }
}
