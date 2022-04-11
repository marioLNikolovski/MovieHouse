using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MovieHouse.Controllers
{
    
    [Authorize]
    public class BaseController : Controller
    {
       
    }
}
