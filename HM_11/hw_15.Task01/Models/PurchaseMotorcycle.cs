using hw_15.Task01.Attributes;
using System;
using System.ComponentModel.DataAnnotations;

namespace hw_15.Task01.Models
{
    class PurchaseMotocycle
    {
        public const string Bank = "BelSwissBank";
        [Range(1, 100000)]
        public double Price { get; set; }
        [Required, MyCreditCard, StringLength(16, MinimumLength = 13)]
        //[CreditCard]
        public string CreditCard { get; set; }
        public Customer Customer { get; set; }
        public Motorcycle Motocycle { get; set; }

        [Obsolete("Soon this method will be removed!")]
        public void BuyMotorcycle()
        {
            // Doing something
        }
    }
}
