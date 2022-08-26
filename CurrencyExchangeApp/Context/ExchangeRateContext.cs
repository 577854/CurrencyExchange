using CurrencyExchangeApp.Models;
using System.Data.Entity;

namespace CurrencyExchangeApp.Context
{
    public class ExchangeRateContext : DbContext
    {
        public DbSet<ExchangeRates> ExchangeRates { get; set; }
        public DbSet<Currency> Currency { get; set; }
    }
}
