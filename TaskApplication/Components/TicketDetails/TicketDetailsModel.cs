using App.Controller.TicketList.Model;
using App.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace App.Components.TicketList
{

    public class TicketDetailsModel
    {
        public bool ReadOnly { get; internal set; }

        public ListEntry Status { get; set; }
        public ListEntry Priority { get; set; }
        public ListEntry Customer { get; set; }
        public ListEntry ServiceType { get; set; }
        public ListEntry TicketType { get; set; }

        public String Description { get; set; }
        public String Subject { get; set; }
      
        public ICollection<ListEntry> Statuses { get; set; }
        public ICollection<ListEntry> Priorities { get; set; }
        public ICollection<ListEntry> Customers { get; set; }
        public ICollection<ListEntry> ServiceTypes { get; set; }
        public ICollection<ListEntry> TicketTypes { get; set; }
        public int Id { get; internal set; }
    }


   
}
