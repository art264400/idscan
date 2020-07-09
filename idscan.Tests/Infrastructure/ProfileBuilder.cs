using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using idscan.Models;

namespace idscan.Tests.Infrastructure
{
    class ProfileBuilder
    {
        private readonly List<Contact> _contact;
        public ProfileBuilder(Contact contact)
        {
            if (contact == null)
            {
                throw new ArgumentNullException();
            }
            else if (contact.Phone.Length > 11)
            {
                throw new InvalidOperationException("long number");
            }
            _contact = new List<Contact>
            {
                contact
            };
        }

        public Contact GetFirstContact()
        {
            return _contact.FirstOrDefault();
        }

        public Contact GetContactById(int Id)
        {
            return _contact.FirstOrDefault(m=>m.Id==Id);
        }
    }
}
