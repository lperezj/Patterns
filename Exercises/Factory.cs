using System;
using System.Collections.Generic;
using Exercises;
using NUnit.Framework;

namespace Exercises
{ 
    public class PersonFactory
    {
        private int id = 0;

        public Person CreatePerson(string name)
        {
            return new Person(id++, name);
        }
    }

    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Person(int id, string name)
        {
            this.Id = id;
            this.Name = name;
        }
    }
}

namespace Exercise.UnitTests
{
    [TestFixture]
    public class FirstTestSuite
    {
        [Test]
        public void Test()
        {
            var pf = new PersonFactory();

            var p1 = pf.CreatePerson("Luis");
            Assert.That(p1.Name, Is.EqualTo("Luis"));
            Assert.That(p1.Id, Is.EqualTo(0));

            var p2 = pf.CreatePerson("Paloma");
            Assert.That(p2.Id, Is.EqualTo(1));
        }
    }
}
