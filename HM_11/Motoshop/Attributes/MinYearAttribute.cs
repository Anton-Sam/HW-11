using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Motoshop.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class MinYearAttribute : DataTypeAttribute
    {
        public int MinYear { get; set; }

        public MinYearAttribute() : base("DateTime")
        {           
        }

        public override bool IsValid(object value)
        {
            ErrorMessage = $"Value is must be within [{MinYear} year; {DateTime.Now.ToShortDateString()}]";
            if (value is not DateTime)
                return false;
            var dateTime = (DateTime)value;
            return dateTime.Year >= MinYear && dateTime <= DateTime.Now; 
        }
    }
}
