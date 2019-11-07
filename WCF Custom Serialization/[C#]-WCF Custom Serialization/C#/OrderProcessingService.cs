using System;

namespace OptimizedSerialization
{
    public class OrderProcessingService : IOrderProcessing
    {
        public void ProcessOrder(Order order)
        {
            Console.WriteLine("Processing order {0} from {1}", order.Id, order.Date);
            Console.WriteLine("Products:");
            foreach (var product in order.Items)
            {
                Console.WriteLine(" {0}: ${1} per {2}", product.Name, product.UnitPrice, product.Unit);
            }
        }

        public Order GetOrder(int id)
        {
            return new Order
            {
                Id = id,
                Date = DateTime.Now,
                Items = new Product[]
                {
                    new Product { Name = "Bread", Unit = "un", UnitPrice = 1 },
                    new Product { Name = "Milk", Unit = "box", UnitPrice = 2 },
                },
            };
        }
    }
}
