using Microsoft.AspNetCore.Mvc;

namespace MeuRobo.Controllers.Base
{
    public class BaseController : Controller
    {
        public void MessageError(string erro, string type) {

            ViewBag.type = type;
            ViewBag.Message = erro;


        }
    }
}
