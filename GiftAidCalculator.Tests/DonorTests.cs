using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace GiftAidCalculator.Tests
{
    [TestFixture]
    public class DonorTests
    {
        #region Story 1 Tests
        [Test]
        public void Gift_aid_should_return_proper_amount_with_correct_tax()
        {

            var giftAidCalculator = new Model.GiftAidCalculator();
            const decimal donationAmount = 4.0m;
            const decimal taxRate = 20.0m;
            var giftAidAmount = giftAidCalculator.CalculateGiftAidAmount(donationAmount, taxRate);

            Assert.AreEqual(1.0m, giftAidAmount);
        }

        [Test]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void less_or_equal_than_zero_donation_amount_should_throw_exception()
        {
            var giftAidCalculator = new Model.GiftAidCalculator();
            const decimal donationAmount = -10.0m;
            const decimal taxRate = 20.0m;
            var giftAidAmount = giftAidCalculator.CalculateGiftAidAmount(donationAmount, taxRate);
        }

        [Test]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Negative_tax_rate_should_throw_exception()
        {
            var giftAidCalculator = new Model.GiftAidCalculator();
            const decimal donationAmount = 10.0m;
            const decimal taxRate = -20.0m;
            var giftAidAmount = giftAidCalculator.CalculateGiftAidAmount(donationAmount, taxRate);
        }

        [Test]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Tax_rate_greater_or_equal_to_hundred_should_throw_exception()
        {
            var giftAidCalculator = new Model.GiftAidCalculator();
            const decimal donationAmount = 10.0m;
            const decimal taxRate = 120.0m;
            var giftAidAmount = giftAidCalculator.CalculateGiftAidAmount(donationAmount, taxRate);
        }
         #endregion

        #region Story 3 Tests

        [Test]
        public void Gift_aid_amount_should_be_rounded_to_two_decimal_digits()
        {

            var giftAidCalculator = new Model.GiftAidCalculator();
            const decimal donationAmount = 55.5m;
            const decimal taxRate = 17.5m;
            var giftAidAmount = giftAidCalculator.CalculateGiftAidAmount(donationAmount, taxRate);

            const decimal expectedValue = 11.77m;

            //Assert
            Assert.AreEqual(giftAidAmount, expectedValue);

        } 
        #endregion
    }
}
