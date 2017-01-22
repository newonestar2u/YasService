namespace YasService.Controllers
{
    using System.Collections.Generic;
    using System.Web.Http;

    using Models;
    using Models.Context;

    public class OrderLinesController : BaseController<OrderLine>
    {
        public OrderLinesController(IUnitOfWork<YasContext> context) : base(context) { }


        [Route("Orders/{orderId}/OrderLine"), HttpGet]
        public new IEnumerable<OrderLine> Get(int orderId)
        {
            return this.Repository.Get(f => f.OrderNumber.Equals(orderId));
        }

        [Route("Orders/{orderId}/OrderLine/{Id}"), HttpGet]
        public OrderLine Get(int orderId, int id)
        {
            return base.Get(id);
        }

        [Route("Orders/{orderId}/OrderLine"), HttpPost]
        public OrderLine Post(int orderId, [FromBody]OrderLine orderLIne)
        {
            return base.Post(orderLIne);
        }

        [Route("Orders/{orderId}/OrderLine/{Id}"), HttpPut]
        public OrderLine Put(int orderId, int id, [FromBody]OrderLine orderLIne)
        {
            return base.Put(id, orderLIne);
        }

        [Route("Orders/{orderId}/OrderLine/{Id}"), HttpDelete]
        public void Delete(int orderId, int id)
        {
            base.Delete(id);
        }
    }
}
