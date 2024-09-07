

using FluentValidation;
using Microsoft.AspNetCore.Http;

namespace AcademyApp.Application.Dtos.StudentDtos
{
    public class StudentCreateDto
    {
        public int GroupId { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public DateTime BirthDay { get; set; }
        public IFormFile File { get; set; }
    }
    public class StudentCreteDtoValidator : AbstractValidator<StudentCreateDto>
    {
        public StudentCreteDtoValidator()
        {
            RuleFor(s => s.FullName)
                .NotEmpty()
                .MaximumLength(35)
                .MinimumLength(5);
            RuleFor(s => s.Email)
                .NotEmpty()
                .EmailAddress()
                .MinimumLength(5)
                .MaximumLength(100);
            RuleFor(s => s.BirthDay.Date)
                .LessThanOrEqualTo(DateTime.Now.AddYears(-15));//15 beraber yada boyuk olmalidi
            RuleFor(s => s).Custom((s, c) =>
            {
                if (s.FullName == null && char.IsUpper(s.FullName[0]))
                {
                    c.AddFailure(nameof(s.FullName), "fullname must start Uppercase");
                }
            });
            RuleFor(s => s).Custom((s, c) =>
            {
                if (s.File == null && s.File.Length / 1024 > 300)
                {
                    c.AddFailure(nameof(s.File), "The file size is bigger");
                }
                if (!(s.File != null && s.File.ContentType.Contains("image/")))
                {
                    c.AddFailure(nameof(s.File), "The file msut be image");
                }
            });
        }
    }
}
