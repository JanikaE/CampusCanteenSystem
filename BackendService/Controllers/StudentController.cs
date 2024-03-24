using Common.Dto;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace BackendService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        public StudentController() { }

        [HttpGet]
        [Route("/Student/GetStudentByCardID")]
        public async Task<Student> GetStudentByCardID([Required]string cardId)
        {
            Student student = new()
            {
                Id = 1,
                CardId = cardId,
                Name = "aa"
            };
            return student;
        }
    }
}
