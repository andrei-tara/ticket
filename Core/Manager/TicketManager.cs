using Core.Service;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Manager
{
    public class TicketManager
    {

        private static TicketManager _instance = new TicketManager();
        private TicketManager() { }
        public static TicketManager Instance => _instance;
        public ICollection<Ticket> FindUserTickets(int userId)
        {
            var criteria = new TicketSearchCriteria{ AsigneeUserId = userId };
            return ServiceProvider.TicketService.Search(criteria);
        }

        public ICollection<O> FindUserTickets<O>(int userId, IAdaptor<Ticket,O> adaptor)
        {
            var criteria = new TicketSearchCriteria { AsigneeUserId = userId };
            var entries = FindUserTickets(userId);
            return entries.Select(entry => adaptor.adapt(entry)).ToArray();
        }

        public async Task<ICollection<O>> FindUserTicketsAsync<O>(int userId, IAdaptor<Ticket, O> adaptor)
        {
            var notClosedStatus = StatusManager.Instance.FindNotClosedStatusesIds();
            var criteria = new TicketSearchCriteria { AsigneeUserId = userId , Statuses = notClosedStatus };
            var tickets = await ServiceProvider.TicketService.SearchAsync(criteria);
            return tickets.Select(entry => adaptor.adapt(entry)).ToArray();
        }

        public void PersistTicket(Ticket ticket, int userId)
        {  
            if (ticket.Id == 0)
            {
                ticket.Creator_Id = userId;
                ticket.Asignee_Id = userId;
                ticket.CreatedAt = DateTime.Now;
                ServiceProvider.TicketService.Create(ticket);
            }
            else
            {
                ticket.UpdatedAt = DateTime.Now;
                ServiceProvider.TicketService.Update(ticket);
            }
        }

        public Ticket FindById(int ticketId)
        {
            return ServiceProvider.TicketService.FindById(ticketId);
        }
    }
}
