using ASP_Projekat_API.ErrorsLogger;
using ASP_Projekat_Application.UseCaseHandler;
using ASP_Projekat_Application.UseCases.Command.CommentsCommand;
using ASP_Projekat_Application.UseCases.DTO;
using ASP_Projekat_Application.UseCases.Queries;
using ASP_Projekat_Application.UseCases.Queries.Searches;
using ASP_Projekat_DataAccess.Entities;
using ASP_Projekat_Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ASP_Projekat_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CommentController : LocalController
    {
        private BlogContext _context;
        private ICommandHandler _commandHandler;
        private IQueryHandler _queryHandler;


        public CommentController(BlogContext context, IErrorLoger logger, ICommandHandler commandHandler, IQueryHandler queryHandler)
            : base(logger)
        {
            _context = context;
            _commandHandler = commandHandler;
            _queryHandler = queryHandler;
        }
        /// <summary>
        /// Search comment whit keyword
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        ///<response code="500">Internal server error</response>
        ///<response code="404">Not found</response>
        ///<response code="201">Ok</response>
        // GET: api/<CommentController>
        [HttpGet]
        public IActionResult Get([FromQuery] SearchCommnetDTO dto, [FromServices] ISearchCommentQuery query)
        {
            var data = _queryHandler.HandleQuery(query, dto);
            return Ok(data);

        }

        /// <summary>
        /// Adding comment
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        ///<response code="201">Succesfully updated</response>
        ///<response code="500">Internal server error</response>
        ///<response code="409">Conflict</response>
        ///<response code="422">Validation error</response>

        // POST api/<CommentController>
        [HttpPost]
        public IActionResult Post([FromBody] CreateCommentDTO dto, [FromServices] ICreateCommentCommand command)
        {
            _commandHandler.HandleCommand(command, dto);
            return StatusCode(201);
 
        }

        /// <summary>
        /// Updating comment
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        ///<response code="201">Succesfully updated</response>
        ///<response code="500">Internal server error</response>
        ///<response code="409">Conflict</response>
        ///<response code="422">Validation error</response>
        // PUT api/<CommentController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] UpdateCommentTextDTO dto, [FromServices] IUpdateCommentCommand command)
        {
            dto.Id = id;
            _commandHandler.HandleCommand(command, dto);
            return NoContent();
            
            
        }
        /// <summary>
        /// Deleting  comment
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        ///<response code="201">Succesfully deleted</response>
        ///<response code="500">Internal server error</response>
        ///<response code="409">Conflict</response>
        ///<response code="422">Validation error</response>
        // DELETE api/<CommentController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id, [FromServices] IDeleteCommentCommand command)
        {
            _commandHandler.HandleCommand(command, id);
            return StatusCode(204, new { message = "Comment is succesfuly deleted" }); ;
        }
    }
}
