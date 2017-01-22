namespace YasService.Controllers
{
    using System.Collections.Generic;
    using System.Web.Http;

    using Models;
    using Models.Context;

    using YasService.Exceptions;

    public class CustomersController : BaseController<Customer>
    {
        public CustomersController(IUnitOfWork<YasContext> context) : base(context) { }

        [Route("Customers"), HttpGet]
        public override IEnumerable<Customer> Get()
        {
            return base.Get();
        }

        [Route("Customers/{Id}"), HttpGet]
        public override Customer Get(int id)
        {
            return base.Get(id);
        }

        [Route("Customers"), HttpPost]
        public override Customer Post([FromBody]Customer customer)
        {
            if (base.Repository.Any(f => f.CustomerId == customer.CustomerId))
                throw new BusinessValidationException($"Customer Id already used.");

            return base.Post(customer);
        }

        [Route("Customers/{Id}"), HttpPut]
        public override Customer Put(int id, [FromBody]Customer customer)
        {
            return base.Put(id, customer);
        }

        [Route("Customers/{Id}"), HttpDelete]
        public override void Delete(int id)
        {
            base.Delete(id);
        }
    }
}
