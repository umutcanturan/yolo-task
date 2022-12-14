using System;
using System.IO;
using System.IO.Pipes;
using System.Net;
using System.Reflection.Emit;
using System.Security.Cryptography;
using System.Text;
using yolo.common.exceptions;
using yolo.service.interfaces;

namespace yolo.service.implementations
{
	public class FileService : IFileService
	{

        public string ComputeSHA(string path = "", string localName = "")
        {
            if(string.IsNullOrEmpty(path))
            {
                path = "https://speed.hetzner.de/100MB.bin";
            }
            if(string.IsNullOrEmpty(localName))
            {
                localName = @"..//files//docName";
            }
            using (WebClient client = new WebClient())
            {
                client.DownloadFile(path, localName);
            }


            SHA256 mySHA256 = SHA256Managed.Create();
            StringBuilder str = new StringBuilder();
            const int chunkSize = 1024000;
            var list = new List<string>();
            using (var file = File.OpenRead(localName))
            {
                int bytesRead;
                var buffer = new byte[chunkSize];
                while ((bytesRead = file.Read(buffer, 0, buffer.Length)) > 0)
                {
                    byte[] hashValue = mySHA256.ComputeHash(buffer);
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
    }
}

