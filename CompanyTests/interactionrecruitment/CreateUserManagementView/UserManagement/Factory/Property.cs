using System.Runtime.Serialization;

namespace UserManagement.Factory
{
    [DataContract(Namespace = "Data", Name = "Property")]
    [KnownType(typeof(Property))]
    public class Property
    {
        [DataMember(IsRequired = true, Order = 1)]
        public string Code { get; set; }

        [DataMember(IsRequired = true, Order = 2)]
        public string Value { get; set; }

        public override string ToString()
        {
            return $"{Code}: {Value}";
        }
    }
}
