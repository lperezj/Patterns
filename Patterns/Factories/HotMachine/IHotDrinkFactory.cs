using System;
namespace Patterns.Factories.HotMachine
{
    public interface IHotDrinkFactory
    {
        IHotDrinks Prepare(int amount);
    }
}
