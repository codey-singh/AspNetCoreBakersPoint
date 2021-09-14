using BakersPoint.Domain;
using BakersPoint.Infrastructure;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BakersPoint.Application
{
    public interface IInvoiceService
    {
        Task<Invoice> GetInvoiceById(int id);
        Task<IEnumerable<Invoice>> GetAllInvoices();
    }
    public class InvoiceService : IInvoiceService
    {
        private readonly IApplicationContext _context;
        public InvoiceService(IApplicationContext context)
        {
            _context = context;
        }
        public Task<IEnumerable<Invoice>> GetAllInvoices()
        {
            return Task.FromResult(_context.Invoices.AsEnumerable());
        }

        public async Task<Invoice> GetInvoiceById(int id)
        {
            return await _context.Invoices.FindAsync(id);
        }
    }
}
