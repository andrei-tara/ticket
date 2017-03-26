using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Core.Service
{
    public interface IServiceTypeService 
    {
        void Create(string name);
        ServiceType FindByName(string name);
        ServiceType FindOrCreate(string name);
        ICollection<ServiceType> FindAll();
    }
}
