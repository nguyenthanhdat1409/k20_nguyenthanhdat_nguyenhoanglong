using System.Web.Mvc;

namespace PhoneStore.Areas.RoleRoot
{
    public class RoleRootAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "RoleRoot";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "RoleRoot_default",
                "RoleRoot/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}