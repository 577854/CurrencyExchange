using System.ComponentModel.DataAnnotations;

namespace CurrencyExchangeApp.Models
{
    public class Currency
    {
        public string CurrencyCode { get; set; }
        public decimal RateToEur { get; set; }

        [Key]
        public int ExchangeRateId { get; set; }
        public virtual ExchangeRates ExchangeRates { get; set; }
    }
}
