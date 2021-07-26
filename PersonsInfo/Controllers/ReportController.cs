using Core.Application.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Presentation.PersonsInfoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        private readonly PersonService personService;

        // GET: api/<ReportController>
        public ReportController(PersonService personService)
        {
            this.personService = personService;
        }

        [HttpGet]
        public IActionResult Report()
        {
            return Ok(personService.Report());
        }
    }
}
