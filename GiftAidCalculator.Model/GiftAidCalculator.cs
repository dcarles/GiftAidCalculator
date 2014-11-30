using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GiftAidCalculator.Model
{
    public class GiftAidCalculator
    {
        public decimal CalculateGiftAidAmount(decimal donationAmount, decimal taxRate)
        {
            if (taxRate <= 0m || taxRate >= 100m) throw new ArgumentOutOfRangeException("taxRate");
            if (donationAmount <= 0m) throw new ArgumentOutOfRangeException("donationAmount");
          
            var gaRatio = taxRate / (100 - taxRate);
            var giftAidAmount = donationAmount*gaRatio;
            return CalculationHelper.RoundDecimal(giftAidAmount,2);
        }
    }
}
