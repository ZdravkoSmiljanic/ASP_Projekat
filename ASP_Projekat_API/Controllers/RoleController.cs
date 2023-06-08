using ASP_Projekat_API.ErrorsLogger;
using ASP_Projekat_Application.UseCaseHandler;
using ASP_Projekat_Application.UseCases.Command.RoleCommands;
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
    public class RoleController : LocalController
    {
        private BlogContext _context;
        private ICommandHandler _commandHandler;
        private IQueryHandler _queryHandler;

        public RoleController(BlogContext context, IErrorLoger logger, ICommandHandler commandHandler, IQueryHandler queryHandler)
            : base(logger)
        {
            _context = context;
            _commandHandler = commandHandler;
            _queryHandler = queryHandler;
        }
        /// <summary>
        /// Search of all roles
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        ///<response code="500">Internal server error</response>
        ///<response code="404">Not found</response>
        ///<response code="201">Ok</response>
        // GET: api/<RoleController>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var data = _context.Role;
                if (data == null)
                {
                    return NotFound(new { message = "There isnt any role value in our database" });
                }
                return Ok(data);

            }catch(System.Exception ex)
            {
                return Error(ex);
            }
        }
        /// <summary>
        /// Search of roles whit id
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        ///<response code="500">Internal server error</response>
        ///<response code="404">Not found</response>
        ///<response code="201">Ok</response>
        // GET api/<RoleController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id, [FromServices] IGetRoleQuery query)
        {
            var data = _queryHandler.HandleQuery(query, id);

            return Ok(data);



        }
        /// <summary>
        /// Adding new role
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        ///<response code="201">Succesfully added</response>
        ///<response code="500">Internal server error</response>
        ///<response code="409">Conflict</response>
        ///<response code="422">Validation error</response>
        // POST api/<RoleController>
        [HttpPost]
        public IActionResult Post([FromBody] CreateRoleDTO dto, [FromServices] ICreateRoleCommand commnad)
        {
        
                _commandHandler.HandleCommand(commnad, dto);

                return StatusCode(201);
        }


        /// <summary>
        /// Deleting  roles
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        ///<response code="201">Succesfully deleted</response>
        ///<response code="500">Internal server error</response>
        ///<response code="409">Conflict</response>
        ///<response code="422">Validation error</response>
        // DELETE api/<RoleController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id, [FromServices] IDeleteRoleCommand command)
        {
            _commandHandler.HandleCommand(command, id);
            return NoContent();
        }
    }
}
