using WebApp.Totp.Interface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppOtp.Models;

namespace WebAppOtp.Controllers
{
    public class OtpController : Controller
    {

        private ITotpGenerator _totpGenerator;
        private ITotpValidator _totpValidator;
        private string accountSecretKey = "7FF3F52B-2BE1-41DF-80DE-04D32171F8A3";

        public OtpController(ITotpGenerator totpGenerator, ITotpValidator totpValidator)
        {
            _totpGenerator = totpGenerator;
            _totpValidator = totpValidator;
        }
        public IActionResult Index()
        {

            long counter = _totpGenerator.GetCurrentCounter();
            int digit = 6;
            var data = _totpGenerator.Generate(accountSecretKey, counter, digit);

            OtpModels models = new()
            {
                Otp = data,
                Counter = counter
            };
            return View(models);
        }
        // Vefy the otp
        [HttpPost]
        public IActionResult Index(OtpModels model)
        {
            bool Status = _totpValidator.Validate(accountSecretKey, model.Otp);
            if (Status)
            {
                return RedirectToAction("Validated");

            }
            else
            { 
            // Write login if otp is wrong 
            }

            return View();
        }

        public IActionResult Validated()
        {


            return View();
        }
    }
}
