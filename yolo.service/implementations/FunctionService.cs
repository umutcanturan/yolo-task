using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using yolo.common.commands;
using yolo.service.interfaces;

namespace yolo.service.implementations
{
    public class FunctionService : IFunctionService
    {
        private readonly IMediator _bus;
        public FunctionService(IMediator bus)
        {
            _bus= bus;
        }

        public async Task FunctionA()
        {
            for(int i = 1; i <= 1000; i++)
            {
                var result = await _bus.Send(new FunctionBCommand(i));
            }
        }

        public async Task<bool> FunctionB(int item)
        {
            await Task.Delay(100);
            return true;
        }
    }
}
