using ASP_Projekat_API.DTO;
using ASP_Projekat_API.ErrorsLogger;
using ASP_Projekat_API.Extensions;
using Bugsnag.AspNet.Core;
using ASP_Projekat_Domain;
using Microsoft.EntityFrameworkCore;
using ASP_Projekat_Application.Email;
using ASP_Projekat_API.Emails;
using Microsoft.OpenApi.Models;
using System.Reflection;
using ASP_Projekat_API.Jwt;
using ASP_Projekat_API.Jwt.TokenStorage;
using ASP_Projekat_Application;
using System.IdentityModel.Tokens.Jwt;
using Newtonsoft.Json;
using ASP_Projekat_API.Middlewares;
using ASP_Projekat_Application.UseCaseHandler;
using ASP_Projekat_Implementation.Logging;
using ASP_Projekat_Application.Logging;
using ASP_Projekat_Implementation.UseCases.Commands.Tags;
using ASP_Projekat_Application.UseCases.Command.TagCommands;
using ASP_Projekat_Implementation.Validators.TagValidators;
using ASP_Projekat_Application.UseCases.Queries;
using ASP_Projekat_Implementation.UseCases.Queries;
using ASP_Projekat_Implementation.Validators.RoleValidators;
using ASP_Projekat_Application.UseCases.Command.RoleCommands;
using ASP_Projekat_Implementation.UseCases.Commands.Roles;
using ASP_Projekat_Implementation.Validators.ImageValidators;
using ASP_Projekat_Application.UseCases.Command.ImageCommands;
using ASP_Projekat_Implementation.UseCases.Commands.Images;
using ASP_Projekat_Implementation.Validators.LogEntryValidators;
using ASP_Projekat_Implementation.UseCases.Commands.LogEntry;
using ASP_Projekat_Implementation.Validators.ReactionValidator;
using ASP_Projekat_Application.UseCases.Command.ReactionCommand;
using ASP_Projekat_Implementation.UseCases.Commands.Reactions;
using ASP_Projekat_Implementation.Validators.UserValidator;
using ASP_Projekat_Application.UseCases.Command.Users;
using ASP_Projekat_Implementation.UseCases.Commands.Users;
using ASP_Projekat_Implementation.Validators.BlogValidator;
using ASP_Projekat_Application.UseCases.Command.BlogCommands;
using ASP_Projekat_Implementation.UseCases.Commands.Blogs;
using ASP_Projekat_Implementation.Validators.ReactionOnBlogValidator;
using ASP_Projekat_Application.UseCases.Command.ReactionOnBlogCommands;
using ASP_Projekat_Implementation.UseCases.Commands.ReactionOnBlog;
using ASP_Projekat_Implementation.Validators.CommentValidators;
using ASP_Projekat_Application.UseCases.Command.CommentsCommand;
using ASP_Projekat_Implementation.UseCases.Commands.Comments;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
var appSettings = new AppSettings();
builder.Configuration.Bind(appSettings);

var configuration = builder.Configuration;
builder.Services.AddTransient<QueryHandler>();


builder.Services.AddTransient<ITokenStorage, InMemoryTokenStorage>();
builder.Services.AddTransient<JwtManager>(x =>
{
    var context = x.GetService<BlogContext>();
    var tokenStorage = x.GetService<ITokenStorage>();
    return new JwtManager(context, appSettings.Jwt.Issuer, appSettings.Jwt.SecretKey, appSettings.Jwt.DurationSeconds, tokenStorage);
});
builder.Services.AddLogger();

builder.Services.AddBugsnag(configuration => {
    configuration.ApiKey = appSettings.BugSnagKey;
});
builder.Services.AddHttpContextAccessor();

