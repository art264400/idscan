using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using idscan.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace idscan.Controllers
{
    [Authorize]
    [Produces("application/json")]
    [Route("api/Contact")]
    public class ContactController : Controller
    {
        private ContactContext db;
        public ContactController(ContactContext context)
        {
            db = context;
        }
        [HttpGet]
        public JsonResult GetAllContact()
        {
            var user=db.Users.FirstOrDefault(m=>m.Login==User.Identity.Name);
            return Json(db.Contacts.Where(m=>m.UserId==user.Id && m.IsDeleted==false));
        }
        [HttpPost]
        public ActionResult Post(Contact contact)
        {

            if (contact == null)
            {
                return BadRequest();
            }
            contact.UserId= db.Users.FirstOrDefault(m => m.Login == User.Identity.Name).Id;
            db.Contacts.Add(contact);
            db.SaveChanges();
            return Ok(contact);
        }
        [HttpPut]
        public ActionResult Put(Contact contact)
        {

            if (contact == null)
            {
                return BadRequest();
            }
            contact.UserId = db.Users.FirstOrDefault(m => m.Login == User.Identity.Name).Id;
            db.Contacts.Update(contact);
            db.SaveChanges();
            return Ok(contact);
        }
        [HttpDelete]
        public ActionResult Delete(int Id)
        {
            var contact = db.Contacts.FirstOrDefault(m=>m.Id==Id);
            if (contact == null ) return BadRequest();
            var userId= db.Users.FirstOrDefault(m => m.Login == User.Identity.Name).Id;
            if (userId != contact.UserId) return BadRequest();
            contact.IsDeleted = true;
            db.Contacts.Update(contact);
            db.SaveChanges();
            return Ok();
        }
        //[HttpGet]
        //public JsonResult GetContactById(int id)
        //{

        //    return Json(db.Contacts);
        //}
    }
}