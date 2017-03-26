using App.Controller.TicketList.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace App.Components.TicketList
{
    public class TicketListModel
    {   
        public BindingSource BindingSource { get; }

        public TicketListModel()
        {
            BindingSource = new BindingSource();
        }
    }
}
