namespace CurrencyExchangeApp.Handler
{
    public class ExchangeHandler
    {
        public ExchangeHandler() { }

        public decimal GetExchangeRate(List<KeyValuePair<string, decimal>> currencies, string currencyFrom, string currencyTo)
        {
            decimal currencyRateFrom = decimal.Zero;
            decimal currencyRateTo = decimal.Zero;

            foreach(var currency in currencies)
            {
                if (currency.Key.Equals(currencyFrom))
                {
                    currencyRateFrom = currency.Value;
                }

                if (currency.Key.Equals(currencyTo))
                {
                    currencyRateTo = currency.Value;
                }
            }

            if(currencyRateFrom != decimal.Zero && currencyRateTo != decimal.Zero)
            { 
                return decimal.Round(decimal.Divide(currencyRateTo, currencyRateFrom), 6);
            }

            Console.WriteLine($"\nCurrecny does not exsist in the currenct list of Currencies. Either \"{currencyFrom}\" or \"{currencyTo}\" is not a valid currency");
            return decimal.Zero;
        }
    }
}
