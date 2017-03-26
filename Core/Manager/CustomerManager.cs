using Core.Service;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Manager
{
    public class CustomerManager
    {

        private static CustomerManager _instance = new CustomerManager();
        private CustomerManager() { }
        public static CustomerManager Instance => _instance;
       

        public ICollection<O> FindAllAndAdapt<O>(IAdaptor<Customer,O> adaptor)
        {
            var entries = ServiceProvider.CustomerService.FindAll();
            return entries.Select(entry => adaptor.adapt(entry)).ToArray();
        }
        
    }
}
