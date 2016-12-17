using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using UserManagement.Annotations;
using UserManagement.Database;
using UserManagement.Model;

namespace UserManagement.Factory
{
    [DataContract(Namespace = "Data", Name = "Entity")]
    [KnownType(typeof(Property))]
    [KnownType(typeof(User))]
    [KnownType(typeof(Role))]

    public class Entity : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged( [CallerMemberName] string propertyName = null )
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private static List<Entity> _entities;
        internal static List<Entity> Entities => _entities ?? (_entities = XML.Load<List<Entity>>());

        [DataMember(IsRequired = true, Order = 0)]
        public int ID { get; private set; }

        [DataMember(IsRequired = true, Order = 1)]
        internal EntityType Type { get; set; }

        private ObservableCollection<Property> _properties;
        [DataMember(IsRequired = true, Order = 2)]
        public ObservableCollection<Property> Properties
        {
            get { return _properties; }
            set
            {
                if (Equals(value, _properties)) return;
                _properties = value;
                OnPropertyChanged();
            }
        }

        protected Entity(EntityType type)
        {
            if (type == EntityType.Unknown)
            {
                Debug.WriteLine("Error: EntityType is unknown while creating entity!");
                return;
            }

            Type = type;

            //temporary solution to add only highter id then already exists, does not take into account audit/track data as there is none of such
            var maxID = 0;
            foreach (var entity in Entities)
            {
                if (entity.ID > maxID) maxID = entity.ID + 1;
            }

            ID = maxID;
            
            Properties = new ObservableCollection<Property>();

            Debug.WriteLine($"Info: Created entity({type}) with id = {ID}");
            
        }

        protected Property PropertyMapping(string code)
        {
            if (Properties == null)
            {
                Debug.WriteLine("Error: Properties not loaded or else!");
                return null;
            }

            var result = Properties.FirstOrDefault(p => p.Code == code);
            if (result == null)
            {
                Debug.WriteLine($"Error: Property {code} not found!");
                return null;
            }

            return result;
        }

        protected static List<T> Load<T>() where T : class
        {
            //get type of entity from attribute stored along enum
            var type = Enum.GetValues(typeof (EntityType))
                .Cast<EntityType>()
                .First(c => c.ToType() == typeof (T));

            //get entities of this type
            var result = Entities.Where(e => e.Type == type).Select(entity => entity as T);
            
            return result.ToList(); 
        }

        public override string ToString()
        {
            return $"{Type}: {ID}";
        }

    }
}