using ASP_Projekat_API.ErrorsLogger;
using ASP_Projekat_DataAccess.Entities;
using ASP_Projekat_Domain;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ASP_Projekat_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InitialDataController : LocalController
    {
        private BlogContext _context;

        public InitialDataController(BlogContext context, IErrorLoger logger)
            : base(logger)
        {
            _context = context;
        }

        // POST api/<InitialDataController>
        [HttpPost]
        public IActionResult Post()
        {
            try
            {
                var roles = new List<Role>
                {
                    new Role{RoleName="admin",CreatedAt=DateTime.UtcNow},
                    new Role{RoleName="user", CreatedAt=DateTime.UtcNow}
                };

                var tag = new List<Tag>
                {
                    new Tag{TagText="#th7", CreatedAt=DateTime.UtcNow},
                    new Tag{TagText="#grobari", CreatedAt=DateTime.UtcNow},
                    new Tag{TagText="#lol", CreatedAt=DateTime.UtcNow},
                    new Tag{TagText="#lmao", CreatedAt=DateTime.UtcNow},
                    new Tag{TagText="#basket", CreatedAt=DateTime.UtcNow},
                    new Tag{TagText="#3x3", CreatedAt=DateTime.UtcNow},
                    new Tag{TagText="#nuggets", CreatedAt=DateTime.UtcNow},
                    new Tag{TagText="#nba", CreatedAt=DateTime.UtcNow},
                    new Tag{TagText="#joker", CreatedAt=DateTime.UtcNow},
                };

                var images = new List<Image>
                {
                    new Image{ImagePath="putanja1", ImageSize=10,CreatedAt=DateTime.UtcNow},
                    new Image{ImagePath="putanja2", ImageSize=12,CreatedAt=DateTime.UtcNow},
                    new Image{ImagePath="putanja3", ImageSize=14,CreatedAt=DateTime.UtcNow},
                    new Image{ImagePath="putanja4", ImageSize=10,CreatedAt=DateTime.UtcNow},
                    new Image{ImagePath="putanja5", ImageSize=16,CreatedAt=DateTime.UtcNow},
                    new Image{ImagePath="putanja6", ImageSize=20,CreatedAt=DateTime.UtcNow},
                    new Image{ImagePath="putanja7", ImageSize=19,CreatedAt=DateTime.UtcNow},
                    new Image{ImagePath="putanja8", ImageSize=18,CreatedAt=DateTime.UtcNow},
                    new Image{ImagePath="putanja9", ImageSize=11,CreatedAt=DateTime.UtcNow},

                    new Image{ImagePath="reakcijaimg1", ImageSize=11,CreatedAt=DateTime.UtcNow},
                    new Image{ImagePath="reakcijaimg2", ImageSize=11,CreatedAt=DateTime.UtcNow},
                    new Image{ImagePath="reakcijaimg3", ImageSize=11,CreatedAt=DateTime.UtcNow},
                    new Image{ImagePath="reakcijaimg4", ImageSize=11,CreatedAt=DateTime.UtcNow},
                    new Image{ImagePath="reakcijaimg5", ImageSize=11,CreatedAt=DateTime.UtcNow},
                };

                var reactions = new List<Reaction>
                {
                    new Reaction{ReactionName="Wow",Image=images.ElementAt(9),CreatedAt=DateTime.UtcNow},
                    new Reaction{ReactionName="Thumb Down",Image=images.ElementAt(10),CreatedAt=DateTime.UtcNow},
                    new Reaction{ReactionName="Thumb Up",Image=images.ElementAt(11),CreatedAt=DateTime.UtcNow},
                    new Reaction{ReactionName="Smily",Image=images.ElementAt(12),CreatedAt=DateTime.UtcNow},
                    new Reaction{ReactionName="Hearth",Image=images.ElementAt(13),CreatedAt=DateTime.UtcNow},
                };

                var users = new List<User>
                {
                    new User{Name="Kevin", Surname="Panter", UserName="kevinPanter7", Password="sifra1", Image=images.ElementAt(1),
                    Email="kevinpan@gmail.com", Role=roles.First(), CreatedAt=DateTime.UtcNow},
                    new User{Name="Zdravko", Surname="Smiljanic", UserName="zsmiljanic", Password="sifra1", Image=images.ElementAt(2),
                    Email="smiljanic2620@ict.edu.rs", Role=roles.First(), CreatedAt=DateTime.UtcNow},
                    new User{Name="Zach", Surname="Ledey", UserName="zachhh222", Password="sifra1",
                    Email="zach@outlook.com", Role=roles.ElementAt(1), CreatedAt=DateTime.UtcNow},
                    new User{Name="Mina", Surname="Pasesnik", UserName="minamina", Password="sifra1", Image=images.ElementAt(3),
                    Email="minaaaaa@gmail.com", Role=roles.ElementAt(1), CreatedAt=DateTime.UtcNow},
                    new User{Name="Zeljko", Surname="Obradovic", UserName="zoc9", Password="sifra1",
                    Email="zeljko.obr@gmail.com", Role=roles.ElementAt(1), CreatedAt=DateTime.UtcNow},
                    new User{Name="Isidora", Surname="Smiljanic", UserName="isidoraSmiljaniccc", Password="sifra1",
                    Email="isidora98@gmail.com", Role=roles.First(), CreatedAt=DateTime.UtcNow},
                };

                var blogs = new List<Blog>
                {
                    new Blog{BlogText="Otkako su se zagrebačka Cedevita i ljubljanska Olimpija spojili u Cedevita Olimpiju, 8. jula 2019, Partizan nije uspeo da savlada taj novonastali hrvatsko-slovenački klub u gostima, odnosno u Ljubljani. Danas (18 časova) u tom gradu „crno-beli” igraju drugi meč polufinala plej-ofa ABA lige, a ukoliko pobede, plasiraće se u finale u kojem je već Crvena zvezda. Preksinoć, u „Štark areni”, pobedili su sa 85:70 i poveli sa 1:0 (igra se na dve dobijene utakmice, finale na tri)", User=users.ElementAt(3)},
                    new Blog{BlogText="Zato su malo vremena „ukrali“ od sna, revanš malo pripremali i u autobusu. Mada – ovo će biti pet meč dva tima ove sezone. Teško da je ostala neka nepoznanica, pa i da je moguće bilo kakvo iznenađenje.- Analiza utakmice je napravljena. Video sa igračima odrađen, kako bismo se dobro pripremili. Želimo da probamo da igramo dobru utakmicu i da prođemo u finale – poručio je Obradović.", User=users.ElementAt(4)},
                    new Blog{BlogText="Srpski stručnjak se dovodio u vezu sa Partizanom kao trener koji bi mogao da počne narednu sezonu na klupi crno-belih, ali je Nikolić odlučio da se oproba u Dubaiju.On će potpisati ugovor na godinu dana sa Al Ahli Šababom iz Dubaija, potvrđeno je Sport klubu. ", User=users.ElementAt(3)},
                    new Blog{BlogText="Đoković je nakon dva i po sata igre savladao Aleksandra Kovačevića u tri seta i tako lako prošao u narednu rundu drugog Grend slema u sezoni.Posle pobede je prema tradiciji ispisao poruku na kameri koja je snimala prenost tog meča, ali je ovaj put poruka imala snažnije značenje nego u nekim drugim navratima.'Kosovo je srce Srbije! Stop nasilju', napisao je treći nosilac na Rolan Garosu.Đokovićev naredni rival će biti mađarski teniser Marton Fučovič.", User=users.ElementAt(2)}
                };


                var blogImages = new List<BlogImages>
                {
                    new BlogImages{Blog=blogs.ElementAt(0),Image=images.ElementAt(4)},
                    new BlogImages{Blog=blogs.ElementAt(1),Image=images.ElementAt(5)},
                    new BlogImages{Blog=blogs.ElementAt(2),Image=images.ElementAt(6)},
                    new BlogImages{Blog=blogs.ElementAt(3),Image=images.ElementAt(7)},
                };


                var blogReactions = new List<BlogReactions>
                {
                    new BlogReactions{Blog=blogs.First(), Reaction=reactions.ElementAt(1), User=users.ElementAt(3)},
                    new BlogReactions{Blog=blogs.First(), Reaction=reactions.ElementAt(1), User=users.ElementAt(2)},
                    new BlogReactions{Blog=blogs.First(), Reaction=reactions.ElementAt(3), User=users.ElementAt(1)},
                    new BlogReactions{Blog=blogs.ElementAt(1), Reaction=reactions.ElementAt(2), User=users.ElementAt(5)},
                    new BlogReactions{Blog=blogs.ElementAt(1), Reaction=reactions.ElementAt(1), User=users.ElementAt(4)},
                    new BlogReactions{Blog=blogs.ElementAt(2), Reaction=reactions.ElementAt(2), User=users.ElementAt(1)},
                    new BlogReactions{Blog=blogs.ElementAt(3), Reaction=reactions.ElementAt(1), User=users.ElementAt(2)},
                    new BlogReactions{Blog=blogs.ElementAt(3), Reaction=reactions.ElementAt(3), User=users.ElementAt(3)},
                };

                var blogTag = new List<BlogTag>
                {
                    new BlogTag{Blog=blogs.First(), Tag=tag.ElementAt(1) },
                    new BlogTag{Blog=blogs.ElementAt(1), Tag=tag.ElementAt(1) },
                    new BlogTag{Blog=blogs.ElementAt(1), Tag=tag.ElementAt(2) },
                    new BlogTag{Blog=blogs.ElementAt(1), Tag=tag.ElementAt(3) },
                    new BlogTag{Blog=blogs.ElementAt(2), Tag=tag.First() },
                    new BlogTag{Blog=blogs.ElementAt(3), Tag=tag.First() },
                    new BlogTag{Blog=blogs.ElementAt(3), Tag=tag.ElementAt(1) },
                };


                var comments = new List<Comment>
                {
                    new Comment{Blog=blogs.ElementAt(1), TextComment="ova objava je bas zanimljivog karaktera",User=users.ElementAt(1),},
                    new Comment{Blog=blogs.ElementAt(2), TextComment="Tezak je to put bio.",User=users.ElementAt(4)},
                    new Comment{Blog=blogs.ElementAt(3), TextComment="Bravo Nole svaka cast!!!",User=users.ElementAt(3)},
                };

                var subcomments = new List<Comment>
                {
                    new Comment{Blog=blogs.ElementAt(1), TextComment="totalno se slazem",User=users.ElementAt(3),ParentCommnet=comments.First()},
                    new Comment{Blog=blogs.ElementAt(1), TextComment="Bilo je mnogo teskihh",User=users.ElementAt(2),ParentCommnet=comments.First()},
                    new Comment{Blog=blogs.ElementAt(3), TextComment="Steta mogao je da se vrati da opet bude tango smrti!!!",User=users.ElementAt(1),ParentCommnet=comments.ElementAt(2)},
                };


                if (_context.Users.Any())
                {
                    return Conflict();
                }
                _context.Users.AddRange(users);
                _context.Tags.AddRange(tag);
                _context.Images.AddRange(images);
                _context.Role.AddRange(roles);
                

                _context.Reactions.AddRange(reactions);
                _context.BlogImages.AddRange(blogImages);
                _context.BlogReactions.AddRange(blogReactions);
                _context.Blogs.AddRange(blogs);
                _context.BlogTags.AddRange(blogTag);
                _context.Comments.AddRange(comments);
                _context.Comments.AddRange(subcomments);
                _context.SaveChanges();


                return StatusCode(StatusCodes.Status200OK);







            }
            catch (System.Exception ex)
            {
                
                return Error(ex);
            }
        }

    }
}
