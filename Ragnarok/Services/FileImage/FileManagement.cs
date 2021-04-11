using Microsoft.AspNetCore.Http;
using System.IO;


namespace Ragnarok.Services.FileImage
{
    public class FileManagement
    {
        public static string UploadFileImage(IFormFile file)
        {
            var NomeArquivo = KeyGenerator.KeyGenerator.GetUniqueKey(50) + Path.GetExtension(file.FileName);
            var caminho = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/imageEmployee/", NomeArquivo);
            using (var stream = new FileStream(caminho, FileMode.Create))
            {
                file.CopyTo(stream);
            }

            return Path.Combine("/imageEmployee/", NomeArquivo);
        }

        public static bool RemoveFileImage(string caminho)
        {
            if (!string.IsNullOrEmpty(caminho))
            {
                string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", caminho.TrimStart('/'));

                if (File.Exists(path))
                {
                    File.Delete(path);
                    return true;
                }
            }
            return false;

        }
    }
}
