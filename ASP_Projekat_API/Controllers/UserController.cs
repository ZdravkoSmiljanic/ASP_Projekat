using ASP_Projekat_API.DTO;
using ASP_Projekat_API.ErrorsLogger;
using ASP_Projekat_Application.Email;
using ASP_Projekat_Application.UseCaseHandler;
using ASP_Projekat_Application.UseCases.Command.Users;
using ASP_Projekat_Application.UseCases.DTO;
using ASP_Projekat_Application.UseCases.Queries;
using ASP_Projekat_Application.UseCases.Queries.Searches;
using ASP_Projekat_DataAccess.Entities;
using ASP_Projekat_Domain;
using Castle.Core.Smtp;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net.Mail;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ASP_Projekat_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : LocalController
    {
        public static IEnumerable<string> AllowedExtensions =>new List<string> { ".jpg", ".png", ".jpeg" };
        private BlogContext _context;
        private readonly IEmailSend _sender;
        private ICommandHandler _commandHandler;
        private IQueryHandler _queryHandler;

        public UserController(BlogContext context, IErrorLoger logger, IEmailSend sender, ICommandHandler commandHandler, IQueryHandler queryHandler)
            : base(logger)
        {
            _context = context;
            _sender = sender;
            _commandHandler = commandHandler;
            _queryHandler = queryHandler;
        }
        /// <summary>
        /// Search of users whit keyword
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        ///<response code="500">Internal server error</response>
        ///<response code="404">Not found</response>
        ///<response code="201">Ok</response>
        // GET: api/<UserController>
        [HttpGet]
        [Authorize]
        public IActionResult Get([FromQuery] SearchUsersDTO dto, [FromServices] ISearchUser query )
        {
            var data = _queryHandler.HandleQuery(query, dto);

            return Ok(data);

        }
        /// <summary>
        /// Search of users whit id
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        ///<response code="500">Internal server error</response>
        ///<response code="404">Not found</response>
        ///<response code="201">Ok</response>
        // GET api/<UserController>/5
        [HttpGet("{id}")]
        [Authorize]
        public IActionResult Get(int id, [FromServices] IGetUserQuery query)
        {
            var data = _queryHandler.HandleQuery(query, id);

            return Ok(data);
        }

        /// <summary>
        /// Registration of new user
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /api/users
        ///     {
        ///        "email": "string",
        ///         "password": "string",
        ///         "name": "string",
        ///         "surname": "string",
        ///         "userName": "string",
        ///         "imageId": 0
        ///     }
        ///
        /// </remarks>
        ///<response code="201">Succesfully added</response>
        ///<response code="500">Internal server error</response>
        ///<response code="409">Conflict</response>
        ///<response code="422">Validation error</response>


        // POST api/<UserController>
        [HttpPost]
        public IActionResult Post([FromForm] CreateUserDTO dto, [FromServices] ICreateUserCommand command)
        {
            if (dto.ImageId != null)
            {
                var guid = Guid.NewGuid().ToString();

                var extension = Path.GetExtension(dto.ImageId.FileName);

                if (!AllowedExtensions.Contains(extension))
                {
                    throw new InvalidOperationException("Unsupported file of uploading image.");
                }

                var fileName = guid + extension;

                var filePath = Path.Combine("wwwroot", "Images", fileName);

                using var stream = new FileStream(filePath, FileMode.Create);
                dto.ImageId.CopyTo(stream);
                dto.ImageFileName = fileName;
            }
            _commandHandler.HandleCommand(command, dto);

            return StatusCode(201);
        }

        /// <summary>
        /// Updating of user
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     Put /api/users/{id}
        ///     {
        ///        "email": "string",
        ///         "password": "string",
        ///         "name": "string",
        ///         "surname": "string",
        ///         "userName": "string",
        ///         "imageId": 0
        ///     }
        ///
        /// </remarks>
        ///<response code="201">Succesfully updated</response>
        ///<response code="500">Internal server error</response>
        ///<response code="409">Conflict</response>
        ///<response code="422">Validation error</response>

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        [Authorize]
        public IActionResult Put(int id, [FromBody] UpdateUserDTO dto, [FromServices] IUpdateUserCommand command)
        {
            dto.Id = id;
            _commandHandler.HandleCommand(command, dto);
            return NoContent();

        }
        /// <summary>
        /// Deleting  user
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        ///<response code="201">Succesfully deleted</response>
        ///<response code="500">Internal server error</response>
        ///<response code="409">Conflict</response>
        ///<response code="422">Validation error</response>
        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        [Authorize]
        public IActionResult Delete(int id, [FromServices] IDeleteUserCommand commnad)
        {
            _commandHandler.HandleCommand(commnad, id);
            return NoContent();
        }


       
    }
}
