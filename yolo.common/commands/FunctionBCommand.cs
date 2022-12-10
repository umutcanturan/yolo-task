using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace yolo.common.queries
{
    public record FunctionBCommand(int item) : IRequest<bool>;
}
