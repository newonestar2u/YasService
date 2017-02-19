namespace YasService.Controllers
{
    using System.Web.Http;
    using System.Collections.Generic;
    using Models;
    using Models.Context;

    public class InvoicesController : BaseController<Invoice>
    {
        public InvoicesController(IUnitOfWork<YasContext> context) : base(context) { }

        [Route("Invoices"), HttpGet]
        public override IEnumerable<Invoice> Get()
        {
            return this.Repository.Get(f => f.Status == "Open");
        }

        [Route("Invoices/{id}"), HttpGet]
        public override Invoice Get(int id)
        {
            return base.Get(id);
        }

        [Route("Invoices"), HttpPost]
        public override Invoice Post([FromBody]Invoice invoice)
        {
            return base.Post(invoice);
        }
    }
}