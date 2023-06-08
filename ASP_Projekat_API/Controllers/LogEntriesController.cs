using ASP_Projekat_API.DTO;
using ASP_Projekat_API.ErrorsLogger;
using ASP_Projekat_Application.UseCaseHandler;
using ASP_Projekat_Application.UseCases.DTO;
using ASP_Projekat_Application.UseCases.Queries;
using ASP_Projekat_Application.UseCases.Queries.Searches;
using ASP_Projekat_Domain;
using ASP_Projekat_Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ASP_Projekat_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class LogEntriesController : LocalController
    {
        private BlogContext _context;
        private ICommandHandler _commandHandler;
        private IQueryHandler _queryHandler;


        public LogEntriesController(BlogContext context, IErrorLoger logger, ICommandHandler commandHandler, IQueryHandler queryHandler)
            : base(logger)
        {
            _context = context;
            _commandHandler = commandHandler;
            _queryHandler = queryHandler;
        }
        // GET: api/<LogEntriesController>
        [HttpGet]
        public IActionResult Get([FromQuery] SearchLogDTO dto, [FromServices] IGetLogEntryQuery query)
        {

            var data = _queryHandler.HandleQuery(query, dto);

            return Ok(data);

        }

    }
}
