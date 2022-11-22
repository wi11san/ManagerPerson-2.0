using ManagerPersonAPI.Models;
using ManagerPersonAPI.Services;
using ManagerPersonAPI.Services.ServicesInterfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ManagerPersonAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private IPersonService _service;
        public PersonController()
        {
            _service = new PersonService();
        }

        [HttpGet]
        public IActionResult ListAll()
        {
            return Ok(_service.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult FindById(int id)
        {
            return Ok(_service.GetById(id));
        }

        [HttpPost]
        public IActionResult SavePerson([FromBody] Person person)
        {
            _service.InsertPerson(person);
            return Ok(person);
        }

        [HttpPut]
        public IActionResult UpdatePerson([FromBody] Person person)
        {
            _service.UpdatePerson(person);
            return Ok(person);
        }

        [HttpDelete("{id}")]
        public IActionResult DeletePerson(int id)
        {
            _service.DeletePerson(id);
            return NoContent();
        }
    }
}
