using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Core.Service.Impl
{
    class StatusServiceImpl : AbstractEntityService<Status>, IStatusService
    {

        public override void Create(string name)
        {
            var context = new Entities();
            context.Statuses.Add(new Status { Name = name });
            context.SaveChanges();
        }

        public override ICollection<Status> FindAll()
        {
            var context = new Entities();
            var query = from entry in context.Statuses select entry;
            return query.ToList();
        }

        public override Status FindByName(string name)
        {
            var context = new Entities();
            var query = from entry in context.Statuses
                        where entry.Name == name
                        select entry;

            return query.FirstOrDefault();
        }
    }
}
