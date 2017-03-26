using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Core.Service.Impl
{
    class ServiceTypeServiceImpl : AbstractEntityService<ServiceType>, IServiceTypeService
    {

        public override void Create(string name)
        {
            var context = new Entities();
            context.ServiceTypes.Add(new ServiceType { Name = name });
            context.SaveChanges();
        }

        public override ICollection<ServiceType> FindAll()
        {
            var context = new Entities();
            var query = from entry in context.ServiceTypes select entry;
            return query.ToList();
        }

        public override ServiceType FindByName(string name)
        {
            var context = new Entities();
            var query = from entry in context.ServiceTypes
                        where entry.Name == name
                        select entry;

            return query.FirstOrDefault();
        }
    }
}
