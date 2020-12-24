using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mic.PhoneBook.DataLayer.Entities;
using Mic.PhoneBook.DataLayer.Interfaces;
using Mic.PhoneBook.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Mic.PhoneBook.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhoneController : ControllerBase
    {
        private readonly IPhoneRepository _repository;

        public PhoneController(IPhoneRepository repository)
        {
            _repository = repository;
        }

        // GET: api/<ValuesController>
        [HttpGet]
        public IEnumerable<PhoneModel> Get()
        {
            var dbPhones = _repository.GetPhoneList();
            var phoneViewMode = dbPhones.Select(p => new PhoneModel()
            {
                PersonName = p.PersonName,
                PhoneNumber = p.PhoneNumber
            }).ToList();
            return phoneViewMode;
        }

        // POST api/<ValuesController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] PhoneModel model)
        {
            var phoneDbModel = new Phone()
            {
                PersonName = model.PersonName,
                PhoneNumber = model.PhoneNumber
            };
           var result = await _repository.AddPhone(phoneDbModel);

           if (result)
           {
               return Ok(result);
           }

           return BadRequest(result);
        }
    }
}
