using Microsoft.AspNetCore.Mvc;

namespace Supermarket.API.REST
{
    public abstract class Controller : Microsoft.AspNetCore.Mvc.Controller
    {
        public override OkResult Ok()
        {
            return base.Ok();
        }
    }
}
