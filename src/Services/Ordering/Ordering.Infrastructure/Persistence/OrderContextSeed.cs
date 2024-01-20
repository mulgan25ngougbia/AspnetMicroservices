using Microsoft.Extensions.Logging;
using Ordering.Domain.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Infrastructure.Persistence
{
    public class OrderContextSeed
    {
        public static async Task SeedAsync(OrderContext orderContext, ILogger<OrderContextSeed> logger)
        {
            if (orderContext.Orders != null && !orderContext.Orders.Any())
            {
                orderContext.Orders.AddRange(GetPreconfiguredOrders());
                await orderContext.SaveChangesAsync();
                logger.LogInformation("Seed database associated with context {DbContextName}", typeof(OrderContext).Name);
            }
        }

        private static IEnumerable<Order> GetPreconfiguredOrders()
        {
            return new List<Order>
            {
                new Order() {UserName = "swn", FirstName = "Mehmet", LastName = "Ozkaya", CVV = "xxxx", CardNumber = "xxxx-xxxx-xxxx-xxxx", CardName= "card name",Expiration ="Never",PaymentMethod= 0,
                    EmailAddress = "ezozkme@gmail.com", AddressLine = "Bahcelievler", State="city", Country = "Turkey", TotalPrice = 350, ZipCode = "5222",
                    CreatedBy = "swn", CreatedDate = DateTime.Now, LastModifiedBy = "swn", LastModifiedDate = DateTime.Now,
                }
            };
        }
    }
}
