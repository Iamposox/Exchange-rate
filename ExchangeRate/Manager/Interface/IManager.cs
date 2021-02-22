using System.Collections.Generic;
using System.Threading.Tasks;
using ExchangeRate.Helper.JsonParse.Valutes.Abstract;

namespace ExchangeRate.Manager.Interface {
    public interface IManager {
        Task<IEnumerable<AbstractCurrency>> GetRateAsync(string requestUrl);
    }
}
