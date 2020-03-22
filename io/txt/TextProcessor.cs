using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using csharp_concepts.domain;

namespace csharp_concepts.io.txt
{
    class TextProcessor
    {
        public static void process() {
            StreamReader personsStream = new StreamReader("./../../../io/files/persons.txt");

            bool isRowValid(string row)
            {
                string[] columns = row.Split(",");
                if (columns.Length == 8)
                {
                    foreach (string column in columns)
                    {
                        if (string.IsNullOrEmpty(column))
                            return false;
                    }
                    return true;
                }
                else
                    return false;
            }

            Person convertRowToPerson(string row)
            {
                string[] columns = row.Split(",");
                string name = $"{columns[1]} {columns[2]}";
                Gender gender = columns[3] == "Female" ? Gender.FEMALE : Gender.MALE;
                int age = int.Parse(columns[5]);
                string id = columns[7];
                return new Person(name: name, age: age, gender: gender, id: id);
            }

            string row;
            List<string> rows = new List<string>();
            while ((row = personsStream.ReadLine()) != null)
            {
                rows.Add(row);
            }
            List<Person> people = rows.FindAll(isRowValid).ConvertAll(convertRowToPerson);
            Console.WriteLine(people.Count);
        }
    }
}
