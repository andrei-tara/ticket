using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using System.Data.Entity;

namespace Core.Service.Impl
{
    class TicketServiceImpl : ITicketService
    {
        public int Create(Ticket ticket)
        {
            var context = new Entities();
            context.Tickets.Add(ticket);
            return context.SaveChanges();
        }

        public Ticket FindById(int ticketId)
        {
            var context = new Entities();
            var query = from entry in context.Tickets
                        where entry.Id == ticketId
                        select entry;

            return query.FirstOrDefault();
        }

        public ICollection<Ticket> Search(TicketSearchCriteria criteria)
        {
            var context = new Entities();
            var query = from ticket in context.Tickets select ticket;
            MapSearchCriteria(query, criteria);
            return query.ToList();
        }

        private void MapSearchCriteria(IQueryable<Ticket> query, TicketSearchCriteria criteria)
        {
            if (criteria.AsigneeUserId != null)
            {
                query = query.Where(task => task.Asignee_Id == criteria.AsigneeUserId);

            }

            if (criteria.Statuses.Count != 0)
            {
                query = query.Where(task => criteria.Statuses.Contains(task.Status_Id));
            }
        }

        public async Task<ICollection<Ticket>> SearchAsync(TicketSearchCriteria criteria)
        {
            var context = new Entities();
            var query = from ticket in context.Tickets select ticket;
            MapSearchCriteria(query, criteria);
            return await query.ToListAsync();
        }

        public int Update(Ticket ticket)
        {
            var context = new Entities();
            context.Tickets.Attach(ticket);
            return context.SaveChanges();
        }
    }
}
