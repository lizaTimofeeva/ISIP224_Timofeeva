using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3ISIP_224_Timofeeva
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int count = 0;
            while (count < 2 || count > 40)
            {
                Console.WriteLine("Сколько трат внести (от 2 до 40)? ");
                count = Convert.ToInt32(Console.ReadLine());
            }

            string[] names = new string[count];
            int[] prices = new int[count];

            Console.WriteLine("\nВводите траты по шаблону (Название; Сумма)\n");
            for (int i = 0; i < count; i++)
            {
                Console.Write("Операция " + (i + 1) + ": ");
                string[] parts = Console.ReadLine().Replace("(", "").Replace(")", "").Split(';');
                names[i] = parts[0].Trim();
                prices[i] = Convert.ToInt32(parts[1].Trim());
            }
            while (true)
            {
                Console.WriteLine("\n 1. Вывод данных \n 2. Статистика \n 3. Сортировка по цене \n 4. Конвертация валюты \n 5. Поиск по названию \n 0. Выход \n");
                int n = Convert.ToInt32(Console.ReadLine());
                Console.Clear();

                if (n == 1)
                {
                    for (int i = 0; i < count; i++)
                        Console.WriteLine(names[i] + " - " + prices[i] + " руб.");
                }
                else if (n == 2)
                {
                    int sum = 0, max = prices[0], min = prices[0];
                    for (int i = 0; i < count; i++)
                    {
                        sum += prices[i];
                        if (prices[i] > max) max = prices[i];
                        if (prices[i] < min) min = prices[i];
                    }
                    Console.WriteLine("Сумма: " + sum + " руб.");
                    Console.WriteLine("Среднее: " + Math.Round((double)sum / count, 2) + " руб.");
                    Console.WriteLine("Максимум: " + max + " руб.");
                    Console.WriteLine("Минимум: " + min + " руб.");
                }
                else if (n == 3)
                {
                    for (int i = 0; i < count - 1; i++)
                        for (int j = 0; j < count - 1 - i; j++)
                            if (prices[j] > prices[j + 1])
                            {
                                int t = prices[j]; prices[j] = prices[j + 1]; prices[j + 1] = t;
                                string s = names[j]; names[j] = names[j + 1]; names[j + 1] = s;
                            }

                    for (int i = 0; i < count; i++)
                        Console.WriteLine(names[i] + " - " + prices[i] + " руб.");
                }
                else if (n == 4)
                {
                    Console.WriteLine(" 1. Доллар (90) \n 2. Евро (100) \n 3. Юань (12) \n");
                    int c = Convert.ToInt32(Console.ReadLine());

                    double rate = 0;
                    string valuta = "";
                    if (c == 1) { rate = 90; valuta = "$"; }
                    else if (c == 2) { rate = 100; valuta = "€"; }
                    else if (c == 3) { rate = 12; valuta = "¥"; }
                    else { Console.WriteLine("Неизвестная валюта"); continue; }

                    for (int i = 0; i < count; i++)
                        Console.WriteLine(names[i] + " - " + Math.Round(prices[i] / rate, 2) + " " + valuta);
                }
                else if (n == 5)
                {
                    Console.WriteLine("Введите название: ");
                    string q = Console.ReadLine().ToLower();

                    for (int i = 0; i < count; i++)
                        if (names[i].ToLower().Contains(q))
                            Console.WriteLine(names[i] + " - " + prices[i] + " руб.");
                }
                else if (n == 0) return;
                else Console.WriteLine("Неизвестная функция");

            }
        }
    }
}
