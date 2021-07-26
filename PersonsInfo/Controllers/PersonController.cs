using Core.Application.Dtos;
using Core.Application.Filters;
using Core.Application.Interfaces;
using Core.Application.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Presentation.PersonsInfoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly PersonService personService;
    
        public PersonController(PersonService personService)
        {
            this.personService = personService;
    
        }
     
        [HttpGet("GetPeopleWithFastSearch")]
        public async Task<IActionResult> GetPeopleWithFastSearch([FromQuery] PersonFastFilter personFastFilter)
        {
            var result = await personService.GetPeopleWithFastSearch(personFastFilter);
            return Ok(result);
        }

        [HttpGet("GetPeopleWithDetailSearch")]
        public async Task<IActionResult> GetPeopleWithDetailSearch([FromQuery] PersonDetailFilter personDetailFilter)
        {
            var result = await personService.GetPeopleWithDetailSearch(personDetailFilter);
            return Ok(result);
        }

        // GET api/<PersonController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await personService.GetPersonById(id);
            return Ok(result);
        }

        // POST api/<PersonController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AddPersonDto addPerssonDto)
        {

            await personService.Add(addPerssonDto);
            return Ok();
        }

        // PUT api/<PersonController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] UpdatePersonDto updatePersonDto)
        {
            await personService.Update(id, updatePersonDto);
            return Ok();
        }


        // DELETE api/<PersonController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await personService.Delete(id);
            return Ok();
        }


        [HttpPost("UploadPictue")]
        public async Task<IActionResult> AddPicture([FromForm] UploadPictureDto uploadPictureDto)
        {
            await personService.UploadPicture(uploadPictureDto);
            return Ok();
        }

        [HttpPost("RelatedPerson")]
        public  async Task< IActionResult> AddRelatedPerson([FromBody] AddPersonRelationDto personRelationDto)
        {
           await personService.AddRelatedPerson(personRelationDto);
            return Ok();
        }


        [HttpPost("NewRelatedPerson")]
        public async Task<IActionResult> AddNewRelatedPerson([FromBody] PersonRilationDto personRilationDto)
        {
            await personService.AddNewRelatedPerson(personRilationDto);
            return Ok();
        }
        [HttpDelete("RelatedPerson")]
        public async Task<IActionResult> DeleteRelatedPerson([FromQuery] int personId ,int relatedPersonId)
        {
            await personService.DeleteRelatedPerson(personId, relatedPersonId);
            return Ok();
        }

    }
}

