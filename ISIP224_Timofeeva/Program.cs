using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3ISIP_224_Timofeeva
{
    enum Category
    {
        Food = 1,
        ForHome = 2,
        Alcohol = 3,
        Other = 4
    }

    class Product
    {
        public int ID;
        public string Name;
        public int Cost;
        public int Count;
        public Category Cat;

        
        public Product(int id, string name, int cost, int count, Category cat)
        {
            ID = id;
            Name = name;
            Cost = cost;
            Count = count;
            Cat = cat;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {


            List<Product> products = new List<Product>();
            int nextID = 1; 

            
            products.Add(new Product(nextID, "Хлеб", 45, 20, Category.Food));
            nextID++;
            products.Add(new Product(nextID, "Молоко", 90, 15, Category.Food));
            nextID++;
            products.Add(new Product(nextID, "Влажные салфетки", 235, 8, Category.ForHome));
            nextID++;
            products.Add(new Product(nextID, "Вино красное", 700, 5, Category.Alcohol));
            nextID++;
            products.Add(new Product(nextID, "Батарейки AA", 320, 0, Category.Other));
            nextID++;

            while (true)
            {
                Console.WriteLine("Выберите пункт: ");
                Console.WriteLine("\n 1. Показать все товары \n 2. Добавить товар \n 3. Удалить товар \n 4. Заказать поставку \n 5. Продать товар \n 6. Поиск товара \n 0. Выход \n");
                int n = Convert.ToInt32(Console.ReadLine());
                Console.Clear();

                if (n == 0) return;

                
                if (n == 1)
                {
                    if (products.Count == 0)
                        Console.WriteLine("Список товаров пуст");

                    for (int i = 0; i < products.Count; i++)
                        Print(products[i]);
                }

                else if (n == 2)
                {
                    string name = "";
                    while (name == "")
                    {
                        Console.Write("Название: ");
                        name = Console.ReadLine().Trim();
                        if (name == "")
                            Console.WriteLine("Название не может быть пустым");
                    }
                    Console.WriteLine("Введите цену: ");
                    int cost = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Введите количество штук: ");
                    int count = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Категория: ");
                    Console.WriteLine("\n 1. Продукты \n 2. Для дома \n 3. Алкоголь \n 4. Другое \n");
                    int c = Convert.ToInt32(Console.ReadLine());

                    Category cat = Category.Other;
                    if (c == 1) cat = Category.Food;
                    else if (c == 2) cat = Category.ForHome;
                    else if (c == 3) cat = Category.Alcohol;

                    products.Add(new Product(nextID, name, cost, count, cat));
                    Console.WriteLine("\nТовар добавлен, его код: " + nextID);
                    nextID++;
                }

                
                else if (n == 3)
                {
                    for (int i = 0; i < products.Count; i++)
                        Print(products[i]);

                    Console.WriteLine("Введите код товара: ");
                    int id = Convert.ToInt32(Console.ReadLine());

                    int index = -1; 
                    for (int i = 0; i < products.Count; i++)
                        if (products[i].ID == id)
                            index = i;

                    if (index == -1)
                        Console.WriteLine("Товара с таким кодом нет");
                    else
                    {
                        Console.WriteLine("Товар \"" + products[index].Name + "\" удалён");
                        products.RemoveAt(index);
                    }
                }

                
                else if (n == 4)
                {
                    for (int i = 0; i < products.Count; i++)
                        Print(products[i]);

                    Console.WriteLine("Введите код товара: ");
                    int id = Convert.ToInt32(Console.ReadLine());

                    int index = -1;
                    for (int i = 0; i < products.Count; i++)
                        if (products[i].ID == id)
                            index = i;

                    if (index == -1)
                        Console.WriteLine("Товара с таким кодом нет");
                    else
                    {
                        Console.WriteLine("Сколько штук привезли:  ");
                        int count = Convert.ToInt32(Console.ReadLine());
                        products[index].Count = products[index].Count + count;
                        Console.WriteLine("Поставка принята, на складе стало " + products[index].Count + " шт.");
                    }
                }

                
                else if (n == 5)
                {
                    for (int i = 0; i < products.Count; i++)
                        Print(products[i]);

                    Console.WriteLine("Введите код товара: ");
                    int id = Convert.ToInt32(Console.ReadLine());

                    int index = -1;
                    for (int i = 0; i < products.Count; i++)
                        if (products[i].ID == id)
                            index = i;

                    if (index == -1)
                        Console.WriteLine("Товара с таким кодом нет");
                    else if (products[index].Count == 0)
                        Console.WriteLine("Товара \"" + products[index].Name + "\" нет на складе");
                    else
                    {
                        Console.WriteLine("Сколько штук продаем: ");
                        int count = Convert.ToInt32(Console.ReadLine());
                        
                        if (count > products[index].Count)
                            Console.WriteLine("На складе только " + products[index].Count + " шт., продажа отменена");
                        else
                        {
                            products[index].Count = products[index].Count - count;
                            Console.WriteLine("Продано " + count + " шт. на сумму " + count * products[index].Cost + " руб.");
                            Console.WriteLine("Осталось на складе: " + products[index].Count + " шт.");
                        }
                    }
                }

                
                
                else if (n == 6)
                {
                    string q = "";
                    while (q == "")
                    {
                        Console.Write("Название или часть названия: ");
                        q = Console.ReadLine().Trim().ToLower();
                    }

                    Console.WriteLine();
                    bool found = false;

                    for (int i = 0; i < products.Count; i++)
                        if (products[i].Name.ToLower().Contains(q))
                        {
                            Print(products[i]);
                            found = true;
                        }

                    if (found == false)
                        Console.WriteLine("Ничего не найдено");
                }
            }
        }

       
        static void Print(Product p)
        {
            string sklad = "нет";
            if (p.Count > 0) sklad = "да";

            string cat = "Другое";
            if (p.Cat == Category.Food) cat = "Продукты";
            else if (p.Cat == Category.ForHome) cat = "Для дома";
            else if (p.Cat == Category.Alcohol) cat = "Алкоголь";

            Console.WriteLine("Код: " + p.ID + " | " + p.Name + " | " + p.Cost + " руб. | "
                + p.Count + " шт. | категория: " + cat + " | на складе: " + sklad);
        }

        
    }
}
