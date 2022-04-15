using System.Web.Mvc;

namespace WEB.Areas.Öğrenci
{
    public class ÖğrenciAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Öğrenci";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Öğrenci_default",
                "Öğrenci/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}