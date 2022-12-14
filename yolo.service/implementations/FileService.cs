using Microsoft.Extensions.Configuration;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using yolo.common.exceptions;
using yolo.service.interfaces;

namespace yolo.service.implementations
{
    public class FileService : IFileService
	{
        private readonly IConfiguration Configuration;

        public FileService(IConfiguration configuration)
        {
            Configuration = configuration;
        }


        public string ComputeSHA(string path = "", string localName = "")
        {
            if (string.IsNullOrEmpty(path))
            {
                path = Configuration["DefaultFileUrl"];
            }
            string downloadFile = GetDownloadPath(localName);

            try
            {
                WebClient webClient = new();
                using (WebClient client = webClient)
                {
                    client.DownloadFile(path, downloadFile);
                }
            }
            catch (Exception ex)
            {
                throw new FileDownloadFailedException("File download failed:" + ex.Message);
            }
           
            const int chunkSize = 1024000;
            var list = new List<string>();
            using (var file = File.OpenRead(downloadFile))
            {
                var buffer = new byte[chunkSize];
                while ((_ = file.Read(buffer, 0, buffer.Length)) > 0)
                {
                    byte[] hashValue = SHA256.HashData(buffer);
                    list.Add(BytesToStr(hashValue)); // collect all SHA values in list
                }
                file.Close();
            }
            return "Completed";
        }

        private string BytesToStr(byte[] bytes)
        {
            StringBuilder str = new StringBuilder();

            for (int i = 0; i < bytes.Length; i++)
                str.AppendFormat("{0:X2}", bytes[i]);

            return str.ToString();
        }

        private string GetDownloadPath(string file)
        {
            var downloadPath = Configuration["DownloadDirectory"];
            if (!Directory.Exists(downloadPath))
            {
                Directory.CreateDirectory(downloadPath);
            }
            if (string.IsNullOrEmpty(file))
            {
                return $"{downloadPath}//docName";
            }else if (!file.StartsWith("//")) {
                return downloadPath + file;
            }else
            {
                return $"{downloadPath}//{file}";
            }
            
        }
    }
}

