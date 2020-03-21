using System;
using Exercises;
using Patterns;

namespace Main
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Fluent Pattern

            var luis1 = PersonSimple.New.Called("Luis Perez").WorkAsA("Xamarin Tech Lead").Build();

            Console.WriteLine(luis1);

            Person me = new PersonBuilder().identity.Me("Luis", "Perez Jimenez")
                                           .works.At("Cognizant").AsA("Xamarin Tech Lead").Income(2019)
                                           .lives.In("Madrid").At("Rafaela Bonilla").WithPostCode("28028");

            Console.WriteLine(me);


            var cb = new CodeBuilder("Person").AddField("Name", "string").AddField("Age", "int");
            Console.WriteLine(cb);

            #endregion
        }
    }
}
