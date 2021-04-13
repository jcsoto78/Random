using System;

namespace FactoryPatternTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"GOLD_CC expiration date  {CreditCardFactory.CreateProduct(CreditCardFactory.CCrequest.GOLD_CC).GetCardExpirationDate()}");
            Console.WriteLine($"BASIC_CC Funds  {CreditCardFactory.CreateProduct(CreditCardFactory.CCrequest.BASIC_CC).GetCardFunds()}");
        }
    }

    public class CreditCardFactory
    {
        public enum CCrequest { BASIC_CC =0, GOLD_CC =1 };

        public static ICreditCard CreateProduct(CCrequest requestCC)
        {
            if (requestCC == CCrequest.GOLD_CC)
            {
                return new GoldCard();
            }

            return new BasicCard();
        }
    }

    public interface ICreditCard
    {
        string GetCardType() => "BASIC_CC";

        decimal GetCardFunds() => 100;

        DateTime GetCardExpirationDate() => DateTime.Today;
    }


    public class GoldCard : ICreditCard
    {
        public DateTime GetCardExpirationDate() => DateTime.Today.AddYears(1);

        public decimal GetCardFunds() => 20000;

        public string GetCardType() => "GOLD_CC";    
    }

    public class BasicCard : ICreditCard
    {
        //uses code defined on Interface
    }
}
