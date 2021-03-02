using Signature_Assessment_Models;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using System.Web.Security;

namespace Signature_Assessment_Web.Controllers
{
    public class HomeController : Controller
    {
        HttpClient client;
        string Apiurl = "https://localhost:44324/api/User";
        public HomeController()
        {
            client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        [AllowAnonymous]
        public ActionResult Login(Login login)
        {
            if (ModelState.IsValid && (!string.IsNullOrEmpty(login.Username) && !string.IsNullOrEmpty(login.Password)))
            {
                try
                {
                    if (Membership.ValidateUser(login.Username, login.Password))
                    {
                        FormsAuthentication.RedirectFromLoginPage("Welcome you have been granted permission", true);
                        string PersonId = Session["PersonInfo"].ToString();
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Incorrect Login details");
                    }
                }
                catch (Exception ex)
                {
                    Response.Write("Something went wrong! please enter valid information");
                }
            }
            return View();
        }

        [Authorize]
        public async Task<ActionResult> Index()
        {
            string PersonId = Session["PersonInfo"].ToString();
            Person personInfo = new Person();
            try
            {
                HttpResponseMessage responseMessage = await client.GetAsync(string.Format(Apiurl + "/GetPersonById/" + PersonId));
                var responseData = responseMessage.Content.ReadAsStringAsync().Result;

                //
                var js = new JavaScriptSerializer();
                var records = js.Deserialize<Person>(responseData.ToString());
              //  return Json(new { records }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception  ex)
            {

            }
            return View(personInfo);
        }

        public JsonResult Update(Person personInfo)
        {
            //string PersonId = Session["PersonInfo"].ToString();
            //Person personInfo = new Person();
            //try
            //{
            //    HttpResponseMessage responseMessage =  client.GetAsync(string.Format(Apiurl + "/GetPersonById/" + PersonId)).Result;
            //    var responseData = responseMessage.Content.ReadAsStringAsync().Result;

            //    var js = new JavaScriptSerializer();
            //    var records = js.Deserialize<Person>(responseData.ToString());
            //   return Json(new { responseData }, JsonRequestBehavior.AllowGet);
            //}
            //catch (Exception ex)
            //{
            
           return new JsonResult();
            //}
           // return View(personInfo);
        }

        public JsonResult GetDetails()
        {
            string PersonId = Session["PersonInfo"].ToString();
            Person personInfo = new Person();
            try
            {
                HttpResponseMessage responseMessage = client.GetAsync(string.Format(Apiurl + "/GetPersonById/" + PersonId)).Result;
                var responseData = responseMessage.Content.ReadAsStringAsync().Result;

                var js = new JavaScriptSerializer();
                var records = js.Deserialize<Person>(responseData.ToString());
                return Json(new { responseData }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return new JsonResult();
            }
            // return View(personInfo);
        }
    }
}