using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using ExchangeRate.Helper.JsonParse;
using ExchangeRate.Manager.Interface;
using Newtonsoft.Json;

namespace ExchangeRate.Manager {
    public class CBRManager : IManager {
        private readonly HttpClient _httpClient;

        public CBRManager(HttpClient httpClient) => _httpClient = httpClient;

        public async Task<Dictionary<string, double>> GetRateAsync(string requestUrl) {
            var downloadRate = await _httpClient.GetStringAsync(requestUrl);
            var rate = JsonConvert.DeserializeObject<RateCurrency>(downloadRate);
            return ConvertToDictionary(rate.Currencies);
        }

        private Dictionary<string, double> ConvertToDictionary(Currency rate) {
            var rateDict = new Dictionary<string, double>() {
                {rate.EUR.Name, rate.EUR.Value},
                {rate.USD.Name, rate.USD.Value}
            };
            return rateDict;
        }
    }
}