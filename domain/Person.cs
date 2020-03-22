using System;
using System.Collections.Generic;
using System.Text;

namespace csharp_concepts.domain
{
    class Person : IEquatable<Person>
    {
        private string id, name;
        private int age;
        private Gender gender;
        private List<long> phoneNumbers;

        public Person(string id, string name, Gender gender, int age)
        {
            this.id = id;
            this.name = name;
            this.gender = gender;
            this.age = age;
        }

        public Person(string id, string name, Gender gender, int age, List<long> phoneNumbers)
        {
            this.id = id;
            this.name = name;
            this.gender = gender;
            this.age = age;
            this.phoneNumbers = phoneNumbers;
        }

        public List<long> PhoneNumbers
        {
            get { return this.phoneNumbers; }
            set { this.phoneNumbers = value; }
        }

        public string GetName()
        {
            return this.name;
        }

        public int GetAge()
        {
            return this.age;
        }

        public string GetID()
        {
            return this.id;
        }

        public Gender GetGender()
        {
            return this.gender;
        }

        public bool Equals(Person other)
        {
            if (other == null)
            {
                return false;
            }
            else if (this.id.CompareTo(other.id) == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public override string ToString()
        {
            return $"name is {this.name}";
        }
    }
}
