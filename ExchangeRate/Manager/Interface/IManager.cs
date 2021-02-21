using System.Collections.Generic;
using System.Threading.Tasks;

namespace ExchangeRate.Manager.Interface {
    public interface IManager<T> {
        Task<Dictionary<string, double>> GetRate(string rateXml);
    }
}
