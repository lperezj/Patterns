using System;
using System.Threading.Tasks;
using Exercises;
using Patterns;
using Patterns.Decorator;
using Patterns.Factories;

namespace Main
{
    class Program
    {
        enum Pattern
        {
            Fluent,
            Factory,
            Decorator
        }

        static async Task Main(string[] args)
        {

            var patterToExecute = Pattern.Decorator;

            switch (patterToExecute)
            {
                case Pattern.Fluent:
                    #region Fluent Pattern

                    var luis1 = PersonSimple.New.Called("Luis Perez").WorkAsA("Xamarin Tech Lead").Build();

                    Console.WriteLine(luis1);

                    Patterns.Person me = new PersonBuilder().identity.Me("Luis", "Perez Jimenez")
                                                   .works.At("Cognizant").AsA("Xamarin Tech Lead").Income(2019)
                                                   .lives.In("Madrid").At("Rafaela Bonilla").WithPostCode("28028");

                    Console.WriteLine(me);


                    var cb = new Builder("Person").AddField("Name", "string").AddField("Age", "int");
                    Console.WriteLine(cb);

                    #endregion
                    break;
                case Pattern.Factory:
                    #region Factories
                    //var point = Point.Factory.NewPolarPoint(1, Math.PI / 2);
                    //Console.WriteLine(point);


                    //var pointAsync = await PointAsync.CreateAsync(4, 6);
                    //Console.WriteLine(pointAsync);

                    //var machine = new HotDrinkMachine();
                    //var drink = machine.MakeDrink(HotDrinkMachine.AvailaleDrink.Coffe, 250);

                    //drink.Consume();

                    var machine = new HotDrinkMachine();
                    var drink = machine.MakeDrink();

                    drink.Consume();

                    #endregion
                    break;

                case Pattern.Decorator:
                    CodeBuilder s = "hello ";
                    s += "world"; 
                    Console.WriteLine(s);
                    break;

            }
        }
    }
}
