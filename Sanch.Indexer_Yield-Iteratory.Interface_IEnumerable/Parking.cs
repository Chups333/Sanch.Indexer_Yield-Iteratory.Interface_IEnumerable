using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sanch.Indexer_Yield_Iteratory.Interface_IEnumerable
{
    class Parking : IEnumerable//чтоб не возвращал тип object используем типизированный IEnumerable (смотри GetEnumerator)
    {
        private List<Car> _cars = new List<Car>();
        private const int MAX_CARS = 100;

        //public /*тип*/ this[/*тип*/ /*индекс*/] // индексатор - как со свойствами работа
        //{
        //get
        //{

        //}
        //set
        //{

        //}
        //}

        public Car this[string number]
        {
            get
            {
                var car = _cars.FirstOrDefault(c => c.Number == number);
                return car;
            }

        }
        public Car this[int position]
        {
            get
            {
                if (position < _cars.Count)
                {
                    return _cars[position];
                }

                return null;



            }
            set
            {
                if (position < _cars.Count)
                {
                    _cars[position] = value;
                }
            }

        }
        public int Count => _cars.Count;  //быстрое свойство - позволяет быстрый доступ для чтения
        public string Name { get; set; }

        public int Add(Car car)
        {
            if (car == null)
            {
                throw new ArgumentNullException(nameof(car), "Car is null");
            }
            if (_cars.Count < MAX_CARS)
            {
                _cars.Add(car);
                return _cars.Count - 1;
            }
            return -1;

        }
        public void GoOut(string number)
        {
            if (string.IsNullOrWhiteSpace(number))
            {
                throw new ArgumentNullException(nameof(number), "Number is null");
            }

            var car = _cars.FirstOrDefault(c => c.Number == number);
            if (car != null)
            {
                _cars.Remove(car);
            }

        }

        /*public IEnumerator GetEnumerator()
        {
            var current = 0;
            for (int i = 0; i < 10; i++)
            {
                current += i;
                yield return current; // yield - можем изменить
            }
        }*/

        IEnumerator<Car> GetEnumerator() // - специальный класс специальный обЪект позволяет перебирать элементы коллекций от начала коллекции и по одному элементу переходит 
        {
            return _cars.GetEnumerator(); // точно также будет устанавливать на начальный элемент списка и будет идти 
        }

        IEnumerator IEnumerable.GetEnumerator() // нужен обязательно - ругается
        {
            return _cars.GetEnumerator();
        }

        public IEnumerable GetNames() //тип - IEnumerable обязательно для перечисления 
        {
            foreach (var car in _cars)
            {
                yield return car.Name;
            }
        }


    }
    /*public class ParkingEnumerator : IEnumerator // интерфейс который возвращает нам коллекцию. Итератор - перебор коллекции
    {
        public object Current => throw new NotImplementedException(); //указатель не текущий элемент коллекции

        public bool MoveNext()
        {
            throw new NotImplementedException();
        }

        public void Reset()
        {
            throw new NotImplementedException();
        }
    }*/

}
