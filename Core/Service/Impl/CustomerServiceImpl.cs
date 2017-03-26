using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Core.Service.Impl
{
    class CustomerServiceImpl : AbstractEntityService<Customer>, ICustomerService
    {
       
        public override void Create(string name)
        {
            var context = new Entities();
            context.Customers.Add(new Customer { Name = name });
            context.SaveChanges();
        }

        public override ICollection<Customer> FindAll()
        {
            var context = new Entities();
            var query = from entry in context.Customers  select entry;
            return query.ToList();
        }

        public override Customer FindByName(string name)
        {
            var context = new Entities();
            var query = from entry in context.Customers
                        where entry.Name == name
                        select entry;

            return query.FirstOrDefault();
        }

      
    }
}
