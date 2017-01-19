using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
namespace YasService.Controllers
{
    using System.Web.Http;
    using Models;
    using Models.Context;

    public class OrderController : BaseController<Order>
    {
        public OrderController(IUnitOfWork<YasContext> context) : base(context) { }

        [Route("Order"), HttpGet]
        public override IEnumerable<Order> Get()
        {
            return base.Get();
        }

        [Route("Order/{Id}"), HttpGet]
        public override Order Get(int id)
        {
            var data = base.Get(id);
            return data;
        }

        [Route("Order"), HttpPost]
        public override Order Post([FromBody]Order order)
        {
            return base.Post(order);
        }

        [Route("Order/{Id}"), HttpPut]
        public override Order Put(int id, [FromBody]Order order)
        {
            return base.Put(id, order);
        }

        [Route("Order/{Id}"), HttpDelete]
        public override void Delete(int id)
        {
            base.Delete(id);
        }
    }
}
