using AcademyApp.Application.Dtos.GroupDtos;
using AcademyApp.Application.Exceptions;
using AcademyApp.Application.Service.Interfaces;
using AcademyApp.Core.Entities;
using AcademyApp.DataAccess.Implementations;
using AutoMapper;

namespace AcademyApp.Application.Service.Implementations
{
    public class GroupService
        (IUnitOfWork unitOfWork,
        IMapper _mapper
        ) : IGroupService
    {
        public async Task<int> Create(GroupCreateDto groupCreateDto)
        {
            var group = await unitOfWork.groupRepository.IsExist(g => g.Name == groupCreateDto.Name);
            if (group)
                throw new CustomException(404, "The group name exist ");
            var newGroup = _mapper.Map<Group>(groupCreateDto);
            await unitOfWork.groupRepository.Create(newGroup);
            unitOfWork.Commit();
            return newGroup.Id;
        }

        public async Task<List<Group>> GetAll()
        {
            return await unitOfWork.groupRepository.GetAll();
        }

        public async Task<Group> GetOne(string name)
        {
            return await unitOfWork.groupRepository.GetEntity(g => g.Name == name);
        }
    }
}
