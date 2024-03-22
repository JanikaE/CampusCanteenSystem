﻿using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace BackendService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        public HomeController()
        {
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
