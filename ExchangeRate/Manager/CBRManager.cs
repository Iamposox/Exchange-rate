using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using ExchangeRate.Helper.JsonParse;
using ExchangeRate.Helper.JsonParse.Valutes.Abstract;
using ExchangeRate.Manager.Interface;
using Newtonsoft.Json;

namespace ExchangeRate.Manager {
    public class CBRManager : IManager {
        private readonly HttpClient _httpClient;

        public CBRManager(HttpClient httpClient) => _httpClient = httpClient;

        public async Task<List<AbstractCurrency>> GetRateAsync(string requestUrl) {
            var downloadRate = await _httpClient.GetStringAsync(requestUrl);
            var rate = JsonConvert.DeserializeObject<RateCurrency>(downloadRate);
            return ConvertToList(rate.Currencies);
        }

        private List<AbstractCurrency> ConvertToList(Currency rate) =>
            new List<AbstractCurrency>() {
                rate.EUR,
                rate.USD
            };
    }
}