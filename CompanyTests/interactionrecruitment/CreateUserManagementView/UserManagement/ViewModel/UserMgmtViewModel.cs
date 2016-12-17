using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using UserManagement.Model;

namespace UserManagement.ViewModel
{
    public class UserMgmtViewModel : ViewModelBaseClass
    {
        public Window CallingForm; // Used to close the form. Not a property, just a field.

        private int recordcount;
        public int RecordCount
        {
            get { return recordcount; }
            set
            {
                recordcount = value;
                RaisePropertyChanged("RecordCount");
            }
        }

        public Commands.AppCommands _commands;
        public Commands.AppCommands Commands { get { return _commands; } }

       // WPFTestsEntities mgr;

        public ObservableCollection<User> people { get; set; }

        private User selectedperson;
        public User SelectedPerson
        {
            get { return selectedperson; }
            set
            {
                selectedperson = value;
                RaisePropertyChanged("SelectedPerson");
            }
        }

        public UserMgmtViewModel()
        {
           // mgr = new WPFTestsEntities();
           

            _commands = new Commands.AppCommands();

            //_commands.AddCommand("Add", x => Add(), x => !CanSave());
            //_commands.AddCommand("Save", x => Save(), x => CanSave());
            //_commands.AddCommand("Cancel", x => Cancel(), x => CanSave());
            //_commands.AddCommand("Delete", x => Delete(), x => !CanSave());
            //_commands.AddCommand("Close", x => Close(), x => !CanSave());

            LoadData();
        }

        private void LoadData()
        {
            people.Clear();
            people = new ObservableCollection<User>(User.Users);
            RecordCount = people.Count;
            SelectedPerson = people[0];
        }

        //void Add()
        //{
        //    Person NewGuy = new Person();
        //    NewGuy.ID = Guid.NewGuid();
        //    mgr.People.Add(NewGuy);
        //    people.Add(NewGuy);
        //    SelectedPerson = NewGuy;
        //}

        //void Delete()
        //{
        //    if (MessageBox.Show
        //      ("Delete selected row?",
        //      "Not undoable", MessageBoxButton.YesNo,
        //      MessageBoxImage.Question) == MessageBoxResult.Yes)
        //    {
        //        mgr.People.Remove(SelectedPerson);
        //        mgr.SaveChanges();
        //        people.Remove(SelectedPerson);
        //        SelectedPerson = people[0];
        //        RecordCount = people.Count;
        //    }
        //}

        //void Save()
        //{
        //    mgr.SaveChanges();
        //    RecordCount = people.Count;
        //}

        //bool CanSave()
        //{ return mgr.ChangeTracker.HasChanges(); }

        //void Cancel()
        //{
        //    foreach (DbEntityEntry entry in mgr.ChangeTracker.Entries())
        //    {
        //        switch (entry.State)
        //        {
        //            case EntityState.Modified:
        //                entry.State = EntityState.Unchanged; break;
        //            case EntityState.Added:
        //                entry.State = EntityState.Detached; break;
        //            case EntityState.Deleted:
        //                entry.Reload(); break;
        //            default: break;
        //        }
        //    }
        //    LoadData();
        //}

        //void Close()
        //{
        //    if (CallingForm == null)
        //    { MessageBox.Show("Callingform wasn't assigned in codebehind"); }
        //    else { CallingForm.Close(); }
        //}
    }
}
