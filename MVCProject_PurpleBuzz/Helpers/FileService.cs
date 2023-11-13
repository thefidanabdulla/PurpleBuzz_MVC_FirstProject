using Microsoft.AspNetCore.Hosting;
using MVCProject_PurpleBuzz.DAL;
using MVCProject_PurpleBuzz.Models;

namespace MVCProject_PurpleBuzz.Helpers
{
    public class FileService : IFileService
    {

        public async Task<string> UploadAsync(string webRootPath, IFormFile file)
        {
            var fileName = $"{Guid.NewGuid()}_{file.FileName}";
            var path = Path.Combine(webRootPath, "assets", "img", fileName);

            using (FileStream fileStream = new FileStream(path, FileMode.Create, FileAccess.ReadWrite))
            {
                await file.CopyToAsync(fileStream);
            }
            return fileName ;
        }
        public void Delete(string webRootPath, string fileName)
        {
            var path = Path.Combine(webRootPath, "assets", "img", fileName);
            if (File.Exists(path)) File.Delete(path);
        }

        public bool IsImage(IFormFile file)
        {
            if (file.ContentType.Contains("image/"))
            {
                return true;
            }
             return false;
        }

        public bool SizeCheck(IFormFile file)
        {
            if(file.Length / 1024 > 300)
            {
                return true;
            }
            return false;
        }
    }
}
