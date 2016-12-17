using System.Runtime.Serialization;
using UserManagement.Factory;

namespace UserManagement.Model
{
    [DataContract(Namespace = "Data", Name = "Role")]
    [KnownType(typeof(Role))]
    public class Role : Entity
    {
        public Role() 
            : base(EntityType.Role)
        { }
    }
}