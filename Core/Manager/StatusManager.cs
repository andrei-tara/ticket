using Core.Service;
using Core.Util;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Manager
{
    public class StatusManager
    {

        private static StatusManager _instance = new StatusManager();
        private StatusManager() { }
        public static StatusManager Instance => _instance;
       

        public ICollection<O> FindAllAndAdapt<O>(IAdaptor<Status,O> adaptor)
        {
            var entries = ServiceProvider.StatusService.FindAll();
            return entries.Select(entry => adaptor.adapt(entry)).ToArray();
        }

        public Status FindByName(string name)
        {
            return ServiceProvider.StatusService.FindByName(name);
        }

        public Status FindOrCreateByName(string name)
        {
            return ServiceProvider.StatusService.FindOrCreate(name);
        }

        public int FindClosedStatusId()
        {
            // TODO read from config
           return FindOrCreateByName("Closed").Id;
        }

        public ICollection<int> FindNotClosedStatusesIds()
        {
            // TODO read from config
            return CollectionUtil.AsList(
                FindOrCreateByName("Open").Id,
                FindOrCreateByName("In progress").Id
             );
        }
    }
}
