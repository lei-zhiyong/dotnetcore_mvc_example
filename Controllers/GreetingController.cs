using Microsoft.AspNetCore.Mvc;
using services;

namespace web.Controllers
{
    public class GreetingController : Controller
    {
        private GreetingService _service;
        public GreetingController(GreetingService service)
        {
            _service = service;
        }

        public JsonResult Index(string name = "")
        {
            var model = _service.GetGreetings(name);
            return Json(model);
        }
    }
}