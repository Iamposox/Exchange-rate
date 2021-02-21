using System.Net.Http;
using Ninject.Modules;
using ExchangeRate.Configuration;
using ExchangeRate.Manager;
using ExchangeRate.Manager.Interface;
using Microsoft.Extensions.Configuration;

namespace ExchangeRate.IoC {
    public class ServiceNinjectModule : NinjectModule {
        public override void Load() {
            var config = GetConfiguration<Config>("config.json");
            Bind<Config>().ToConstant(config);

            Bind<HttpClient>().ToMethod(x => new HttpClient()).InSingletonScope();
            Bind<IManager>().To<CBRManager>().InSingletonScope();
        }

        private TKey GetConfiguration<TKey>(string fileName) where TKey : new() {
            IConfigurationBuilder configBuilder = new ConfigurationBuilder().AddJsonFile(fileName);
            IConfigurationRoot config = configBuilder.Build();
            var serviceConfig = new TKey();
            config.Bind(serviceConfig);
            return serviceConfig;
        }
    }
}
