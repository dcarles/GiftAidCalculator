using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using GiftAidCalculator.Model;
using Moq;

namespace GiftAidCalculator.Tests
{
    [TestFixture]
    public class DonorTests
    {
        private List<EventSupplement> _events;
        [SetUp]
        public void Init()
        {
            var runEvent = new EventSupplement(EventType.Running, 5);
            var swimmingEvent = new EventSupplement(EventType.Swimming, 3);
            var otherEvent = new EventSupplement(EventType.Other, 0);
            var repository = new FakeRepository<EventSupplement>();
            repository.Insert(runEvent);
            repository.Insert(swimmingEvent);
            repository.Insert(otherEvent);

            _events = repository.GetAll().ToList();
            
        }

        [Test]
        public void Gift_aid_should_return_proper_amount_with_correct_tax()
        {

            var taxRepository = new Mock<ITaxRepository>();
            taxRepository.Setup(t => t.RetrieveTaxRate()).Returns(20m);
            var giftAidCalculator = new Model.GiftAidCalculator(taxRepository.Object);
            const decimal donationAmount = 4.0m;
            var otherEvent = _events.Find(e => e.EventType == EventType.Other);
            var giftAidAmount = giftAidCalculator.CalculateGiftAidAmount(donationAmount,otherEvent);

            Assert.AreEqual(1.0m, giftAidAmount);
        }

        [Test]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Less_or_equal_than_zero_donation_amount_should_throw_exception()
        {
            var taxRepository = new Mock<ITaxRepository>();
            var giftAidCalculator = new Model.GiftAidCalculator(taxRepository.Object);
            const decimal donationAmount = -10.0m;
            var otherEvent = _events.Find(e => e.EventType == EventType.Other);
            var giftAidAmount = giftAidCalculator.CalculateGiftAidAmount(donationAmount,otherEvent);
        }


        [Test]
        public void Gift_aid_amount_should_be_rounded_to_two_decimal_digits()
        {

            var taxRepository = new Mock<ITaxRepository>();
            taxRepository.Setup(t => t.RetrieveTaxRate()).Returns(17.5m);
            var giftAidCalculator = new Model.GiftAidCalculator(taxRepository.Object);
            const decimal donationAmount = 55.5m;
            var otherEvent = _events.Find(e => e.EventType == EventType.Other);
            var giftAidAmount = giftAidCalculator.CalculateGiftAidAmount(donationAmount,otherEvent);

            const decimal expectedValue = 11.77m;

            //Assert
            Assert.AreEqual(giftAidAmount, expectedValue);

        }

        [Test]
        public void Gift_aid_should_return_proper_amount_with_five_percent_supplement_on_running_events()
        {

            var taxRepository = new Mock<ITaxRepository>();
            taxRepository.Setup(t => t.RetrieveTaxRate()).Returns(20m);
            var giftAidCalculator = new Model.GiftAidCalculator(taxRepository.Object);
            const decimal donationAmount = 100m;
            var runningEvent = _events.Find(e => e.EventType == EventType.Running);
            var giftAidAmount = giftAidCalculator.CalculateGiftAidAmount(donationAmount, runningEvent);

            Assert.AreEqual(26.25m, giftAidAmount);
        }

        [Test]
        public void Gift_aid_should_return_proper_amount_with_three_percent_supplement_on_swimming_events()
        {
            var taxRepository = new Mock<ITaxRepository>();
            taxRepository.Setup(t => t.RetrieveTaxRate()).Returns(20m);
            var giftAidCalculator = new Model.GiftAidCalculator(taxRepository.Object);
            const decimal donationAmount = 100m;
            var swimmingEvent = _events.Find(e => e.EventType == EventType.Swimming);
            var giftAidAmount = giftAidCalculator.CalculateGiftAidAmount(donationAmount, swimmingEvent);

            Assert.AreEqual(25.75m, giftAidAmount);
        }


    }
}
