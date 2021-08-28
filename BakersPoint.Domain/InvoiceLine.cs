namespace BakersPoint.Domain
{
    public class InvoiceLine
    {
        public int InvoiceLineId { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }

        //navigation properties
        public int InvoiceId { get; set; }
        public Invoice Invoice { get; set; }
    }
}