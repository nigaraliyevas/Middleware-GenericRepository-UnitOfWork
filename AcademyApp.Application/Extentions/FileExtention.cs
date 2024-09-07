using Microsoft.AspNetCore.Http;

namespace AcademyApp.Application.Extentions
{
    public static class FileExtention
    {
        public static string Save(this IFormFile file, string root, string folder)
        {
            var newFileName = Guid.NewGuid().ToString() + file.FileName;
            string filePath = Path.Combine(root, "wwwroot", folder, newFileName);
            using FileStream fs = new FileStream(filePath, FileMode.Create);
            file.CopyTo(fs);
            return newFileName;
        }

    }
}
