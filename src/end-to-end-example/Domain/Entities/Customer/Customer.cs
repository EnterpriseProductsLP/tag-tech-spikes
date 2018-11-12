using System.Collections.Generic;
using Common.EntityTypes;

namespace Domain.Entities.Customer
{
    [AggregateRoot]
    public class Customer : Entity
    {
        public Customer()
        {
            Order = new HashSet<Order>();
        }

        public ICollection<Order> Order { get; }
    }
}
