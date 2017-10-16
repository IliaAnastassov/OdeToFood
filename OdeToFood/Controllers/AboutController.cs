using Microsoft.AspNetCore.Mvc;

namespace OdeToFood.Controllers
{
    [Route("company/[controller]/[action]")]
    public class AboutController
    {
        public string Phone()
        {
            return "187-666-999-3333";
        }

        public string Address()
        {
            return "66 Sunset Bld. CA, USA";
        }
    }
}
