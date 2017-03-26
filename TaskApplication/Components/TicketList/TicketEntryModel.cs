using Core.Manager;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Model
{
    struct TicketEntryModel
    {
        public Int32 Id { get; set; }
        public String Subject { get; set; }
        public String Type { get; set; }
        public String Customer { get; set; }
        public String Status { get; set; }
        public String ServiceType { get; set; }
        public  DateTime? CreatedAt { get; set; }
    }


    class TicketEntryModelAdaptor : IAdaptor<Ticket, TicketEntryModel>
    {
        public TicketEntryModel adapt(Ticket entry)
        {
            return new TicketEntryModel
            {
                Id = entry.Id,
                Subject = entry.Subject,
                Type = (entry.TicketType != null) ? entry.TicketType.Name : "",
                Status = (entry.Status != null) ? entry.Status.Name : "",
                Customer = (entry.Customer != null) ? entry.Customer.Name : "",
                ServiceType = (entry.ServiceType != null) ? entry.ServiceType.Name : "",
                CreatedAt = entry.CreatedAt,
            };
        }
    }
}
