using System;
using System.ComponentModel.DataAnnotations;

namespace Motoshop.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class GuidAttribute : DataTypeAttribute
    {     
        public GuidAttribute() : base("Guid")
        {
            ErrorMessage = "Value is not Guid type";
        }

        public override bool IsValid(object value)
        {
            if (value == null)
                return false;
            
            return Guid.TryParse(value.ToString(), out _);
        }
    }
}
