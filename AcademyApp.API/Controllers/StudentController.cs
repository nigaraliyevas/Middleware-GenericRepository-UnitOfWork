using AcademyApp.Application.Dtos.StudentDtos;
using AcademyApp.Application.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AcademyApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController(IStudentService _studentService) : ControllerBase
    {
        [HttpPost]
        public IActionResult Create(StudentCreateDto studentCreateDto)
        {
            return Ok(_studentService.Create(studentCreateDto));
        }
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_studentService.GetAll());
        }
    }
}
