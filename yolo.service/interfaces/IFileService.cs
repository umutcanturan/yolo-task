using System;
namespace yolo.service.interfaces
{
	public interface IFileService
	{
		public string ComputeSHA(string path, string localName);
	}
}

