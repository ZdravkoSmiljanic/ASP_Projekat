using ASP_Projekat_API.ErrorsLogger;
using ASP_Projekat_Application.UseCaseHandler;
using ASP_Projekat_Application.UseCases.Command.BlogCommands;
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
    //[Authorize]
    public class BlogController : LocalController
    {
        private BlogContext _context;
        private ICommandHandler _commandHandler;
        private IQueryHandler _queryHandler;

        public BlogController(BlogContext context, IErrorLoger logger, ICommandHandler commandHandler, IQueryHandler queryHandler)
            : base(logger)
        {
            _context = context;
            _commandHandler = commandHandler;
            _queryHandler = queryHandler;
        }

        /// <summary>
        /// Search of blog whit keyword
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        ///<response code="500">Internal server error</response>
        ///<response code="404">Not found</response>
        ///<response code="201">Ok</response>
        // GET: api/<BlogController>
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Get([FromQuery] SerachBlogDTO dto, [FromServices] ISearchBlog query)
        {
            var data = _queryHandler.HandleQuery(query, dto);

            return Ok(data);
        }
        
        /// <summary>
        /// Search of blog whit id
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        ///<response code="500">Internal server error</response>
        ///<response code="404">Not found</response>
        ///<response code="201">Ok</response>
        // GET api/<BlogController>/5
        [HttpGet("{id}")]
        [Authorize]
        public IActionResult Get(int id, [FromServices] IGetBlogQuery query)
        {
            var data = _queryHandler.HandleQuery(query, id);

            return Ok(data);
        }
        
        /// <summary>
        /// Creating new blog
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        ///<response code="201">Succesfully added</response>
        ///<response code="500">Internal server error</response>
        ///<response code="409">Conflict</response>
        ///<response code="422">Validation error</response>
        // POST api/<BlogController>
        [HttpPost]
        [Authorize]
        public IActionResult Post([FromBody] CreateBlogDTO dto, [FromServices] ICreateBlogCommand command)
        {
            _commandHandler.HandleCommand(command, dto);

            return StatusCode(201);
        }
        
        /// <summary>
        /// Updating  blog
        /// </summary>
        /// <param name="dto"></param>
        ///<response code="201">Succesfully added</response>
        ///<response code="500">Internal server error</response>
        ///<response code="409">Conflict</response>
        ///<response code="422">Validation error</response>
        // PUT api/<BlogController>/5
        [HttpPut("{id}")]
        [Authorize]
        public IActionResult Put(int id, [FromBody] UpdateBlogDTO dto, [FromServices] IUpdateBlogCommand command)
        {
            dto.Id = id;
            _commandHandler.HandleCommand(command, dto);
            return NoContent();

        }
        /// <summary>
        /// Deleting  blog
        /// </summary>
        /// <returns></returns>
        ///<response code="201">Succesfully deleted</response>
        ///<response code="500">Internal server error</response>
        ///<response code="409">Conflict</response>
        ///<response code="422">Validation error</response>
        // DELETE api/<BlogController>/5
        [HttpDelete("{id}")]
        [Authorize]
        public IActionResult Delete(int id, [FromServices] IDeleteBlogCommand command)
        {
            _commandHandler.HandleCommand(command, id);
            return NoContent();

        }
    }
}
