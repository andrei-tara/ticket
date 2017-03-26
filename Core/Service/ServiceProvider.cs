using Core.Service.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Service
{
    public class ServiceProvider
    {

        private static IUserService _userService = new UserServiceImpl();
        public static IUserService UserService => _userService;


        private static ITicketService _ticketService = new TicketServiceImpl();
        public static ITicketService TicketService => _ticketService;


        private static IStatusService _statusService = new StatusServiceImpl();
        public static IStatusService StatusService => _statusService;


        private static IPriorityService _priorityService = new PriorityServiceImpl();
        public static IPriorityService PriorityService => _priorityService;


        private static IServiceTypeService _serviceTypeService = new ServiceTypeServiceImpl();
        public static IServiceTypeService ServiceTypeService => _serviceTypeService;


        private static ICustomerService _customerService = new CustomerServiceImpl();
        public static ICustomerService CustomerService => _customerService;


        private static ITicketTypeService _ticketTypeService = new TicketTypeServiceImpl();
        public static ITicketTypeService TicketTypeService => _ticketTypeService;

    }
}
