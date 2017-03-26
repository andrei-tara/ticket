using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Core.Service
{
    public interface ITicketService
    {
        ICollection<Ticket> Search(TicketSearchCriteria criteria);
        Task<ICollection<Ticket>> SearchAsync(TicketSearchCriteria criteria);
        int Create(Ticket ticket);
        Ticket FindById(int ticketId);
        int Update(Ticket ticket);
    }
}
