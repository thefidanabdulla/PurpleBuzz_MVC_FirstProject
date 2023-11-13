﻿namespace MVCProject_PurpleBuzz.Helpers
{
    public interface IFileService
    {
        Task<string> UploadAsync(string webRootPath, IFormFile file);
        void Delete(string webRootPath, string fileName);
        bool IsImage(IFormFile file);
        bool SizeCheck(IFormFile file);
    }
}
