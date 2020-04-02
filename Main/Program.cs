﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Exercises;
using Patterns;
using Patterns.Command;
using Patterns.Decorator;
using Patterns.Factories;
using Patterns.Proxy;

namespace Main
{
    public class Creature
    {
        private Property<int> agility = new Property<int>();

        public int Agility
        {
            get => agility.Value;
            set => agility.Value = value;
        }
    }

    class Program
    {
        enum Pattern
        {
            Fluent,
            Factory,
            Decorator,
            Proxy,
            Command
        }

        static async Task Main(string[] args)
        {

            var patterToExecute = Pattern.Command;

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
                    // Uncomment AbstractFactories class

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

                case Pattern.Proxy:
                    #region Proxy Protect
                    ICar car1 = new CarProxy(new Driver(12)); 
                    car1.Drive();
                    ICar car2 = new CarProxy(new Driver(22));
                    car2.Drive();
                    #endregion

                    #region Proxy Property
                    var c = new Creature();
                    c.Agility = 10; // c.set_Agility(10) xxxxxxxxxxxxx
                                    // c.Agility = new Property<int>(10)
                    c.Agility = 10; // --> Not asigned
                    #endregion
                    break;

                case Pattern.Command:
                    #region Command
                    var ba = new Patterns.Command.BankAccount();
                    var commands = new List<BankAccountCommand>
                    {
                        new BankAccountCommand(ba,BankAccountCommand.Action.Deposit, 100),
                        new BankAccountCommand(ba, BankAccountCommand.Action.Withdraw, 1000)
                    };

                    Console.WriteLine(ba);

                    foreach(var comm in commands)
                    {
                        comm.Call();
                    }

                    Console.WriteLine(ba);

                    foreach (var comm in Enumerable.Reverse(commands))
                    {
                        comm.Undo();
                    }

                    Console.WriteLine(ba);
                    break;
                #endregion
            }
        }
    }
}
