using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFReportViewer.Model
{
    public class MenuItem
    {
        public String EventTypeDescriptionName { get; set; }
        public ObservableCollection<MenuItem> EventTypesItems { get; set; }

        public MenuItem()
        {
            EventTypesItems = new ObservableCollection<MenuItem>();
        }
        
        
    }
}
