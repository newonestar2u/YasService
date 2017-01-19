namespace YasService.Controllers
{
    using System.Collections.Generic;
    using System.Web.Http;

    using Models;
    using Models.Context;

    using YasService.Exceptions;

    public class CustomerController : BaseController<Customer>
    {
        public CustomerController(IUnitOfWork<YasContext> context) : base(context) { }

        [Route("Customer"), HttpGet]
        public override IEnumerable<Customer> Get()
        {
            return base.Get();
        }

        [Route("Customer/{Id}"), HttpGet]
        public override Customer Get(int id)
        {
            return base.Get(id);
        }

        [Route("Customer"), HttpPost]
        public override Customer Post([FromBody]Customer customer)
        {
            if (base.Repository.Any(f => f.CustomerId == customer.CustomerId))
                throw new BusinessValidationException($"Customer Id already used.");

            return base.Post(customer);
        }

        [Route("Customer/{Id}"), HttpPut]
        public override Customer Put(int id, [FromBody]Customer customer)
        {
            return base.Put(id, customer);
        }

        [Route("Customer/{Id}"), HttpDelete]
        public override void Delete(int id)
        {
            base.Delete(id);
        }
    }
}
