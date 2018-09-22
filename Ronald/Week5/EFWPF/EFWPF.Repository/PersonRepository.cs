using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFWPF.Data;
using EFWPF.Repository.Abstract;

namespace EFWPF.Repository
{
    public class PersonRepository : IPersonRepository
    {
        private readonly EfWpfDbContext _context;

        public PersonRepository()
        {
            _context = new EfWpfDbContext();
        }


        public int CreatePerson(Person person)
        {
            // todo: validatie
            _context.Person.Add(person);
            _context.SaveChanges();
            return person.Id;
        }

        public ObservableCollection<Person> GetPeople()
        {
            var persons = new ObservableCollection<Person>(_context.Person);
            return persons;
        }
    }
}
