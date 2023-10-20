using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PRN221.Team5.Domain.Entity;

namespace PRN221.Team5.Web.Pages
{
    [Authorize(Roles = nameof(Role.Administrator))]
    public class IndexModel : PageModel
    {
        public class Animal
        {
            public string Id { get; set; }
            public string Name { get; set; }
            public string Specie { get; set; }
            public string CreatedDate { get; set; }
            public string CreatedBy { get; set; }
        }

        public class Account
        {
            public string UserName { get; set; }
            public string Name { get; set; }
            public string Role { get; set; }
            public string CreatedDate { get; set; }
        }

        public class Post {
            public string Id { get; set; }
            public string Title { get; set; }
            public string Content { get; set; }
            public string CreatedDate { get; set; }
            public string CreatedBy { get; set; }
            public string Status { get; set; }
        }

        [BindProperty]
        public List<Animal> Animals { get; set; } = new List<Animal>();

        [BindProperty]
        public List<Account> Accounts { get; set; } = new List<Account>();

        [BindProperty]
        public List<Post> Posts { get; set; } = new List<Post>();

        public void OnGet()
        {
            var animals = new List<Animal>
            {
                new Animal
                {
                    Id = "1",
                    Name = "Dog",
                    Specie = "Mammal",
                    CreatedDate = "2021-09-01",
                    CreatedBy = "Admin"
                },
                new Animal
                {
                    Id = "2",
                    Name = "Cat",
                    Specie = "Mammal",
                    CreatedDate = "2021-09-01",
                    CreatedBy = "Admin"
                },
                new Animal
                {
                    Id = "3",
                    Name = "Chicken",
                    Specie = "Bird",
                    CreatedDate = "2021-09-01",
                    CreatedBy = "Admin"
                },
                new Animal
                {
                    Id = "4",
                    Name = "Duck",
                    Specie = "Bird",
                    CreatedDate = "2021-09-01",
                    CreatedBy = "Admin"
                },
                new Animal
                {
                    Id = "5",
                    Name = "Pig",
                    Specie = "Mammal",
                    CreatedDate = "2021-09-01",
                    CreatedBy = "Admin"
                },
                new Animal
                {
                    Id = "6",
                    Name = "Cow",
                    Specie = "Mammal",
                    CreatedDate = "2021-09-01",
                    CreatedBy = "Admin"
                },
                new Animal
                {
                    Id = "7",
                    Name = "Goat",
                    Specie = "Mammal",
                    CreatedDate = "2021-09-01",
                    CreatedBy = "Admin"
                },
                new Animal
                {
                    Id = "8",
                    Name = "Sheep",
                    Specie = "Mammal",
                    CreatedDate = "2021-09-01",
                    CreatedBy = "Admin"
                },
                new Animal
                {
                    Id = "9",
                    Name = "Horse",
                    Specie = "Mammal",
                    CreatedDate = "2021-09-01",
                    CreatedBy = "Admin"
                }
            };

            Animals = animals;

            var accounts = new List<Account>
            {
                new Account
                {
                    UserName = "minhngoc",
                    Name = "Vu Minh Ngoc",
                    CreatedDate = "2021-09-01",
                    Role = "Staff",
                },
                new Account
                {
                    UserName = "thiennhi",
                    Name = "Pham Thien Nhi",
                    CreatedDate = "2021-09-01",
                    Role = "Zoo Trainer",
                },
                new Account
                {
                    UserName = "thanhthao",
                    Name = "Nguyen Thi Thanh Thao",
                    CreatedDate = "2021-09-01",
                    Role = "Zoo Trainer",
                },
                new Account
                {
                    UserName = "thienminh",
                    Name = "Cao Thien Minh",
                    CreatedDate = "2021-09-01",
                    Role = "Zoo Trainer",
                },
                new Account
                {
                    UserName = "ngochung",
                    Name = "Tran Ngoc Hung",
                    CreatedDate = "2021-09-01",
                    Role = "Zoo Trainer",
                },
                new Account
                {
                    UserName = "Chi Cong",
                    Name = "Dinh Chi Cong",
                    CreatedDate = "2021-09-01",
                    Role = "Staff",
                },
                new Account
                {
                    UserName = "Chi Cong",
                    Name = "Dinh Chi Cong",
                    CreatedDate = "2021-09-01",
                    Role = "Staff",
                },
                new Account
                {
                    UserName = "Chi Cong",
                    Name = "Dinh Chi Cong",
                    CreatedDate = "2021-09-01",
                    Role = "Staff",
                },
            };

            Accounts = accounts;



            var posts = new List<Post>
            {
                new Post
                {
                    Id = "1",
                    Title = "Dog",
                    Content = "Lorem ipsum dolor, sit amet consectetur adipisicing elit. Sed, veritatis impedit iure non velit mollitia incidunt voluptates nihil, enim voluptate ipsum aperiam veniam repellat itaque nulla, nam quo temporibus accusamus.",
                    CreatedDate = "2021-09-01",
                    CreatedBy = "Admin",
                    Status = "Approved"
                },
                new Post
                {
                    Id = "2",
                    Title = "Cat",
                    Content = "Lorem ipsum dolor, sit amet consectetur adipisicing elit. Sed, veritatis impedit iure non velit mollitia incidunt voluptates nihil, enim voluptate ipsum aperiam veniam repellat itaque nulla, nam quo temporibus accusamus.",
                    CreatedDate = "2021-09-01",
                    CreatedBy = "Admin",
                    Status = "Approved"
                },
                new Post
                {
                    Id = "3",
                    Title = "Chicken",
                    Content = "Lorem ipsum dolor, sit amet consectetur adipisicing elit. Sed, veritatis impedit iure non velit mollitia incidunt voluptates nihil, enim voluptate ipsum aperiam veniam repellat itaque nulla, nam quo temporibus accusamus.",
                    CreatedDate = "2021-09-01",
                    CreatedBy = "Admin",
                    Status = "Approved"
                },
                new Post
                {
                    Id = "4",
                    Title = "Duck",
                    Content = "Lorem ipsum dolor, sit amet consectetur adipisicing elit. Sed, veritatis impedit iure non velit mollitia incidunt voluptates nihil, enim voluptate ipsum aperiam veniam repellat itaque nulla, nam quo temporibus accusamus.",
                    CreatedDate = "2021-09-01",
                    CreatedBy = "Admin",
                    Status = "Approved"
                },
                new Post
                {
                    Id = "5",
                    Title = "Pig",
                    Content = "Lorem ipsum dolor, sit amet consectetur adipisicing elit. Sed, veritatis impedit iure non velit mollitia incidunt voluptates nihil, enim voluptate ipsum aperiam veniam repellat itaque nulla, nam quo temporibus accusamus.",
                    CreatedDate = "2021-09-01",
                    CreatedBy = "Admin",
                    Status = "Approved"
                },
                new Post
                {
                    Id = "6",
                    Title = "Cow",
                    Content = "Lorem ipsum dolor, sit amet consectetur adipisicing elit. Sed, veritatis impedit iure non velit mollitia incidunt voluptates nihil, enim voluptate ipsum aperiam veniam repellat itaque nulla, nam quo temporibus accusamus.",
                    CreatedDate = "2021-09-01",
                    CreatedBy = "Admin",
                    Status = "Approved"
                },
                new Post
                {
                    Id = "7",
                    Title = "Goat",
                    Content = "Lorem ipsum dolor, sit amet consectetur adipisicing elit. Sed, veritatis impedit iure non velit mollitia incidunt voluptates nihil, enim voluptate ipsum aperiam veniam repellat itaque nulla, nam quo temporibus accusamus.",
                    CreatedDate = "2021-09-01",
                    CreatedBy = "Admin",
                    Status = "Approved"
                },
                new Post
                {
                    Id = "8",
                    Title = "Sheep",
                    Content = "Lorem ipsum dolor, sit amet consectetur adipisicing elit. Sed, veritatis impedit iure non velit mollitia incidunt voluptates nihil, enim voluptate ipsum aperiam veniam repellat itaque nulla, nam quo temporibus accusamus.",
                    CreatedDate = "2021-09-01",
                    CreatedBy = "Admin",
                    Status = "Approved"
                },
                new Post
                {
                    Id = "9",
                    Title = "Horse",
                    Content = "Lorem ipsum dolor, sit amet consectetur adipisicing elit. Sed, veritatis impedit iure non velit mollitia incidunt voluptates nihil, enim voluptate ipsum aperiam veniam repellat itaque nulla, nam quo temporibus accusamus.",
                    CreatedDate = "2021-09-01",
                    CreatedBy = "Admin",
                    Status = "Approved"
                }
            };
            
            Posts = posts;
        }
    }
}
