using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class ExtendedDictionaryElement<T, U, V>
    {

        public T Key { get; }

        public U Value1 { get; }

        public V Value2 { get; }

        public ExtendedDictionaryElement(T key, U value1, V value2)
        {
            Key = key;
            Value1 = value1;
            Value2 = value2;
        }


    }


    public class ExtendedDictionary<T, U, V> : IEnumerable<ExtendedDictionaryElement<T, U, V>>
    {
        // Використовуємо List для зручного роботою елементами

        private List<ExtendedDictionaryElement<T, U, V>> _items = new List<ExtendedDictionaryElement<T, U, V>>();


        public int Count
        {
            get { return _items.Count; }
        }

        public bool Add(T key, U value1, V value2)
        {

            if (ContainsKey(key))
            {
                // Якщо ключ вже існує, не додаємо і повертаємо false
                return false;
            }

            // Створюємо новий елемент і додаємо до списку
            var newElement = new ExtendedDictionaryElement<T, U, V>(key, value1, value2);
            _items.Add(newElement);
            return true;
        }


        /// Видаляє елемент зі словника за заданим ключем.
        public bool Remove(T key)
        {


            var elementToRemove = _items.FirstOrDefault(item => item.Key.Equals(key));

            if (elementToRemove != null)
            {
                // Якщо елемент знайдено, видаляємо його
                _items.Remove(elementToRemove);
                return true;
            }

            // Елемент не знайдено
            return false;
        }


        /// Перевіряє наявність елемента із заданим ключем.
        public bool ContainsKey(T key)
        {
            // чи існує хоча б один елемент, що відповідає умові
            return _items.Any(item => item.Key.Equals(key));
        }


        /// Перевіряє наявність елемента із заданою парою значень.
        public bool ContainsValues(U value1, V value2)
        {
            // обробляємо null-значення
            Func<U, U, bool> val1Equals = (a, b) => a != null ? a.Equals(b) : b == null;
            Func<V, V, bool> val2Equals = (a, b) => a != null ? a.Equals(b) : b == null;

            return _items.Any(item =>
                val1Equals(item.Value1, value1) &&
                val2Equals(item.Value2, value2)
            );
        }


        // ExpandedDictionary.cs (Виправлений індексатор)
        public ExtendedDictionaryElement<T, U, V> this[T key]
        {
            get
            {
                var element = _items.FirstOrDefault(item => item.Key.Equals(key));
                if (element == null)
                {
                    // Замість Console.WriteLine викидаємо стандартну помилку
                    throw new KeyNotFoundException($"Ключ '{key}' не знайдено у словнику.");
                }
                return element;
            }
        }


        // Реалізація IEnumerable для підтримки foreach 
        // Повертає перелічувач, який ітерує по колекції.
        public IEnumerator<ExtendedDictionaryElement<T, U, V>> GetEnumerator()
        {
            // повертаємо перелічувач нашого внутрішнього списку
            return _items.GetEnumerator();
        }


        /// Повертає перелічувач для сумісності зі минулим кодом
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
