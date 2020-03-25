using System;
namespace Patterns
{
    public class Person
    {
        public string FirstName, LastName;
        public string StreetAddress, PostCode, City;
        public string CompanyName, Position;
        public int AnnualIncome;

        public override string ToString()
        {
            return $"{FirstName} {LastName}:{StreetAddress} ({PostCode}) - {City} -> '{CompanyName}/{Position}' ({AnnualIncome})";
        }
    }

    public class PersonBuilder
    {
        protected Person person = new Person();
        public PersonJobBuilder works => new PersonJobBuilder(person);
        public PersonAddressBuilder lives => new PersonAddressBuilder(person);
        public PersonIdentityBuilder identity => new PersonIdentityBuilder(person);

        public static implicit operator Person(PersonBuilder pb)
        {
            return pb.person;
        }
    }

    public class PersonIdentityBuilder : PersonBuilder
    {
        public PersonIdentityBuilder(Person person)
        {
            this.person = person;
        }

        public PersonIdentityBuilder Me(string firstname, string lastname)
        {
            person.FirstName = firstname;
            person.LastName = lastname;
            return this;
        }
    }

    public class PersonAddressBuilder : PersonBuilder
    {
        public PersonAddressBuilder(Person person)
        {
            this.person = person;
        }

        public PersonAddressBuilder At(string street)
        {
            person.StreetAddress = street;
            return this;
        }

        public PersonAddressBuilder In(string city)
        {
            person.City = city;
            return this;
        }

        public PersonAddressBuilder WithPostCode(string postcode)
        {
            person.PostCode = postcode;
            return this;
        }
    }

    public class PersonJobBuilder : PersonBuilder
    {
        public PersonJobBuilder(Person person)
        {
            this.person = person;
        }

        public PersonJobBuilder At(string company)
        {
            person.CompanyName = company;
            return this;
        }

        public PersonJobBuilder AsA(string position)
        {
            person.Position = position;
            return this;
        }

        public PersonJobBuilder Income(int income)
        {
            person.AnnualIncome = income;
            return this;
        } 
    }
}
