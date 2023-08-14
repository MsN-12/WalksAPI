using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;

namespace WalksAPI.Controllers
{
    [Route("/api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAllStudents()
        {
            string[] studentNames = new string[] { "mmd", "ali", "jafar" };
            return Ok(studentNames);
        }
    }
}
