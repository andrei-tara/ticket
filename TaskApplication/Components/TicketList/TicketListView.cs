using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using App.Controller;
using App.Controller.TicketList;
using App.Model;
using App.Components;
using App.Util;
using Core.Manager;
using Model;

namespace App.UI
{
    public partial class TicketListView : Form
    {
        public TicketListController Controller { get; set; }

        public TicketListView()
        {
            InitializeComponent();
            
        }

        private void TicketListView_Load(object sender, EventArgs e)
        {
            ticketsGridView.DataSource = Controller.Model.BindingSource;
        }

        private void resolveTicketButton_Click(object sender, EventArgs e)
        {
            var selection = UIUtil.GetSelectionFromDataGrid<TicketEntryModel>(ticketsGridView);
            if (selection == null)
            {
                MessageBox.Show("Select ticket");
                return;
            }

            FlowController.Instance.NavigateToCloseTicket(selection?.Id);
        }

        private void createTicket_Click(object sender, EventArgs e)
        {
            FlowController.Instance.NavigateToTicket(null, CRUDActionType.CREATE);
        }

        private void editTicketButton_Click(object sender, EventArgs e)
        {
            var selection = UIUtil.GetSelectionFromDataGrid<TicketEntryModel>(ticketsGridView);
            if (selection == null)
            {
                MessageBox.Show("Select ticket");
                return;
            }
            FlowController.Instance.NavigateToTicket(selection?.Id, CRUDActionType.UPDATE);
        }
    }
}
