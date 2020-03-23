using System;
using System.Collections.Generic;
using System.Text;
using csharp_concepts.domain;
using csharp_concepts.io.txt;

namespace csharp_concepts
{
    public class YieldPeople
    {
        private static List<Person> people = TextProcessor.process();

        public static void yieldPerson() {
            Predicate<Person> predicate = (person) => person.GetAge() > 50;
            foreach(Person person in GetFilteredPeople(predicate))
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine($"{person.GetName()} received");
            }


        }

        public static IEnumerable<Person> GetFilteredPeople(Predicate<Person> predicate) { 
        
            foreach(Person person in people){
                if (predicate.Invoke(person)) {
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                    Console.WriteLine($"{person.GetName()} returned from yield block");
                    yield return person;
                }
            }
        }
    }
}
