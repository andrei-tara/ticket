using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Core.Service.Impl
{
    class TicketTypeServiceImpl : AbstractEntityService<TicketType>, ITicketTypeService
    {

        public override void Create(string name)
        {
            var context = new Entities();
            context.TicketTypes.Add(new TicketType { Name = name });
            context.SaveChanges();
        }
        public override ICollection<TicketType> FindAll()
        {
            var context = new Entities();
            var query = from entry in context.TicketTypes select entry;
            return query.ToList();
        }
        
        public override TicketType FindByName(string name)
        {
            var context = new Entities();
            var query = from entry in context.TicketTypes
                        where entry.Name == name
                        select entry;

            return query.FirstOrDefault();
        }
    }
}
