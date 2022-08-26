using System.Text.RegularExpressions;

namespace CurrencyExchangeApp.Handler
{
    public class InputHandler
    {
        public InputHandler() { }

        public string HandleCurrencyInput()
        {
            string currencyInput = Console.ReadLine();
            string pattern = @"[A-Z]{3}";
            var rg = new Regex(pattern);

            var currencyIsCorrect = rg.IsMatch(currencyInput.ToUpper());

            while (!currencyIsCorrect)
            {
                Console.WriteLine("Currency input inncorrect. Currency must be 3 letters and can only be alphabetical characters");
                currencyInput = Console.ReadLine();
                currencyIsCorrect = rg.IsMatch(currencyInput.ToUpper());
            }

            return currencyInput.ToUpper();
        }

        public decimal HandleCurrencyAmountInput()
        {
            var currencyAmountInput = Console.ReadLine();
            var pattern = @"\d+.?\d+";//only decimal numbers
            var rg = new Regex(pattern);

            while (!rg.IsMatch(currencyAmountInput))
            {
                Console.WriteLine("Amount input incorrect. Amount must be a decimal number");
                currencyAmountInput = Console.ReadLine();
            }

            return decimal.Parse(currencyAmountInput.ToString().Replace(".",","));
        }

        public DateOnly HandleDateInput()
        {
            DateOnly date;
            var dateIsCorrect = DateOnly.TryParse(Console.ReadLine(), out date);

            while (!dateIsCorrect)
            {
                Console.WriteLine("Date input incorrect. Please enter correct date format (YYYY-MM-DD)");
                dateIsCorrect = DateOnly.TryParse(Console.ReadLine(), out date);
            }

            return date;
        }
    }
}
