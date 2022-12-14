using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace yolo.service.interfaces
{
    public interface IFunctionService
    {
        public Task FunctionA(bool useEvent);
        public Task<bool> FunctionB(int item);

    }
}
