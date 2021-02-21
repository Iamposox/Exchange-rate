using System.Collections.Generic;
using System.Threading.Tasks;

namespace ExchangeRate.Manager.Interface {
    public interface IManager {
        Task<Dictionary<string, double>> GetRateAsync(string requestUrl);
    }
}
