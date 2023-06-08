using ASP_Projekat_API.DTO;
using ASP_Projekat_API.ErrorsLogger;
using ASP_Projekat_Application.UseCaseHandler;
using ASP_Projekat_Application.UseCases.Command.ReactionOnBlogCommands;
using ASP_Projekat_Application.UseCases.DTO;
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
    public class ReactCommnetController : LocalController
    {
        private BlogContext _context;
        private ICommandHandler _commandHandler;
        private IQueryHandler _queryHandler;

        public ReactCommnetController(BlogContext context, IErrorLoger logger, IQueryHandler queryHandler, ICommandHandler commandHandler)
            : base(logger)
        {
            _context = context;
            _queryHandler = queryHandler;
            _commandHandler = commandHandler;
        }


        /// <summary>
        ///Reacting on blog
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /api/ReactCommnetController
        ///     {
        ///        "reactionId":1,
        ///        "blogId":1,
        ///        "userId":1
        ///     }
        ///
        /// </remarks>
        ///<response code="201">Succesfully added</response>
        ///<response code="500">Internal server error</response>
        ///<response code="409">Conflict</response>
        ///<response code="422">Validation error</response>
        // POST api/<ReactCommnetController>
        [HttpPost]
        public IActionResult Post([FromBody] ReactOnBlogDTO dto, [FromServices] IReactOnBlogCommand command)
        {
            _commandHandler.HandleCommand(command, dto);
            return StatusCode(201);

        }


        /// <summary>
        /// Deleting  reaction on commnet
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>

        ///<response code="201">Succesfully deleted</response>
        ///<response code="500">Internal server error</response>
        ///<response code="409">Conflict</response>
        ///<response code="422">Validation error</response>
        // DELETE api/<ReactCommnetController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id, int idReaction, int idUser, [FromServices] IDeleteReactionOnBlogCommand command)
        {
            var ints=new List<int>();
            ints.Add(id);
            ints.Add(idReaction);
            ints.Add(idUser);
            _commandHandler.HandleCommand(command, ints);
            return NoContent();

            
            
        }
    }
}
