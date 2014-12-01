using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GiftAidCalculator.Model;
using NUnit.Framework;

namespace GiftAidCalculator.Tests
{
    [TestFixture]
    public class SiteAdministratorTests
    {
        [Test]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Less_or_equal_than_zero_tax_rate_should_throw_exception()
        {
            const decimal taxRate = -10m;
            var taxStore = new TaxRepository();
            taxStore.StoreTaxRate(taxRate);
        }

        [Test]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Greater_or_equal_to_hundred_tax_rate_should_throw_exception()
        {
            const decimal taxRate = 110m;
            var taxStore = new TaxRepository();
            taxStore.StoreTaxRate(taxRate);
        }

        [Test]
        public void Stored_tax_rate_should_be_retrievable()
        {
            const decimal taxRate = 25m;

            var taxStore = new TaxRepository();
            taxStore.StoreTaxRate(taxRate);

            var taxRateValue = taxStore.RetrieveTaxRate();

            Assert.AreEqual(taxRate, taxRateValue);
        }
    }
}
