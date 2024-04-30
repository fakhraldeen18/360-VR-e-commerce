

using Microsoft.AspNetCore.Mvc;
using sda_onsite_2_csharp_backend_teamwork.src.Entities;

namespace sda_onsite_2_csharp_backend_teamwork.src.Abstractions
{
    public interface IOrderService
    {
        public List<Order> FindAll();
        public Order? FindOne(string OrderId);
        public Order CreateOne([FromBody] Order order);
        public Order? DeleteOne(string OrderId);

    }
}