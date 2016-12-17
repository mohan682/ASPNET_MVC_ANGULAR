using System;
using System.Diagnostics;
using UserManagement.Annotations;

namespace UserManagement.Factory
{
    public static class Extensions
    {
        public static Type ToType( this Enum value )
        {
            //works only with EntityType
            if (value is EntityType == false)
            {
                Debug.WriteLine("Error, Enum.ToType() called for not compactible enum!");
                return null;
            }

            var fi = value.GetType().GetField(value.ToString());

            var attributes = (EntityTypeMappingAttribute[])fi.GetCustomAttributes(typeof(EntityTypeMappingAttribute), false);

            return attributes[0].Type;
        }

        [ContractAnnotation("null=>false")]
        public static bool HasValue( this string s )
        {
            return !string.IsNullOrWhiteSpace(s);
        }

        [ContractAnnotation("null=>true")]
        public static bool HasNoValue( this string value )
        {
            return !value.HasValue();
        }
    }
}
