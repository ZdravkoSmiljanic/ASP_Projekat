using ASP_Projekat_API.ErrorsLogger;
using ASP_Projekat_Application.UseCaseHandler;
using ASP_Projekat_Application.UseCases.Command.ImageCommands;
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
    public class ImageController : LocalController
    {
        private BlogContext _context;
        private ICommandHandler _commandHandler;
        private IQueryHandler _queryHandler;

        public ImageController(BlogContext context, IErrorLoger logger, ICommandHandler commandHandler, IQueryHandler queryHandler)
            : base(logger)
        {
            _context = context;
            _commandHandler = commandHandler;
            _queryHandler = queryHandler;
        }
        /// <summary>
        /// Get all images
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        ///<response code="500">Internal server error</response>
        ///<response code="404">Not found</response>
        ///<response code="201">Ok</response>
        // GET: api/<ImageController>
        [HttpGet]
        public IActionResult Get()
        {

            try
            {
                var data = _context.Images;
                if (data == null)
                {
                    return NotFound(new { message = "There isnt any image value in our database" });
                }
                return Ok(data);
            }
            catch (System.Exception ex)
            {
                return Error(ex);
            }
        }
        /// <summary>
        /// Search of image whit id
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        ///<response code="500">Internal server error</response>
        ///<response code="404">Not found</response>
        ///<response code="201">Ok</response>
        // GET api/<ImageController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id, [FromServices] IGetImageQuery query)
        {
            var data = _queryHandler.HandleQuery(query, id);

            return Ok(data);
        }
        /// <summary>
        /// Adding image
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        ///<response code="201">Succesfully updated</response>
        ///<response code="500">Internal server error</response>
        ///<response code="409">Conflict</response>
        ///<response code="422">Validation error</response>
        // POST api/<ImageController>
        [HttpPost]
        public IActionResult Post([FromBody] CreateImageDTO dto, [FromServices] ICreateImageCommand commnad)
        {
            _commandHandler.HandleCommand(commnad, dto);

            return StatusCode(201);

        }


        /// <summary>
        /// Deleting  image
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        ///<response code="201">Succesfully deleted</response>
        ///<response code="500">Internal server error</response>
        ///<response code="409">Conflict</response>
        ///<response code="422">Validation error</response>
        // DELETE api/<ImageController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id, [FromServices] IDeleteImageCommand command)
        {
            _commandHandler.HandleCommand(command, id);
            return NoContent();
        }
    }
}
