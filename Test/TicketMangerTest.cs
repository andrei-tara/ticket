using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Core.Manager;
using Model;

namespace TicketMangerTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Test_FindById()
        {
            var ticket = TicketManager.Instance.FindById(1);
            Assert.AreEqual(ticket.Id, 1);
        }

        [TestMethod]
        public void Test_FindUserTickets()
        {
            var tickets = TicketManager.Instance.FindUserTickets(1);
            Assert.AreNotEqual(tickets.Count, 0);
        }
        

        [TestMethod]
        public async System.Threading.Tasks.Task Test_FindUserTicketsAsync()
        {
            var tickets = await TicketManager.Instance.FindUserTicketsAsync(1, new TestAdaptor());
            Assert.AreNotEqual(tickets.Count, 0);
        }

    }


    class TestAdaptor : IAdaptor<Ticket, Ticket>
    {
        public Ticket adapt(Ticket entry)
        {
            return entry;
        }
    }
}
