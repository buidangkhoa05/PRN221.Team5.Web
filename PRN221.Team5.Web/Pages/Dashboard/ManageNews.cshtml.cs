using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace PRN221.Team5.Web.Pages.Dashboard
{
    public class ManageNews : PageModel
    {
        private readonly ILogger<ManageNews> _logger;

        public ManageNews(ILogger<ManageNews> logger)
        {
            _logger = logger;
        }
        public enum Status
        {
            Pending,
            Approved,
            Rejected
        }
        public class Post
        {
            public string Title { get; set; }
            public string Description { get; set; }
            public string CreateDate { get; set; }
            public string UpdateDate { get; set; }
            public string CreateBy { get; set; }
            public string UpdateBy { get; set; }
            public Status Status { get; set; }
        }

        public class Account
        {
            public string Username { get; set; }
            public string FullName { get; set; }
            public string Role { get; set; }
        }

        [BindProperty]
        public List<Post> News { get; set; } = new List<Post>();


        [BindProperty]
        public Post NewPost { get; set; } = new Post();

        [BindProperty]
        public Account Creator { get; set; } = new Account
        {
            Username = "nguyena",
            FullName = "Nguyen Van A",
            Role = "Staff"
        };

        public void OnGet()
        {
            var sessionData = HttpContext.Session.GetString("SessionNews");
            if (!string.IsNullOrEmpty(sessionData))
            {
                News = JsonConvert.DeserializeObject<List<Post>>(sessionData);
            }
        }

        public IActionResult OnPost()
        {
            // Create a new post and add it to the list
            var newPost = new Post
            {
                Title = NewPost.Title,
                Description = NewPost.Description,
                CreateDate = DateTime.Now.ToString("yyyy-MM-dd"),
                UpdateDate = DateTime.Now.ToString("yyyy-MM-dd"),
                CreateBy = "Nguyen Van A",
                UpdateBy = "Nguyen Van A",
                Status = Status.Pending
            };

            Console.WriteLine(newPost.CreateBy);

            var sessionData = HttpContext.Session.GetString("SessionNews");

            // Check if there are existing posts
            if (!string.IsNullOrEmpty(sessionData))
            {
                // Deserialize the existing posts
                var existingPosts = JsonConvert.DeserializeObject<List<Post>>(sessionData);

                // Append the new post to the existing list
                existingPosts.Add(newPost);

                // Serialize the updated list and save it to the session
                sessionData = JsonConvert.SerializeObject(existingPosts);
                HttpContext.Session.SetString("SessionNews", sessionData);
            }
            else
            {
                // If there are no existing posts, create a new list with the new post
                var newPosts = new List<Post> { newPost };
                sessionData = JsonConvert.SerializeObject(newPosts);
                HttpContext.Session.SetString("SessionNews", sessionData);
            }

            // Redirect back to the same page
            return RedirectToPage("/Dashboard/ManageNews");
        }
    }


}