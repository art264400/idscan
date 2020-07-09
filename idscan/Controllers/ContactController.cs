using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using idscan.Models;
using idscan.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace idscan.Controllers
{
    [Authorize]
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class ContactController : Controller
    {
        public IContactService _contactService;

        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }
        [HttpGet]
        public JsonResult GetAllContact()
        {
            var userId = _contactService.GetUserByLogin(User.Identity.Name).Id;
            var contacts = _contactService.GetAllContactForUserById(userId);
            return Json(contacts);
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var contact = _contactService.GetContactById(id);
            if (contact == null) return BadRequest();
            return Ok(contact);
        }
        [HttpPost]
        public ActionResult Post(Contact contact)
        {

            if (contact == null)
            {
                return BadRequest();
            }
            contact.UserId = _contactService.GetUserByLogin(User.Identity.Name).Id;
            if (!_contactService.CreateContact(contact)) return BadRequest();
            return Ok(contact);
        }
        [HttpPut]
        public ActionResult Put(Contact contact)
        {

            if (contact == null)
            {
                return BadRequest();
            }
            contact.UserId = _contactService.GetUserByLogin(User.Identity.Name).Id;
            if (!_contactService.UpdateContact(contact)) return BadRequest();
            return Ok(contact);
        }
        [HttpDelete]
        public ActionResult Delete(int Id)
        {
            var userId = _contactService.GetUserByLogin(User.Identity.Name).Id;
            _contactService.DeleteContact(Id, userId);
            return Ok();
        }

    }
}