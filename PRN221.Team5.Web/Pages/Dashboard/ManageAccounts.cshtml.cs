using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace PRN221.Team5.Web.Pages.Dashboard
{
    public class ManageAccount : PageModel
    {
        private readonly ILogger<ManageAccount> _logger;

        public ManageAccount(ILogger<ManageAccount> logger)
        {
            _logger = logger;
        }
        public enum Role
        {
            Admin,
            Staff,
            ZooTrainer
        }

        public class Account
        {
            public string Username { get; set; }
            public string Fullname { get; set; }
            public string Email { get; set; }
            public string Phone { get; set; }
            public string Role { get; set; }

            public string Age { get; set; }

            public string Status { get; set; }

            public string CreateDate { get; set; }

            public string UpdateDate { get; set; }

            public string CreateBy { get; set; }
            public string UpdateBy { get; set; }
        }



        [BindProperty]
        public List<Account> Accounts { get; set; } = new List<Account>();
        [BindProperty]
        public Dictionary<Role, string> Roles { get; } = new Dictionary<Role, string>
        {
            { Role.Admin, "Admin" },
            { Role.Staff, "Staff" },
            { Role.ZooTrainer, "Zoo Trainer" }

        };
        [BindProperty]
        public Dictionary<string, string> Statuses { get; } = new Dictionary<string, string>
        {
            { "Active", "Active" },
            { "Inactive", "Inactive" },
        };


        public void OnGet()
        {
            var accounts = new List<Account>{
                new Account
                {
                    Username = "nguyenvana",
                    Fullname = "Nguyen Van A",
                    Email = "vana222@gmail.com",
                    Phone = "0123456789",
                    Role = Roles[Role.Staff],
                    Age = "20",
                    Status = "Active",
                    CreateDate = "2021-01-01",
                    UpdateDate = "2021-01-01",
                    CreateBy = "admin",
                    UpdateBy = "admin"
                },
                new Account {
                    Username = "nguyenvanb",
                    Fullname = "Nguyen Van B",
                    Email = "vanb333@gmail.com",
                    Phone = "0123456789",
                    Role = Roles[Role.ZooTrainer],
                    Age = "40",
                    Status = "Active",
                    CreateDate = "2021-01-01",
                    UpdateDate = "2022-01-01",
                    CreateBy = "admin",
                    UpdateBy = "admin"
                },
            };

            Accounts = accounts;
        }

        public async Task<IActionResult> OnPost(){
            return Page();;
        }
    }
}