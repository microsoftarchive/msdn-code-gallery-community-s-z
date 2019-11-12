using System;
using Microsoft.AspNetCore.Mvc;
using RegistrationForm.ViewModels;
using Twilio;
using Twilio.Types;
using Twilio.Rest.Api.V2010.Account;

namespace SMSApp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "ASP.Net Core Article !!";

            return View();
        }

        public IActionResult Registration()
        {
            ViewData["Message"] = "Registration!.";
            return View();
        }

        [HttpPost]
        public IActionResult Registration(RegistrationViewModel model)
        {
            ViewData["Message"] = "Your registration page!.";

            ViewBag.SuccessMessage = null;

            if (model.Email.Contains("menoth.com"))
            {
                ModelState.AddModelError("Email", "We don't support menoth Address !!");
            }

            if (ModelState.IsValid)
            {
                try
                {
                    // Find your Account Sid and Auth Token at twilio.com/user/account
                    const string accountSid = "AXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX";
                    const string authToken = "6XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX";
                    TwilioClient.Init(accountSid, authToken);

                    var to = new PhoneNumber("+91" + model.Mobile);
                    var message = MessageResource.Create(
                        to,
                        from: new PhoneNumber("+18XXXXXXXXXX"), //  From number, must be an SMS-enabled Twilio number ( This will send sms from ur "To" numbers ).
                        body:  $"Hello {model.Name} !! Welcome to Asp.Net Core With Twilio SMS API !!");

                    ModelState.Clear();
                    ViewBag.SuccessMessage = "Registered Successfully !!";
                }
                catch (Exception ex)
                {
                    Console.WriteLine($" Registration Failure : {ex.Message} ");
                }

            }

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}