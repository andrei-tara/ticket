using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Core.Service
{
    public interface IPriorityService
    {
        void Create(string name);
        Priority FindByName(string name);
        Priority FindOrCreate(string name);
        ICollection<Priority> FindAll();
    }
}
