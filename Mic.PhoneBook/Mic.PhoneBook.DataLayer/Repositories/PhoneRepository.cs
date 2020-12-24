using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mic.PhoneBook.DataLayer.Entities;
using Mic.PhoneBook.DataLayer.Interfaces;

namespace Mic.PhoneBook.DataLayer.Repositories
{
    public class PhoneRepository: IPhoneRepository
    {
        private readonly MicphonebookdbContext _context;

        public PhoneRepository(MicphonebookdbContext context)
        {
            _context = context;
        }

        public List<Phone> GetPhoneList()
        {
            return _context.Phone.ToList();
        }

        public async Task<bool> AddPhone(Phone model)
        {
            await _context.Phone.AddAsync(model);
            var result = (await _context.SaveChangesAsync()) > 0;
            return result;
        }
    }
}
