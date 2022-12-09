using System;
using yolo.service.interfaces;

namespace yolo.service.implementations
{
    public class StringService : IStringService
    {
        public string Reverse(string value)
        {
            if(string.IsNullOrWhiteSpace(value))
            {
                return string.Empty;
            }
            char[] charArray = value.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }
    }
}

