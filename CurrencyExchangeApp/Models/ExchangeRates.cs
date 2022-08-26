using System.ComponentModel.DataAnnotations;

namespace CurrencyExchangeApp.Models
{
    public class ExchangeRates
    {
        [Key]
        public int ExchangeRateId { get; set; }
        public string BaseCurrency { get; set; }
        public DateOnly CurrencyDate { get; set; }
        public List<Currency> Rates { get; set; }
    }
}
