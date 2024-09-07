using AcademyApp.Application.Dtos.GroupDtos;
using AcademyApp.Core.Entities;

namespace AcademyApp.Application.Service.Interfaces
{
    public interface IGroupService
    {
        Task<int> Create(GroupCreateDto groupCreateDto);
        Task<List<Group>> GetAll();
        Task<Group> GetOne(string name);
    }
}
