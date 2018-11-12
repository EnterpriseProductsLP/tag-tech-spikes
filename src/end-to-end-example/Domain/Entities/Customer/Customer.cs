using System.Collections.Generic;
using Common.EntityTypes;

namespace Domain.Entities.Customer
{
    [AggregateRoot]
    public class Customer : Entity
    {
        public Customer()
        {
            Orders = new HashSet<Order>();
        }

        public ICollection<Order> Orders { get; }
    }
}
