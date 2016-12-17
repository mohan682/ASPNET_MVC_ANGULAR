using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserManagement.ViewModel
{
    public class ViewModelBaseClass : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged = delegate { };
        public void RaisePropertyChanged(string property)
        { PropertyChanged(this, new PropertyChangedEventArgs(property)); }

       
    }
}
