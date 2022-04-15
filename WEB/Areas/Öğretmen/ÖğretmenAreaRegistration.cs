using System.Web.Mvc;

namespace WEB.Areas.Öğretmen
{
    public class ÖğretmenAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Öğretmen";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Öğretmen_default",
                "Öğretmen/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}