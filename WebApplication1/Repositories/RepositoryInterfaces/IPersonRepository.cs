using System.Collections.Generic;
using ManagerPersonAPI.Models;

namespace ManagerPersonAPI.Repositories.RepositoryInterfaces
{
    public interface IPersonRepository
    {
        Person GetById(int id);
        List<Person> GetAll();
        void InsertPerson(Person person);
        Person UpdatePerson(Person person);
        void DeletePerson(int id);
    }
}
