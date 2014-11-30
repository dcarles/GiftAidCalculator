using System;

namespace GiftAidCalculator.TestConsole
{
	class Program
	{
		static void Main(string[] args)
		{
            //NOTE: For simplicity of the Test I am not validating the user inputs to be numbers and
            //in the correct format, as i think is not the point of this test and in real projects
            //there will be better way to validate that (although test and logic validate upper and lower
            //bounds for the inputs).

            ////////////////////////////////////////////////////////////////////////////////
            // Story 2. As a site administrator I should be able to change Tax Rate
            Console.WriteLine("------------------------- Site Administrator ---------------");
            Console.WriteLine("Please Enter tax rate:");
            var taxRate = decimal.Parse(Console.ReadLine());
            ////////////////////////////////////////////////////////////////////////////////
            // Story 1 & 3. As a donor
            Console.WriteLine("------------------------- Donor ---------------");
			Console.WriteLine("Please Enter donation amount:");
		    var donation = decimal.Parse(Console.ReadLine());
		    var giftAidCalculator = new Model.GiftAidCalculator();
            Console.WriteLine("Your gift aid amount is:");
            Console.WriteLine(giftAidCalculator.CalculateGiftAidAmount(donation, taxRate));
			Console.WriteLine("Press any key to exit.");
			Console.ReadLine();
		}
		
	}
}