builder.Services.AddScoped<IApplicationActor>(x =>
{
    var accessor = x.GetService<IHttpContextAccessor>();
    var header = accessor.HttpContext.Request.Headers["Authorization"];

    var data = header.ToString().Split("Bearer ");

    if (data.Length < 2)
    {
        return new AnonimousUser();
    }

    var handler = new JwtSecurityTokenHandler();

    var tokenObj = handler.ReadJwtToken(data[1].ToString());

    var claims = tokenObj.Claims;

    var email = claims.First(x => x.Type == "Email").Value;
    var id = claims.First(x => x.Type == "Id").Value;
    var username = claims.First(x => x.Type == "Username").Value;
    var useCases = claims.First(x => x.Type == "UseCases").Value;

    List<int> useCaseIds = JsonConvert.DeserializeObject<List<int>>(useCases);

    return new JwtActor
    {
        Email = email,
        AllowedUseCases = useCaseIds,
        Id = int.Parse(id),
        Username = username,
    };
});
builder.Services.AddJwt(appSettings);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//Region za dodavanje zavisnosti Interfejs- EfCommand
builder.Services.AddTransient<ICreateTagCommand, EfCreateTagCommand>();
builder.Services.AddTransient<IDeleteTagCommand, EfDeleteTagCommand>();
builder.Services.AddTransient<IGetTagQuery, EfGetTagQuery>();
//dependency za roles
builder.Services.AddTransient<IGetRoleQuery, EfGetRoleQuery>();
builder.Services.AddTransient<IDeleteRoleCommand, EfDeleteRoleCommand>();
builder.Services.AddTransient<ICreateRoleCommand, EfCreateRoleCommand>();
//dependency za image
builder.Services.AddTransient<IGetImageQuery, EfGetImageQuery>();
builder.Services.AddTransient<IDeleteImageCommand, EfDeleteImageCommand>();
builder.Services.AddTransient<ICreateImageCommand, EfCreateImageCommand>();
//Log entry
builder.Services.AddTransient<IGetLogEntryQuery, EfLogEntryQuery>();
//dependency za reakcije
builder.Services.AddTransient<IGetReactionQuery, EfGetReactionQuery>();
builder.Services.AddTransient<ICreateReactionCommand, EfCreateReactionCommand>();
builder.Services.AddTransient<IDeleteReactionCommand, EfDeleteReactionCommand>();
//dependency za usere
builder.Services.AddTransient<IGetUserQuery, EfGetUserQuery>();
builder.Services.AddTransient<ISearchUser, EfSerachUserQuery>();
builder.Services.AddTransient<IDeleteUserCommand, EfDeleteUserCommand>();
builder.Services.AddTransient<IUpdateUserCommand, EfUpdateUserCommand>();
builder.Services.AddTransient<ICreateUserCommand, EfCreateUserCommand>();
//dependency za blogve
builder.Services.AddTransient<IDeleteBlogCommand, EfDeleteBlogCommand>();
builder.Services.AddTransient<IGetBlogQuery, EfGetBlogQuery>();
builder.Services.AddTransient<ISearchBlog, EfSearchBlogQuery>();
builder.Services.AddTransient<ICreateBlogCommand, EfCreateBlogCommand>();
builder.Services.AddTransient<IUpdateBlogCommand, EfUpdateBlogCommand>();
//za reagovanje na blog
builder.Services.AddTransient<IReactOnBlogCommand, EfReationOnBlogCommand>();
builder.Services.AddTransient<IDeleteReactionOnBlogCommand, EfDeleteReactOnBlogCommand>();
//za komentare
builder.Services.AddTransient<IDeleteCommentCommand, EfDeleteCommentCommand>();
builder.Services.AddTransient<ICreateCommentCommand, EfCreateCommentCommand>();
builder.Services.AddTransient<IUpdateCommentCommand, EfUpdateCommentCommnad>();
builder.Services.AddTransient<ISearchCommentQuery, EfSearchCommentQuery>();








builder.Services.AddTransient<ICommandHandler, CommandHandler>();
builder.Services.AddTransient<IQueryHandler, QueryHandler>();
builder.Services.AddTransient<IUseCaseHandelr, EfUserCaseLogger>();




//za validaciju tagova
builder.Services.AddTransient<CreateTagValidator>();
builder.Services.AddTransient<DeleteTagValidator>();
builder.Services.AddTransient<GetTagValidator>();
//za validaciju rola
builder.Services.AddTransient<DeleteRoleValidator>();
builder.Services.AddTransient<GetRoleValidator>();
builder.Services.AddTransient<CreateRoleValidator>();
//za validaciju slika
builder.Services.AddTransient<CreateImageValidator>();
builder.Services.AddTransient<DeleteImageValidator>();
builder.Services.AddTransient<GetImageValidator>();
//pretraga logova
builder.Services.AddTransient<LogEntryValidators>();
//za validaciju reakcija
builder.Services.AddTransient<CreateReactionValidator>();
builder.Services.AddTransient<DeleteReactionValidator>();
builder.Services.AddTransient<GetReactionValidator>();
//za validaicju usera
builder.Services.AddTransient<SearchUserIdValidator>();
builder.Services.AddTransient<SearchUserValidator>();
builder.Services.AddTransient<DeleteUserValidator>();
builder.Services.AddTransient<CreateUserValidator>();
builder.Services.AddTransient<UpdateUserValidator>();
//za validaciju blogova
builder.Services.AddTransient<DeleteBlogValidator>();
builder.Services.AddTransient<GetBlogValidator>();
builder.Services.AddTransient<SearchBlogValidator>();
builder.Services.AddTransient<CreateBlogValidator>();
builder.Services.AddTransient<UpdateBlogValidator>();
//za reagovanje na blogove
builder.Services.AddTransient<ReactOnBlogValidator>();
builder.Services.AddTransient<DeleteReactionOnBlog>();
//za validaciju komentara
builder.Services.AddTransient<DeleteCommentValidator>();
builder.Services.AddTransient<SearchCommentValidator>();
builder.Services.AddTransient<UpdateCommentValidator>();
builder.Services.AddTransient<CreateCommentValidator>();





builder.Services.AddTransient<BlogContext>(x =>
{
    DbContextOptionsBuilder builder = new DbContextOptionsBuilder();
    builder.UseSqlServer("Data Source=localhost; Initial Catalog = projekat_blog1; Integrated Security = true");
    return new BlogContext(builder.Options);
});



builder.Services.AddTransient<IEmailSend, EmailSend>();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "ASP_Projekat_API", Version = "v1" });

    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    c.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory,xmlFilename));
});

builder.Services.AddTransient<IQueryHandler>(x =>
{
    var actor = x.GetService<IApplicationActor>();
    var logger = x.GetService<IUseCaseHandelr>();
    var queryHandler = new QueryHandler();
    var timeTrackingHandler = new TimeTrackingQueryHandler(queryHandler);
    var loggingHandler = new LoggingQueryHandler(timeTrackingHandler, actor, logger);
    var decoration = new AuthorizationQueryHandler(actor, loggingHandler);

    return decoration;
});




var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();
app.UseMiddleware<ExceptionMiddleware>();


app.MapControllers();

app.Run();
