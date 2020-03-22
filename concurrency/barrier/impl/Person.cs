using System;
using System.Collections.Generic;
using System.Text;

namespace csharp_concepts.concurrency.barrier.impl
{
    public class Person
    {
        private string name;

        public Person(string name)
        {
            this.name = name;
        }

        public override bool Equals(object obj)
        {
            return obj is Person person &&
                   name == person.name;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(name);
        }

        public string GetName()
        {
            return name;
        }
    }
}
