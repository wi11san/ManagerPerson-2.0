using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using ManagerPersonAPI.Models;
using Dapper;
using System.Linq;
using ManagerPersonAPI.Repositories.RepositoryInterfaces;
using System;

namespace ManagerPersonAPI.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        private IDbConnection _connection;

        public PersonRepository()
        {
            _connection = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ManagerPersonDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }

        public List<Person> GetAll()
        {
            var person = _connection.Query<Person>("FindAllPeople", commandType: CommandType.StoredProcedure);
            return person.ToList();
        }

        public Person GetById(int id)
        {
            var person = _connection.Query<Person>("FindPersonById", new { Id = id }, commandType: CommandType.StoredProcedure);
            return person.SingleOrDefault();
        }

        public void InsertPerson(Person person)
        {
            var values = new {Name = person.Name, Email = person.Email, CPF = person.CPF, Office = person.Office, Salary = person.Salary, Active = person.Active};
            _connection.Query<Person>("[InsertPerson]", values, commandType: CommandType.StoredProcedure);
        }

        public Person UpdatePerson(Person person)
        {
            var values = new {Id = person.Id, Name = person.Name, Email = person.Email, CPF = person.CPF, Office = person.Office, Salary = person.Salary, Active = person.Active };
            var exec = _connection.Query<Person>("[UpdatePerson]", values, commandType: CommandType.StoredProcedure);
            return exec.SingleOrDefault();
        }

        public void DeletePerson(int id)
        {
            _connection.Query<Person>("[DeletePerson]", new { Id = id }, commandType: CommandType.StoredProcedure);
        }
    }
}
