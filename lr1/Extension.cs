using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ConsoleApp1
{
    public static class StringExtension
    {
        public static int WordCount(this string str, char c)/// підрахунок кількості входжень заданого у параметрі символа у рядок. 
        {
            int counter = 0;
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == c)
                    counter++;
            }
            return counter;
        }
        public static string Invert(this string str)
        {
            if (string.IsNullOrEmpty(str)) return str;

            // Використання char array для O(n) швидкості
            char[] charArray = str.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }
    }

        public static class ArrayExtensions
        {
            public static int Search<T>(this T[] array, T elemFind) where T : IComparable<T>
            {
                if (array == null)
                {
                    return 0;
                }

                int count = 0;
                foreach (T element in array)
                {

                    // Він повертає 0, якщо елементи рівні.
                    if (element != null && element.CompareTo(elemFind) == 0)
                    {
                        count++;
                    }
                }
                return count;
            }


            public static void Print<T>(this T[] array) where T : IComparable<T>
            {
                //простий вивід масиву

                foreach (T element in array)
                {

                    Console.Write(element + " ");

                }
                Console.Write("\n");
            }


            public static T[] GetUnique<T>(this T[] array)
            {
                if (array == null)
                {
                    return new T[0]; // Повертаємо порожній масив
                }

                List<T> uniqueList = new List<T>();

                foreach (T element in array)
                {

                    if (!uniqueList.Contains(element))
                    {
                        uniqueList.Add(element);
                    }
                }

                return uniqueList.ToArray();

            }
        }
    }
