using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace yolo.common.exceptions
{
    public class FileDownloadFailedException : Exception
    {
        public FileDownloadFailedException()
        {
        }

        public FileDownloadFailedException(string message)
            : base(message)
        {
        }

        public FileDownloadFailedException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
