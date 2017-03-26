using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Core.Service
{
    public interface ICustomerService
    {
        void Create(string name);
        Customer FindByName(string name);
        Customer FindOrCreate(string name);
        ICollection<Customer> FindAll();
    }
}
