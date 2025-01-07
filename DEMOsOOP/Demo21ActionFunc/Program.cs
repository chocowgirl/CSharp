﻿using Demo21ActionFunc.Models;
using System.Diagnostics;

namespace Demo21ActionFunc
{
    public delegate bool  Condition(Product p);
    public delegate List<Product> Filtre(Condition condition);

    internal class Program
    {
        static void Main(string[] args)
        {
            List<Product> shop = new List<Product>()
            {
                new Product("Pull de Noel", 29.99M),
                new Product("Casque Gaming", 149.99M),
                new Product("Jeux de société", 24.99M),
                new Product("Cartes à jouer", 49.99M),
                new Product("Cartes de tarot", 12.50M),
            };

            Func<Func<Product,bool>,List<Product>> fonctionFiltre = delegate (Func<Product,bool> conditionFiltre)
            {
                List<Product> result = new List<Product>();
                foreach (Product p in shop)
                {
                    if (conditionFiltre(p)) result.Add(p);
                }
                return result;
            };

            Func<Product, bool> conditionPrix = delegate (Product p)
            {
                return p.Price < 50M;
            };

            foreach (Product p in fonctionFiltre(conditionPrix))
            {
                Console.WriteLine($"{p.Name} : {p.Price} Euro(s)");
            }

            Action<string> cw = Test 01;
        }
        static void Test01(string message)
        {
            Console.WriteLine(message);
        }
    }
    //petit test Action or Func

    public delegate void Delegate01(string s, int i);
    //Action<string, int>

    public delegate void Delegate02(bool b, int i, string s);
    //Action<bool, int, string>

    public delegate bool Delegate03(string s);
    //Func<string, bool> //d'abord parametres, puis le type de retour

    public delegate object Delegate04(object o);
    //Func<object, ojbect>

    public delegate object Delegate05(object o, object o2);
    //Func<object, object, object>

    public delegate void Delegate06(int i, int i2, int i3);
    //Action<int, int, int>

    public delegate string Delegate07();
    //Func<string>

    public delegate void Delegate08();
    //Action

    public delegate double Delegate09(string s, int i);
    //Func<string, int, double>

    public delegate bool Delegate10<T>(T arg);
    //Func<T, bool>

    //public delegate bool Condition(Product p);
    //Func<Product, bool>
    //public delegate List<Product> Filtre(Condition condition);
    //Func<Condition, List<Product>>
    //Func<Func<Product, bool>, List<Product>> //this one is more correct because it eliminates the need for the creation of the other delegate
}
