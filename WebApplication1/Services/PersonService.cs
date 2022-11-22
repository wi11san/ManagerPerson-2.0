using System.Collections.Generic;
using System.Linq;
using ManagerPersonAPI.Models;
using ManagerPersonAPI.Repositories;
using ManagerPersonAPI.Repositories.RepositoryInterfaces;
using ManagerPersonAPI.Services.ServicesInterfaces;

namespace ManagerPersonAPI.Services
{
    public class PersonService : IPersonService
    {
        private readonly IPersonRepository _repository;
        public PersonService()
        {
            _repository = new PersonRepository();
        }

        public List<Person> GetAll()
        {
            return _repository.GetAll();
        }

        public Person GetById(int id)
        {
            return _repository.GetById(id);
        }

        public void InsertPerson(Person person)
        {
            _repository.InsertPerson(person);
        }

        public Person UpdatePerson(Person person)
        {
            var newPerson = _repository.UpdatePerson(person);
            return newPerson;
        }

        public void DeletePerson(int id)
        {
            _repository.DeletePerson(id);
        }
    }
}
