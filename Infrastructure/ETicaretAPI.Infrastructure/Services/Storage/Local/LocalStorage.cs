using ETicaretAPI.Application.Abstractions.Storage.Local;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace ETicaretAPI.Infrastructure.Services.Storage.Local
{
    public class LocalStorage : Storage, ILocalStorage
    {
        readonly IWebHostEnvironment _webHostEnvironment;

        public LocalStorage(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        // Delete File
        public async Task DeleteAsync(string path, string fileName)
            => File.Delete($"{path}\\{fileName}");

        //Get File
        public List<string> GetFiles(string path)
        {
            DirectoryInfo directory = new(path);
            return directory.GetFiles().Select(f => f.Name).ToList();
        }

        // Has File
        public bool HasFile(string path, string fileName)
            => File.Exists($"{path}\\{fileName}");

        // Copy File
        async Task<bool> CopyFileAsync(string filePath, IFormFile file)
        {
            try
            {
                await using FileStream fileStream = new(filePath, FileMode.Create, FileAccess.Write, FileShare.None, 1024 * 1024, useAsync: false);

                await file.CopyToAsync(fileStream);
                await fileStream.FlushAsync();

                return true;
            }
            catch (Exception ex)
            {
                //todo log!
                throw ex;
            }
        }

        // Upload File
        public async Task<List<(string fileName, string pathOrContainerName)>> UploadAsync(string path, IFormFileCollection files)
        {
            string uploadPath = Path.Combine(_webHostEnvironment.WebRootPath, path);
            if (!Directory.Exists(uploadPath))
            {
                Directory.CreateDirectory(uploadPath);
            }

            List<(string fileName, string filePath)> datas = new();

            foreach (IFormFile file in files)
            {
                string fileNewName = await FileRenameAsync(path, file.Name, HasFile);

                await CopyFileAsync($"{uploadPath}\\{fileNewName}", file);
                datas.Add((fileNewName, $"{path}\\{fileNewName}"));
            }

            return datas;

            //todo Eğer ki yukarıdaki if geçerli değilse burada sunucuda dosyaların yüklenirken hata alındığına dair uyarıcı exception oluşturup fırlatılması gerek.
        }
    }
}
