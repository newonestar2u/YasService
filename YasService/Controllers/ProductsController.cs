namespace YasService.Controllers
{
    using System.Collections.Generic;
    using System.Web.Http;
    using Exceptions;
    using Models;
    using Models.Context;

    public class ProductsController : BaseController<Product>
    {
        public ProductsController(IUnitOfWork<YasContext> context) : base(context) { }

        [Route("Products", Name = "Product"), HttpGet]
        public override IEnumerable<Product> Get()
        {
            return base.Get();
        }

        [Route("Products/{Id}"), HttpGet]
        public override Product Get(int id)
        {
            return base.Get(id);
        }

        [Route("Products"), HttpPost]
        public override Product Post([FromBody]Product product)
        {
            if (base.Repository.Any(f => f.Name == product.Name))
                throw new BusinessValidationException($"Product Name already used.");

            return base.Post(product);
        }

        [Route("Products/{Id}"), HttpPut]
        public override Product Put(int id, [FromBody]Product product)
        {
            return base.Put(id, product);
        }

        [Route("Products/{Id}"), HttpDelete]
        public override void Delete(int id)
        {
            base.Delete(id);
        }
    }
}
