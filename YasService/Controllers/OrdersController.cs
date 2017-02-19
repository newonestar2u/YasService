namespace YasService.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
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

        [Route("Orders/{Id}", Name = "GetById"), HttpGet]
        public override Order Get(int id)
        {
            var data = base.Get(id);
            return data;
        }

        [Route("Orders", Name = "PostOrders"), HttpPost]
        public new IHttpActionResult Post([FromBody]Order order)
        {
            order.Approved = true;
            var result = base.Post(order);
            foreach (var orderLine in order.OrderLines)
            {
                orderLine.OrderNumber = result.Id;
                Context.GetRepository<OrderLine>().Insert(orderLine);
            }

            var invoice = new Invoice
            {
                Amount = result.OrderLines.Sum(x => x.Amount),
                CustomerId = result.CustomerId,
                OrderNumber = result.Id,
                Status = "Open",
                OrderdOn = DateTime.Now
            };
            Context.GetRepository<Invoice>().Insert(invoice);
            Context.Save();

            return CreatedAtRoute("GetById", new { controller = "messages", id = result.Id }, result);
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
