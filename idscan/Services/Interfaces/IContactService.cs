using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using idscan.Models;

namespace idscan.Services.Interfaces
{
    public interface IContactService
    {
        Contact[] GetAllContactForUserById(int userId);
        Contact GetContactById(int id);
        bool CreateContact(Contact contact);
        bool UpdateContact(Contact contact);
        bool DeleteContact(int id, int userId);

        User GetUserByLogin(string login);
    }
}
