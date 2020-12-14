using Microsoft.AspNetCore.Mvc;

namespace MyProductStore.API.Controllers
{
    [Controller]
    public class BaseUserControllerController : ControllerBase
    {
        public int? UserId => (int?)HttpContext.Items["UserId"];
    }
}
