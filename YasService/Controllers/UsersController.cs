namespace YasService.Controllers
{
    using System.Collections.Generic;
    using System.Web.Http;

    using Models;
    using Models.Context;

    using YasService.Exceptions;

    public class UsersController : BaseController<User>
    {
        public UsersController(IUnitOfWork<YasContext> context) : base(context) { }

        [Route("Users"), HttpGet]
        public override IEnumerable<User> Get()
        {
            return base.Get();
        }

        [Route("Userss/{Id}"), HttpGet]
        public override User Get(int id)
        {
            return base.Get(id);
        }

        [Route("Users"), HttpPost]
        public override User Post([FromBody]User user)
        {
            if (base.Repository.Any(f => f.UserId == user.UserId))
                throw new BusinessValidationException($"User Id already used.");

            return base.Post(user);
        }

        [Route("Users/{Id}"), HttpPut]
        public override User Put(int id, [FromBody]User user)
        {
            return base.Put(id, user);
        }

        [Route("Users/{Id}"), HttpDelete]
        public override void Delete(int id)
        {
            base.Delete(id);
        }
    }
}
