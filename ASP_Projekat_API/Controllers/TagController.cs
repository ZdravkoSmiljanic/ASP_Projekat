using ASP_Projekat_API.ErrorsLogger;
using ASP_Projekat_Application.UseCaseHandler;
using ASP_Projekat_Application.UseCases.Command.TagCommands;
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
    public class TagController : LocalController
    {
        private BlogContext _context;
        private ICommandHandler _commandHandler;
        private IQueryHandler _queryHandler;


        public TagController(BlogContext context, IErrorLoger logger, ICommandHandler commandHandler, IQueryHandler queryHandler)
            : base(logger)
        {
            _context = context;
            _commandHandler = commandHandler;
            _queryHandler = queryHandler;
        }
        /// <summary>
        /// Search of all tags
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        ///<response code="500">Internal server error</response>
        ///<response code="404">Not found</response>
        ///<response code="201">Ok</response>
        // GET: api/<TagController>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var data = _context.Tags;
                if (data == null)
                {
                    return NotFound(new {message="There isnt any tag value in our database"});
                }
                return Ok(data);
            }
            catch(System.Exception ex)
            {
                return Error(ex);
            }
        }

        /// <summary>
        /// Search of tag whit id
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        ///<response code="500">Internal server error</response>
        ///<response code="404">Not found</response>
        ///<response code="201">Ok</response>
        // GET api/<TagController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id, [FromServices] IGetTagQuery query)
        {
            var data=_queryHandler.HandleQuery(query, id);

            return Ok(data);

        }
        /// <summary>
        /// Adding new tag
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        ///<response code="201">Succesfully updated</response>
        ///<response code="500">Internal server error</response>
        ///<response code="409">Conflict</response>
        ///<response code="422">Validation error</response>
        // POST api/<TagController>
        [HttpPost]
        public IActionResult Post([FromBody] CreateTagDTO dto, [FromServices] ICreateTagCommand commnad)
        {

                _commandHandler.HandleCommand(commnad, dto);

                return StatusCode(201);



        }

        /// <summary>
        /// Deleting  tag
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        ///<response code="201">Succesfully deleted</response>
        ///<response code="500">Internal server error</response>
        ///<response code="409">Conflict</response>
        ///<response code="422">Validation error</response>

        // DELETE api/<TagController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id, [FromServices] IDeleteTagCommand commnad)
        {


                _commandHandler.HandleCommand(commnad, id);
                return NoContent();

          
        }
    }
}
