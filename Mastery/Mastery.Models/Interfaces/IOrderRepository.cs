using System.Collections.Generic;

namespace Mastery.Models.Interfaces
{
    public interface IOrderRepository
    {
        List<Order> LoadOrders(string Date);

        Order EditOrder(Order order);

        Order LoadOrder(string Date, int OrderNumber);

        Order DeleteOrder(string Date, int OrderNumber);

        Order AddOrder(Order order);

        int OrderNumber(string Date);

    }
}
