using Core.Service;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Manager
{
    public class TicketTypeManager
    {

        private static TicketTypeManager _instance = new TicketTypeManager();
        private TicketTypeManager() { }
        public static TicketTypeManager Instance => _instance;
       

        public ICollection<O> FindAllAndAdapt<O>(IAdaptor<TicketType,O> adaptor)
        {
            var entries = ServiceProvider.TicketTypeService.FindAll();
            return entries.Select(entry => adaptor.adapt(entry)).ToArray();
        }
        
    }
}
