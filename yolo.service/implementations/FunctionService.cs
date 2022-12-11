using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using yolo.common.commands;
using yolo.common.events;
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

        public async Task FunctionA(bool useEvent)
        {
            for(int i = 1; i <= 1000; i++)
            {
                if(useEvent)
                {
                    // this function will fire new event for each time called.
                    FunctionAEvent(i);
                }
                else
                {
                    // mediatr usage
                    var result = await _bus.Send(new FunctionBCommand(i));
                }
                
            }
        }

       
        public async Task<bool> FunctionB(int item)
        {
            await Task.Delay(100);
            return true;
        }
        private async Task FunctionAEvent(int i)
        {
            var bEvent = new BEvent();
            bEvent.ProcessCompleted += (sender, e) =>
            {
                if (e)
                {
                    var message = "success";
                }
            };

            bEvent.StartProcess(i, FunctionB);
        }
    }
}
