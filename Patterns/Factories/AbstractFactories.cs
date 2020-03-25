using System;
using System.Collections.Generic;
using Patterns.Factories.HotMachine;

namespace Patterns.Factories
{
    internal class Tea : IHotDrinks
    {
        public void Consume()
        {
            Console.WriteLine("Drinking Tea...");
        }
    }

    internal class Coffe : IHotDrinks
    {
        public void Consume()
        {
            Console.WriteLine("Drinking Coffe...");
        }
    }

    internal class TeaFactory : IHotDrinkFactory
    {
        public IHotDrinks Prepare(int amount)
        {
            Console.WriteLine($"Put in a tea bug, boil wate, pour {amount} ml, add lemon, enjoy!!!");
            return new Tea();
        }
    }

    internal class CoffeFactory : IHotDrinkFactory
    {
        public IHotDrinks Prepare(int amount)
        {
            Console.WriteLine($"Grind some beans, boil wate, pour {amount} ml, add cream, enjoy!!!");
            return new Coffe();
        }
    }

    public class HotDrinkMachine
    {
        //public enum AvailaleDrink
        //{
        //    Coffe,
        //    Tea
        //}

        //private Dictionary<AvailaleDrink, IHotDrinkFactory> factories = new Dictionary<AvailaleDrink, IHotDrinkFactory>();

        //public HotDrinkMachine()
        //{
        //    factories.Add(AvailaleDrink.Tea, new TeaFactory());
        //    factories.Add(AvailaleDrink.Coffe, new CoffeFactory());
        //}

        //public IHotDrinks MakeDrink(AvailaleDrink drink, int amount)
        //{
        //    return factories[drink].Prepare(amount);
        //}

        private List<Tuple<string, IHotDrinkFactory>> factories = new List<Tuple<string, IHotDrinkFactory>>();

        public HotDrinkMachine()
        {
            foreach (var t in typeof(HotDrinkMachine).Assembly.GetTypes())
            {
                if (typeof(IHotDrinkFactory).IsAssignableFrom(t) && !t.IsInterface)
                {
                    factories.Add(Tuple.Create(t.Name.Replace("Factory", string.Empty), (IHotDrinkFactory)Activator.CreateInstance(t)));
                }
            }
        }

        public IHotDrinks MakeDrink()
        {
            Console.WriteLine("Available drinks:");
            for (var index = 0; index < factories.Count; index++)
            {
                var tuple = factories[index];
                Console.WriteLine($"{index}: {tuple.Item1}");
            }

            while (true)
            {
                string s;
                if ((s = Console.ReadLine()) != null
                    && int.TryParse(s, out int i)
                    && i >= 0
                    && i < factories.Count)
                {
                    Console.Write("Specify amount: ");
                    s = Console.ReadLine();

                    if (s != null
                        && int.TryParse(s, out int ammount)
                        && ammount > 0)
                    {
                        return factories[i].Item2.Prepare(ammount);
                    }
                }

                Console.WriteLine("Incorrect, try again");
            }
        }
        
    }
}
