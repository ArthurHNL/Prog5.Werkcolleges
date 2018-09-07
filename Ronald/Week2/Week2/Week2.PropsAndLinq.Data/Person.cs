using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week2.PropsAndLinq.Data
{
    public class Person
    {
        public Person()
        {
        }


        public string Name { get; set; }
        public Gender Gender { get; set; }

        public List<Person> GetPeople()
        {
            return new List<Person>
            {
                new Person{ Name = "Ronald", Gender = Gender.Male},
                new Person{ Name = "Jasper", Gender = Gender.Male},
                new Person{ Name = "Roland", Gender = Gender.Male},
                new Person{ Name = "Stijn", Gender = Gender.Male},
                new Person{ Name = "Piet", Gender = Gender.Male},
                new Person{ Name = "Anne", Gender = Gender.Female},
                new Person{ Name = "Laura", Gender = Gender.Female},
                new Person{ Name = "Margot", Gender = Gender.Female},
                new Person{ Name = "Pino", Gender = Gender.Unknown},
                new Person{ Name = "Elmo", Gender = Gender.Unknown},
            }; ;
        }
    }
}
