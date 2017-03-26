using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using App.Controller;
using App.UI;
using App.Controller.TicketList;
using App.Controller.TicketList.Model;
using App.Components.TicketDetails;
using App.Components;
using Core.Manager;
using Model;

namespace App.Controller
{
    public class FlowController
    {
        private static FlowController _instance = new FlowController();
        private FlowController()
        {
            Context = new AppContext();
        }
        public static FlowController Instance => _instance;

        public AppContext Context { get; }


        private TicketListView ticketForm;

        /// <summary>
        /// Get application entry point
        /// </summary>
        /// <returns></returns>
        internal Form GetStartingPoint()
        {
            var loginForm = new LoginView();
            return loginForm;
        }

        /// <summary>
        /// Navigate to main ticket screen 
        /// </summary>
        /// <returns></returns>
        internal void NavigateToTicketList(int userId)
        {
            if (ticketForm == null)
            {
                ticketForm = new TicketListView();
                var controller = new TicketListController(Context);
                ticketForm.Controller = controller;
            }

            ticketForm.Show();
            ticketForm.Controller.LoadTicketsAsync();

        }

        internal void NavigateToCloseTicket(int? ticketId)
        {
            var ticketDetailView = NavigateToTicket(ticketId, CRUDActionType.UPDATE);
            var controller = ticketDetailView.Controller;
            var model = controller.Model;
            Status status = StatusManager.Instance.FindByName("Closed");
            model.Status = model.Statuses.Single(elem => elem.Id == status.Id);
        }

        /// <summary>
        /// Navigate to ticket edit
        /// </summary>
        /// <param name="ticketId"></param>
        internal TicketDetailsView NavigateToTicket(int? ticketId, CRUDActionType action)
        {
            var ticketDetailsForm = new TicketDetailsView();
            var controller = new TicketDetailsController(Context);
            controller.LoadModel(ticketId, action);
            ticketDetailsForm.Controller = controller;
            ticketDetailsForm.ShowDialog();
            return ticketDetailsForm;

        }

        internal void NavigateBackToTicketList()
        {
            ticketForm.Show();
            ticketForm.Controller.LoadTicketsAsync();
        }
    }
}
