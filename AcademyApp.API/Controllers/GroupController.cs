using AcademyApp.Application.Dtos.GroupDtos;
using AcademyApp.Application.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AcademyApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupController : ControllerBase
    {
        private readonly IGroupService _groupService;


        public GroupController(IGroupService groupService)
        {
            _groupService = groupService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _groupService.GetAll());
        }
        [HttpPost]
        public async Task<IActionResult> Create(GroupCreateDto groupCreateDto)
        {
            return Ok(await _groupService.Create(groupCreateDto));
        }
        [HttpGet("{name")]
        public async Task<IActionResult> Get(string name)
        {
            return Ok(await _groupService.GetOne(name));
        }
    }
}
