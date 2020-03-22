using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using csharp_concepts.domain;

namespace csharp_concepts.collection
{
    public class Collections
    {
        public static void list() {
            var numbers = new List<short> { 1, 2, 3, 4, 5 };
            numbers.ForEach(number => Console.WriteLine($"The element is {number}"));
            var evenNumbers = numbers.FindAll((number) => number % 2 == 0);
            Console.WriteLine(evenNumbers.Count);

        }


        public static void map()
        {
            var stateNameToCapital = new Dictionary<string, string>();
            stateNameToCapital.Add("Assam", "Dispur");
            stateNameToCapital.Add("Karnataka", "Bangalore");
            var capital = stateNameToCapital.GetValueOrDefault("Kerela", "Not found");
            Console.WriteLine(capital);
        }

        public static void set()
        {

            Person sameer = new Person("1", "sameer", Gender.MALE, 30);
            Person mayuri = new Person("2", "mayuri", Gender.FEMALE, 30);
            var people = new HashSet<Person> { sameer, mayuri, sameer };
            Console.WriteLine(people.Count);

        }

        public static void linqUsingDSL()
        {
            List<int> scores = new List<int> { 90, 92, 85, 75, 79 };
            IEnumerable<int> highScoresQuery =
            from score in scores
            where score > 80
            orderby score descending
            select score;

            List<int> premium = highScoresQuery.ToList();
            premium.ForEach(number => Console.WriteLine($"The element is {number}"));
        }

        public static void linqUsingMethods()
        {
            List<int> scores = new List<int> { 90, 92, 85, 75, 79 };
            List<int> premium = scores.Distinct().TakeWhile((number) => number > 80).OrderBy((number) => number).ToList();
            premium.ForEach(number => Console.WriteLine($"The element is {number}"));
            var totalScore = scores.Aggregate(0, (total, current) => total + current);
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"the total score is {totalScore}");

            Person sameer = new Person("1", "sameer", Gender.MALE, 30);
            sameer.PhoneNumbers = new List<long> { 1234, 3465 };
            Person mayuri = new Person("2", "mayuri", Gender.FEMALE, 30);
            mayuri.PhoneNumbers = new List<long> { 976, 643536 };
            Person kanta = new Person("3", "kanta", Gender.FEMALE, 32);
            Person panda = new Person(id: "4", name: "panda", gender: Gender.MALE, age: 28);
            List<Person> people = new List<Person> { sameer, mayuri, kanta, panda };
            List<string> maleNames = people.Where((person) => person.GetGender() == Gender.MALE).Select((person) => person.GetName()).ToList();
            maleNames.ForEach((name) => Console.WriteLine($"the name is : {name}"));
            Console.ForegroundColor = ConsoleColor.Green;
            var groupedByGender = people.GroupBy((person) => person.GetGender());
            groupedByGender.ToList().ForEach(entry => {
                var oldestInGroup = entry.AsEnumerable().OrderByDescending((person) => person.GetAge()).First();
                Console.WriteLine($"The oldest in {entry.Key} is { oldestInGroup.GetName() }");
            });
            Console.ForegroundColor = ConsoleColor.Gray;
            var allContactNumbers = people.SelectMany((person) => {
                if (person.PhoneNumbers == null || person.PhoneNumbers.Count == 0)
                {
                    Console.WriteLine("No contact numbers");
                    return new List<long>();
                }
                return person.PhoneNumbers;
            });
            foreach (long phNum in allContactNumbers.ToList())
            {
                Console.WriteLine(phNum);
            }
        }
    }
}
