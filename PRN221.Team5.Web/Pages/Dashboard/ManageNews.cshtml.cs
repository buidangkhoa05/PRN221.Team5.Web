using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace PRN221.Team5.Web.Pages.Dashboard
{
    public class ManageNew : PageModel
    {
        private readonly ILogger<ManageNew> _logger;

        public ManageNew(ILogger<ManageNew> logger)
        {
            _logger = logger;
        }
        public enum Status
        {
            Pending,
            Approved,
            Rejected
        }
        public class New
        {
            public string Title { get; set; }
            public string Description { get; set; }
            public string CreateDate { get; set; }
            public string UpdateDate { get; set; }
            public string CreateBy { get; set; }
            public string UpdateBy { get; set; }

            public string Status { get; set; }
        }

        [BindProperty]
        public List<New> News { get; set; } = new List<New>();
        [BindProperty]
        public Dictionary<Status, string> Statuses { get; } = new Dictionary<Status, string>
        {
            { Status.Pending, "Pending" },
            { Status.Approved, "Approved" },
            { Status.Rejected, "Rejected" }
        };

        public void OnGet()
        {
            var news = new List<New>{
                new New{
                    Title = "New 1",
                    Description = "Description 1 lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.",
                    CreateDate = "2021-05-01",
                    UpdateDate = "2021-05-01",
                    CreateBy = "Nguyen Van A",
                    UpdateBy = "Nguyen Van A",
                    Status = "Pending"
                },
                new New{
                    Title = "New 2",
                    Description = "Description 2 Description 1 lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.",
                    CreateDate = "2021-05-01",
                    UpdateDate = "2021-05-01",
                    CreateBy = "Nguyen Van B",
                    UpdateBy = "Nguyen Van B",
                    Status = "Approved"
                },
                new New{
                    Title = "New 3",
                    Description = "Description 3 Description 1 lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.",
                    CreateDate = "2021-05-01",
                    UpdateDate = "2021-05-01",
                    CreateBy = "Nguyen Van C",
                    UpdateBy = "Nguyen Van C",
                    Status = "Pending"
                },
                new New{
                    Title = "New 4",
                    Description = "Description 4 Description 1 lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.",
                    CreateDate = "2021-05-01",
                    UpdateDate = "2021-05-01",
                    CreateBy = "Nguyen Van D",
                    UpdateBy = "Nguyen Van D",
                    Status = "Rejected"
                },

        };
            News = news;
        }
    }
}