using Coding.Exercise;
using System;
using System.Collections.Generic;
using System.Text;

namespace Coding.Exercise
{
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    //your code here
    public class PersonFactory
    {
        private readonly List<WeakReference<Person>> persons =
            new List<WeakReference<Person>>();
        public Person CreatePerson(string Name)
        {
            Person person = new Person()
            {
                Id = persons.Count,
                Name = Name
            };
            persons.Add(new WeakReference<Person>(person));
            return person;
        }
        public string Info
        {
            get
            {
                StringBuilder sb = new StringBuilder();
                foreach (var person in persons)
                {
                    if (person.TryGetTarget(out var target))
                    {
                        sb.AppendLine($"{target.Id} {target.Name}");
                    }
                }
                return sb.ToString();
            }
        }

    }
    
}

class Program
{

    static void Main(string[] args)
    {
        var factory = new PersonFactory();
        var person0 = factory.CreatePerson("DoanVan");
        var person1 = factory.CreatePerson("CongDanh");
        var person2 = factory.CreatePerson("MinhDuc"); 
        var person3 = factory.CreatePerson("MinhHoang");    
        Console.WriteLine(factory.Info);                
    }
    //end your code
}

