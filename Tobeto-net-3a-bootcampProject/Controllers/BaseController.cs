using Core.Utilities.Results;
using Microsoft.AspNetCore.Mvc;

namespace Tobeto_net_3a_bootcampProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController : ControllerBase
    {
        protected IActionResult HandleDataResult<T>(IDataResult<T> dataResult)
        {
            return dataResult.Success ? Ok(dataResult) : BadRequest(dataResult);
        }
        
        protected IActionResult HandleResult(Core.Utilities.Results.IResult result)
        {
            return result.Success ? Ok(result) : BadRequest(result);
        }
    }
}
