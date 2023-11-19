using Microsoft.AspNetCore.Mvc;
using Seminar_2.Models;

namespace Seminar_2.Controllers
{

    [Route("[Controller]")]
    public class UserController : Controller
    {
        private readonly Seminar2Context context;
        public UserController(Seminar2Context context)
        {
            this.context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var list = context.Users.Select(p => new UserVM().UserToUserVM(p)).ToList();
            return View(list);
        }

        [HttpGet]
        [Route("New")]
        public IActionResult New()
        {
            var user = new UserVM();
            return View(user);
        }

        [HttpPost]
        [Route("New")]
        public IActionResult Create(UserVM dto)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError(string.Empty, "There were some errors in your form");
                return View("New", dto);
            }

            if(dto.Password != dto.ConfirmPassword)
            {
                ModelState.AddModelError(string.Empty, "Password and Confirm Password doesn't match");
                return View("New", dto);
            }

            dto.Password=Base64.Base64Encode(dto.ConfirmPassword);

            context.Add(UserVM.VMUserToUser(dto));
            context.SaveChanges();

            return View("Index", context.Users.Select(p => new UserVM().UserToUserVM(p)).ToList());
        }

        [HttpGet]
        [Route("Edit/{id}")]
        public IActionResult Edit(int id)
        {
            var prod = context.Users.FirstOrDefault(p => p.Id == id);

            if (prod == null)
                return View("Index", context.Users.Select(p => new UserVM().UserToUserVM(p)).ToList());
            else
                return View(new UserVM().UserToUserVM(prod));
        }

        [HttpPost]
        [Route("Edit/{id}")]
        public IActionResult Edit(int id, UserVM dto)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError(string.Empty, "There were some errors in your form");
                return View($"Edit/{id}", dto);
            }

            var prod = context.Users.FirstOrDefault(p => p.Id == id);
            if (prod == null)
                return View("Index", context.Users.Select(p => new UserVM().UserToUserVM(p)).ToList());

            prod.Name = dto.Name;
            prod.Surname = dto.Surname;
            prod.UserName = dto.UserName;
            prod.LastLogin = dto.LastLogin;

            context.Users.Update(prod);
            context.SaveChanges();


            return View("Index", context.Users.Select(p => new UserVM().UserToUserVM(p)).ToList());
        }

        [HttpDelete]
        [Route("Delete/{id}")]
        public JsonResult Delete(int id)
        {
            var prod = context.Users.FirstOrDefault(p => p.Id == id);
            if (prod == null)
                return Json(new { success = true, message = "Already Deleted" });

            context.Users.Remove(prod);
            context.SaveChanges();

            return Json(new { success = true, message = "Delete success" });
        }

    }
}
