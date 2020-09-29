using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Models.EFModels;
using WebAPI.Context;
using Microsoft.EntityFrameworkCore;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PhoneContactController : Controller
    {
        readonly ApplicationDbContext _applicationDbContext;  

        public PhoneContactController(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        [HttpGet]
        public async Task<IEnumerable<PhoneContact>> Get()
        {
            return await _applicationDbContext.PhoneContacts.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PhoneContact>> GetPhoneContact(int id)
        {
            var phoneContact = await _applicationDbContext.PhoneContacts.FindAsync(id);

            if (phoneContact == null)
                return NotFound();

            return phoneContact;
                   
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<PhoneContact>> DeletePhoneContact(int id)
        {
            var phoneContact = await _applicationDbContext.PhoneContacts.FindAsync(id);
            if (phoneContact == null)
                return NotFound();

            _applicationDbContext.PhoneContacts.Remove(phoneContact);
            await _applicationDbContext.SaveChangesAsync();

            return phoneContact;
        }

        [HttpPost]
        public async Task<ActionResult<PhoneContact>> PostPhoneContact(PhoneContact phoneContact)
        {
            _applicationDbContext.PhoneContacts.Add(phoneContact);
            await _applicationDbContext.SaveChangesAsync();

            return CreatedAtAction("GetPhoneContact", new { id = phoneContact.ID }, phoneContact);
        }
    }
}
