using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using yolo.common.queries;
using yolo.service.interfaces;

namespace yolo.service.commands.commandHandlers
{
    public class FunctionBCommandHandler : IRequestHandler<FunctionBCommand, bool>
    {
        private IFunctionService _functionService;
        public FunctionBCommandHandler(IFunctionService functionService)
        {
            _functionService= functionService;
        }

        public async Task<bool> Handle(FunctionBCommand request, CancellationToken cancellationToken)
        {
            return await _functionService.FunctionB(request.item);
        }
    }
}
