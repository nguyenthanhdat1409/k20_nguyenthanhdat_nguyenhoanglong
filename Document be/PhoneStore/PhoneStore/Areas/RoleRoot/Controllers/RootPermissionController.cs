using PhoneStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PhoneStore.Areas.RoleRoot.Controllers
{
    public class RootPermissionController : Controller
    {
        ApplicationDbContext dbContext = new ApplicationDbContext();
        // GET: RoleRoot/RootPermission
        [Authorize(Roles = "Root")]
        public ActionResult Index()
        {
            List<AspNetUser> listUser = dbContext.User.ToList();
            return View(listUser);
        }
    }
}