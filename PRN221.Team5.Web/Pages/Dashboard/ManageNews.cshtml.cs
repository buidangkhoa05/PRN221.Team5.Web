using System;
using System.Collections.Generic;
using System.Composition;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Xml;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using PRN221.Team5.Domain.Entity;
using Team5.Application.Repository;
using Team5.Domain.Common;

namespace PRN221.Team5.Web.Pages.Dashboard
{
    public class ManageNews : PageModel
    {
        private readonly ILogger<ManageNews> _logger;
        private readonly IUnitOfWork _unitOfWork;

        [ActivatorUtilitiesConstructorAttribute]
        public ManageNews(ILogger<ManageNews> logger, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }
        [BindProperty]
        public List<ZooNews> News { get; set; } = new List<ZooNews>();
        [BindProperty]
        public ZooNews CreateNews { get; set; } = new ZooNews();
        [BindProperty]
        public ZooNews DeleteNews { get; set; } = new ZooNews();

        public async Task<IActionResult> OnGetAsync()
        {
            News = (await _unitOfWork.ZooNews.Get(new QueryHelper<ZooNews>()
                {
                    OrderByFields = new List<string>
                {
                    $"{nameof(ZooNews.UpdatedDate)}:desc"
                }.ToArray(),
                }
                )).ToList();
            return Page();
        }
        public async Task<IActionResult> OnPostCreateAsync()
        {
            try
            {
                Account account = (await _unitOfWork.Account.Get()).ToList()[0];

                Guid isSuccess = await _unitOfWork.ZooNews.CreateAsync(new ZooNews
                {
                    Title = CreateNews.Title,
                    //Description = CreateNews.Description,
                    Content = CreateNews.Content,
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now,
                    OwnerId = account.Id,
                }, true);
                Console.WriteLine(isSuccess);

            }
            catch
            {

            }

            return RedirectToPage("/Dashboard/ManageNews");
        }
        public async Task<IActionResult> OnPostUpdateAsync()
        {
            try
            {
                var oldNews = await _unitOfWork.ZooNews.GetById(CreateNews.Id);
                var isSuccess = await _unitOfWork.ZooNews.UpdateAsync(new ZooNews
                {
                    Id = CreateNews.Id,
                    Title = CreateNews.Title,
                    Content = CreateNews.Content,
                    CreatedDate = oldNews.CreatedDate,
                    UpdatedDate = DateTime.Now,
                    OwnerId = oldNews.OwnerId,
                }, true);
                Console.WriteLine(isSuccess);

            }
            catch
            {

            }

            return RedirectToPage("/Dashboard/ManageNews");
        }
        public async Task<IActionResult> OnPostDeleteAsync()
        {
            try
            {
                Expression<Func<ZooNews, bool>> filter = x => x.Id == CreateNews.Id;
                var isSuccess = await _unitOfWork.ZooNews.SoftDeleteAsync(filter);
                Console.WriteLine(isSuccess);

            }
            catch
            {

            }

            return RedirectToPage("/Dashboard/ManageNews");
        }


        //public IActionResult OnPostCreate()
        //{
        //    var newPost = new Post
        //    {
        //        Title = CreateNews.Title,
        //        Description = CreateNews.Description,
        //        CreateDate = DateTime.Now.ToString("yyyy-MM-dd"),
        //        UpdateDate = DateTime.Now.ToString("yyyy-MM-dd"),
        //        CreateBy = "Nguyen Van A",
        //        UpdateBy = "Nguyen Van A",
        //        Status = Status.Pending
        //    };

        //    Console.WriteLine(newPost.CreateBy);

        //    var sessionData = HttpContext.Session.GetString("SessionNews");

        //    // Check if there are existing posts
        //    if (!string.IsNullOrEmpty(sessionData))
        //    {
        //        // Deserialize the existing posts
        //        var existingPosts = JsonConvert.DeserializeObject<List<Post>>(sessionData);

        //        // Append the new post to the existing list
        //        existingPosts.Add(newPost);

        //        // Serialize the updated list and save it to the session
        //        sessionData = JsonConvert.SerializeObject(existingPosts);
        //        HttpContext.Session.SetString("SessionNews", sessionData);
        //    }
        //    else
        //    {
        //        // If there are no existing posts, create a new list with the new post
        //        var newPosts = new List<Post> { newPost };
        //        sessionData = JsonConvert.SerializeObject(newPosts);
        //        HttpContext.Session.SetString("SessionNews", sessionData);
        //    }

        //    // Redirect back to the same page
        //    return RedirectToPage("/Dashboard/ManageNews");
        //}

    }


}