using Microsoft.AspNetCore.Mvc;

namespace BackendService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private CustomContext dbContext;

        public HomeController(CustomContext dbContext)
        {
            this.dbContext = dbContext;

            dbContext.Database.EnsureCreated();
        }

        [HttpGet]
        [Route("/Home/GetTime")]
        public string GetTime()
        {
            string msg = DateTime.Now.ToString();
            return msg;
        }
    }
}
