using System.Web.Mvc;

namespace ImbarkPlatform.Areas.AccountManagement
{
    public class AccountManagementAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "AccountManagement";
            }
        }

        public override void RegisterArea( AreaRegistrationContext context )
        {
            context.MapRoute(
                "AccountManagement_default",
                "AccountManagement/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional },
                null,
                new string[] { "ImbarkPlatform.AccountManagement.Controllers" }
            );
        }
    }
}
