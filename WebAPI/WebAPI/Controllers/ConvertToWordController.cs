using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Models.EFModels;
using WebAPI.Models;
using WebAPI.Context;
using Microsoft.EntityFrameworkCore;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ConvertToWordController : Controller
    {
        readonly IWordService _wordService;
        readonly ApplicationDbContext _applicationDbContext;
        public ConvertToWordController( IWordService wordService, ApplicationDbContext applicationDbContext)
        {
            _wordService = wordService;
            _applicationDbContext = applicationDbContext;
        }
        
        [HttpPost]
        public async Task<bool> Convert(string path)
        {
            var phoneContacts = await _applicationDbContext.PhoneContacts.ToListAsync();
            _wordService.CreateDocument(@"C:\Users\Bezi\Desktop\Angualr_Asp.net_core\PhoneBook\Contact.docx");
            _wordService.AddTableWithContactToDocument(@"C:\Users\Bezi\Desktop\Angualr_Asp.net_core\PhoneBook\Contact.docx", phoneContacts);

            return true;
        }
    }
}
