using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Authentication;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using NewsParserSite.API.Models;

namespace NewsParserSite.API.Controllers
{
    [RequireHttps]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }

        public ActionResult RegisterExternal()
        {
            return View();
        }
        [HttpPost]
        public ActionResult RegisterExternal(RegisterBindingModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            AccountController accountController = new AccountController();
            var result = accountController.Register(model).Result;
            #region NotWorkingMethod
            //using (var client = new HttpClient())
            //{

            //    var request = new HttpRequestMessage()
            //    {
            //        RequestUri = new Uri("http://localhost/api/Account/Register"),
            //        Method = HttpMethod.Post,
            //    };
            //    request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("text/json"));
            //    request.Headers.Add("Email", model.Email);
            //    request.Headers.Add("Password", model.Password);
            //    request.Headers.Add("ConfirmPassword", model.ConfirmPassword);
            //    var response = client.SendAsync(request);
            //    response.Wait();

            //    var responseResult = response.Result;

            //    if (responseResult.IsSuccessStatusCode)
            //    {
            //        Debug.WriteLine("Ok");
            //        return RedirectToAction("Index", "Home");
            //    }
            //    throw new InvalidCredentialException("результат не успешен!");
            //}
            #endregion





            return RedirectToAction("Index", "Home");
        }

        public ActionResult Login()
        {
            return View();
        }
    }
}
