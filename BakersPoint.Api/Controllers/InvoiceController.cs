using BakersPoint.Application;
using Microsoft.AspNetCore.Mvc;

namespace BakersPoint.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceController : ControllerBase
    {
        private readonly ILogger<ProductController> _logger;
        private readonly IInvoiceService _invoiceService;

        public InvoiceController(ILogger<ProductController> logger, IInvoiceService invoiceService)
        {
            _logger = logger;
            _invoiceService = invoiceService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            _logger.LogInformation("Getting all invoices");
            var invoices = await _invoiceService.GetAllInvoices();
            return Ok(invoices);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var invoice = await _invoiceService.GetInvoiceById(id);

            if (invoice is null)
                return NotFound();

            return Ok(invoice);
        }
    }
}
