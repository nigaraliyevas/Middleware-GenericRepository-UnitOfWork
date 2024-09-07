using AcademyApp.Application.Dtos.StudentDtos;
using AcademyApp.Application.Exceptions;
using AcademyApp.Application.Service.Interfaces;
using AcademyApp.Core.Entities;
using AcademyApp.DataAccess.Data;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace AcademyApp.Application.Service.Implementations
{
    public class StudentService(
        AcademyAppDbContext _context,
        IMapper _mapper
        ) : IStudentService
    {
        public int Create(StudentCreateDto studentCreateDto)
        {
            var group = _context
                .Groups
                .Include(g => g.Students)
                .FirstOrDefault(g => g.Id == studentCreateDto.GroupId);
            if (group == null || group.Limit <= group.Students.Count())
                throw new CustomException(404, "Id and Limit", "Group not found or Limit is full");
            var student = _mapper.Map<Student>(studentCreateDto);
            _context.Students.Add(student);
            _context.SaveChanges();
            return student.Id;
        }
        public List<StudentReturnDto> GetAll()
        {
            return _mapper.Map<List<StudentReturnDto>>(_context
                .Students
                .Include(s => s.Group)
                .ToList());
        }
    }
}
