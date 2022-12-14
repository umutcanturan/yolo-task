using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace yolo.common.events
{

    public class BEvent
    {
        public event EventHandler<bool> ProcessCompleted; 
        public delegate Task<bool> FuncToExecute(int item);

        public BEvent() {
           
        }

        public async Task StartProcess(int item, FuncToExecute func)
        {
            try
            {
                var result = await func(item);
                OnProcessCompleted(result);
            }
            catch
            {
                OnProcessCompleted(false);
            }
        }

        protected virtual void OnProcessCompleted(bool result) 
        {
            ProcessCompleted?.Invoke(this, result);
        }
    }
}
