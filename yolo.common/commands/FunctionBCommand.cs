using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace yolo.common.commands
{
    public record FunctionBCommand(int item) : IRequest<bool>;
}
