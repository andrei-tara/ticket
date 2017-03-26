using App.Components.TicketList;
using App.Controller;
using App.Controller.TicketList;
using App.Util;
using Core.Service;
using Core.Util;
using Model;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace App.Components.TicketDetails
{
    public partial class TicketDetailsView : Form
    {
        public TicketDetailsController Controller { get; set; }

        public TicketDetailsView()
        {
            InitializeComponent();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void TicketDetailsView_Load(object sender, EventArgs e)
        {
            FillViewFromModel();
        }

        private void FillViewFromModel()
        {
            var model = Controller.Model;
            UIUtil.PopulateComboBox(priorityComboBox, model.Priorities, model.Priority);
            UIUtil.PopulateComboBox(customerComboBox, model.Customers, model.Customer);
            UIUtil.PopulateComboBox(statusComboBox, model.Statuses, model.Status);
            UIUtil.PopulateComboBox(serviceTypeComboBox, model.ServiceTypes, model.ServiceType);
            UIUtil.PopulateComboBox(typeComboBox, model.TicketTypes, model.TicketType);

            subjectTextBox.Text = model.Subject;
            descriptionRichTextBox.Text = model.Description;
        }
        
        private void saveButton_Click(object sender, EventArgs e)
        {
            if (!ValidateAll())
            {
                MessageBox.Show("All inputs are required");
                return;
            }

            FillModelFromView();
            Controller.SaveModel();
            FlowController.Instance.NavigateBackToTicketList();
            Close();
        }

        private void FillModelFromView()
        {
            var model = Controller.Model;
            model.Subject = subjectTextBox.Text;
            model.Description = descriptionRichTextBox.Text;
            model.Priority = UIUtil.GetValue(priorityComboBox);
            model.ServiceType = UIUtil.GetValue(serviceTypeComboBox);
            model.Status = UIUtil.GetValue(statusComboBox);
            model.TicketType = UIUtil.GetValue(typeComboBox);
            model.Customer = UIUtil.GetValue(customerComboBox);
        }

        private bool ValidateAll()
        {
            bool valid = true;

            IList<ComboBox> comboBoxes = CollectionUtil.AsList(statusComboBox, priorityComboBox, serviceTypeComboBox, typeComboBox);
            valid &= UIUtil.ValidateComboBoxes(comboBoxes);
            valid &= !String.IsNullOrWhiteSpace(subjectTextBox.Text);
            valid &= !String.IsNullOrWhiteSpace(descriptionRichTextBox.Text);

            return valid;
        }
        
      
    }
}
