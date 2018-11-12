using System;
using Common.EntityTypes;

namespace Domain.Entities.Customer
{
    [Aggregate]
    public class Order : Entity
    {
        public decimal OrderTotal { get; set; }

        public DateTime DateAndTimePlaced { get; set; }
    }
}