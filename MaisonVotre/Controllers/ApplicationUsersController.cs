using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using MaisonVotre.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using MaisonVotre;

namespace P_Market.Controllers
{
    [Authorize(Roles = "admin")]
    public class ApplicationUsersController : Controller
    {
        private ApplicationUserManager _userManager;

        ApplicationDbContext db = new ApplicationDbContext();

        // GET: ApplicationUsers
        public ActionResult Index(ApplicationDbContext db)
        {
            return View(db.Users.ToList());
        }

        public List<Rols> getRoles()
        {
            var rolList = db.Roles;
            var roles = new List<Rols>();

            foreach (var role in rolList)
            {
                roles.Add(new Rols
                {
                    RolName = role.Name
                });
            }
            return roles;
        }

        public ActionResult Roles()
        {
            return View(getRoles());

        }

        public List<Rols> getUsrRoles(ApplicationUser user)
        {
            var usersAndRoles = new List<User_Role>();

                foreach (var role in user.Roles)
                {
                    var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db));
                    var rol = roleManager.FindById(role.RoleId);
                    usersAndRoles.Add(new User_Role
                    {
                        UserName = user.UserName,
                        RolName = rol.Name
                    });
                }
            
            var ur = usersAndRoles.Where(r => r.UserName == user.UserName);

            var roles = new List<Rols>();
            foreach (var role in usersAndRoles)
            {
                var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db));
                var rol = roleManager.FindByName(role.RolName);
                roles.Add(new Rols
                {
                    RolName = rol.Name
                });
            }
            return roles;
        }

        public ActionResult UserRoles(string name)
        {
            if (name == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
            var user = userManager.FindByName(name);
            if (user == null)
            {
                return HttpNotFound();
            }
            var usersAndRoles = new List<User_Role>();

            var roles = getUsrRoles(user);

            foreach (var r in roles)
            {
                usersAndRoles.Add(new User_Role
                {
                    UserName = user.UserName,
                    RolName = r.RolName
                });
            }
            if (usersAndRoles.Count == 0)
            {
                usersAndRoles.Add(new User_Role
                {
                    UserName = user.UserName
                }
                );
            }

            ViewBag.Roles = new SelectList(roles, "RolName", "RolName");

            return View(usersAndRoles);
        }

        //GET
        [Authorize(Roles = "admin")]
        public ActionResult AggRole(string usrname)
        {
            User_Role UserRol = new User_Role();

            UserRol.UserName = usrname;

            ViewBag.Roles = new SelectList(getRoles(), "RolName", "RolName");

            return View(UserRol);

        }
        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AggRole(User_Role model)
        {
            string rolname = Request.Form["Roles"].ToString();
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db));

            var user = userManager.FindByName(model.UserName);
            var role = roleManager.FindByName(rolname);

            if (!userManager.IsInRole(user.Id, role.Name))
            {
                userManager.AddToRole(
                    user.Id,
                    role.Name
                );
            }
            return RedirectToAction("UserRoles", "ApplicationUsers", new { name = user.UserName });

        }


        // GET: ApplicationUsers/Details/5
        [Authorize(Roles = "admin")]
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApplicationUser applicationUser = db.Users.Find(id);
            if (applicationUser == null)
            {
                return HttpNotFound();
            }
            return View(applicationUser);
        }

        // GET: ApplicationUsers/Create
        [Authorize(Roles = "admin")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: ApplicationUsers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Email,EmailConfirmed,PasswordHash,SecurityStamp,PhoneNumber,PhoneNumberConfirmed,TwoFactorEnabled,LockoutEndDateUtc,LockoutEnabled,AccessFailedCount,UserName")] ApplicationUser applicationUser)
        {
            if (ModelState.IsValid)
            {
                db.Users.Add(applicationUser);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(applicationUser);
        }

        // GET: ApplicationUsers/Edit/5
        [Authorize(Roles = "admin")]
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApplicationUser applicationUser = db.Users.Find(id);
            if (applicationUser == null)
            {
                return HttpNotFound();
            }
            return View(applicationUser);
        }

        // POST: ApplicationUsers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Email,EmailConfirmed,PasswordHash,SecurityStamp,PhoneNumber,PhoneNumberConfirmed,TwoFactorEnabled,LockoutEndDateUtc,LockoutEnabled,AccessFailedCount,UserName")] ApplicationUser applicationUser)
        {
            if (ModelState.IsValid)
            {
                db.Entry(applicationUser).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(applicationUser);
        }

        // GET: ApplicationUsers/Delete/5
        [Authorize(Roles = "admin")]
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
            var applicationUser = userManager.FindById(id);
            if (applicationUser == null)
            {
                return HttpNotFound();
            }

            return View(applicationUser);
        }

        // POST: ApplicationUsers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            ApplicationUser applicationUser = db.Users.Find(id);
            db.Users.Remove(applicationUser);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DeleteUserRol(string rol, string user)
        {
            if (user == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if (rol == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            User_Role userRole = new User_Role();
            userRole.UserName = user;
            userRole.RolName = rol;

            return View(userRole);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteUserRol(User_Role model)
        {
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db));

            var usr = userManager.FindByName(model.UserName);
            var role = roleManager.FindByName(model.RolName);

            if (userManager.IsInRole(usr.Id, role.Name))
            {
                userManager.RemoveFromRole(
                    usr.Id,
                    role.Name
                );
            }
            return RedirectToAction("UserRoles", "ApplicationUsers", new { name = usr.UserName });
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        public ActionResult ChangePassword(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApplicationUser us = db.Users.Find(id);
            CambiarContraseña cc = new CambiarContraseña();
            cc.Id = id;
            cc.Name = us.UserName;
            if (cc == null)
            {
                return HttpNotFound();
            }
            return View(cc);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ChangePassword(CambiarContraseña model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
           
            var tok = UserManager.GeneratePasswordResetToken(model.Id);
            var result = await UserManager.ResetPasswordAsync(model.Id, tok, model.NewPassword);
            
            if (result.Succeeded)
            {
                return RedirectToAction("Index", new { Message = ManageMessageId.ChangePasswordSuccess });
            }
            AddErrors(result);

            return View(model);
        }

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }

        public ActionResult Register()
        {
            return View();
        }

        // POST: /Account/Register
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser { UserName = model.Name, Email = model.Email };
                var result = await UserManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "ApplicationUsers");
                }
                AddErrors(result);
            }

            // Si llegamos a este punto, es que se ha producido un error y volvemos a mostrar el formulario
            return View(model);
        }

        public enum ManageMessageId
        {
            AddPhoneSuccess,
            ChangePasswordSuccess,
            SetTwoFactorSuccess,
            SetPasswordSuccess,
            RemoveLoginSuccess,
            RemovePhoneSuccess,
            Error
        }

    }
}
