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

        }
    }
    public enum category
    {
        Food = 1,
        ForHome = 2,
        Alcohol = 3,
        Other = 4,
    }

    public class Store
    {

        public int ID { get; private set; }
        public string Name { get; private set; }
        public int Cost { get; private set; }
        public int Count { get; private set; }
        public bool Sklad { get; private set; }
        public category Category;

        public int GenereteID()
        {
            int ID = 1;
            return ID++;
        }

        public string GetName(string name)
        {
            Name = name;
            return Name;
        }
        public int GetCost(int cost)
        {
            Cost = cost;
            return Cost;
        }
        public int GetCount(int count)
        {
            Count = count;
            return Count;
        }

        public void InSklad(int l)
        {
            if (Count == 0)
            {
                Sklad = false;
            }
            else if (Count > 0)
            {
                Sklad = true;
            }
        }

        

    }
}
