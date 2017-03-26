using App.Components.TicketList;
using Core.Manager;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace App.Util
{
    class UIUtil
    {
        public static void PopulateComboBox<T>(ComboBox comboBox, ICollection<T> items, T selectedItem)
        {
            foreach (var elem in items)
            {
                comboBox.Items.Add(elem);
            }

            if (selectedItem != null)
            {
                comboBox.SelectedItem = selectedItem;
            }

        }

        public static ListEntry GetValue(ComboBox comboBox)
        {
            var item = comboBox.SelectedItem as ListEntry;
            return item ?? new ListEntry(null, comboBox.SelectedText);
        }

        public static bool ValidateComboBoxes(ICollection<ComboBox> comboBoxes)
        {
            bool valid = true;
            foreach (var combo in comboBoxes)
            {
                valid &= ValidateComboBox(combo);
            }
            return valid;
        }

        private static bool ValidateComboBox(ComboBox comboBox)
        {
            return comboBox.SelectedItem != null;
        }

        public static T? GetSelectionFromDataGrid<T>(DataGridView grid) where T:struct
        {
            var rows = grid.SelectedRows;
            return (rows.Count >= 1) ? (rows[0].DataBoundItem as T?) : null;
        }
    }



    public class ListEntry
    {
        public int? Id { get; set; }
        public string Name { get; set; }

        public ListEntry(int? id, string name)
        {
            Id = id;
            Name = name;
        }

        public override string ToString()
        {
            return Name;
        }
    }

    class ListEntryAdaptor : IAdaptor<Customer, ListEntry>, IAdaptor<Status, ListEntry>, IAdaptor<Priority, ListEntry>, IAdaptor<ServiceType, ListEntry>, IAdaptor<TicketType, ListEntry>
    {
        public ListEntry adapt(ServiceType entry)
        {
            return new ListEntry(entry.Id, entry.Name);
        }
        public ListEntry adapt(TicketType entry)
        {
            return new ListEntry(entry.Id, entry.Name);
        }
        public ListEntry adapt(Customer entry)
        {
            return new ListEntry(entry.Id, entry.Name);
        }
        public ListEntry adapt(Priority entry)
        {
            return new ListEntry(entry.Id, entry.Name);
        }
        public ListEntry adapt(Status entry)
        {
            return new ListEntry(entry.Id, entry.Name);
        }
    }

}
