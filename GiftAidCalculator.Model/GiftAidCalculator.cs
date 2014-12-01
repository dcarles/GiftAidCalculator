using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GiftAidCalculator.Model
{
    public class GiftAidCalculator
    {
        private readonly ITaxRepository _taxRepository;

        public GiftAidCalculator(ITaxRepository taxRepository)
        {
            _taxRepository = taxRepository;
        }

        public decimal CalculateGiftAidAmount(decimal donationAmount, EventSupplement selectedEventSupplement)
        {
            if (donationAmount <= 0m) throw new ArgumentOutOfRangeException("donationAmount");

            var currentTaxRate = _taxRepository.RetrieveTaxRate();

            var supplementAmount = this.CalculateSupplementedAmount(donationAmount, selectedEventSupplement);
            var gaRatio = currentTaxRate / (100 - currentTaxRate);
            var giftAidAmount = supplementAmount * gaRatio;
            return CalculationHelper.RoundDecimal(giftAidAmount, 2);
        }

        private decimal CalculateSupplementedAmount(decimal donationAmount, EventSupplement selectedEvent)
        {
            return donationAmount + donationAmount * selectedEvent.SupplementRate / 100m;
        }
    }
}
