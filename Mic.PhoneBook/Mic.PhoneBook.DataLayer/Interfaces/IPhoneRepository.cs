using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Mic.PhoneBook.DataLayer.Entities;

namespace Mic.PhoneBook.DataLayer.Interfaces
{
    public interface IPhoneRepository
    {
        List<Phone> GetPhoneList();
        Task<bool> AddPhone(Phone model);
    }
}
