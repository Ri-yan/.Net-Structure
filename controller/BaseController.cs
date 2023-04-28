using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Project.Controllers
{
    [Authorize]
    [Route("[controller]")]
    [ApiController]
    public class BaseController : ControllerBase
    {

    }

    public class ApiResponse
    {
        public object Data { get; set; }
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public List<ErroInfo> Errors { get; set; }
    }

    public class ErroInfo
    {
        public int Code { get; set; }
        public string Error { get; set; }
    }
}
