﻿namespace EventSourcingAndOutbox.Models.Request
{
    public class CreateOrderRequest
    {
        public string Product { get; set; }
        public int Quantity { get; set; }
    }
}
