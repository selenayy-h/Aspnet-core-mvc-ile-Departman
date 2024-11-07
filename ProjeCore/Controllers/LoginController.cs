using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using ProjeCore.Models;
using System.Security.Claims;

namespace ProjeCore.Controllers
{
    public class LoginController : Controller
    {
		Context c = new Context();

		[HttpGet]
		[Route("Login/GirisYap")]
		public IActionResult GirisYap()
        {
            return View();
        }

		[HttpPost]
		[Route("Login/GirisYapPost")]
		public async Task<IActionResult>GirisYap(Admin p)
        {

            var bilgiler = c.Admins.FirstOrDefault(x => x.Kullanici == p.Kullanici && x.Sifre == p.Sifre);


            if (bilgiler != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name,p.Kullanici)
                };

                var useridentity=new ClaimsIdentity(claims,"Login");
                ClaimsPrincipal principal = new ClaimsPrincipal(useridentity);
                await HttpContext.SignInAsync(principal);
                return RedirectToAction("Index","Personelim");

            
            }

            
            return View();

		}
    }
}
