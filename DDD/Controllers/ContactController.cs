using Microsoft.AspNetCore.Mvc;
using Phonebook.Application.Service;
using Phonebook.Infrastructure.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Phonebook.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContactController : ControllerBase  
    {
        private readonly PhonebookService _phonebookService;
        public ContactController(PhonebookService service)
        {
            _phonebookService = service;
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] CreateDTO createDTO)
        {
            await _phonebookService.Create(createDTO);
            return Ok(); 
        }

        [HttpGet("GetAll")]
        public async Task<List<GetAllDto>> GetAll()
        {
            var dataAll = await _phonebookService.GetAll();

            var result = new List<GetAllDto>();
            foreach (var item in dataAll)
            {
                result.Add(new GetAllDto
                {
                    Id = item.Id,
                    PhoneNumber = item.PhoneNumber,
                });
            }

            return result;
        }

        [HttpGet("GetById/{id}")]
        public async Task<ActionResult<GetByIdDto>> GetById([FromRoute] int id)
        {
            var data = await _phonebookService.GetById(id);
            if (data == null)
                return NotFound();

            return Ok(new GetByIdDto
            {
                Id = data.Id,
                PhoneNumber = data.PhoneNumber
            });
        }
        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var result = await _phonebookService.Delete(id);
            if (!result)
                return NotFound();
            return Ok();
        }
    }
}
