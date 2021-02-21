using System;
using System.Collections.Generic;
using System.Text;

namespace ExchangeRate.Helper.JsonParse {
    public abstract class AbstractCurrency {
        public string Name { get; set; }
        public float Value { get; set; }
    }
}
