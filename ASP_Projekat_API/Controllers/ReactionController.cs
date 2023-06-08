using ASP_Projekat_API.DTO;
using ASP_Projekat_API.ErrorsLogger;
using ASP_Projekat_Application.UseCaseHandler;
using ASP_Projekat_Application.UseCases.Command.ReactionCommand;
using ASP_Projekat_Application.UseCases.DTO;
using ASP_Projekat_Application.UseCases.Queries;
using ASP_Projekat_DataAccess.Entities;
using ASP_Projekat_Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ASP_Projekat_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ReactionController : LocalController
    {
        private BlogContext _context;
        private ICommandHandler _commandHandler;
        private IQueryHandler _queryHandler;

        public ReactionController(BlogContext context, IErrorLoger logger, ICommandHandler commandHandler, IQueryHandler queryHandler)
            : base(logger)
        {
            _context = context;
            _commandHandler = commandHandler;
            _queryHandler = queryHandler;
        }
        /// <summary>
        /// Search of all reactions
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        ///<response code="500">Internal server error</response>
        ///<response code="404">Not found</response>
        ///<response code="201">Ok</response>
        // GET: api/<ReactionController>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var data = _context.Reactions;
                if (data == null)
                {
                    return NotFound(new { message = "There isnt any reaction value in our database" });
                }
                return Ok(data);
            }
            catch (System.Exception ex)
            {
                return Error(ex);
            }
        }
        /// <summary>
        /// Search of reaction whit id
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        ///<response code="500">Internal server error</response>
        ///<response code="404">Not found</response>
        ///<response code="201">Ok</response>
        // GET api/<ReactionController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id, [FromServices] IGetReactionQuery query)
        {
            var data = _queryHandler.HandleQuery(query, id);

            return Ok(data);
        }
        /// <summary>
        /// Adding new reaction
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        ///<response code="201">Succesfully updated</response>
        ///<response code="500">Internal server error</response>
        ///<response code="409">Conflict</response>
        ///<response code="422">Validation error</response>
        // POST api/<ReactionController>
        [HttpPost]
        public IActionResult Post([FromBody] CreateReactionDTO dto, [FromServices] ICreateReactionCommand command)
        {

            _commandHandler.HandleCommand(command, dto);

            return StatusCode(201);

        }


        /// <summary>
        /// Deleting  reaction
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        ///<response code="201">Succesfully deleted</response>
        ///<response code="500">Internal server error</response>
        ///<response code="409">Conflict</response>
        ///<response code="422">Validation error</response>
        // DELETE api/<ReactionController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id, [FromServices] IDeleteReactionCommand command)
        {
            _commandHandler.HandleCommand(command, id);
            return NoContent();
        }
    }
}
