using Core.Service;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Manager
{
    public class ServiceTypeManager
    {

        private static ServiceTypeManager _instance = new ServiceTypeManager();
        private ServiceTypeManager() { }
        public static ServiceTypeManager Instance => _instance;
       

        public ICollection<O> FindAllAndAdapt<O>(IAdaptor<ServiceType,O> adaptor)
        {
            var entries = ServiceProvider.ServiceTypeService.FindAll();
            return entries.Select(entry => adaptor.adapt(entry)).ToArray();
        }
        
    }
}
