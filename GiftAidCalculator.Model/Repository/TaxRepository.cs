using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GiftAidCalculator.Model
{
    public class TaxRepository: ITaxRepository
    {
        private decimal _taxRate = 20m;
        public decimal RetrieveTaxRate()
        {
            return _taxRate;
        }

        public void StoreTaxRate(decimal taxRate)
        {
            if (taxRate <= 0m || taxRate >= 100m) throw new ArgumentOutOfRangeException("taxRate");
            _taxRate = taxRate;
        }
    }
}
