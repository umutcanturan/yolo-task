using System;
using Newtonsoft.Json;

namespace yolo.common.models
{
    public class ErrorResponse
    {
        public int StatusCode { get; set; }
        public string? Message { get; set; }
    }
}

