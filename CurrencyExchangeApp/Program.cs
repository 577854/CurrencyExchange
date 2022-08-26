using CurrencyExchangeApp.Client;
using CurrencyExchangeApp.Handler;

var input = new InputHandler();
var exchange = new ExchangeHandler();
var dbHandler = new DBHandler();
var quit = false;

Console.WriteLine("\n------------- Welcome To Currency converter! -------------");

Console.WriteLine("Please provide API key for the fixer api:");
var apikey = Console.ReadLine();
var client = new CurrencyClient(apikey);

var exchangeRates = client.GetLatestConversionRatesFromEuro();
dbHandler.SaveExchangeRatesToDB(exchangeRates.Result);

while (!quit) {

    Console.WriteLine("\n[1] Get exchange rate between two currencies with date");
    Console.WriteLine("[2] Quit");
    var choise = Console.ReadLine();

    if (choise.Equals("1"))
    {
        Console.WriteLine("\nPlease type the currency to convert from:");
        var currencyFrom = input.HandleCurrencyInput();

        Console.WriteLine("\nPlease type the currency to convert to:");
        var currencyTo = input.HandleCurrencyInput();

        Console.WriteLine("\nPlease type the amount the currency should be converted from:");
        var amount = input.HandleCurrencyAmountInput();

        Console.WriteLine("Please enter year (YYYY) month (MM) and day (DD) for the rate of the currency:");
        var date = input.HandleDateInput();

        var rates = await client.GetConversionRatesFromEuroByDate(date);

        var rate = exchange.GetExchangeRate(rates, currencyFrom, currencyTo);

        Console.WriteLine($"\nNEW: {amount} {currencyFrom} is {amount * rate} {currencyTo} at {date}. Rate is at {rate}");
    }
    else if (choise.Equals("2"))
    {
        quit = true;
    }
    else
    {
        Console.WriteLine("Incorrect input...");
    }
}

Console.WriteLine("\nQuitting program...");