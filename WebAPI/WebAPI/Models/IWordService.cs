using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models.EFModels;

namespace WebAPI.Models
{
    public interface IWordService
    {
        void CreateDocument(string filePath);
        void AddTableWithContactToDocument(string filePath,IEnumerable<PhoneContact> phoneContacts);

    }
}
