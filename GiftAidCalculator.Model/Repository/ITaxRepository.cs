using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GiftAidCalculator.Model
{
    public interface ITaxRepository
    {
        decimal RetrieveTaxRate();
        void StoreTaxRate(decimal taxRate);
    }
}
