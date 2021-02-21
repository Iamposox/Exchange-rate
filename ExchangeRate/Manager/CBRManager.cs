using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using ExchangeRate.Helper.JsonParse;
using ExchangeRate.Manager.Interface;
using Newtonsoft.Json;

namespace ExchangeRate.Manager {
    public class CBRManager : IManager<CBRManager> {

        public async Task<Dictionary<string, double>> GetRate(string requestUrl) {
            using var httpClient = new HttpClient();
            var downloadRate = await httpClient.GetStringAsync(requestUrl);
            var rate = JsonConvert.DeserializeObject<RateCurrency>(downloadRate);
            return ConvertToDictionary(rate.Currencies);
        }

        private Dictionary<string, double> ConvertToDictionary(Currency rate) {
            var rateDict = new Dictionary<string, double>();
            rateDict.Add(rate.EUR.Name, rate.EUR.Value);
            rateDict.Add(rate.USD.Name, rate.USD.Value);
            return rateDict;
        }
    }
}