using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Core.Service.Impl
{
    class PriorityServiceImpl : AbstractEntityService<Priority>, IPriorityService
    {
        public override void  Create(string name)
        {
            var context = new Entities();
            context.Priorities.Add(new Priority { Name = name });
            context.SaveChanges();
        }


        public override ICollection<Priority> FindAll()
        {
            var context = new Entities();
            var query = from entry in context.Priorities select entry;
            return query.ToList();
        }

        public override Priority FindByName(string name)
        {
            var context = new Entities();
            var query = from user in context.Priorities
                        where user.Name == name
                        select user;

            return query.FirstOrDefault();
        }
    }
}
