using App.Components;
using App.Components.TicketList;
using App.Controller.TicketList.Model;
using App.Util;
using Core.Manager;
using Core.Service;
using Model;

using System.Linq;



namespace App.Controller.TicketList
{
    public class TicketDetailsController
    {

        public TicketDetailsModel Model { get; }

        private AppContext Context { get; }
        

        public TicketDetailsController(AppContext context)
        {
            Model = new TicketDetailsModel();
            Context = context;
        }
        

        internal void SaveModel( )
        {
            // Create customer if required
            var customer = ServiceProvider.CustomerService.FindOrCreate(Model.Customer.Name);
            var ticket = new Ticket
            {
                Id = Model.Id,
                Subject = Model.Subject,
                Description = Model.Description,
                Priority_Id = (int)Model.Priority.Id,
                ServiceType_Id = (int)Model.ServiceType.Id,
                Status_Id = (int)Model.Status.Id,
                Type_Id = (int)Model.TicketType.Id,
                Customer_Id = customer.Id

            };
            TicketManager.Instance.PersistTicket(ticket, Context.UserId);
        }

        internal void LoadModel(int? ticketId, CRUDActionType action)
        {
            Model.ReadOnly = (action == CRUDActionType.DELETE);
            FillSelectorsCandidateSets();

            switch (action)
            {
                case CRUDActionType.CREATE:
                    break;
                case CRUDActionType.DELETE:
                case CRUDActionType.UPDATE:
                    Model.Id = (int)ticketId;
                    var ticket = TicketManager.Instance.FindById((int)ticketId);
                    FillSelectorsSelections(ticket);
                    break;
            }
        }

        private void FillSelectorsSelections(Ticket ticket)
        {  
            Model.Customer = Model.Customers.Single(elem => elem.Id == ticket.Customer_Id);
            Model.Priority = Model.Priorities.Single(elem => elem.Id == ticket.Priority_Id);
            Model.ServiceType = Model.ServiceTypes.Single(elem => elem.Id == ticket.ServiceType_Id);
            Model.Status = Model.Statuses.Single(elem => elem.Id == ticket.Status_Id);
            Model.TicketType = Model.TicketTypes.Single(elem => elem.Id == ticket.Type_Id);
        }

        private void FillSelectorsCandidateSets()
        {
            var adaptor = new ListEntryAdaptor();
            Model.Customers = CustomerManager.Instance.FindAllAndAdapt(adaptor as IAdaptor<Customer, ListEntry>);
            Model.Priorities = PriorityManager.Instance.FindAllAndAdapt(adaptor as IAdaptor<Priority, ListEntry>);
            Model.Statuses = StatusManager.Instance.FindAllAndAdapt(adaptor as IAdaptor<Status, ListEntry>);
            Model.ServiceTypes = ServiceTypeManager.Instance.FindAllAndAdapt(adaptor as IAdaptor<ServiceType, ListEntry>);
            Model.TicketTypes = TicketTypeManager.Instance.FindAllAndAdapt(adaptor as IAdaptor<TicketType, ListEntry>);
        }
    }

   
}
