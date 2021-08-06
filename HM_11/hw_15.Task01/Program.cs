using hw_15.Task01.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;

namespace hw_15.Task01
{
    class Program
    {
        static void Main(string[] args)
        {
            Example();
        }

        private static void Example()
        {
            #region Task01
            Random random = new Random();
            Customer customer1 = new Customer() { Age = random.Next(18, 100) };
            Validate(nameof(customer1), customer1);
            Customer customer2 = new Customer() { Age = random.Next(1, 17), Name = Faker.Name.FullName() };
            Validate(nameof(customer2), customer2);

            Motorcycle motorcycle1 = new Motorcycle() { Model = "Honda CB CM400T", VIN = "WWW234BC234" };
            Validate(nameof(motorcycle1), motorcycle1);
            Motorcycle motorcycle2 = new Motorcycle() { Model = "Yamaha XJ 600", Odometer = 3000, VIN = "WWW3458NN34" };
            Validate(nameof(motorcycle2), motorcycle2);

            PurchaseMotocycle purchaseMotocycle1 = new PurchaseMotocycle() { Motocycle = motorcycle1, Customer = customer1, Price = random.Next(5000, 20000), CreditCard = "4556043419646344" };
            Validate(nameof(purchaseMotocycle1), purchaseMotocycle1);
            PurchaseMotocycle purchaseMotocycle2 = new PurchaseMotocycle() { Motocycle = motorcycle2, Customer = customer2, Price = random.Next(5000, 20000) };
            Validate(nameof(purchaseMotocycle2), purchaseMotocycle2);
            purchaseMotocycle2.CreditCard = EnterCreaditCardNumber(purchaseMotocycle2, "CreditCard");
            Validate(nameof(purchaseMotocycle2), purchaseMotocycle2);
            #endregion

            #region Task03
            ChangeObsoleteMessage(purchaseMotocycle2);
            ChangeConstantBank(purchaseMotocycle2);
            #endregion
        }

        #region Task01
        private static void Validate<T>(string objName, T obj)
        {
            var results = new List<ValidationResult>();
            var context = new ValidationContext(obj);
            Console.Write($"Object ({objName})");
            if (!Validator.TryValidateObject(obj, context, results, true))
            {
                Console.WriteLine(" is not valid");
                foreach (var error in results)
                    Console.WriteLine(error.ErrorMessage);
                Console.WriteLine("");
                return;
            }
            Console.WriteLine(" is valid\n");
        }

        private static string EnterCreaditCardNumber<T>(T obj, string propertyName)
        {
            Console.Write("Enter credit card number: ");
            string creditCard = Console.ReadLine();
            var results = new List<ValidationResult>();
            var context = new ValidationContext(creditCard);
            var attributes = typeof(T)
                .GetProperty(propertyName)
                .GetCustomAttributes(false)
                .OfType<ValidationAttribute>()
                .ToArray();

            if (!Validator.TryValidateValue(creditCard, context, results, attributes))
            {
                foreach (var result in results)
                    Console.WriteLine(result.ErrorMessage);
                return EnterCreaditCardNumber(obj, propertyName);
            }
            return creditCard;
        }
        #endregion

        #region Task03
        private static void ChangeObsoleteMessage<T>(T obj)
        {
            Type objType = typeof(T);
            foreach (var method in objType.GetTypeInfo().DeclaredMethods)
            {
                foreach (var attribute in method.GetCustomAttributes())
                {
                    ObsoleteAttribute methodAttribute = attribute as ObsoleteAttribute;
                    if (methodAttribute != null)
                    {
                        Console.WriteLine($"Original Obsolete error message: {methodAttribute.Message}");
                        Type obsoletType = typeof(ObsoleteAttribute);
                        IList<FieldInfo> fields = obsoletType.GetRuntimeFields().ToList();
                        for (int i = 0; i < fields.Count; i++)
                        {
                            if (fields[i].Name.Contains("<Message>"))
                            {
                                fields[i].SetValue(methodAttribute, "Soon this method will NOT be removed!");
                                break;
                            }
                        }
                        Console.WriteLine($"Changed Obsolete error message: {methodAttribute.Message}\n\n");
                    }
                }
            }
        }

        private static void ChangeConstantBank<T>(T obj)
        {
            Type objType = typeof(T);
            FieldInfo bank = objType.GetField("Bank", BindingFlags.Public | BindingFlags.Static | BindingFlags.FlattenHierarchy);
            if (bank != null)
            {
                Console.WriteLine($"Original constant: {bank.GetValue(obj)}");
                try
                {
                    bank.SetValue(obj, "AlfaBank");
                    Console.WriteLine($"Changed constant: {bank.GetValue(obj)}");
                }
                catch (FieldAccessException ex)
                {
                    Console.WriteLine($"{ex.Message}");
                }
            }
        }
        #endregion
    }
}
