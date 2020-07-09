using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using idscan.Models;
using idscan.Services.Interfaces;

namespace idscan.Services
{
    public class EntityContactService:IContactService
    {
        private ContactContext db;
        public EntityContactService(ContactContext context)
        {
            db = context;
        }
        public Contact[] GetAllContactForUserById(int userId)
        {
                return db.Contacts.Where(m => m.IsDeleted == false && m.UserId==userId).ToArray();
        }

        public Contact GetContactById(int id)
        {
                return db.Contacts.FirstOrDefault(m => m.Id == id);
        }

        public bool CreateContact(Contact contact)
        {
                try
                {
                    db.Contacts.Add(contact);
                    db.SaveChanges();
                    return true;
                }
                catch (Exception e)
                {
                    return false;
                }
             
        }

        public bool UpdateContact(Contact contact)
        {
                try
                {
                    db.Contacts.Update(contact);
                    db.SaveChanges();
                    return true;
                }
                catch (Exception e)
                {
                    return false;
                }

        }

        public bool DeleteContact(int id,int userId)
        {
                try
                {
                    var contact = db.Contacts.FirstOrDefault(m => m.Id == id);
                    if (contact == null) return false;
                    if (userId != contact.UserId) return false;
                    contact.IsDeleted = true;
                    db.Contacts.Update(contact);
                    db.SaveChanges();
                    return true;
                }
                catch (Exception e)
                {
                    return false;
                }
        }
        
        public User GetUserByLogin(string login)
        {

                return db.Users.FirstOrDefault(m => m.Login == login);
        }
    }
}
