using System;
using System.Collections.Generic;

namespace BakersPoint.Domain
{
    public class Invoice
    {
        public int InvoiceId { get; set; }
        public string CustomerName { get; set; }
        public string DeliveryAddress { get; set; }
        public DateTime PlannedTime { get; set; }
        public DateTime? ActualDeliveryTime { get; set; }

        //Navigation Properties
        public ICollection<InvoiceLine> InvoiceLines { get; set; }
    }
}