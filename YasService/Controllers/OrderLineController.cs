namespace YasService.Controllers
{
    using System.Collections.Generic;
    using System.Web.Http;

    using Models;
    using Models.Context;

    public class OrderLineController : BaseController<OrderLine>
    {
        public OrderLineController(IUnitOfWork<YasContext> context) : base(context) { }


        [Route("Order/{orderId}/OrderLine"), HttpGet]
        public new IEnumerable<OrderLine> Get(int orderId)
        {
            return this.Repository.Get(f => f.OrderNumber.Equals(orderId));
        }

        [Route("Order/{orderId}/OrderLine/{Id}"), HttpGet]
        public OrderLine Get(int orderId, int id)
        {
            return base.Get(id);
        }

        [Route("Order/{orderId}/OrderLine"), HttpPost]
        public OrderLine Post(int orderId, [FromBody]OrderLine orderLIne)
        {
            return base.Post(orderLIne);
        }

        [Route("Order/{orderId}/OrderLine/{Id}"), HttpPut]
        public OrderLine Put(int orderId, int id, [FromBody]OrderLine orderLIne)
        {
            return base.Put(id, orderLIne);
        }

        [Route("Order/{orderId}/OrderLine/{Id}"), HttpDelete]
        public void Delete(int orderId, int id)
        {
            base.Delete(id);
        }
    }
}
