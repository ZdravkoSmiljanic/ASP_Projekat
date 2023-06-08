using ASP_Projekat_API.ErrorsLogger;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ASP_Projekat_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocalController : ControllerBase
    {

        private IErrorLoger _logger;

        protected LocalController(IErrorLoger loger)
        {
            _logger = loger;
        }

        protected IActionResult Error(Exception ex)
        {
            Guid errorGUID = Guid.NewGuid();
            AppError error = new AppError
            {
                exception = ex,
                errorGUID = errorGUID
            };
            _logger.LogError(error);

            return StatusCode(500, new { message = $"There was an error processing your request, please contact administrator with  code: {errorGUID}." });
        }
    }
}
