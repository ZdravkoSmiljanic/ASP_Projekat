using ASP_Projekat_Application;

namespace ASP_Projekat_API.Jwt
{
    public class JwtActor : IApplicationActor
    {
        public int Id { get; set; }

        public string Email { get; set; }

        public string Username { get; set; }

        public IEnumerable<int> AllowedUseCases { get; set; }
    }

    public class AnonimousUser : IApplicationActor
    {
        public int Id => 0;

        public string Email => "anonymous@test.com";

        public string Username => "Anonymous";

        public IEnumerable<int> AllowedUseCases => new List<int> {17 };
    }
}
