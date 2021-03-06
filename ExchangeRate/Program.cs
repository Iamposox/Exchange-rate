﻿using System;
using NLog;
using static System.Console;
using System.Threading.Tasks;
using ExchangeRate.Configuration;
using ExchangeRate.IoC;
using Ninject;
using ExchangeRate.Manager.Interface;

namespace ExchangeRate {
    class Program {
        private static readonly ILogger _logger = LogManager.GetCurrentClassLogger();

        public async static Task Main(string[] args) {
            try {
                var kernel = new StandardKernel(new ServiceNinjectModule());
                var config = kernel!.Get<Config>();

                var cbrManager = kernel!.Get<IManager>();

                var currencies = await cbrManager.GetRateAsync(config.RequestUrl);

                foreach (var pair in currencies) {
                    WriteLine($"{pair.Name, 10}: {pair.Value}руб.");
                }
            } catch (Exception e) {
                _logger.Error(e);
                throw;
            }
        }
    }
}
