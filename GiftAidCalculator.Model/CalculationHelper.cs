using System;
namespace GiftAidCalculator.Model
{
    public static class CalculationHelper
    {
        public static decimal RoundDecimal(decimal amount, int decimalPoints)
        {
            return decimal.Round(amount, decimalPoints, MidpointRounding.AwayFromZero);
        }
    }
}