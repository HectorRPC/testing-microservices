using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

public abstract class BaseController : ControllerBase
{
    public ILogger _logger;
    public BaseController(ILogger<BaseController> logger):base(){
        _logger = logger;
    }
}