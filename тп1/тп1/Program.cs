using System;

namespace FUT
{
    public class Program
    {
        static void Main(string[] args)
        {
            var factories = Factory.GetFactories();
            var units = Unit.GetUnits(factories);
            var tanks = Tank.GetTanks(units);
            int totalVolume = Tank.GetTotalVolume(tanks.ToArray());
            var foundUnit = Unit.FindUnit(units.ToArray(), tanks.ToArray(), "Резервуар 1");
            

            Factory foundFactory = null;
            if (foundUnit != null)
            {
                foundFactory = Factory.FindFactory(factories.ToArray(), foundUnit);
            }

            Console.WriteLine("Заводы:\n");
            foreach (var factory in factories)
            {
                factory.DisplayInfo();
            }

            Console.WriteLine("\nУстановки:\n");
            foreach (var unit in units)
            {
                unit.DisplayInfo();
            }

            Console.WriteLine("\nРезервуары:\n");
            foreach (var tank in tanks)
            {
                tank.DisplayInfo();
            }

            Console.WriteLine($"\nОбщий максимальный объем резервуаров: {totalVolume}\n");

            Console.WriteLine("Резервуар 1");
            if (foundUnit != null)
            {
                Console.WriteLine($"Установка: {foundUnit.Name}");

                if (foundFactory != null)
                {
                    Console.WriteLine($"Завод: {foundFactory.Name}");
                }
                else
                {
                    Console.WriteLine("Завод не найден.");
                }
            }
            else
            {
                Console.WriteLine("Установка не найдена.");
            }

        }
    }
}
