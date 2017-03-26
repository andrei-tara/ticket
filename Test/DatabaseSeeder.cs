using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Core.Manager;
using Core.Service;
using Model;

namespace Test
{
    [TestClass]
    public class DatabaseSeeder
    {
        [TestMethod]
        public void FillDatabaseUsers()
        {

            UserManager.Instance.FindOrCreate("andrei.tara@email.com", "1234");
            UserManager.Instance.FindOrCreate("jonny.cash@email.com", "12345");

        }

        [TestMethod]
        public void FillDatabasePriorities()
        {

            ServiceProvider.PriorityService.FindOrCreate("Major");
            ServiceProvider.PriorityService.FindOrCreate("Minor");
            ServiceProvider.PriorityService.FindOrCreate("Critical");
            ServiceProvider.PriorityService.FindOrCreate("Trivial");

        }

        [TestMethod]
        public void FillDatabaseTicketTypes()
        {

            ServiceProvider.TicketTypeService.FindOrCreate("Bug");
            ServiceProvider.TicketTypeService.FindOrCreate("Improuvement");

        }

        [TestMethod]
        public void FillDatabaseServiceTypes()
        {
            ServiceProvider.ServiceTypeService.FindOrCreate("Support");
            ServiceProvider.ServiceTypeService.FindOrCreate("Development");

        }

        [TestMethod]
        public void FillDatabaseCustomers()
        {

            ServiceProvider.CustomerService.FindOrCreate("Microsft");
            ServiceProvider.CustomerService.FindOrCreate("Amazon");
            ServiceProvider.CustomerService.FindOrCreate("Google");

        }

        [TestMethod]
        public void FillDatabaseStatusese()
        {

            ServiceProvider.StatusService.Create("Open");
            ServiceProvider.StatusService.Create("Closed");
            ServiceProvider.StatusService.Create("In progress");

        }

        [TestMethod]
        public void FillDatabaseDummyTickets()
        {
            User user = UserManager.Instance.FindOrCreate("andrei.tara@email.com", "1234");

            var ticket1 = new Ticket
            {
                Subject = "Ticket - 01",
                Description = "Description 01",
                Priority_Id = ServiceProvider.PriorityService.FindByName("Trivial").Id,
                Customer_Id = ServiceProvider.CustomerService.FindByName("Google").Id,
                ServiceType_Id = ServiceProvider.ServiceTypeService.FindByName("Development").Id,
                Status_Id = ServiceProvider.StatusService.FindByName("Open").Id,
                Type_Id = ServiceProvider.TicketTypeService.FindByName("Bug").Id

            };
            TicketManager.Instance.PersistTicket(ticket1, user.Id);

            var ticket2 = new Ticket
            {
                Subject = "Ticket - 02",
                Description = "Description 02",
                Priority_Id = ServiceProvider.PriorityService.FindByName("Trivial").Id,
                Customer_Id = ServiceProvider.CustomerService.FindByName("Amazon").Id,
                ServiceType_Id = ServiceProvider.ServiceTypeService.FindByName("Support").Id,
                Status_Id = ServiceProvider.StatusService.FindByName("Open").Id,
                Type_Id = ServiceProvider.TicketTypeService.FindByName("Bug").Id

            };

            TicketManager.Instance.PersistTicket(ticket2, user.Id);
        }
        


    }
}
