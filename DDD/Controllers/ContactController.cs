using Microsoft.AspNetCore.Mvc;
using Phonebook.Api.DTOs;
using Phonebook.Api.Service.Abs;

namespace Phonebook.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContactController : ControllerBase
    {
        private readonly IPhoneBookService _phonebookService;
        public ContactController(IPhoneBookService service)
        {
            _phonebookService = service;
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] CreateDTO createDTO)
        {
            await _phonebookService.Createasync(createDTO);
            return Ok();
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var dataAll = await _phonebookService.GetAllAsync();

            if (dataAll.Count == 0)
                return NoContent();

            return Ok(dataAll);
        }

        [HttpGet("GetById/{id}")]
        public async Task<ActionResult<GetByIdDto>> GetById([FromRoute] int id)
        {
            var data = await _phonebookService.GetByIdAsync(id);
            if (data == null)
                return BadRequest("Phonebook not found");

            return Ok(new GetByIdDto
            {
                Id = data.Id,
                PhoneNumber = data.PhoneNumber
            });
        }
        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var result = await _phonebookService.DeleteAsync(id);
            if (!result)
                return NotFound();
            return Ok();
        }
    }
}
