using ContactTrackingSystem.Data;
using ContactTrackingSystem.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore.ValueGeneration.Internal;
using Microsoft.EntityFrameworkCore;
using BCrypt.Net;
using Microsoft.AspNetCore.Identity;

namespace ContactTrackingSystem.Controllers
{
    [Route("[controller]")]
    public class HomeController : Controller
    {
        private readonly CTSDbContext _context;
        private readonly ILogger<ContactsController> _logger;

        public HomeController(CTSDbContext context, ILogger<ContactsController> logger)
        {
            _context = context;
            _logger = logger;
        }

        [Route("[action]")]
        [Route("/")]
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [Route("[action]")]
        [HttpPost]
        public IActionResult Login(UserLogin user)
        {
            if (user != null)
            {
                if (!string.IsNullOrEmpty(user.Username) && !string.IsNullOrEmpty(user.Password))
                {
                    try
                    {
                        var dbUser = _context.UserLogins.Where(x => x.Username == user.Username).FirstOrDefault();
                        if (dbUser != null)
                        {
                            if (!string.IsNullOrEmpty(dbUser.Username) && !string.IsNullOrEmpty(dbUser.Password))
                            {

                                if (BCrypt.Net.BCrypt.Verify(user.Password, dbUser.Password) == true)
                                {
                                    HttpContext.Session.SetString("UserSession", user.Username);
                                    //return RedirectToAction("Index", "Contacts");
                                    return RedirectToRoute(new
                                    {
                                        controller = "Contacts",
                                        action = "Index"

                                    });
                                }
                                else
                                {
                                    ViewBag.Message = "Login Failed.";
                                }
                            }
                            else
                            { ViewBag.Message = "Login Failed."; }
                        }
                        else
                        {
                            ViewBag.Message = "Invalid Login.";
                        }

                    }catch(SaltParseException salEx)
                    {
                        _logger.LogError(salEx.Message);
                        HttpContext.Response.StatusCode = 500;
                        HttpContext.Response.WriteAsync("Login Failed.");
                        
        
                    }
                    catch(Exception ex)
                    {
                        _logger.LogError(ex.Message);
                        HttpContext.Response.StatusCode = 500;
                        HttpContext.Response.WriteAsync("Login Failed.");
                    }
                }
            }
            return View();
        }

        [Route("[action]")]
        [HttpGet]
        public IActionResult Logout()
        {
               if ( HttpContext.Session.GetString("UserSession") != null)
                {
                    HttpContext.Session.Remove("UserSession");
                    return RedirectToAction("Login");
                }
            return View();
        }

        [Route("action")]
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }


        [Route("action")]
        [HttpPost]
        public async Task<IActionResult> Register(UserLogin registerUser)
        {
            if (ModelState.IsValid)
            {
                if (registerUser.Username != null)
                {
                    var dbUser = _context.UserLogins.Where(x => x.Username == registerUser.Username).FirstOrDefault();
                    if (dbUser != null)
                    {
                        TempData["Failure"] = "User already exists in the system. Reset password is not implemented at this time. Please contact customer support.";
                        return View();
                    }

                    registerUser.Id = Guid.NewGuid();
                    registerUser.Password = BCrypt.Net.BCrypt.HashPassword(registerUser.Password);
                    var newUser = new UserLogin()
                    {
                        Id = registerUser.Id,
                        Username = registerUser.Username,
                        Password = registerUser.Password
                    };

                    //var dbUser = _context.UserLogins.Where(x => x.Username == registerUser.Username).FirstOrDefault();
                    //if (dbUser != null)
                    //{
                    //    TempData["Failure"] = "User already exists in the system. Reset password is not implemented at this time. Please contact customer support.";
                    //    return View();
                    //}

                    await _context.UserLogins.AddAsync(newUser);
                    await _context.SaveChangesAsync();
                    TempData["Success"] = "Registered successfully";
                    return RedirectToAction("Login");
                }
            }
            return View();
        }


        [Route("About")]
        [HttpGet]
        public IActionResult About()
        {
            return View();
        }


        [Route("Privacy")]
        [HttpGet]
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
