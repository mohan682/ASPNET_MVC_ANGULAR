using System;
using UserManagement.Model;

namespace UserManagement.Factory
{
    public enum EntityType
    {
        [EntityTypeMapping(typeof(Entity))]
        Unknown, 

        [EntityTypeMapping(typeof(User))]
        User,

        [EntityTypeMapping(typeof(Role))]
        Role
    }

    public class EntityTypeMappingAttribute : Attribute
    {
        public Type Type { get; }

        public EntityTypeMappingAttribute( Type type )
        {
            Type = type;
        }
    }
}