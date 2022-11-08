using APIhomework2.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APIhomework2.Models;
using Microsoft.AspNetCore.Mvc;

namespace APIhomework2.Controllers
{
    [Route("api")]
    public class PersonController : ControllerBase
    {

        private static PersonRepository _repository = null;

        public PersonController(PersonRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        [Route("persons")]
        public IActionResult GetPaging([FromQuery] int skip, [FromQuery] int take)
        {
            return Ok(_repository.GetPaging(skip, take));
        }

        [HttpGet]
        [Route("persons/search")]
        public IActionResult GetByName([FromQuery] string searchTerm)
        {
            return Ok(_repository.GetByName(searchTerm));
        }

        [HttpGet]
        [Route("persons/{id}")]
        public IActionResult GetById([FromRoute] int id)
        {
            return Ok(_repository.GetById(id));
        }

        [HttpPost]
        [Route("persons")]
        public IActionResult CreateNew([FromBody] Person newPerson)
        {
            _repository.CreateNew(newPerson);
            return Ok("Data updated.");
        }

        [HttpPut]
        [Route("persons")]
        public IActionResult UpdateExisting(int id, [FromBody] Person newPerson)
        {
            _repository.UpdateExisting(id, newPerson);
            return Ok("Data updated.");
        }

        [HttpDelete]
        [Route("persons/{id}")]
        public IActionResult DeleteExisting([FromRoute] int id)
        {
            _repository.DeleteExisting(id);
            return Ok("Data deleted.");
        }
    }
}
