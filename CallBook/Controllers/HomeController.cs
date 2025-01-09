using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using CallBook.Models;
using CallBook.Data;
using Microsoft.AspNetCore.Mvc;

using Microsoft.CodeAnalysis;


namespace CallBook.Controllers
{
    public class HomeController : Controller
    {
       
        private readonly Data.AppContext _context;

        public HomeController(Data.AppContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        //     **Add Contact**  
        [HttpPost]
        public async Task<IActionResult> Add()
        {
            //- Allow users to add new contacts with the following fields:  
            //  - Name(required)
            //  - Phone Number(required, unique)
            //  - Email Address(optional)
            if (!ModelState.IsValid)
            {
            }
            // Check if a contact already exists based on a unique field, e.g., phoneNumber to avoid duplicates
            if (await _context.contacts.AnyAsync(c => c.PhoneNumber == c.PhoneNumber))
            {
                ModelState.AddModelError("Learner.PhoneNumber", "A Contact with this Phone Number already exists.");
                return View(Add);
            }

        
        

            return View();
        }

   //     **Update Contact**  
   //- Allow users to update existing contact details.
        public async Task<IActionResult> Update()
        {
            if (!ModelState.IsValid)
            {
            }

            return View();
        }


   //      **Delete Contact**  
   //- Allow users to delete a contact from the phonebook.
        public async Task<IActionResult> Delete()
        {
            if (!ModelState.IsValid)
            {
            }

            return View();
        }



        //      **Search Contact**  

        public async Task<IActionResult> Search( string name, string phone)
        {
            //Provide a search functionality to look up contacts by name or phone number.
            var search = await _context.contacts.Where(c => c.Name.Contains(name) || c.PhoneNumber.Contains(phone)).ToListAsync();

            return View(search);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
