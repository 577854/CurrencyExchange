using CurrencyExchangeApp.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;

namespace CurrencyExchangeApp.Client
{
    public class CurrencyClient
    {
        private string _apiKey;
        public CurrencyClient(string apiKey) 
        {
            _apiKey = apiKey;
        }

        public async Task<decimal> GetCurrencyConversionRate(string currencyFrom, string currencyTo, decimal amount, DateOnly date)
        {
            using var client = new HttpClient();
            client.DefaultRequestHeaders.Add("apikey", _apiKey);
            
            using var response = await client.GetAsync($"https://api.apilayer.com/fixer/convert?date={date:yyyy-MM-dd}&from={currencyFrom}&to={currencyTo}&amount={amount.ToString().Replace(",",".")}");
            
            var content = await response.Content.ReadAsStringAsync();
            var jsonContent = JObject.Parse(content);

            try
            {
                return jsonContent.Root["info"].Value<decimal>("rate");
            }
            catch(Exception ex)
            {
                Console.WriteLine($"An error occured getting the exchange rate from the response. Message: {ex.Message}");
                throw;
            }
        }

        public async Task<ExchangeRates> GetLatestConversionRatesFromEuro()
        {   
            using var client = new HttpClient();
            client.DefaultRequestHeaders.Add("apikey", _apiKey);

            using var response = await client.GetAsync("https://api.apilayer.com/fixer/latest");

            var content = await response.Content.ReadAsStringAsync();
            var jsonConten = JObject.Parse(content);
            
            var baseCurrency = jsonConten.Root["base"].Value<string>();
            var date = DateOnly.Parse(jsonConten.Root["date"].Value<string>());
            
            var rates = jsonConten.Root["rates"]
                .ToObject<Dictionary<string, decimal>>()
                .ToList();

            var currencyRates = new List<Currency>();
            foreach (var rate in rates)
            {
                currencyRates.Add(new Currency { CurrencyCode = rate.Key, RateToEur = rate.Value });
            }

            return new ExchangeRates { BaseCurrency = baseCurrency, CurrencyDate = date, Rates = currencyRates };
        }
        public async Task<List<KeyValuePair<string, decimal>>> GetConversionRatesFromEuroByDate(DateOnly date)
        {
            using var client = new HttpClient();
            client.DefaultRequestHeaders.Add("apikey", _apiKey);

            using var response = await client.GetAsync($"https://api.apilayer.com/fixer/{date:yyyy-MM-dd}");

            var content = await response.Content.ReadAsStringAsync();
            var jsonConten = JObject.Parse(content);
            var rates = jsonConten.Root["rates"]
                .ToObject<Dictionary<string, decimal>>()
                .ToList();

            return rates;
        }
    }
}
