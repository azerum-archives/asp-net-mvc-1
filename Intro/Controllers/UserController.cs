using System.Security.Cryptography;
using System.Text;
using System.Web.Mvc;
using Intro.Models.Entities;
using Intro.Models.ViewModels;

namespace Intro.Controllers
{
    public class UserController : Controller
    {
        public ViewResult Register()
        {
            return View(new UserRegistrationVm());
        }

        [HttpPost]
        public ActionResult Register(UserRegistrationVm newUser)
        {
            if (!ModelState.IsValid)
            {
                return View(newUser);
            }

            User user = new User
            {
                Name = newUser.Name,
                Email = newUser.Email,
                EmailIsConfirmed = false,
                PasswordHash = Hash(newUser.Password)
            };

            //TODO: Login user somehow

            UserAccountVm accountVm = new UserAccountVm
            {
                Name = user.Name,
                Email = user.Email,
                EmailIsConfirmed = user.EmailIsConfirmed
            };

            return RedirectToAction("Account", accountVm);
        }
        
        //TODO: might move out of controller
        private byte[] Hash(string s)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(s);

            using (SHA256 hasher = SHA256.Create())
            {
                return hasher.ComputeHash(bytes);
            }
        }

        public ViewResult Account(UserAccountVm accountVm)
        {
            return View(accountVm);
        }
    }
}
