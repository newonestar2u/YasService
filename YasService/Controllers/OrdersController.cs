using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
namespace YasService.Controllers
{
    using System.Web.Http;
    using Models;
    using Models.Context;

    public class OrdersController : BaseController<Order>
    {
        public OrdersController(IUnitOfWork<YasContext> context) : base(context) { }

        [Route("Orders"), HttpGet]
        public override IEnumerable<Order> Get()
        {
            return base.Get();
        }

        [Route("Orders/{Id}"), HttpGet]
        public override Order Get(int id)
        {
            var data = base.Get(id);
            return data;
        }

        [Route("Orders"), HttpPost]
        public override Order Post([FromBody]Order order)
        {
            return base.Post(order);
        }

        [Route("Orders/{Id}"), HttpPut]
        public override Order Put(int id, [FromBody]Order order)
        {
            return base.Put(id, order);
        }

        [Route("Orders/{Id}"), HttpDelete]
        public override void Delete(int id)
        {
            base.Delete(id);
        }
    }
}
