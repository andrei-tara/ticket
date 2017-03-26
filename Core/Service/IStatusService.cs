using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Core.Service
{
    public interface IStatusService
    {
        void Create(string name);
        Status FindByName(string name);
        Status FindOrCreate(string name);
        ICollection<Status> FindAll();
    }
}
