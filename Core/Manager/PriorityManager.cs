using Core.Service;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Manager
{
    public class PriorityManager
    {

        private static PriorityManager _instance = new PriorityManager();
        private PriorityManager() { }
        public static PriorityManager Instance => _instance;
       

        public ICollection<O> FindAllAndAdapt<O>(IAdaptor<Priority,O> adaptor)
        {
            var entries = ServiceProvider.PriorityService.FindAll();
            return entries.Select(entry => adaptor.adapt(entry)).ToArray();
        }
        
    }
}
