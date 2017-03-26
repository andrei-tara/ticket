using System.Collections.Generic;

namespace Core.Service
{
    public class TicketSearchCriteria
    {
        public int? AsigneeUserId {get;set;}
        public ICollection<int> Statuses { get; set; }
    }
}