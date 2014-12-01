using System;
using System.Collections.Generic;
using System.Linq;
using GiftAidCalculator.Model;

namespace GiftAidCalculator.TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            //NOTE: For simplicity of the Test I am not validating the user inputs to be numbers and
            //in the correct format, as i think is not the point of this test and in real projects
            //there will be better way to validate that or even better way to input things with controls and not
            //with simple console commands (although test and logic validate upper and lower bounds for the inputs).


            ////////////////////////////////////////////////////////////////////////////////
            // Story 2. As a site administrator I should be able to change Tax Rate
            var taxRepository = StoreTaxRate();

            ////////////////////////////////////////////////////////////////////////////////
            // Story 1,3,4 . As a donor should be able to calculate gift aid using current tax rate
            // and adding correct supplement depending on the event
            Console.WriteLine("------------------------- Donor -------------------");
            var selectedEventSupplement = GetSelectedEventSupplement();
            CalculateGiftAid(taxRepository, selectedEventSupplement);

            Console.WriteLine("Press any key to exit.");
            Console.ReadLine();
        }

        private static void CalculateGiftAid(TaxRepository taxRepository, EventSupplement selectedEventSupplement)
        {
            Console.WriteLine("Please Enter donation amount:");
            var donation = decimal.Parse(Console.ReadLine());

            var giftAidCalculator = new Model.GiftAidCalculator(taxRepository);
            Console.WriteLine("Your gift aid amount is:");
            Console.WriteLine(giftAidCalculator.CalculateGiftAidAmount(donation, selectedEventSupplement));
        }

        private static TaxRepository StoreTaxRate()
        {
            Console.WriteLine("------------------------- Site Administrator ---------------");
            Console.WriteLine("Please Enter tax rate:");
            var taxRate = decimal.Parse(Console.ReadLine());
            var taxRepository = new TaxRepository();
            taxRepository.StoreTaxRate(taxRate);
            return taxRepository;
        }

        private static EventSupplement GetSelectedEventSupplement()
        {
            Console.WriteLine("********************** Promotions ******************");
            var events = InitEvents();
            var option = 1;
            foreach (var eventSupplement in events)
            {
                Console.WriteLine(option + ") " + eventSupplement.ToString());
                option++;
            }
            Console.WriteLine("Please Enter event option:");
            var selectedEventOption = int.Parse(Console.ReadLine());
            var eventType = (EventType) selectedEventOption;
            var selectedEventSupplement = events.Find(e => e.EventType == eventType);
            return selectedEventSupplement;
        }

        private static List<EventSupplement> InitEvents()
        {
            var runEvent = new EventSupplement(EventType.Running, 5);
            var swimmingEvent = new EventSupplement(EventType.Swimming, 3);
            var otherEvent = new EventSupplement(EventType.Other, 0);

            var repository = new FakeRepository<EventSupplement>();

            repository.Insert(runEvent);
            repository.Insert(swimmingEvent);
            repository.Insert(otherEvent);

            return repository.GetAll().ToList();

        }



    }
}
