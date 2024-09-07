using AcademyApp.Application.Dtos.StudentDtos;

namespace AcademyApp.Application.Service.Interfaces
{
    public interface IStudentService
    {
        int Create(StudentCreateDto studentCreateDto);
        List<StudentReturnDto> GetAll();
    }
}
