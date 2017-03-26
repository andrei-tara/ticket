using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Core.Service
{
    public interface ITicketTypeService 
    {
        void Create(string name);
        TicketType FindByName(string name);
        TicketType FindOrCreate(string name);
        ICollection<TicketType> FindAll();
    }
}
