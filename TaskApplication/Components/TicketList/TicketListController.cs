using App.Components.TicketList;
using App.Controller;
using App.Controller.TicketList.Model;
using App.Model;
using Core.Manager;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace App.Controller.TicketList
{
    public class TicketListController
    {

        public TicketListModel Model { get; }

        public AppContext Context { get; }

        public TicketListController(AppContext context)
        {
            Model = new TicketListModel();
            Context = context;
        }

        public async Task LoadTicketsAsync()
        {
            Model.BindingSource.Clear();

            var userId = Context.UserId;
            IAdaptor<Ticket, TicketEntryModel> adaptor = new TicketEntryModelAdaptor();
            ICollection<TicketEntryModel> entries = await TicketManager.Instance.FindUserTicketsAsync(userId, adaptor);
            foreach (var entry in entries)
            {
                Model.BindingSource.Add(entry);
            }
        }
    }
}
