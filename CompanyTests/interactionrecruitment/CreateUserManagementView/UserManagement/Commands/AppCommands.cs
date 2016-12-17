﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace UserManagement.Commands
{
    [TypeDescriptionProvider(typeof(CommandMapDescriptionProvider))]
    public class AppCommands
    {
        public void AddCommand(string commandName, Action<object> executeMethod)
        { Commands[commandName] = new DelegateCommand(executeMethod); }

        public void AddCommand(string commandName, Action<object> executeMethod, Predicate<object> canExecuteMethod)
        { Commands[commandName] = new DelegateCommand(executeMethod, canExecuteMethod); }

        public void RemoveCommand(string commandName) { Commands.Remove(commandName); }

        protected Dictionary<string, ICommand> Commands
        { get { if (null == _commands) { _commands = new Dictionary<string, ICommand>(); } return _commands; } }

        private Dictionary<string, ICommand> _commands;

        private class DelegateCommand : ICommand
        {
            public DelegateCommand(Action<object> executeMethod) : this(executeMethod, null) { }
            public DelegateCommand(Action<object> executeMethod, Predicate<object> canExecuteMethod)
            {
                if (null == executeMethod) throw new ArgumentNullException("executeMethod");
                this._executeMethod = executeMethod; this._canExecuteMethod = canExecuteMethod;
            }
            public bool CanExecute(object parameter)
            { return (null == _canExecuteMethod) ? true : _canExecuteMethod(parameter); }
            public event EventHandler CanExecuteChanged
            {
                add { CommandManager.RequerySuggested += value; }
                remove { CommandManager.RequerySuggested -= value; }
            }
            public void Execute(object parameter) { _executeMethod(parameter); }
            private Predicate<object> _canExecuteMethod;
            private Action<object> _executeMethod;
        }

        private class CommandMapDescriptionProvider : TypeDescriptionProvider
        {
            public CommandMapDescriptionProvider() : this(TypeDescriptor.GetProvider(typeof(AppCommands))) { }
            public CommandMapDescriptionProvider(TypeDescriptionProvider parent) : base(parent) { }
            public override ICustomTypeDescriptor GetTypeDescriptor(Type objectType, object instance)
            { return new CommandMapDescriptor(base.GetTypeDescriptor(objectType, instance), instance as AppCommands); }
        }

        private class CommandMapDescriptor : CustomTypeDescriptor
        {
            public CommandMapDescriptor(ICustomTypeDescriptor descriptor, AppCommands map) : base(descriptor) { _map = map; }
            public override PropertyDescriptorCollection GetProperties()
            {
                PropertyDescriptor[] props = new PropertyDescriptor[_map.Commands.Count];
                int pos = 0; foreach (KeyValuePair<string, ICommand> command in _map.Commands)
                    props[pos++] = new CommandPropertyDescriptor(command);
                return new PropertyDescriptorCollection(props);
            }
            private AppCommands _map;
        }

        private class CommandPropertyDescriptor : PropertyDescriptor
        {
            public CommandPropertyDescriptor(KeyValuePair<string, ICommand> command) : base(command.Key, null)
            { _command = command.Value; }
            public override bool IsReadOnly { get { return true; } }
            public override bool CanResetValue(object component) { return false; }
            public override Type ComponentType { get { throw new NotImplementedException(); } }
            public override object GetValue(object component)
            {
                AppCommands map = component as AppCommands;
                if (null == map) { throw new ArgumentException("component is not a CommandMap instance", "component"); }
                return map.Commands[this.Name];
            }
            public override Type PropertyType { get { return typeof(ICommand); } }
            public override void ResetValue(object component) { throw new NotImplementedException(); }
            public override void SetValue(object component, object value) { throw new NotImplementedException(); }
            public override bool ShouldSerializeValue(object component) { return false; }
            private ICommand _command;
        }
    }
}
