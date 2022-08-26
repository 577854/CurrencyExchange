using CurrencyExchangeApp.Context;
using CurrencyExchangeApp.Models;

namespace CurrencyExchangeApp.Handler
{
    public class DBHandler
    {
        public DBHandler() { }

        public void SaveExchangeRatesToDB(ExchangeRates exchangeRates)
        {
            using var db = new ExchangeRateContext();
            db.ExchangeRates.Add(exchangeRates);
            db.SaveChangesAsync();
        }
    }
}
