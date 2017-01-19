namespace YasService.Controllers
{
    using System.Collections.Generic;
    using System.Web.Http;
    using Models;
    using Models.Context;
    using Exceptions;

    public class EmployeeController : BaseController<Employee>
    {
        public EmployeeController(IUnitOfWork<YasContext> context) : base(context) { }

        [Route("Employee"), HttpGet]
        public override IEnumerable<Employee> Get()
        {
            return base.Get();
        }

        [Route("Employee/{Id}"), HttpGet]
        public override Employee Get(int id)
        {
            return base.Get(id);
        }

        [Route("Employee"), HttpPost]
        public override Employee Post([FromBody]Employee employee)
        {
            if (base.Repository.Any(f => f.UserId == employee.UserId))
                throw new BusinessValidationException($"User Id already used.");

            return base.Post(employee);
        }

        [Route("Employee/{Id}"), HttpPut]
        public override Employee Put(int id, [FromBody]Employee employee)
        {
            return base.Put(id, employee);
        }

        [Route("Employee/{Id}"), HttpDelete]
        public override void Delete(int id)
        {
            base.Delete(id);
        }
    }
}
