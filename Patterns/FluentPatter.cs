using System;

namespace Patterns
{
    public class PersonSimple
    {
        public string Name;
        public string Position;

        public class Builder : PersonSimpleJobBuilder<Builder>
        {

        }

        public static Builder New => new Builder();

        public override string ToString()
        {
            return $"{nameof(Name)}: {Name}, {nameof(Position)}: {Position}";
        }
    }

    public abstract class PersonSimpleBuilder
    {
        protected PersonSimple p = new PersonSimple();

        public PersonSimple Build()
        {
            return p;
        }
    }

    public class PersonSimpleInfoBuilder<T> : PersonSimpleBuilder where T : PersonSimpleInfoBuilder<T>
    {
        public T Called(string name)
        {
            p.Name = name;
            return (T)this;
        }
    }

    public class PersonSimpleJobBuilder<T> : PersonSimpleInfoBuilder<PersonSimpleJobBuilder<T>> where T : PersonSimpleJobBuilder<T>
    {
        public T WorkAsA(string position)
        {
            p.Position = position;
            return (T)this;
        }
    }
}
