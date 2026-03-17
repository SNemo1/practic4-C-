using System;

namespace TripCalculator
{
    public class TripCalculator
    {
        public static void Main(string[] args)
        {

            Console.Write("Введіть відстань поїздки (км): ");
            double distance = Convert.ToDouble(Console.ReadLine());

            Console.Write("Введіть середню витрату пального (л/100 км): ");
            double fuelConsumption = Convert.ToDouble(Console.ReadLine());

            Console.Write("Введіть вартість 1 літра пального (грн): ");
            double fuelPrice = Convert.ToDouble(Console.ReadLine());

            Console.Write("Введіть середню швидкість (км/год): ");
            double speed = Convert.ToDouble(Console.ReadLine());
            
            double fuelNeeded = CalculateFuelNeeded(distance, fuelConsumption);
            double tripCost = CalculateTripCost(fuelNeeded, fuelPrice);
            double travelTime = CalculateTravelTime(distance, speed);
            
            int hours = GetHours(travelTime);
            int minutes = GetMinutes(travelTime);
            int stops = CalculateStops(travelTime);
            double miles = ConvertToMiles(distance);

            PrintTripSummary(distance, miles, hours, minutes, fuelNeeded, tripCost, stops);
        }

        static double CalculateFuelNeeded(double distance, double fuelConsumption)
        {
            return (distance / 100.0) * fuelConsumption;
        }

        static double CalculateTripCost(double fuelNeeded, double fuelPrice)
        {
            return fuelNeeded * fuelPrice;
        }

        static double CalculateTravelTime(double distance, double speed)
        {
            return distance / speed;
        }

        static int GetHours(double travelTime)
        {
            return (int)travelTime; 
        }

        static int GetMinutes(double travelTime)
        {
            double fractionalPart = travelTime - GetHours(travelTime);
            return (int)Math.Round(fractionalPart * 60);
        }

        static int CalculateStops(double travelTime)
        {
            return (int)(travelTime / 2.5);
        }
        static double ConvertToMiles(double distanceKm)
        {
            return distanceKm * 0.621371;
        }
        
        static void PrintTripSummary(double distanceKm, double distanceMiles, int hours, int minutes, double fuelNeeded, double tripCost, int stops)
        {
            String text = $"""
                              --- ЗВІТ ПРО ПОДОРОЖ ---
                           Відстань: {distanceKm} км ({distanceMiles:F2} миль
                           Орієнтовний час у дорозі: {hours} годин {minutes} хвилин
                           Рекомендована кількість зупинок: {stops}
                           Необхідно пального: {fuelNeeded:F2} л
                           Орієнтовна вартість поїздки: {tripCost:F2} грн
                               
                           """;
            Console.WriteLine(text);
        }
    }
}
