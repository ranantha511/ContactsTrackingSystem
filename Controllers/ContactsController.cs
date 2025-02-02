
using ContactTrackingSystem.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics.Eventing.Reader;
using ContactTrackingSystem.ViewModels;
using ContactTrackingSystem.Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace ContactTrackingSystem.Controllers
{
    [Route("[controller]")]
    public class ContactsController : Controller
    {

        //private fields
        private readonly IContactsRepository _contactsRepository;
        private readonly ILogger<ContactsController> _logger;

        //Constructor  Dependency injection
        public ContactsController(IContactsRepository contactsRepository, ILogger<ContactsController> logger)
        {
            _contactsRepository = contactsRepository;
            _logger = logger;
        }

        //Url: contacts/index
        [Route("[action]")]
        //[Route("index")]
        [HttpGet]
        public async Task<IActionResult> Index( string searchby, string searchString)
        {

            if (!String.IsNullOrEmpty(HttpContext.Session.GetString("UserSession")))
            {
                ViewBag.MySession = HttpContext.Session.GetString("UserSession").ToString();
            }
            else
            {
                return RedirectToAction("Login","Home");
            }

            //Search
            ViewBag.SearchFields = new Dictionary<string, string>()
            {
                { nameof(ContactViewModel.FirstName), "First Name" },
                { nameof(ContactViewModel.LastName), "Last Name" },
                { nameof(ContactViewModel.EmailAddress), "Email Address" },
                { nameof(ContactViewModel.PhoneNumber), "Phone Number" },
                { nameof(ContactViewModel.ZipCode), "Zipcode" }
            };

            var contacts =  _contactsRepository.GetFilteredContacts(searchby,searchString);
            ViewBag.currentsearchBy = searchby;
            ViewBag.currentsearchString = searchString;
            return  View(contacts);//Views/contacts/Index.cshtml
            

        }

        //Executes when the user clicks on "Create Create" hyperlink(while opening the create view)
        //Url: contacts/create
        [Route("[action]")]
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var contacts =   _contactsRepository.GetAllContacts();
            
            ViewBag.contacts = new SelectList(contacts,"ContactID","ID");
            if (contacts == null)
            {
                _logger.LogInformation("No rows returned");
                HttpContext.Response.StatusCode = 404;
                _ = HttpContext.Response.WriteAsync("No rows found");
            }
            return View();
        }

        //Url: contacts/create
        [Route("[action]")]
        [HttpPost]
        public async Task<IActionResult> Create(ContactViewModel contactView)
        {
            if(!ModelState.IsValid)
            {
                 return View();
            }
            // Save the contact to the database
            await _contactsRepository.AddContact(contactView);

            // Redirect to List all contacts page
            return RedirectToAction("Index", "Contacts");
        }


        //url:contacts/edit
        [Route("[action]/{contactID}")] //Eg: /contacts/edit/1
        [HttpGet]
        public async Task<IActionResult>Edit(Guid contactID)
        {
            //Fetch the contact details
            var editContact =  await _contactsRepository.GetContactByID(contactID);
         

            return View(editContact);
        }

        //url: contacts/edit
        [Route("[action]/{contactID}")]
        [HttpPost]

        public async Task<IActionResult> Edit(ContactViewModel contactEdit)
        {
            if (!ModelState.IsValid)
            {
                return View(contactEdit);
            }

            //Update the database with modified details
            await _contactsRepository.UpdateContact(contactEdit);

            // Redirect to List all department page
            return RedirectToAction("Index", "Contacts");

        }




    }
}
