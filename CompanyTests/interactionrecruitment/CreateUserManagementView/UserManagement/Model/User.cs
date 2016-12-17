using System.Collections.Generic;
using System.Runtime.Serialization;
using UserManagement.Factory;

namespace UserManagement.Model
{
    [DataContract(Namespace = "Data", Name = "User")]
    [KnownType(typeof(User))]
    public class User : Entity
    {
        public static List<User> Users => Load<User>();

        public Property Firstname => PropertyMapping("Firstname");

        public Property Surname => PropertyMapping("Surname");

        [DataMember(IsRequired = true, Order = 110)]
        public Role Role { get; set; }

        public User() 
            : base(EntityType.User)
        { }

        public override string ToString()
        {
            return $"[{ID.ToString().PadLeft(3, '0')}] {Firstname?.Value} {Surname?.Value}";
        }
    }
}
