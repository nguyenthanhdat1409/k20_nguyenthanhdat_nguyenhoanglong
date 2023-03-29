using System.Web.Mvc;

namespace PhoneStore.Areas.RoleAdmin
{
    public class RoleAdminAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "RoleAdmin";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "RoleAdmin_default",
                "RoleAdmin/{controller}/{action}/{id}",
                new {controller= "RoleAdmin", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}