using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sanch.Indexer_Yield_Iteratory.Interface_IEnumerable
{
    class Program
    {
        static void Main(string[] args)
        {
            var cars = new List<Car>()
            {
                new Car()
                {
                    Name = "Ford",
                    Number = "A001AA01"
                },
                new Car()
                {
                    Name = "Lada",
                    Number = "B727ET77"
                }

            };
            var parking = new Parking();
            foreach (var car in cars)
            {
                parking.Add(car);
            }

            foreach (var car in parking) // parking уже коллекция и она может перечислить машина на парковке
            {
                Console.WriteLine(car);
            }

            foreach(var item in parking)
            {
                Console.WriteLine(item + " ");
            }
            foreach(var name in parking.GetNames())
            {
                Console.WriteLine(name);
            }

            Console.WriteLine();

            Console.WriteLine(parking["A001AA01"]?.Name); // поиск по индексу(ищем машину с таким номером)
            Console.WriteLine(parking["A001AA02"]?.Name);

            Console.WriteLine("Ведите номер нового автомобиля");
            var num = Console.ReadLine();

            parking[1] = new Car()
            {
                Name = "BMW",
                Number = num
            };
            Console.WriteLine(parking[1]);



            Console.ReadKey();


        }
    }
}
